using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using SubtitlesParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


using TT_Edit.Forms;

namespace TT_Edit.Classes
{
    // Class for Docx File
    public class DocxFileConverter
    {
        /* ************** Variables ****************/
        public string path;
        public string name;
        public int lines;

        public DateTime date_created;
        public string status = "Pending";
        public List<string> AllItems = new List<string>();
        public int PreLines = 0;

        // Constructor with required fields
        public DocxFileConverter(string _path, string _name)
        {
            this.path = _path;
            this.name = _name;
            parseDocxFile();
        }



        /********************** Functions ******************/
       
        // Function to get export path
        public string export_path()
        {
            return DocToVTTConverterControl.DocxExportfolderPath + "\\" + name + ".vtt";
        }

        // Function to export
        public void export()
        {
            WriteToVTTFile(AllItems, export_path(), Encoding.UTF8);

        }

        // Function to write subtitles into Docx file
        public void WriteToVTTFile(List<String> finalItems, string filePath, Encoding encoding)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false, encoding))
            {

                foreach (string item in finalItems)
                {
                    // Writing Timeline
                    writer.WriteLine($"{(item)}");

                }
            }

        }

        // Function to parse Docx File
        public void parseDocxFile()
        {

            date_created = File.GetCreationTime(path);

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(this.path, false))
            {
                Body body = wordDoc.MainDocumentPart.Document.Body;

                var reg = new Regex(@"^[\s\p{L}]");

                foreach (Paragraph co in
                            wordDoc.MainDocumentPart.Document.Body.Descendants<Paragraph>())
                {
                    AllItems.Add(co.InnerText);
                }

            }


            lines = AllItems.Count;


        }

    }

}
