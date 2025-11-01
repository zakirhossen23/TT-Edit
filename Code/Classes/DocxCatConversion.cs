using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
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
    public class DocxCatConversion
    {
        /* ************** Variables ****************/
        public string path;
        public string name;
        public int lines;
        public DateTime date_created;
        public string status = "Pending";
        public List<SubtitleItemCustom> AllSubTitleItems;
        public List<string> AllItems = new List<string>();
        public List<string> AllItemsOriginal = new List<string>();
        public List<string> AllItemsTranslated = new List<string>();
        public bool isIncludedTimeCode = true;
        // Constructor with required fields
        public DocxCatConversion(string _path, string _name, bool _isIncludedTimeCode = true)
        {
            this.path = _path;
            this.name = _name;
            this.isIncludedTimeCode= _isIncludedTimeCode;
            parseDocxFile();

        }



        /********************** Functions ******************/
        // Function to get export path
        public string export_path()
        {
            return CatConversionControl.xlsxExportfolderPath + "\\" + name + ".xlsx";
        }

        // Function to export
        public void export()
        {
            WriteToXlsxFile(AllSubTitleItems, export_path(), Encoding.UTF8);

        }


        // Function to write subtitles into Xlsx file
        public void WriteToXlsxFile(List<SubtitleItemCustom> subtitleItems, string filePath, Encoding encoding)
        {


            XSSFWorkbook workbook = new XSSFWorkbook();

            // Defining a border
            XSSFCellStyle borderedCellStyle = (XSSFCellStyle)workbook.CreateCellStyle();

            XSSFFont xSSFFont = (XSSFFont)workbook.CreateFont();
            xSSFFont.FontName="Times new Roman";
            xSSFFont.FontHeightInPoints = 12;
            ISheet Sheet = workbook.CreateSheet("Sheet 1");
            borderedCellStyle.SetFont(xSSFFont);

            if (isIncludedTimeCode)
            {
                int rowIdx = 0;
                for (int i = 0; i< subtitleItems.Count; i++)
                {
                    if (subtitleItems[i].Lines.Count == 2)
                    {
                        IRow row = Sheet.CreateRow(rowIdx);
                        XlsxHelper.CreateCell(row, 0, subtitleItems[i].Lines[0], borderedCellStyle);
                        XlsxHelper.CreateCell(row, 1, subtitleItems[i].Lines[1], borderedCellStyle);
                        rowIdx++;
                    }
                }

            }
            else
            {
                int rowIdx = 0;
                for (int i = 0; i < AllItemsOriginal.Count; i++)
                {
                    IRow row = Sheet.CreateRow(rowIdx);
                    XlsxHelper.CreateCell(row, 0, AllItemsOriginal[i], borderedCellStyle);
                    XlsxHelper.CreateCell(row, 1, AllItemsTranslated[i], borderedCellStyle);
                    rowIdx++;
                }

            }

            for (int i = 0; i <= 1; i++)
            {
                Sheet.AutoSizeColumn(i);
                GC.Collect();
            }

            // Write Excel to disk 
            using (var fileData = new FileStream(filePath, FileMode.Create))
            {
                workbook.Write(fileData);
            }

        }


        public static string GetFormattedStartEnd(SubtitleItemCustom item)
        {
            return item.StartEndString;
        }

     
        // Function to parse VTT File
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

                    string textLine = "";
                    foreach (var run in co.ChildElements)
                    {

                        Run run1 = null;
                        if (run.GetType() == typeof(SdtRun))
                        {
                            run1 = run.ChildElements.OfType<SdtContentRun>().FirstOrDefault().OfType<Run>().FirstOrDefault();
                        }
                        else if (run.GetType() == typeof(Run))
                        {
                            run1 = (Run)run;
                        }
                        else continue;
                        if (run1.ChildElements.Count == 1)
                        {
                            AllItems.Add(textLine);
                            textLine = "";

                        }
                        foreach (var item in run1.ChildElements)
                        {
                            if (item.GetType() == (new Break()).GetType())
                            {
                                AllItems.Add(textLine);
                                textLine = "";
                            }
                            else if (item.GetType() == (new Text()).GetType())
                            {
                                textLine += item.InnerText;
                            }

                        }
                    }
                    if (!string.IsNullOrEmpty(textLine) || co.ChildElements.Count < 2 || ((co.ChildElements.Count == 2) && co.ChildElements.Last().ChildElements.Last().GetType() == (new Break()).GetType()))
                    {
                        AllItems.Add(textLine);
                        textLine = "";
                    }

                }

            }


            // Reading file
            var newParser = new Classes.VttParserCustom();
            using (var fileStream = File.OpenRead(path))
            {

                if (isIncludedTimeCode == false)
                {
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
                            }
                            else
                            {
                                if (AllItemsOriginal.Count == 0) lineCount = 1;
                                if (lineCount == 1)
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
                
                    lines = AllItemsOriginal.Count + AllItemsTranslated.Count;
                }
                else
                {
                    try
                    {
                        var newParsed = newParser.ParseStream(fileStream, Encoding.UTF8, AllItems);
                        AllSubTitleItems = newParsed.ToList();
                        lines = AllSubTitleItems.Count;

                    }
                    catch (Exception)
                    {
                        this.status = "Format Error";
                    }
                }

            }



        }

    }

}
