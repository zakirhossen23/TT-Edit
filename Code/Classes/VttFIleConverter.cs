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
    public class VttFIleConverter
    {
        /* ************** Variables ****************/
        public string path;
        public string name;
        public int lines;
        public DateTime date_created;
        public string status = "Pending";
        public List<SubtitleItem> AllSubTitleItems;

        // Constructor with required fields
        public VttFIleConverter(string _path, string _name)
        {
            this.path = _path;
            this.name = _name;
            parseVttFile();

        }



        /********************** Functions ******************/
        // Function to get export path
        public string export_path()
        {
            return ConverterControl.vTTExportfolderPath + "\\" + name;
        }

        // Function to export
        public void export()
        {
            WriteToVttFile(AllSubTitleItems, export_path(), Encoding.UTF8);

        }


        // Function to write subtitles into VTT file
        public void WriteToVttFile(List<SubtitleItem> subtitleItems, string filePath, Encoding encoding)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false, encoding))
            {
                // First writing default WEBVTT and a newline
                writer.WriteLine("WEBVTT\n");
                foreach (SubtitleItem item in subtitleItems)
                {
                    // Writing Timeline
                    writer.WriteLine($"{FormatTimecode(item.StartTime)} --> {FormatTimecode(item.EndTime)}");

                    // Joining all lines into one line and then writing into new file
                    string draftLines = string.Join(" ", item.Lines.ToArray()).Trim();
                    writer.WriteLine(draftLines);

                    // Add an empty line between subtitle items
                    writer.WriteLine();
                }
            }
        }

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
        public void parseVttFile()
        {
            date_created = File.GetCreationTime(path);

            // Reading file
            var newParser = new Classes.VttParser();
            using (var fileStream = File.OpenRead(path))
            {
                // Parsing the file and storing into AllSubtitleItems as List
                var newParsed = newParser.ParseStream(fileStream, Encoding.UTF8);
                AllSubTitleItems = newParsed.ToList();
            }

            // Setting All subtitle count
            lines = AllSubTitleItems.Count;



        }

    }

}
