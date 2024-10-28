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
    public class DocxFIleFormatter
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
        public DocxFIleFormatter(string _path, string _name)
        {
            this.path = _path;
            this.name = _name;
            parseDocxFile();
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
            return PageTextFormatControl.DocxExportfolderPath + "\\" + name;
        }

        // Function to export
        public void export()
        {
            WriteToDocxFile(AllItemsFinal, export_path(), Encoding.UTF8);

        }

        public void CreateAparagraphLine(ref Body body, string textToAppend)
        {
            body.Append(new Paragraph(new Run(new Text(textToAppend))));

        }

        // Function to write subtitles into Docx file
        public void WriteToDocxFile(List<String> finalItems, string filePath, Encoding encoding)
        {

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(filePath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainDocumentPart = wordDoc.AddMainDocumentPart();
                mainDocumentPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
                mainDocumentPart.Document.Body = new Body();

                Body body = mainDocumentPart.Document.Body;
                for (int i = 0; i < PreLines; i++)
                {
                    CreateAparagraphLine(ref body, "");

                }
                for (int i = 0; i < finalItems.Count; i++)
                {
                    CreateAparagraphLine(ref body, finalItems[i]);
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

                var reg = new Regex(@"^[\s\p{L}]");

                int defaultGapCount = -1;
                int lineCount = 0;
                bool tranlsated = false;
                foreach (Paragraph co in
                            wordDoc.MainDocumentPart.Document.Body.Descendants<Paragraph>())
                {

                    if (co.InnerText == "")
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
                        if (defaultGapCount != -1 &&( lineCount >= (defaultGapCount + 1)))
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
                            AllItems.Add(co.InnerText);
                        }
                        else AllItemsTranslated.Add(co.InnerText);

                        lineCount = 0;
                    }

                }

            }


            lines = AllItems.Count + AllItemsTranslated.Count;


        }

    }

}
