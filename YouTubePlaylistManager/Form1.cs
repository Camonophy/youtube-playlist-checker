using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouTubePlaylistManager
{
    public partial class Form1 : Form
    {

        private readonly String SCRIPTPATH = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"../../src/Manager.py";
        private String credentialsPath = "";
        private String playlistDocumentPath = "";



        public Form1()
        {
            InitializeComponent();
        }

        private void write_clicked(object sender, EventArgs e)
        {
            // Run the Python-Script
            System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
            start.FileName = "python";
            start.Arguments                 = this.SCRIPTPATH +
                                                String.Format(" {0} {1} ",
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
        }

        private void check_clicked(object sender, EventArgs e)
        {

        }

        private void search_button_clicked(object sender, EventArgs e)
        {
            OpenFileDialog findJSON = new OpenFileDialog();
            findJSON.Title = "Please select an credential file";
            findJSON.Filter = "JSON (*.json)|*.json";
            findJSON.ShowDialog();
            this.credentialsPath = findJSON.FileName.ToString() + "\" + findJSON.SafeFileName.ToString();
            this.jsonPath.Text = this.credentialsPath;
        }

        private void playlistButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog findPlaylist = new OpenFileDialog();
            findPlaylist.Title = "Please select an exisiting list";
            findPlaylist.Filter = "Document (*.txt)|*.txt";
            findPlaylist.ShowDialog();
            this.playlistDocumentPath = findPlaylist.FileName.ToString() + "\" + findPlaylist.SafeFileName.ToString();
            this.documentPath.Text = this.playlistDocumentPath;
        }
    }
}
