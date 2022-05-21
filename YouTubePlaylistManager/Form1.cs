using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace YouTubePlaylistManager
{
    public partial class Form1 : Form
    {

        private readonly String SCRIPT  = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"../../src/Manager.py";
        private readonly String SCRIPTPATH  = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"../../src/";
        private readonly String JSONHANDLER = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"../../src/JsonHandler.py";
        private String credentialsPath = "";
        private String playlistDocumentPath = "";


        public Form1()
        {
            InitializeComponent();
        }


        private void WriteButton_Click(object sender, EventArgs e)
        {
            this.LoadingIcon.Visible = true;
            this.Refresh();

            // Run the Python-Script
            System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
            start.FileName = "python";
            start.Arguments                 = this.SCRIPT +
                                              String.Format(" {0} {1} {2} ",
                                                 "w",
                                                 this.credentialsPath,
                                                 this.playlistDocumentPath);
            start.UseShellExecute           = false;
            start.CreateNoWindow            = true;
            start.RedirectStandardOutput    = true;
            start.RedirectStandardError     = true;
            start.LoadUserProfile           = true;

            using (System.Diagnostics.Process process = System.Diagnostics.Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    String stderr = process.StandardError.ReadToEnd();
                    String result = reader.ReadToEnd();
                    Console.Write(stderr == "" ? "" : stderr + "\n");
                    Console.Write(result == "" ? "" : result + "\n");
                }
            }

            this.LoadingIcon.Visible = false;
        }


        private void CheckButton_Click(object sender, EventArgs e)
        {
            this.LoadingIcon.Visible = true;
            this.Refresh();

            // Run the Python-Script
            System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
            start.FileName = "python";
            start.Arguments = this.SCRIPT +
                                              String.Format(" {0} {1} {2} ",
                                                 "u",
                                                 this.credentialsPath,
                                                 this.playlistDocumentPath);
            start.UseShellExecute = false;
            start.CreateNoWindow = true;
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;
            start.LoadUserProfile = true;

            using (System.Diagnostics.Process process = System.Diagnostics.Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    String stderr = process.StandardError.ReadToEnd();
                    String result = reader.ReadToEnd();
                    Console.Write(stderr == "" ? "" : stderr + "\n");
                    Console.Write(result == "" ? "" : result + "\n");
                }
            }

            Results results = JsonConvert.DeserializeObject<Results>(File.ReadAllText("Entries.json"));
            this.LocalFiles.Items.AddRange(results.local);
            this.OnlineFiles.Items.AddRange(results.online);
        
            this.LoadingIcon.Visible = false;
        }


        private void JsonButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog findJSON = new OpenFileDialog();
            findJSON.Title = "Please select an credential file";
            findJSON.Filter = "JSON (*.json)|*.json";
            findJSON.ShowDialog();
            this.credentialsPath = findJSON.FileName.ToString();
            this.JsonPath.Text = this.credentialsPath;
            try
            {
                Client client = JsonConvert.DeserializeObject<Client>(File.ReadAllText(this.credentialsPath));
                this.ApiKeyText.Text = client.api_key;
                this.ChannelIDText.Text = client.channel_id;
                this.PlaylistIDText.Text = client.playlist_id;
            } catch (Exception) { }
        }


        private void PlaylistButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog findPlaylist = new OpenFileDialog();
            findPlaylist.Title = "Please select an exisiting list";
            findPlaylist.Filter = "Document (*.txt)|*.txt";
            findPlaylist.ShowDialog();
            this.playlistDocumentPath = findPlaylist.FileName.ToString();
            this.DocumentPath.Text = this.playlistDocumentPath;
        }


        private void CreateJsonButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Save your credential file";
            saveFile.FileName = "Client";
            saveFile.Filter = "JSON (*.json)|*.json";
            saveFile.ShowDialog();

            // Run the Python-Script
            System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
            start.FileName = "python";
            start.Arguments = this.JSONHANDLER +
                                String.Format(" {0} {1} {2} {3} ",
                                this.ApiKeyText.Text,
                                this.ChannelIDText.Text,
                                this.PlaylistIDText.Text,
                                saveFile.FileName);                     // Not saving properly
            start.UseShellExecute = false;
            start.CreateNoWindow = true;
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;
            start.LoadUserProfile = true;

            using (System.Diagnostics.Process process = System.Diagnostics.Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    String stderr = process.StandardError.ReadToEnd();
                    String result = reader.ReadToEnd();
                    Console.Write(stderr == "" ? "" : stderr + "\n");
                    Console.Write(result == "" ? "" : result + "\n");
                }
            }

            this.CheckButton.Visible = true;
            this.WriteButton.Visible = true;
            this.JsonButton.Visible = true;
            this.PlaylistButton.Visible = true;
            this.CreateButton.Visible = true;
            this.CredentialsLabel.Visible = true;
            this.PlaylistPathLabel.Visible = true;
            this.LocalFiles.Visible = true;
            this.OnlineFiles.Visible = true;
            this.JsonPath.Visible = true;
            this.DocumentPath.Visible = true;
            this.LocalLabel.Visible = true;
            this.OnlineLabel.Visible = true;

            this.CreateJsonButton.Visible = false;
            this.ApiKeyText.Visible = false;
            this.PlaylistIDText.Visible = false;
            this.ChannelIDText.Visible = false;
        }


        private void CreateButton_Click(object sender, EventArgs e)
        {
            this.CheckButton.Visible = false;
            this.WriteButton.Visible = false;
            this.JsonButton.Visible = false;
            this.PlaylistButton.Visible = false;
            this.CreateButton.Visible = false;
            this.CredentialsLabel.Visible = false;
            this.PlaylistPathLabel.Visible = false;
            this.LocalFiles.Visible = false;
            this.OnlineFiles.Visible = false;
            this.JsonPath.Visible = false;
            this.DocumentPath.Visible = false;
            this.LocalLabel.Visible = false;
            this.OnlineLabel.Visible = false;

            this.CreateJsonButton.Visible = true;
            this.ApiKeyText.Visible = true;
            this.PlaylistIDText.Visible = true;
            this.ChannelIDText.Visible = true;
        }
    }


    public class Client
    {
        public string api_key { get; set; }
        public string channel_id { get; set; }
        public string playlist_id { get; set; }
    }

    public class Results
    {
        public string[] local { get; set; }
        public string[] online { get; set; }
    }
}
