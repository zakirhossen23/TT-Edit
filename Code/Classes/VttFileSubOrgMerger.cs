using SubtitlesParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TT_Edit.Forms;

namespace TT_Edit.Classes
{
    // Class for VTT File
    public class VttFileSubOrgMerger
    {
        /* ************** Variables ****************/
        public FileStruct org;
        public FileStruct trans;
        public int lines;

        public DateTime date_created;
        public string status = "Pending";
        public List<SubtitleItem> OrgList = new List<SubtitleItem>();
        public List<SubtitleItem> TransList = new List<SubtitleItem>();
        public List<string> AllItems = new List<string>();

        // Constructor with required fields
        public VttFileSubOrgMerger(FileStruct _org, FileStruct _trans)
        {
            this.org = _org;
            this.trans = _trans;
            this.OrgList = parseVttFile(org.filePath);
            this.TransList = parseVttFile(trans.filePath);
            lines = OrgList.Count;
            format_error_check();
        }



        /********************** Functions ******************/
        public void format_error_check()
        {
            if (OrgList.Count != TransList.Count)
            {
                status = "Format Error";
            }

        }
        // Function to get export path
        public string export_path()
        {
            return SubOrgMergerControl.VTTExportfolderPath + "\\" + trans.fileName+".vtt";
        }

        // Function to export
        public void export()
        {
            WriteToVttFile(AllItems, export_path(), Encoding.UTF8);

        }


        // Function to write subtitles into VTT file
        public void WriteToVttFile(List<String> finalItems, string filePath, Encoding encoding)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false, encoding))
            {
                // First writing default WEBVTT and a newline
                writer.WriteLine("WEBVTT\n");
                foreach (String item in finalItems)
                {
                    // Writing Timeline
                    writer.WriteLine(item);
                }
            }
        }

        // Function to format TimeCode

        public static string GetFormattedStartEnd(SubtitleItem item)
        {
            return $"{FormatTimecode(item.StartTime)} --> {FormatTimecode(item.EndTime)}";
        }

        // Function to format TimeCode
        private static string FormatTimecode(int milliseconds)
        {
            TimeSpan time = TimeSpan.FromMilliseconds(milliseconds);
            return $"{time.Hours:00}:{time.Minutes:00}:{time.Seconds:00}.{time.Milliseconds:000}";
        }


        // Function to parse VTT File
        public List<SubtitleItem> parseVttFile(string path)
        {
            List<SubtitleItem> list = new List<SubtitleItem>();
            date_created = File.GetCreationTime(path);

            // Reading file
            var newParser = new Classes.VttParser();
            using (var fileStream = File.OpenRead(path))
            {
                try
                {
                    // Parsing the file and storing into AllSubtitleItems as List
                    var newParsed = newParser.ParseStream(fileStream, Encoding.UTF8);
                    list = newParsed.ToList();
                }
                catch (ArgumentException ex)
                {
                    this.status = "Format Error";
                }
              
            }

            return list;
        }

    }

}
