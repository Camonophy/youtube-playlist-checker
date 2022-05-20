
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
            this.jsonPath = new System.Windows.Forms.TextBox();
            this.jsonButton = new System.Windows.Forms.Button();
            this.credentialsLabel = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.playlistPathLabel = new System.Windows.Forms.Label();
            this.playlistButton = new System.Windows.Forms.Button();
            this.documentPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // WriteButton
            // 
            this.WriteButton.Location = new System.Drawing.Point(124, 305);
            this.WriteButton.Name = "WriteButton";
            this.WriteButton.Size = new System.Drawing.Size(72, 33);
            this.WriteButton.TabIndex = 0;
            this.WriteButton.Text = "Write";
            this.WriteButton.UseVisualStyleBackColor = true;
            this.WriteButton.Click += new System.EventHandler(this.write_clicked);
            // 
            // CheckButton
            // 
            this.CheckButton.Location = new System.Drawing.Point(500, 305);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(72, 33);
            this.CheckButton.TabIndex = 1;
            this.CheckButton.Text = "Check";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.check_clicked);
            // 
            // jsonPath
            // 
            this.jsonPath.Location = new System.Drawing.Point(164, 21);
            this.jsonPath.Name = "jsonPath";
            this.jsonPath.Size = new System.Drawing.Size(380, 20);
            this.jsonPath.TabIndex = 2;
            // 
            // jsonButton
            // 
            this.jsonButton.Location = new System.Drawing.Point(559, 20);
            this.jsonButton.Name = "jsonButton";
            this.jsonButton.Size = new System.Drawing.Size(80, 20);
            this.jsonButton.TabIndex = 3;
            this.jsonButton.Text = "Search";
            this.jsonButton.UseVisualStyleBackColor = true;
            this.jsonButton.Click += new System.EventHandler(this.search_button_clicked);
            // 
            // credentialsLabel
            // 
            this.credentialsLabel.AutoSize = true;
            this.credentialsLabel.Location = new System.Drawing.Point(65, 24);
            this.credentialsLabel.Name = "credentialsLabel";
            this.credentialsLabel.Size = new System.Drawing.Size(93, 13);
            this.credentialsLabel.TabIndex = 6;
            this.credentialsLabel.Text = "Client credentials: ";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(27, 88);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(297, 211);
            this.treeView1.TabIndex = 7;
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(371, 88);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(297, 211);
            this.treeView2.TabIndex = 8;
            // 
            // playlistPathLabel
            // 
            this.playlistPathLabel.AutoSize = true;
            this.playlistPathLabel.Location = new System.Drawing.Point(65, 50);
            this.playlistPathLabel.Name = "playlistPathLabel";
            this.playlistPathLabel.Size = new System.Drawing.Size(61, 13);
            this.playlistPathLabel.TabIndex = 11;
            this.playlistPathLabel.Text = "Playlist file: ";
            // 
            // playlistButton
            // 
            this.playlistButton.Location = new System.Drawing.Point(559, 47);
            this.playlistButton.Name = "playlistButton";
            this.playlistButton.Size = new System.Drawing.Size(80, 20);
            this.playlistButton.TabIndex = 10;
            this.playlistButton.Text = "Search";
            this.playlistButton.UseVisualStyleBackColor = true;
            this.playlistButton.Click += new System.EventHandler(this.playlistButton_Click);
            // 
            // documentPath
            // 
            this.documentPath.Location = new System.Drawing.Point(164, 47);
            this.documentPath.Name = "documentPath";
            this.documentPath.Size = new System.Drawing.Size(380, 20);
            this.documentPath.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 346);
            this.Controls.Add(this.documentPath);
            this.Controls.Add(this.playlistPathLabel);
            this.Controls.Add(this.playlistButton);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.credentialsLabel);
            this.Controls.Add(this.jsonButton);
            this.Controls.Add(this.jsonPath);
            this.Controls.Add(this.CheckButton);
            this.Controls.Add(this.WriteButton);
            this.Name = "Form1";
            this.Text = "YouTubePlaylistManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button WriteButton;
        private System.Windows.Forms.Button CheckButton;
        private System.Windows.Forms.Button jsonButton;
        private System.Windows.Forms.Label credentialsLabel;
        public System.Windows.Forms.TextBox jsonPath;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Label playlistPathLabel;
        private System.Windows.Forms.Button playlistButton;
        public System.Windows.Forms.TextBox playlistPath;
        public System.Windows.Forms.TextBox documentPath;
    }
}

