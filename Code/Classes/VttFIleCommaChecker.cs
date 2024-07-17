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
    public class VttFIleCommaChecker
    {
        /* ************** Variables ****************/
        public string path;
        public string name;
        public int lines;
        public DateTime date_created;
        public string status = "Pending";
        public string Commas = "Pending";
        public List<SubtitleItemCommas> AllSubTitleItems;

        // Constructor with required fields
        public VttFIleCommaChecker(string _path, string _name)
        {
            this.path = _path;
            this.name = _name;
            parseVttFile();

        }



        /********************** Functions ******************/
        // Function to get export path
        public string export_path()
        {
            return CommaCheckerControl.vTTExportfolderPath + "\\" + name;
        }

        // Function to export
        public void export()
        {
            WriteToVttFile(AllSubTitleItems, export_path(), Encoding.UTF8);

        }


        // Function to write subtitles into VTT file
        public void WriteToVttFile(List<SubtitleItemCommas> subtitleItems, string filePath, Encoding encoding)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false, encoding))
            {
                // First writing default WEBVTT and a newline
                writer.WriteLine("WEBVTT\n");
                foreach (SubtitleItemCommas item in subtitleItems)
                {
                    // Writing Timeline
                    writer.WriteLine(item.StartEndString);

                    for (int i = 0; i < item.Lines.Count; i++)
                    {
                        writer.WriteLine(item.Lines[i]);
                    }
                 
                    // Add an empty line between subtitle items
                    writer.WriteLine();
                }
            }
        }

        // Function to parse VTT File
        public void parseVttFile()
        {
            date_created = File.GetCreationTime(path);

            // Reading file
            var newParser = new Classes.VttParserComma();
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
