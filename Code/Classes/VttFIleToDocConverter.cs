using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
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
    public class VttFIleToDocConverter
    {
        /* ************** Variables ****************/
        public string path;
        public string name;
        public int lines;
        public DateTime date_created;
        public string status = "Pending";
        public List<String> AllItems=new List<String>();

        // Constructor with required fields
        public VttFIleToDocConverter(string _path, string _name)
        {
            this.path = _path;
            this.name = _name;
            parseVttFile();

        }



        /********************** Functions ******************/
        // Function to get export path
        public string export_path()
        {
            return VttToDocControl.vTTExportfolderPath + "\\" + name + ".docx";
        }

        // Function to export
        public void export()
        {
            WriteToDocxFile(AllItems, export_path(), Encoding.UTF8);

        }


        public void CreateAparagraphLine(ref Body body, string textToAppend)
        {
            body.Append(new Paragraph(new Run(new Text(textToAppend))));

        }
        // Function to write lines into VTT file
        public void WriteToDocxFile(List<String> AllItems, string filePath, Encoding encoding)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(filePath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainDocumentPart = wordDoc.AddMainDocumentPart();
                mainDocumentPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
                mainDocumentPart.Document.Body = new Body();

                Body body = mainDocumentPart.Document.Body;

                for (int i = 0; i < AllItems.Count; i++)
                {
                    CreateAparagraphLine(ref body, AllItems[i]);

                }
                mainDocumentPart.Document.Body = body;
                wordDoc.Save();

            }
        }

        // Function to parse VTT File
        public void parseVttFile()
        {
            date_created = File.GetCreationTime(path);

            foreach (var line in File.ReadLines(path)) { 

                AllItems.Add(line);
            }
            // Setting All lines count
            lines = AllItems.Count;



        }

    }

}
