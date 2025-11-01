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
    public class VttCatConversion
    {
        /* ************** Variables ****************/
        public string path;
        public string name;
        public int lines;
        public DateTime date_created;
        public string status = "Pending";
        public List<SubtitleItemCustom> AllSubTitleItems;
        public List<string> AllItems = new List<string>();
        public List<string> AllItemsTranslated = new List<string>();
        public bool isIncludedTimeCode = true;
        // Constructor with required fields
        public VttCatConversion(string _path, string _name, bool _isIncludedTimeCode = true)
        {
            this.path = _path;
            this.name = _name;
            this.isIncludedTimeCode= _isIncludedTimeCode;
            parseDocxFile();
            format_error_check();

        }

        public void format_error_check()
        {
            if (status == "Format Error")
            {
                return;
            }
            if (isIncludedTimeCode == false)
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
            else
            {
                if (AllSubTitleItems[0].Lines.Count == 0)
                {
                    status = "Format Error";
                }
            }
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
            int max_col = 1;
            if (isIncludedTimeCode)
            {
                int rowIdx = -1;
                IRow lastRow = null;
                int lastCol = 2;
                for (int i = 0; i< subtitleItems.Count; i++)
                {
                    if (subtitleItems[i].Lines.Count == 2)
                    {
                        rowIdx++;
                        lastCol =2;
                        IRow row = Sheet.CreateRow(rowIdx);
                        lastRow=row;
                        XlsxHelper.CreateCell(row, 0, subtitleItems[i].Lines[0], borderedCellStyle);
                        XlsxHelper.CreateCell(row, 1, subtitleItems[i].Lines[1], borderedCellStyle);
                        XlsxHelper.CreateCell(row, 2, subtitleItems[i].StartEndString, borderedCellStyle);

                        lastCol++;
                    }
                    else if (subtitleItems[i].Lines.Count == 0)
                    {
                        XlsxHelper.CreateCell(lastRow, lastCol, subtitleItems[i].StartEndString, borderedCellStyle);
                        lastCol++;
                    }
                    max_col = Math.Max(max_col, lastCol);
                }

            }
            else
            {
                int rowIdx = 0;
                for (int i = 0; i < AllItems.Count; i++)
                {
                    IRow row = Sheet.CreateRow(rowIdx);
                    XlsxHelper.CreateCell(row, 0, AllItems[i], borderedCellStyle);
                    XlsxHelper.CreateCell(row, 1, AllItemsTranslated[i], borderedCellStyle);
                    rowIdx++;
                }
                max_col = 2;

            }

            for (int i = 0; i < max_col; i++)
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



            // Reading file
            var newParser = new Classes.VttParserCustom();
            using (var fileStream = File.OpenRead(path))
            {

                if (isIncludedTimeCode == false)
                {
                    // Reading file
                    using (var vttStream = File.OpenRead(path))
                    {
                        vttStream.Position = 0L;
                        StreamReader reader = new StreamReader(vttStream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true);
                        List<string> list = new List<string>();
                        string line = null;
                        bool tranlsated = false;

                        while ((line = reader.ReadLine()) != null)
                        {
                            list.Add(line);
                        }

                        for (int i = 0; i < list.Count; i++)
                        {
                            line = list[i];
                         
                            if (line.Trim() != "")
                            {
                                if (!tranlsated)
                                {

                                    AllItems.Add(line);
                                    tranlsated = true;
                                }
                                else
                                {
                                    AllItemsTranslated.Add(line);
                                    tranlsated = false;
                                }

                            }

                        }
                    }

                    // Setting All subtitle count
                    lines = AllItems.Count + AllItemsTranslated.Count;
                }
                else
                {
                    try
                    {

                        // Parsing the file and storing into AllSubtitleItemCustoms as List
                        var newParsed = newParser.ParseStream(fileStream, Encoding.UTF8);
                        AllSubTitleItems = newParsed.ToList();

                        // Setting All subtitle count
                        lines = AllSubTitleItems.Count;
                    }
                    catch (Exception ex)
                    {
                        status = "Format Error";
                    }

                }

            }



        }

    }

}
