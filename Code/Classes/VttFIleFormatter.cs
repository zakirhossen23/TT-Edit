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
    public class VttFIleFormatter
    {
        /* ************** Variables ****************/
        public string path;
        public string name;
        public int lines;
        public DateTime date_created;
        public string status = "Pending";
        public List<string> AllItems = new List<string>();
        public List<string> AllItemsTranslated = new List<string>();
        public List<string> AllItemsFinal = new List<string>();
        public int PreLines = 0;

        // Constructor with required fields
        public VttFIleFormatter(string _path, string _name)
        {
            this.path = _path;
            this.name = _name;
            parseVttFile();
            format_error_check();

        }



        /********************** Functions ******************/
        public void format_error_check()
        {
            if (AllItems.Count != AllItemsTranslated.Count)
            {
                status = "Format Error";
            }
            if (lines == 0)
            {
                status = "Format Error";

            }

        }

        // Function to get export path
        public string export_path()
        {
            return PageTextFormatVTTControl.vTTExportfolderPath + "\\" + name;
        }

        // Function to export
        public void export()
        {
            WriteToVttFile(AllItemsFinal, export_path(), Encoding.UTF8);

        }


        // Function to write subtitles into VTT file
        public void WriteToVttFile(List<string> finalItems, string filePath, Encoding encoding)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false, encoding))
            {
                for (int i = 0; i < PreLines; i++)
                {
                    writer.WriteLine( "");

                }

                for (int i = 0; i < finalItems.Count; i++)
                {
                    writer.WriteLine( finalItems[i]);
                    writer.WriteLine( "");

                }

            }
        }
    
    

        // Function to parse VTT File
        public void parseVttFile()
        {
            date_created = File.GetCreationTime(path);

            // Reading file
            using (var vttStream = File.OpenRead(path))
            {
                vttStream.Position = 0L;
                StreamReader reader = new StreamReader(vttStream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true);
                List<string> list = new List<string>();
                string line = null;
                int defaultGapCount = -1;
                int lineCount = 0;
                bool tranlsated = false;

                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line);
                }

                for (int i = 0; i < list.Count; i++)
                {
                    line = list[i];
                    if (line.Trim() == "")
                    {
                        if (AllItems.Count >= 1)
                        {
                            lineCount++;
                        }
                        else
                        {
                            PreLines++;
                        }
                    }
                    else
                    {

                        if (defaultGapCount != -1 && (lineCount >= (defaultGapCount + 1)))
                        {
                            tranlsated = true;
                        }
                        if (!tranlsated)
                        {
                            if (defaultGapCount == -1)
                            {
                                if (AllItems.Count >= 1)
                                {
                                    defaultGapCount = lineCount;
                                }

                            }
                            AllItems.Add(line);
                        }
                        else AllItemsTranslated.Add(line);

                        lineCount = 0;
                    }
                }
            }

            // Setting All subtitle count
            lines = AllItems.Count + AllItemsTranslated.Count;



        }

    }

}
