using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Vosk;

namespace CLient4
{
    internal class VoskClass
    {
        Model model;
        SpkModel spkModel;
        public VoskClass()
        {
            Vosk.Vosk.SetLogLevel(1);
            model = new Model("models\\ru");
            spkModel = new SpkModel("model_spk");
        }

        public (string message, List<double[]> speaker) Recognize(string file)
        {
            VoskRecognizer rec = new VoskRecognizer(model, 44000.0f);
            rec.SetSpkModel(spkModel);
            rec.SetMaxAlternatives(0);
            rec.SetWords(true);
            rec.Reset();
            var allText = string.Empty;
            var speaker = new List<double[]>();
            using (var source = File.OpenRead(file))
            {
                byte[] buffer = new byte[4096];
                int bytesRead;
                while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (rec.AcceptWaveform(buffer, bytesRead))
                    {
                        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<VoskResult>(rec.Result());
                        allText += result.Text;
                        if (result.Spk != null)
                        {
                            if (result.Spk_frames > 300) speaker.Add(result.Spk);
                        }
                    }
                }
            }
            var finalResult = Newtonsoft.Json.JsonConvert.DeserializeObject<VoskResult>(rec.FinalResult());
            allText += finalResult.Text;
            if (finalResult.Spk != null)
            {
                if (finalResult.Spk_frames > 300) speaker.Add(finalResult.Spk);
            }
            return (allText, speaker);
        }
    }

    internal class VoskResult
    {
        public double[] Spk { get; set; }
        public int Spk_frames { get; set; }
        public string Text { get; set; }
        public List<WordInfo> Result { get; set; }
    }

    internal class WordInfo
    {
        public float conf { get; set; }
        public float start { get; set; }
        public float end { get; set; }
        public string word { get; set; }
    }
}
