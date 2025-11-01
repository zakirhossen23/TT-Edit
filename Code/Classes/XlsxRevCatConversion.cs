using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using NPOI.HSSF.UserModel;
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
using Run = DocumentFormat.OpenXml.Wordprocessing.Run;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;

namespace TT_Edit.Classes
{
    // Class for XLSX File
    public class XlsxRevCatConversion
    {
        /* ************** Variables ****************/
        public string path;
        public string name;
        public int lines;

        public DateTime date_created;
        public string status = "Pending";
        public List<SubtitleItemCustom> AllSubTitleItems;
        public List<string> AllItems = new List<string>();
        public int PreLines = 0;
        public bool isIncludedTimeCode = true;

        // Constructor with required fields
        public XlsxRevCatConversion(string _path, string _name, bool _isIncludedTimeCode = true)
        {
            this.path = _path;
            this.name = _name;
            this.isIncludedTimeCode= _isIncludedTimeCode;
            parseXlsxFile();
            format_error_check();
        }



        /********************** Functions ******************/
        public void format_error_check()
        {
            if (lines == 0)
            {
                status = "Format Error";

            }

        }
        // Function to get export path
        public string export_path()
        {
            return RevCatConversionControl.DocxExportfolderPath + "\\" + name+".docx";
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

        // Function to write subtitles into Docx file
        public void WriteToDocxFile(List<String> finalItems, string filePath, Encoding encoding)
        {

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(filePath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainDocumentPart = wordDoc.AddMainDocumentPart();
                mainDocumentPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
                mainDocumentPart.Document.Body = new Body();

                Body body = mainDocumentPart.Document.Body;
                if (isIncludedTimeCode)
                {
                    CreateAparagraphLine(ref body, "WEBVTT");
                    CreateAparagraphLine(ref body, "");
                    for (int i = 0; i < finalItems.Count; i++)
                    {
                        CreateAparagraphLine(ref body, finalItems[i]);

                    }

                }
                else
                {
                    for (int i = 0; i < finalItems.Count; i++)
                    {
                        CreateAparagraphLine(ref body, finalItems[i]);
                        CreateAparagraphLine(ref body,"");
                    }
                }
                mainDocumentPart.Document.Body = body;
                wordDoc.Save();

            }
        }

        // Function to format TimeCode


        // Function to parse Xlsx File
        public void parseXlsxFile()
        {

            date_created = File.GetCreationTime(path);
           AllSubTitleItems = new List<SubtitleItemCustom>();
            IWorkbook workbook = null;
            ISheet sheet = null;
            using (FileStream fs = File.OpenRead(path))
            {
                // 2007版本  
                if (path.IndexOf(".xlsx") > 0)
                    workbook = new XSSFWorkbook(fs);
                // 2003版本  
                else if (path.IndexOf(".xls") > 0)
                    workbook = new HSSFWorkbook(fs);

                if (workbook != null)
                {
                    sheet = workbook.GetSheetAt(0);

                    int rowCount = sheet.Count();//总行数  
                    if (rowCount > 0)
                    {
                        
                       
                        for (int i = 0; i < rowCount; i++)
                        {
                            IRow row = sheet.GetRow(i);
                            if (row == null) continue;
                            int cellCount = row.LastCellNum;//列数  

                            if (isIncludedTimeCode)
                            {
                                if (row != null && cellCount >= 3)
                                {
                                    SubtitleItemCustom subtitleItemCustom = new SubtitleItemCustom();
                                    if (row.GetCell(0) != null)
                                    {
                                        subtitleItemCustom.Lines.Add(row.GetCell(0).ToString());
                                    }
                                    if (row.GetCell(1) != null)
                                    {
                                        subtitleItemCustom.Lines.Add(row.GetCell(1).ToString());
                                    }
                                    if (row.GetCell(2) != null)
                                    {
                                        subtitleItemCustom.StartEndString = row.GetCell(2).ToString();
                                    }
                                    AllSubTitleItems.Add(subtitleItemCustom);

                                    for (int j = 3; j < cellCount; j++)
                                    {
                                        if (row.GetCell(j) != null)
                                        {
                                            subtitleItemCustom = new SubtitleItemCustom();
                                            subtitleItemCustom.StartEndString = row.GetCell(j).ToString();
                                            AllSubTitleItems.Add(subtitleItemCustom);
                                        }
                                    }
                                }
                                else
                                {
                                    this.status = "Format Error";
                                    lines=0;
                                    return;
                                }
                            }
                            else
                            {
                                if (row != null && cellCount >= 2)
                                {

                                    SubtitleItemCustom subtitleItemCustom = new SubtitleItemCustom();
                                    if (row.GetCell(0) != null)
                                    {
                                        AllItems.Add(row.GetCell(0).ToString());
                                    }
                                    if (row.GetCell(1) != null)
                                    {
                                        AllItems.Add(row.GetCell(1).ToString());
                                    }
                                }
                                else
                                {
                                    this.status = "Format Error";
                                    lines=0;
                                    return;
                                }
                            }
                           
                        }
                        
                    }

                }


            }


            lines = AllSubTitleItems.Count + AllItems.Count;



        }

    }

}
