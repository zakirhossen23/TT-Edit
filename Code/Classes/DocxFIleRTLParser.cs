using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using SubtitlesParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using TT_Edit.Forms;

namespace TT_Edit.Classes
{
    // Class for Docx File
    public class DocxFIleRTLParser
    {
        /* ************** Variables ****************/
        public string path;
        public string name;
        public int lines;

        public DateTime date_created;
        public string status = "Pending";
        public List<string> AllItems = new List< string>();

        public int PreLines = 0;

        // Constructor with required fields
        public DocxFIleRTLParser(string _path, string _name)
        {
            this.path = _path;
            this.name = _name;
            parseDocxFile();
        }



    
     
        // Function to export
        public void export(string exportPath )
        {
            WriteToDocxFile(AllItems, exportPath, Encoding.UTF8);

        }

        public void CreateAparagraphLine(ref Body body, string textToAppend)
        {
            RunProperties runProperties = new RunProperties();

            RunFonts runFonts = new RunFonts() { Ascii = "Segoe UI" };
            FontSize fontSize = new FontSize() { Val = "24" }; // 24 half-point size = 12 point size

            runProperties.Append(runFonts);
            runProperties.Append(fontSize);

            Run run = new Run();
            run.RunProperties = runProperties;
            run.Append(new Text(textToAppend));
            ParagraphProperties paragraphProperties = new ParagraphProperties();
            paragraphProperties.BiDi = new BiDi();
            paragraphProperties.BiDi.Val = new OnOffValue(true);
            paragraphProperties.TextDirection = new TextDirection();
            paragraphProperties.TextDirection.Val = TextDirectionValues.TopToBottomRightToLeft;
             Paragraph paragraph = new Paragraph();
            paragraph.ParagraphProperties = paragraphProperties;
            paragraph.Append(run);
            body.Append(paragraph);

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
             
                for (int i = 0; i < finalItems.Count; i++)
                {
                    CreateAparagraphLine(ref body, finalItems[i]);

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
            try
            {
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
            }
            catch (IOException ex)
            {
                MessageBox.Show($"File {name} is being used by another process");
                status= "Error";
            }



            lines = AllItems.Count;


        }

    }

}
