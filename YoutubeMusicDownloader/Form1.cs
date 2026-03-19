using YoutubeExplode;
using YoutubeExplode.Channels;
using YoutubeExplode.Converter;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace YoutubeMusicDownloader
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource? _cts;
        public Form1()
        {
            InitializeComponent();
            buttonBrowseFolder.Click += ButtonBrowseFolder_Click;
            buttonStart.Click += ButtonStart_Click;
        }

        private void ButtonBrowseFolder_Click(object? sender, EventArgs e)
        {
            using FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                textBoxFolderToSavePath.Text = dialog.SelectedPath;
        }

        private async void ButtonStart_Click(object? sender, EventArgs e)
        {
            richTextBoxLog.Text = string.Empty;
            string channelUrl = textBoxChannelLink.Text.Trim();
            string outputDir = textBoxFolderToSavePath.Text.Trim();
            int minSeconds = (int)numericMinLengthSeconds.Value;
            int maxSeconds = (int)numericMaxLengthSeconds.Value;

            if (string.IsNullOrEmpty(channelUrl) || string.IsNullOrEmpty(outputDir))
            {
                MessageBox.Show("Please provide a channel link and output folder.", "Missing input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Directory.CreateDirectory(outputDir);

            _cts = new CancellationTokenSource();
            CancellationToken token = _cts.Token;
            buttonCancel.Visible = true;
            buttonStart.Visible = false;
            richTextBoxLog.Clear();

            try
            {
                YoutubeClient youtube = new YoutubeClient();

                Log("Resolving channel...");
                Channel? channel = await youtube.Channels.GetAsync(channelUrl);
                Log($"Channel: {channel.Title}");

                Log("Fetching video list...");
                IAsyncEnumerable<YoutubeExplode.Playlists.PlaylistVideo> videos = youtube.Channels.GetUploadsAsync(channel.Id, token);

                int downloaded = 0, skipped = 0;

                await foreach (YoutubeExplode.Playlists.PlaylistVideo video in videos.WithCancellation(token))
                {
                    string safeTitle = SanitizeFileName(video.Title);
                    string filePath = Path.Combine(outputDir, $"{safeTitle}.mp3");

                    if (File.Exists(filePath))
                    {
                        Log($"[EXISTS] {video.Title}");
                    }
                    else
                    {
                        Log($"[DOWNLOADING] {video.Title}...");

                        await youtube.Videos.DownloadAsync(
                            video.Url,
                            filePath,
                            o => o.SetContainer("mp3")
                                  .SetPreset(ConversionPreset.Medium),
                            progress: new Progress<double>(p =>
                            {
                                //BeginInvoke(() => UpdateLastLogLine(
                                //    $"[DOWNLOADING] {video.Title}... {p:P0}"));
                                BeginInvoke(() => UpdateProgress(video.Title, p));
                            }),
                            cancellationToken: token
                        );
                    }

                    YoutubeExplode.Videos.Video videoInfo = await youtube.Videos.GetAsync(video.Id, token);
                    string tracksOutputDir = Path.Combine(outputDir, safeTitle);
                    Directory.CreateDirectory(tracksOutputDir);
                    string videoDescription = videoInfo.Description;
                    List<YoutubeTrack> tracksInfo = ConvertDescriptionToTracksInfo(videoDescription, videoInfo.Duration);
                    if (tracksInfo.Count == 0)
                    {
                        Log($"[NO TRACKS] No valid timecodes found for {video.Title}");
                    }
                    else
                    {
                        await SplitMp3IntoTracksAsync(filePath, tracksOutputDir, tracksInfo, minSeconds, maxSeconds, token);
                    }

                    downloaded++;
                    Log($"[DONE] {video.Title}");
                }

                Log($"\nFinished! Downloaded: {downloaded}, Skipped: {skipped}");
            }
            catch (OperationCanceledException)
            {
                Log("Cancelled by user.");
            }
            catch (Exception ex)
            {
                Log($"[ERROR] {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _cts = null;
                buttonCancel.Visible = false;
                buttonStart.Visible = true;
            }
        }

        private void Log(string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(() => Log(message));
                return;
            }
            richTextBoxLog.AppendText(message + Environment.NewLine);
            richTextBoxLog.ScrollToCaret();
        }

        private void UpdateProgress(string text, double percent)
        {
            labelCurrentFile.Text = $"{text}... {percent:P0}";
            progressBar1.Value = (int)(percent * 100);
        }

        private static string SanitizeFileName(string name)
        {
            char[] invalid = Path.GetInvalidFileNameChars();
            return string.Concat(name.Select(c => invalid.Contains(c) ? '_' : c));
        }

        private static List<YoutubeTrack> ConvertDescriptionToTracksInfo(string description, TimeSpan? videoDuration)
        {
            List<YoutubeTrack> tracks = new List<YoutubeTrack>();

            if (string.IsNullOrWhiteSpace(description))
                return tracks;

            string[] lines = description.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            Regex timecodeRegex = new Regex(@"^(?:(?<hours>\d{1,2}):)?(?<minutes>[0-5]?\d):(?<seconds>[0-5]?\d)\s*(?:-|–|—|:|\|)\s*(?<title>.+)$", RegexOptions.Compiled);

            foreach (string line in lines)
            {
                Match match = timecodeRegex.Match(line);
                if (!match.Success)
                    continue;

                int hours = match.Groups["hours"].Success ? int.Parse(match.Groups["hours"].Value) : 0;
                int minutes = int.Parse(match.Groups["minutes"].Value);
                int seconds = int.Parse(match.Groups["seconds"].Value);
                string title = match.Groups["title"].Value.Trim();

                if (string.IsNullOrWhiteSpace(title))
                    continue;

                tracks.Add(new YoutubeTrack
                {
                    StartPoint = new TimeSpan(hours, minutes, seconds),
                    Title = title
                });
            }

            tracks = tracks.OrderBy(t => t.StartPoint).ToList();

            for (int i = 0; i < tracks.Count; i++)
            {
                tracks[i].Number = i + 1;

                TimeSpan? endPoint = i < tracks.Count - 1
                    ? tracks[i + 1].StartPoint
                    : videoDuration;

                tracks[i].Duration = endPoint.HasValue && endPoint.Value > tracks[i].StartPoint
                    ? endPoint.Value - tracks[i].StartPoint
                    : TimeSpan.Zero;
            }

            return tracks.Where(t => t.Duration > TimeSpan.Zero).ToList();
        }

        private async Task SplitMp3IntoTracksAsync(
            string sourceFilePath,
            string outputDirectory,
            IReadOnlyCollection<YoutubeTrack> tracks,
            int minSeconds,
            int maxSeconds,
            CancellationToken token)
        {
            foreach (var track in tracks)
            {
                double durationSeconds = track.Duration.TotalSeconds;
                if (durationSeconds < minSeconds)
                {
                    Log($"[SKIP TRACK] {track.Number:D2} {track.Title} - TOO SHORT {track.Duration} ");
                    continue;
                }
                if (durationSeconds > maxSeconds)
                {
                    Log($"[SKIP TRACK] {track.Number:D2} {track.Title} - TOO LONG {track.Duration} ");
                    continue;
                }

                string trackFileName = $"{track.Number:D2}_{SanitizeFileName(track.Title)}.mp3";
                string trackFilePath = Path.Combine(outputDirectory, trackFileName);

                if (File.Exists(trackFilePath))
                {
                    Log($"[TRACK EXISTS] {trackFileName}");
                    continue;
                }

                string start = track.StartPoint.ToString(@"hh\:mm\:ss\.fff");
                string duration = track.Duration.ToString(@"hh\:mm\:ss\.fff");
                string arguments = $"-y -hide_banner -loglevel error -ss {start} -t {duration} -i \"{sourceFilePath}\" -vn -acodec copy \"{trackFilePath}\"";

                using Process process = Process.Start(new ProcessStartInfo
                {
                    FileName = "ffmpeg",
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }) ?? throw new InvalidOperationException("Failed to start ffmpeg process.");

                await process.WaitForExitAsync(token);

                if (process.ExitCode != 0)
                {
                    string error = await process.StandardError.ReadToEndAsync(token);
                    throw new InvalidOperationException($"ffmpeg failed while splitting '{track.Title}': {error}");
                }

                Log($"[TRACK DONE] {trackFileName}");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (_cts is not null)
            {
                _cts.Cancel();
                _cts = null;
            }

            labelCurrentFile.Text = string.Empty;
            progressBar1.Value = 0;
        }
    }
}