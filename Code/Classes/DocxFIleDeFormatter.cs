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
    public class DocxFIleDeFormatter
    {
        /* ************** Variables ****************/
        public string path;
        public string name;
        public int lines;

        public DateTime date_created;
        public string status = "Pending";
        public List<string> AllItemsOriginal = new List<string>();
        public List<string> AllItemsTranslated = new List<string>();
        public int PreLines = 0;

        // Constructor with required fields
        public DocxFIleDeFormatter(string _path, string _name)
        {
            this.path = _path;
            this.name = _name;
            parseDocxFile();
            format_error_check();
        }



        /********************** Functions ******************/
        public void format_error_check()
        {
            if (AllItemsOriginal.Count != AllItemsTranslated.Count)
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
            return PageTextDeFormatControl.DocxExportfolderPath + "\\" + name;
        }

        // Function to export
        public void export()
        {
            WriteToDocxFile( export_path(), Encoding.UTF8);

        }

        public void CreateAparagraphLine(ref Body body, string textToAppend)
        {
            body.Append(new Paragraph(new Run(new Text(textToAppend))));

        }

        // Function to write subtitles into Docx file
        public void WriteToDocxFile( string filePath, Encoding encoding)
        {

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(filePath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainDocumentPart = wordDoc.AddMainDocumentPart();
                mainDocumentPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
                mainDocumentPart.Document.Body = new Body();

                Body body = mainDocumentPart.Document.Body;
                for (int i = 0; i < PreLines; i++) CreateAparagraphLine(ref body, "");

                for (int i = 0; i < AllItemsOriginal.Count; i++)
                {
                    CreateAparagraphLine(ref body, AllItemsOriginal[i]);
                    CreateAparagraphLine(ref body, "");

                }
                for (int i = 0; i < 2; i++) CreateAparagraphLine(ref body, "");

                for (int i = 0; i < AllItemsTranslated.Count; i++)
                {
                    CreateAparagraphLine(ref body, AllItemsTranslated[i]);
                    CreateAparagraphLine(ref body, "");

                }

                mainDocumentPart.Document.Body = body;
                wordDoc.Save();

            }
        }

        // Function to format TimeCode


        // Function to parse Docx File
        public void parseDocxFile()
        {

            date_created = File.GetCreationTime(path);

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(this.path, false))
            {
                Body body = wordDoc.MainDocumentPart.Document.Body;


                int lineCount = 0;
                foreach (Paragraph co in
                            wordDoc.MainDocumentPart.Document.Body.Descendants<Paragraph>())
                {
                      if (co.InnerText == "")
                        {
                            if (AllItemsOriginal.Count >= 1)
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
                            if (AllItemsOriginal.Count == 0) lineCount = 1;
                            if (lineCount == 1 )
                            {
                                AllItemsOriginal.Add(co.InnerText);
                            }
                            else if (lineCount == 2)
                            {
                                AllItemsTranslated.Add(co.InnerText);
                                lineCount = 0;
                            }
                                
                        
                        }
               
                }

            }


            lines = AllItemsOriginal.Count  + AllItemsTranslated.Count;


        }

    }

}
