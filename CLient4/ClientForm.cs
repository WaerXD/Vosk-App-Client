using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace CLient4
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
            if (!Directory.Exists(tempDirectory)) Directory.CreateDirectory(tempDirectory);
            vosk = new VoskClass();
            serverUrl = ConfigurationManager.AppSettings["url"];
        }

        internal VoskClass vosk;
        internal WaveIn waveIn;
        internal WaveFileWriter writer;
        internal string outputFilename = string.Empty;
        internal string tempDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}Temp";
        internal bool IsRecord = false;
        internal string serverUrl;

        internal void ClearDirectory(string directory)
        {
            try
            {
                var files = Directory.GetFiles(directory);
                foreach (var file in files)
                {
                    File.Delete(file);
                }
            }
            catch { }
        }

        internal async void buttonRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsRecord)
                {
                    IsRecord = false;
                    buttonRecord.Text = "Запись";
                    pictureBoxVoice.Visible = false;
                    waveIn.StopRecording();
                    labelFile.Text = $"Текущий файл: {Path.GetFileName(outputFilename)}";
                }
                else
                {
                    IsRecord = true;
                    pictureBoxVoice.Visible = true;
                    buttonRecord.Text = "Остановить";
                    waveIn = new WaveIn();
                    waveIn.DeviceNumber = 0;
                    waveIn.DataAvailable += waveIn_DataAvailable;
                    waveIn.RecordingStopped += new EventHandler<StoppedEventArgs>(waveIn_RecordingStopped);
                    waveIn.WaveFormat = new WaveFormat(44000, 1);
                    outputFilename = $"{tempDirectory}\\{Guid.NewGuid().ToString().Replace("-", "_")}.wav";

                    writer = new WaveFileWriter(outputFilename, waveIn.WaveFormat);
                    waveIn.StartRecording();
                }
            }
            catch { }
        }

        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            writer.Write(e.Buffer, 0, e.BytesRecorded);
        }

        void waveIn_RecordingStopped(object sender, EventArgs e)
        {
            waveIn.Dispose();
            waveIn = null;
            writer.Close();
            writer = null;
        }

        private async void buttonSend_Click(object sender, EventArgs e)
        {
            var result = vosk.Recognize(outputFilename);
            var message = new Message()
            {
                Name = userNameTextBox.Text,
                Text = result.message,
                Dictor = result.speaker,
                HostName = Environment.MachineName
            };
            var client = new HttpClient();
            var resultMessage = await client.PostAsync(serverUrl, new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(message)));
        }

        private void buttonCreateModel_Click(object sender, EventArgs e)
        {
            var result = vosk.Recognize(outputFilename);
            var speakerSigns = new List<SpeakerModel>();
            foreach (var sign in result.speaker)
            {
                speakerSigns.Add(new SpeakerModel()
                {
                    Name = userNameTextBox.Text,
                    Vector = string.Join(";", sign.Select(d => d.ToString()))
                });
            }
            // Save speaker model to file
            File.WriteAllText($"{AppDomain.CurrentDomain.BaseDirectory}speaker.json", Newtonsoft.Json.JsonConvert.SerializeObject(speakerSigns));
        }

        private void pictureBoxVoice_Click(object sender, EventArgs e)
        {

        }
    }

    internal class Message
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public List<double[]> Dictor { get; set; }
        public string HostName { get; set; }
    }

    internal class SpeakerModel
    {
        public string Name { get; set; }
        public string Vector { get; set; }
    }
}
