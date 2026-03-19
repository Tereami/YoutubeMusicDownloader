using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeMusicDownloader
{
    public class YoutubeTrack
    {
        public int Number { get; set; }
        public string Title { get; set; } = "NO_TITLE";

        public TimeSpan StartPoint { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
