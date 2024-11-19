using DocumentFormat.OpenXml.ExtendedProperties;
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
    public class DocxSubOrgMerger
    {
        // Delimiters can be used inbetween timecodes
        private readonly string[] _delimiters = new string[3]
      {
            "-->",
            "- >",
            "->"
      };

        /* ************** Variables ****************/
        public FileStruct org;
        public FileStruct trans;
        public int lines;
        public int PreLines =0;

        public DateTime date_created;
        public string status = "Pending";
        public List<SubtitleItem> OrgList = new List<SubtitleItem>();
        public List<SubtitleItem> TransList = new List<SubtitleItem>();
        public Dictionary<string,string> AllItems = new Dictionary<string, string>();

        // Constructor with required fields
        public DocxSubOrgMerger(FileStruct _org, FileStruct _trans)
        {
            this.org = _org;
            this.trans = _trans;
            this.OrgList =  parseDocxFile(org.filePath);
            this.TransList = parseDocxFile(trans.filePath);
            lines = OrgList.Count;
            format_error_check();
        }



        /********************** Functions ******************/
        public void format_error_check()
        {
            if (OrgList.Count != TransList.Count)
            {
                status = "Format Error";
            }

        }
        // Function to get export path
        public string export_path()
        {
            return PageTextFormatControl.DocxExportfolderPath + "\\" + org.fileName;
        }

        // Function to export
        public void export()
        {
            //WriteToDocxFile(AllItemsFinal, export_path(), Encoding.UTF8);

        }

        public void CreateAparagraphLine(ref Body body, string textToAppend)
        {
            body.Append(new Paragraph(new Run(new Text(textToAppend))));

        }

        // Function to write subtitles into Docx file
        public void WriteToDocxFile(List<String> finalItems, string filePath, Encoding encoding)
        {

            //using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(filePath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            //{
            //    MainDocumentPart mainDocumentPart = wordDoc.AddMainDocumentPart();
            //    mainDocumentPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
            //    mainDocumentPart.Document.Body = new Body();

            //    //Body body = mainDocumentPart.Document.Body;
            //    //for (int i = 0; i < PreLines; i++)
            //    //{
            //    //    CreateAparagraphLine(ref body, "");

            //    //}
            //    //for (int i = 0; i < finalItems.Count; i++)
            //    //{
            //    //    CreateAparagraphLine(ref body, finalItems[i]);
            //    //    CreateAparagraphLine(ref body, "");

            //    //}
            //    //mainDocumentPart.Document.Body = body;
            //    //wordDoc.Save();

            //}
        }

        // Function to format TimeCode


        // Function to parse Docx File
        public List<SubtitleItem> parseDocxFile(string filePath)
        {

            date_created = File.GetCreationTime(filePath);
            List<SubtitleItem> list = new List<SubtitleItem>();
            List<string> list2 = new List<string>();

            if (list2.Any())
            {
                    // Iterating Trimmed list
                    SubtitleItem subtitleItem = new SubtitleItem();
                // Iterating all the lines
                foreach (string item in list2)
                {


                    // Checking if subtitleItem starttime and endtime is 0 or not
                    // Then it will parse
                    if (TryParseTimecodeLine(item, out int startTc, out int endTc))
                    {

                        // Adding this subtitleItem 
                        if ((subtitleItem.StartTime != 0 || subtitleItem.EndTime != 0))
                        {
                            list.Add(subtitleItem);
                            subtitleItem = new SubtitleItem();
                        }
                        subtitleItem.StartTime = startTc;
                        subtitleItem.EndTime = endTc;
                    }
                    else
                    {
                        // Adding this subtitleItem 
                        if ((subtitleItem.StartTime != 0 || subtitleItem.EndTime != 0))
                        {
                            // Else it will add line to that to subtitle
                            subtitleItem.Lines.Add(item);
                        }
                        
                    }


                }

                // Adding this subtitleItem 
                if ((subtitleItem.StartTime != 0 || subtitleItem.EndTime != 0))
                {
                    list.Add(subtitleItem);
                }

            }



            return list;


        }



        // Function to check if possible to Parse TimecodeLine 
        private bool TryParseTimecodeLine(string line, out int startTc, out int endTc)
        {
            string[] array = line.Split(_delimiters, StringSplitOptions.None);
            if (array.Length != 2)
            {
                startTc = -1;
                endTc = -1;
                return false;
            }

            startTc = ParseVttTimecode(array[0]);
            endTc = ParseVttTimecode(array[1]);
            return true;
        }

        // Function to Parse VTT Time code
        private int ParseVttTimecode(string s)
        {
            string text = string.Empty;
            Match match = Regex.Match(s, "[0-9]+:[0-9]+:[0-9]+[,\\.][0-9]+");
            if (match.Success)
            {
                text = match.Value;
            }
            else
            {
                match = Regex.Match(s, "[0-9]+:[0-9]+[,\\.][0-9]+");
                if (match.Success)
                {
                    text = "00:" + match.Value;
                }
            }

            if (!string.IsNullOrEmpty(text))
            {
                text = text.Replace(',', '.');
                if (TimeSpan.TryParse(text, out TimeSpan result))
                {
                    return (int)result.TotalMilliseconds;
                }
            }

            return -1;
        }

    }

}
