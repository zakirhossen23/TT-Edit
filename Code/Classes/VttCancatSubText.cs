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
    public class VttCancatSubText
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
        public VttCancatSubText(string _path, string _name, string[] allFiles)
        {
            this.path = _path;
            this.name = _name;
            if (checkFormat(allFiles))
            parseVttFile();

        }

        public bool checkFormat(string[] allFiles)
        {
            status="Sub File not found";
            foreach (var item in allFiles)
            {
                if ( Path.GetFileName(item).ToLower() == name+ ".sub.vtt")
                {
                    status = "Pending";
                    SubPath = item;
                }

            }
            return status=="Pending";
        }


        /********************** Functions ******************/
        // Function to get export path
        public string export_path()
        {
            return PageConcatSubTextVTTControl.vTTExportfolderPath + "\\" + name+ ".combined.vtt";
        }

        // Function to export
        public void export()
        {
            WriteToVttFile(AllItems, export_path(), Encoding.UTF8);

        }


        // Function to write subtitles into VTT file
        public void WriteToVttFile(List<string> Items, string filePath, Encoding encoding)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false, encoding))
            {
                foreach (string item in Items)
                {

                    writer.WriteLine(item);
                }
            }
        }


        // Function to parse VTT File
        public void parseVttFile()
        {
            date_created = File.GetCreationTime(path);

            foreach (var line in File.ReadLines(path))
            {

                AllItemsOrg.Add(line);
            }
            foreach (var line in File.ReadLines(SubPath))
            {
                AllItemsSub.Add(line);
            }
            // Setting All lines count
            lines = AllItemsOrg.Count + AllItemsSub.Count+3;




        }

    }

}
