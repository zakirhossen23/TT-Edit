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
    public class VttFIleSubOrgMerger
    {
        /* ************** Variables ****************/
        public string path;
        public string name;
        public int lines;

        public DateTime date_created;
        public string status = "Pending";
        public List<SubtitleItem> AllSubTitleItems;

        // Constructor with required fields
        public VttFIleSubOrgMerger(string _path, string _name)
        {
            this.path = _path;
            this.name = _name;
            parseVttFile();
            format_error_check();
        }



        /********************** Functions ******************/
        public void format_error_check()
        {
            if (AllSubTitleItems == null) return;
            int AddToNextTimeFrame = 0;
            int PreviousTimeFrame = 0;
            for (int i = 0; i < AllSubTitleItems.Count - 1; i++)
            {
                SubtitleItem subtitle = AllSubTitleItems[i];

                for (int j = 0;  j< subtitle.Lines.Count;j++)
                {
                    if (subtitle.Lines[j].Split(new string[1]
                        {
                            Environment.NewLine
                        }, StringSplitOptions.None).Count() > 2)
                    {
                        this.status = "Format Error";
                        break;

                    }

                }
                // First joining all lines into a string
                string draftLines = string.Join(" ", subtitle.Lines.ToArray()).Trim();


                if (draftLines.Length != 0)
                {
                    // Counter for next timeframe which are empty
                    AddToNextTimeFrame = 0;
                    PreviousTimeFrame = i;
                    for (int j = i + 1; j < AllSubTitleItems.Count; j++)
                    {
                        if (AllSubTitleItems[j].Lines.Count == 0 )
                        {
                            AddToNextTimeFrame++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if ((subtitle.Lines.Count - 1) > 0)
                    {
                        if (AddToNextTimeFrame != (subtitle.Lines.Count - 1))
                        {
                            this.status = "Format Error";
                            break;
                        }
                    }
                    else
                    {
                        if (AddToNextTimeFrame > 0)
                        {

                            AddToNextTimeFrame--;
                        }
                    }
                }
            }
            


        }
        // Function to get export path
        public string export_path()
        {
            return TimeframeDividerControl.vTTExportfolderPath + "\\" + name;
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
                    writer.WriteLine($"{GetFormattedStartEnd(item)}");

                    for (int i = 0; i < item.Lines.Count; i++)
                    {
                        writer.WriteLine(item.Lines[i]);
                    }


                    // Add an empty line between subtitle items
                    writer.WriteLine();
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
        public void parseVttFile()
        {
            date_created = File.GetCreationTime(path);

            // Reading file
            var newParser = new Classes.VttParserDivider();
            using (var fileStream = File.OpenRead(path))
            {
                try
                {
                    // Parsing the file and storing into AllSubtitleItems as List
                    var newParsed = newParser.ParseStream(fileStream, Encoding.UTF8);
                    AllSubTitleItems = newParsed.ToList();
                }
                catch (ArgumentException ex)
                {
                    this.status = "Format Error";
                }
              
            }

            if (AllSubTitleItems != null)
            // Setting All subtitle count
            lines = AllSubTitleItems.Count;



        }

    }

}
