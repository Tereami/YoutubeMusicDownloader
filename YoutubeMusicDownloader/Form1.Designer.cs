namespace YoutubeMusicDownloader
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            textBoxChannelLink = new TextBox();
            label2 = new Label();
            textBoxFolderToSavePath = new TextBox();
            buttonBrowseFolder = new Button();
            numericMinLengthSeconds = new NumericUpDown();
            label3 = new Label();
            numericMaxLengthSeconds = new NumericUpDown();
            label4 = new Label();
            label5 = new Label();
            buttonStart = new Button();
            label6 = new Label();
            richTextBoxLog = new RichTextBox();
            label7 = new Label();
            labelCurrentFile = new Label();
            progressBar1 = new ProgressBar();
            buttonCancel = new Button();
            buttonOpen = new Button();
            ((System.ComponentModel.ISupportInitialize)numericMinLengthSeconds).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericMaxLengthSeconds).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Margin = new Padding(3, 0, 3, 1);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 0;
            label1.Text = "Channel link:";
            // 
            // textBoxChannelLink
            // 
            textBoxChannelLink.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxChannelLink.Location = new Point(12, 28);
            textBoxChannelLink.Name = "textBoxChannelLink";
            textBoxChannelLink.PlaceholderText = "https://www.youtube.com/channel/UCjoIPWYycsUsV2XueaovRlQ";
            textBoxChannelLink.Size = new Size(439, 23);
            textBoxChannelLink.TabIndex = 1;
            textBoxChannelLink.Text = "https://www.youtube.com/channel/UCjoIPWYycsUsV2XueaovRlQ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 100);
            label2.Margin = new Padding(3, 5, 3, 1);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 2;
            label2.Text = "Folder to save:";
            // 
            // textBoxFolderToSavePath
            // 
            textBoxFolderToSavePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxFolderToSavePath.Location = new Point(12, 119);
            textBoxFolderToSavePath.Name = "textBoxFolderToSavePath";
            textBoxFolderToSavePath.Size = new Size(277, 23);
            textBoxFolderToSavePath.TabIndex = 3;
            textBoxFolderToSavePath.Text = "C:/YoutubeMusic";
            // 
            // buttonBrowseFolder
            // 
            buttonBrowseFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonBrowseFolder.Location = new Point(295, 118);
            buttonBrowseFolder.Name = "buttonBrowseFolder";
            buttonBrowseFolder.Size = new Size(75, 24);
            buttonBrowseFolder.TabIndex = 4;
            buttonBrowseFolder.Text = "Browse";
            buttonBrowseFolder.UseVisualStyleBackColor = true;
            // 
            // numericMinLengthSeconds
            // 
            numericMinLengthSeconds.Location = new Point(138, 66);
            numericMinLengthSeconds.Name = "numericMinLengthSeconds";
            numericMinLengthSeconds.Size = new Size(65, 23);
            numericMinLengthSeconds.TabIndex = 6;
            numericMinLengthSeconds.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 68);
            label3.Name = "label3";
            label3.Size = new Size(120, 15);
            label3.TabIndex = 7;
            label3.Text = "Save tracks only from";
            // 
            // numericMaxLengthSeconds
            // 
            numericMaxLengthSeconds.Location = new Point(233, 66);
            numericMaxLengthSeconds.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericMaxLengthSeconds.Name = "numericMaxLengthSeconds";
            numericMaxLengthSeconds.Size = new Size(65, 23);
            numericMaxLengthSeconds.TabIndex = 6;
            numericMaxLengthSeconds.Value = new decimal(new int[] { 600, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(209, 68);
            label4.Name = "label4";
            label4.Size = new Size(18, 15);
            label4.TabIndex = 7;
            label4.Text = "to";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(304, 68);
            label5.Name = "label5";
            label5.Size = new Size(50, 15);
            label5.TabIndex = 7;
            label5.Text = "seconds";
            // 
            // buttonStart
            // 
            buttonStart.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonStart.Location = new Point(12, 167);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(439, 32);
            buttonStart.TabIndex = 8;
            buttonStart.Text = "START";
            buttonStart.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 275);
            label6.Name = "label6";
            label6.Size = new Size(30, 15);
            label6.TabIndex = 9;
            label6.Text = "Log:";
            // 
            // richTextBoxLog
            // 
            richTextBoxLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBoxLog.Location = new Point(12, 293);
            richTextBoxLog.Name = "richTextBoxLog";
            richTextBoxLog.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            richTextBoxLog.Size = new Size(439, 235);
            richTextBoxLog.TabIndex = 10;
            richTextBoxLog.Text = "";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 219);
            label7.Margin = new Padding(3, 0, 3, 1);
            label7.Name = "label7";
            label7.Size = new Size(81, 15);
            label7.TabIndex = 11;
            label7.Text = "Downloading:";
            // 
            // labelCurrentFile
            // 
            labelCurrentFile.AutoSize = true;
            labelCurrentFile.Location = new Point(99, 219);
            labelCurrentFile.Name = "labelCurrentFile";
            labelCurrentFile.Size = new Size(0, 15);
            labelCurrentFile.TabIndex = 11;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(12, 238);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(439, 23);
            progressBar1.TabIndex = 12;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonCancel.Location = new Point(12, 167);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(439, 32);
            buttonCancel.TabIndex = 13;
            buttonCancel.Text = "CANCEL";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Visible = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonOpen
            // 
            buttonOpen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonOpen.Location = new Point(376, 119);
            buttonOpen.Name = "buttonOpen";
            buttonOpen.Size = new Size(75, 24);
            buttonOpen.TabIndex = 4;
            buttonOpen.Text = "Open";
            buttonOpen.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 540);
            Controls.Add(buttonCancel);
            Controls.Add(progressBar1);
            Controls.Add(labelCurrentFile);
            Controls.Add(label7);
            Controls.Add(richTextBoxLog);
            Controls.Add(label6);
            Controls.Add(buttonStart);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(numericMaxLengthSeconds);
            Controls.Add(numericMinLengthSeconds);
            Controls.Add(buttonOpen);
            Controls.Add(buttonBrowseFolder);
            Controls.Add(textBoxFolderToSavePath);
            Controls.Add(label2);
            Controls.Add(textBoxChannelLink);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Youtube Music Downloader";
            ((System.ComponentModel.ISupportInitialize)numericMinLengthSeconds).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericMaxLengthSeconds).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxChannelLink;
        private Label label2;
        private TextBox textBoxFolderToSavePath;
        private Button buttonBrowseFolder;
        private NumericUpDown numericMinLengthSeconds;
        private Label label3;
        private NumericUpDown numericMaxLengthSeconds;
        private Label label4;
        private Label label5;
        private Button buttonStart;
        private Label label6;
        private RichTextBox richTextBoxLog;
        private Label label7;
        private Label labelCurrentFile;
        private ProgressBar progressBar1;
        private Button buttonCancel;
        private Button buttonOpen;
    }
}
