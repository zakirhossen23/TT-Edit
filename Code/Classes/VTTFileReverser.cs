using SubtitlesParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TT_Edit.Forms;

namespace TT_Edit.Classes
{
    // Class for VTT File

    public class VTTFileReverser
    {
        public string path;
        public string name;
        public int lines;
        public DateTime date_created;
        public string status = "Pending";
        public List<SubtitleItem> AllSubTitleItems;
        public string lang = "";

        public VTTFileReverser(string _path, string _name, string _lang = "")
        {
            this.path = _path;
            this.name = _name;
            this.lang = _lang;
            this.parseVttFile();
        }

        public string export_path() => ReverseConverterControl.vTTExportfolderPath + "\\" + this.name;

        public void export()
        {
            this.WriteToVttFile(this.AllSubTitleItems, this.export_path(), Encoding.UTF8);
        }

        public void WriteToVttFile(
          List<SubtitleItem> subtitleItems,
          string filePath,
          Encoding encoding)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath, false, encoding))
            {
                streamWriter.WriteLine("WEBVTT\n");
                foreach (SubtitleItem subtitleItem in subtitleItems)
                {
                    streamWriter.WriteLine(this.FormatTimecode(subtitleItem.StartTime) + " --> " + this.FormatTimecode(subtitleItem.EndTime));
                    foreach (string str in subtitleItem.Lines.ToArray())
                        streamWriter.WriteLine(str);
                    streamWriter.WriteLine();
                }
            }
        }

        private string FormatTimecode(int milliseconds)
        {
            TimeSpan timeSpan = TimeSpan.FromMilliseconds((double)milliseconds);
            return string.Format("{0:00}:{1:00}:{2:00}.{3:000}", (object)timeSpan.Hours, (object)timeSpan.Minutes, (object)timeSpan.Seconds, (object)timeSpan.Milliseconds);
        }

        public void parseVttFile()
        {
            this.date_created = File.GetCreationTime(this.path);
            using (FileStream vttStream = File.OpenRead(this.path))
                this.AllSubTitleItems = new VttParser().ParseStream((Stream)vttStream, Encoding.UTF8).ToList<SubtitleItem>();
            this.lines = this.AllSubTitleItems.Count;
        }
    }

}
