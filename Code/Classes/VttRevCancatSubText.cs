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
    public class VttRevCancatSubText
    {
        /* ************** Variables ****************/
        public string path;
        public string SubPath;
        public string name;
        public int lines;
        public DateTime date_created;
        public string status = "Pending";
        public List<string> AllItemsOrg = new List<string>();
        public List<string> AllItemsSub = new List<string>();
        public List<string> AllItems = new List<string>();

        // Constructor with required fields
        public VttRevCancatSubText(string _path, string _name)
        {
            this.path = _path;
            this.name = _name;
            parseVttFile();

        }


        /********************** Functions ******************/
        // Function to get export path
        public string export_path()
        {
            return PageRevConcatSubTextVTTControl.vTTExportfolderPath + "\\" + name;
        }

        // Function to export
        public void export()
        {
            WriteToVttFile( export_path(), Encoding.UTF8);

        }


        // Function to write subtitles into VTT file
        public void WriteToVttFile( string filePath, Encoding encoding)
        {
            using (StreamWriter writer = new StreamWriter(filePath+".vtt", false, encoding))
            {
                foreach (string item in AllItemsOrg)
                {

                    writer.WriteLine(item);
                }

            }

            using (StreamWriter writer = new StreamWriter(filePath + ".SUB.vtt", false, encoding))
            {
                foreach (string item in AllItemsSub)
                {
                    writer.WriteLine(item);
                }
            }
        }


        // Function to parse VTT File
        public void parseVttFile()
        {
            date_created = File.GetCreationTime(path);
            var allLines = File.ReadAllLines(path, Encoding.UTF8).ToList();
            if (allLines.Count == 0)
            {
                status = "Empty file";
                return;
            }


            // Find first line that starts with WEBVTT (case-insensitive, trimed)
            int webvttIndex = -1;
            for (int i = 0; i < allLines.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(allLines[i]) &&
                    allLines[i].TrimStart().StartsWith("WEBVTT", StringComparison.OrdinalIgnoreCase))
                {
                    webvttIndex = i;
                    break;
                }
            }

            if (webvttIndex == -1)
            {
                status = "WEBVTT not found";
                return;
            }


            // Top part: everything before WEBVTT
            AllItemsOrg = allLines.Take(webvttIndex-3).ToList();
            // Sub part: from WEBVTT to end
            AllItemsSub = allLines.Skip(webvttIndex).ToList();



            // Setting All lines count
            lines = AllItemsOrg.Count + AllItemsSub.Count;




        }

    }

}
