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
    public class VttFIleTimeDivider
    {
        /* ************** Variables ****************/
        public string path;
        public string name;
        public int lines;

        public DateTime date_created;
        public string status = "Pending";
        public List<SubtitleItemDivider> AllSubTitleItems;

        // Constructor with required fields
        public VttFIleTimeDivider(string _path, string _name)
        {
            this.path = _path;
            this.name = _name;
            parseVttFile();

        }



        /********************** Functions ******************/
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
        public void WriteToVttFile(List<SubtitleItemDivider> subtitleItems, string filePath, Encoding encoding)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false, encoding))
            {
                // First writing default WEBVTT and a newline
                writer.WriteLine("WEBVTT\n");
                foreach (SubtitleItemDivider item in subtitleItems)
                {
                    // Writing Timeline
                    writer.WriteLine($"{(item.StartEndString.ToString())}");

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
