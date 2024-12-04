
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
  
    // Class to Parse VTT
    public class VttParserDivider
    {
        // Delimiters can be used inbetween timecodes
        private readonly string[] _delimiters = new string[3]
      {
            "-->",
            "- >",
            "->"
      };

        // Function to parse VTT file
        public List<SubtitleItem> ParseStream(Stream vttStream, Encoding encoding)
        {
            if (!vttStream.CanRead || !vttStream.CanSeek)
            {
                throw new ArgumentException($"Stream must be seekable and readable in a subtitles parser. Operation interrupted; isSeekable: {vttStream.CanSeek} - isReadable: {vttStream.CanSeek}");
            }

            vttStream.Position = 0L;
            StreamReader reader = new StreamReader(vttStream, encoding, detectEncodingFromByteOrderMarks: true);
            List<SubtitleItem> list = new List<SubtitleItem>();


            // Getting all the string lines form the Vtt files
            List<string> list2 = GetVttSubTitleParts(reader).ToList();
            if (list2.Any())
            {

                // Iterating Trimmed list
                SubtitleItem subtitleItem = new SubtitleItem();
                StringBuilder stringBuilder = new StringBuilder();
                int newLineCount = 0;
                // Iterating all the lines
                foreach (string item in list2)
                {
                    string item2 = item;
                    if (item != null)
                        item2 = item.Trim();
                    if (subtitleItem.ToString() != null && subtitleItem.ToString() != "")
                    // Checking if subtitleItem starttime and endtime is 0 or not
                    {
                       
                        if (item2 != null && item2 != "" )
                        {
                            if (newLineCount == 0)
                            {
                                
                                if (stringBuilder.ToString().TrimEnd() != "")
                                {
                                    stringBuilder.AppendLine(item2);
                                    newLineCount = 0;
                                }
                                else
                                {
                                    stringBuilder.AppendLine(item2);
                                    newLineCount = 0;
                                }
                            }
                            else if (newLineCount > 0)
                            {
                                if (stringBuilder.ToString().TrimEnd() != "")
                                    subtitleItem.Lines.Add(stringBuilder.ToString().TrimEnd());
                                stringBuilder = new StringBuilder();
                                newLineCount = 0;
                                stringBuilder.AppendLine(item2);
                            }
                            else
                            {
                                stringBuilder.AppendLine(item2);
                            }
                            

                        }
                        else
                        {
                            // Else it will add line to that to subtitle
                            newLineCount++;
                        }
                    }
                    string[] array = item2.Split(_delimiters, StringSplitOptions.None);
                    if (array.Length == 2)
                    {
                        // Adding this subtitleItem 
                        if ((subtitleItem.StartTime != 0 || subtitleItem.EndTime != 0))
                        {

                            list.Add(subtitleItem);
                        }
                        newLineCount = 0;
                        subtitleItem = new SubtitleItem();
                        stringBuilder = new StringBuilder();
                        // Then it will parse
                        if (TryParseTimecodeLine(item2, out int startTc, out int endTc))
                        {

                            subtitleItem.StartTime = startTc;
                            subtitleItem.EndTime = endTc;
                        }
                    }else if (item2 != "")
                    { 
                        if (item2.Length > 45 && TimeframeDividerControl.TransOnly)
                        {
                            throw new ArgumentException("Error VTT format");

                        }
                    }

                }
                // Adding this subtitleItem 
                if ((subtitleItem.StartTime != 0 || subtitleItem.EndTime != 0))
                {
                    if (newLineCount == 0)
                    {
                        if (stringBuilder.ToString().TrimEnd() != "")
                            subtitleItem.Lines.Add(stringBuilder.ToString().TrimEnd());
                        
                    }
                    else if (newLineCount > 0)
                    {
                        if (stringBuilder.ToString().TrimEnd() != "")
                            subtitleItem.Lines.Add(stringBuilder.ToString().TrimEnd());

                    }
                    list.Add(subtitleItem);
                }

                // Returning the list of Subtitle Items

                if (list.Any())
                {
                    //list.RemoveAt(0);
                    return list;
                }

                throw new ArgumentException("Stream is not in a valid VTT format");
            }

            throw new FormatException("Parsing as VTT returned no VTT part.");
        }

        // Function to return all the lines of text contain except newline and spaces in list of string
        private IEnumerable<string> GetVttSubTitleParts(TextReader reader)
        {
            StringBuilder stringBuilder = new StringBuilder();
            while (true)
            {
                string text;
                string line = text = reader.ReadLine();
                if (line == null) 
                    break;
                //stringBuilder.AppendLine(line);
                yield return line;
            }
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
