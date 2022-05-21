
namespace YouTubePlaylistManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WriteButton = new System.Windows.Forms.Button();
            this.CheckButton = new System.Windows.Forms.Button();
            this.JsonPath = new System.Windows.Forms.TextBox();
            this.JsonButton = new System.Windows.Forms.Button();
            this.CredentialsLabel = new System.Windows.Forms.Label();
            this.PlaylistPathLabel = new System.Windows.Forms.Label();
            this.PlaylistButton = new System.Windows.Forms.Button();
            this.DocumentPath = new System.Windows.Forms.TextBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.CreateJsonButton = new System.Windows.Forms.Button();
            this.ApiKeyText = new System.Windows.Forms.TextBox();
            this.ChannelIDText = new System.Windows.Forms.TextBox();
            this.PlaylistIDText = new System.Windows.Forms.TextBox();
            this.LocalFiles = new System.Windows.Forms.ListBox();
            this.OnlineFiles = new System.Windows.Forms.ListBox();
            this.LocalLabel = new System.Windows.Forms.Label();
            this.OnlineLabel = new System.Windows.Forms.Label();
            this.LoadingIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // WriteButton
            // 
            this.WriteButton.Location = new System.Drawing.Point(616, 237);
            this.WriteButton.Name = "WriteButton";
            this.WriteButton.Size = new System.Drawing.Size(72, 33);
            this.WriteButton.TabIndex = 0;
            this.WriteButton.Text = "Write";
            this.WriteButton.UseVisualStyleBackColor = true;
            this.WriteButton.Click += new System.EventHandler(this.WriteButton_Click);
            // 
            // CheckButton
            // 
            this.CheckButton.Location = new System.Drawing.Point(616, 276);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(72, 33);
            this.CheckButton.TabIndex = 1;
            this.CheckButton.Text = "Check";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // JsonPath
            // 
            this.JsonPath.Location = new System.Drawing.Point(132, 21);
            this.JsonPath.Name = "JsonPath";
            this.JsonPath.Size = new System.Drawing.Size(380, 20);
            this.JsonPath.TabIndex = 2;
            // 
            // JsonButton
            // 
            this.JsonButton.Location = new System.Drawing.Point(518, 20);
            this.JsonButton.Name = "JsonButton";
            this.JsonButton.Size = new System.Drawing.Size(56, 20);
            this.JsonButton.TabIndex = 3;
            this.JsonButton.Text = "Search";
            this.JsonButton.UseVisualStyleBackColor = true;
            this.JsonButton.Click += new System.EventHandler(this.JsonButton_Click);
            // 
            // CredentialsLabel
            // 
            this.CredentialsLabel.AutoSize = true;
            this.CredentialsLabel.Location = new System.Drawing.Point(33, 24);
            this.CredentialsLabel.Name = "CredentialsLabel";
            this.CredentialsLabel.Size = new System.Drawing.Size(93, 13);
            this.CredentialsLabel.TabIndex = 6;
            this.CredentialsLabel.Text = "Client credentials: ";
            // 
            // PlaylistPathLabel
            // 
            this.PlaylistPathLabel.AutoSize = true;
            this.PlaylistPathLabel.Location = new System.Drawing.Point(33, 50);
            this.PlaylistPathLabel.Name = "PlaylistPathLabel";
            this.PlaylistPathLabel.Size = new System.Drawing.Size(61, 13);
            this.PlaylistPathLabel.TabIndex = 11;
            this.PlaylistPathLabel.Text = "Playlist file: ";
            // 
            // PlaylistButton
            // 
            this.PlaylistButton.Location = new System.Drawing.Point(518, 47);
            this.PlaylistButton.Name = "PlaylistButton";
            this.PlaylistButton.Size = new System.Drawing.Size(120, 20);
            this.PlaylistButton.TabIndex = 10;
            this.PlaylistButton.Text = "Search";
            this.PlaylistButton.UseVisualStyleBackColor = true;
            this.PlaylistButton.Click += new System.EventHandler(this.PlaylistButton_Click);
            // 
            // DocumentPath
            // 
            this.DocumentPath.Location = new System.Drawing.Point(132, 47);
            this.DocumentPath.Name = "DocumentPath";
            this.DocumentPath.Size = new System.Drawing.Size(380, 20);
            this.DocumentPath.TabIndex = 12;
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(580, 20);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(58, 20);
            this.CreateButton.TabIndex = 13;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // CreateJsonButton
            // 
            this.CreateJsonButton.Location = new System.Drawing.Point(272, 266);
            this.CreateJsonButton.Name = "CreateJsonButton";
            this.CreateJsonButton.Size = new System.Drawing.Size(75, 23);
            this.CreateJsonButton.TabIndex = 14;
            this.CreateJsonButton.Text = "Create";
            this.CreateJsonButton.UseVisualStyleBackColor = true;
            this.CreateJsonButton.Visible = false;
            this.CreateJsonButton.Click += new System.EventHandler(this.CreateJsonButton_Click);
            // 
            // ApiKeyText
            // 
            this.ApiKeyText.Location = new System.Drawing.Point(132, 83);
            this.ApiKeyText.Name = "ApiKeyText";
            this.ApiKeyText.Size = new System.Drawing.Size(380, 20);
            this.ApiKeyText.TabIndex = 15;
            this.ApiKeyText.Text = "Api-Key";
            this.ApiKeyText.Visible = false;
            // 
            // ChannelIDText
            // 
            this.ChannelIDText.Location = new System.Drawing.Point(132, 150);
            this.ChannelIDText.Name = "ChannelIDText";
            this.ChannelIDText.Size = new System.Drawing.Size(380, 20);
            this.ChannelIDText.TabIndex = 16;
            this.ChannelIDText.Text = "Channel-ID";
            this.ChannelIDText.Visible = false;
            // 
            // PlaylistIDText
            // 
            this.PlaylistIDText.Location = new System.Drawing.Point(132, 223);
            this.PlaylistIDText.Name = "PlaylistIDText";
            this.PlaylistIDText.Size = new System.Drawing.Size(380, 20);
            this.PlaylistIDText.TabIndex = 17;
            this.PlaylistIDText.Text = "Playlist-ID";
            this.PlaylistIDText.Visible = false;
            // 
            // LocalFiles
            // 
            this.LocalFiles.FormattingEnabled = true;
            this.LocalFiles.Location = new System.Drawing.Point(10, 107);
            this.LocalFiles.Name = "LocalFiles";
            this.LocalFiles.Size = new System.Drawing.Size(297, 212);
            this.LocalFiles.TabIndex = 18;
            // 
            // OnlineFiles
            // 
            this.OnlineFiles.FormattingEnabled = true;
            this.OnlineFiles.Location = new System.Drawing.Point(313, 107);
            this.OnlineFiles.Name = "OnlineFiles";
            this.OnlineFiles.Size = new System.Drawing.Size(297, 212);
            this.OnlineFiles.TabIndex = 19;
            // 
            // LocalLabel
            // 
            this.LocalLabel.AutoSize = true;
            this.LocalLabel.Location = new System.Drawing.Point(13, 89);
            this.LocalLabel.Name = "LocalLabel";
            this.LocalLabel.Size = new System.Drawing.Size(97, 13);
            this.LocalLabel.TabIndex = 20;
            this.LocalLabel.Text = "Local missing titles:";
            // 
            // OnlineLabel
            // 
            this.OnlineLabel.AutoSize = true;
            this.OnlineLabel.Location = new System.Drawing.Point(320, 89);
            this.OnlineLabel.Name = "OnlineLabel";
            this.OnlineLabel.Size = new System.Drawing.Size(101, 13);
            this.OnlineLabel.TabIndex = 21;
            this.OnlineLabel.Text = "Online missing titles:";
            // 
            // LoadingIcon
            // 
            this.LoadingIcon.Image = global::YouTubePlaylistManager.Properties.Resources.Loading;
            this.LoadingIcon.InitialImage = null;
            this.LoadingIcon.Location = new System.Drawing.Point(623, 109);
            this.LoadingIcon.Name = "LoadingIcon";
            this.LoadingIcon.Size = new System.Drawing.Size(72, 71);
            this.LoadingIcon.TabIndex = 22;
            this.LoadingIcon.TabStop = false;
            this.LoadingIcon.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 331);
            this.Controls.Add(this.LoadingIcon);
            this.Controls.Add(this.LocalLabel);
            this.Controls.Add(this.PlaylistIDText);
            this.Controls.Add(this.ChannelIDText);
            this.Controls.Add(this.ApiKeyText);
            this.Controls.Add(this.CreateJsonButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.DocumentPath);
            this.Controls.Add(this.PlaylistPathLabel);
            this.Controls.Add(this.PlaylistButton);
            this.Controls.Add(this.CredentialsLabel);
            this.Controls.Add(this.JsonButton);
            this.Controls.Add(this.JsonPath);
            this.Controls.Add(this.CheckButton);
            this.Controls.Add(this.WriteButton);
            this.Controls.Add(this.LocalFiles);
            this.Controls.Add(this.OnlineFiles);
            this.Controls.Add(this.OnlineLabel);
            this.Name = "Form1";
            this.Text = "YouTubePlaylistManager";
            ((System.ComponentModel.ISupportInitialize)(this.LoadingIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button WriteButton;
        private System.Windows.Forms.Button CheckButton;
        private System.Windows.Forms.Button JsonButton;
        private System.Windows.Forms.Label CredentialsLabel;
        public System.Windows.Forms.TextBox JsonPath;
        private System.Windows.Forms.Label PlaylistPathLabel;
        private System.Windows.Forms.Button PlaylistButton;
        public System.Windows.Forms.TextBox playlistPath;
        public System.Windows.Forms.TextBox DocumentPath;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button CreateJsonButton;
        private System.Windows.Forms.TextBox ApiKeyText;
        private System.Windows.Forms.TextBox ChannelIDText;
        private System.Windows.Forms.TextBox PlaylistIDText;
        private System.Windows.Forms.ListBox LocalFiles;
        private System.Windows.Forms.ListBox OnlineFiles;
        private System.Windows.Forms.Label LocalLabel;
        private System.Windows.Forms.Label OnlineLabel;
        private System.Windows.Forms.PictureBox LoadingIcon;
    }
}

