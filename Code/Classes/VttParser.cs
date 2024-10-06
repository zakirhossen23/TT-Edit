
using SubtitlesParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TT_Edit.Classes
{
    // Class to Parse VTT
    public class VttParser
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
                // Iterating all the lines
                foreach (string item in list2)
                {
                  
                    // Removing newline and other things
                    List<string> list3 = (from s in item.Split(new string[1]
                        {
                            Environment.NewLine
                        }, StringSplitOptions.None)
                                          select s.Trim() into l
                                          where !string.IsNullOrEmpty(l)
                                          select l).ToList();

                    // Iterating Trimmed list
                    SubtitleItem subtitleItem = new SubtitleItem();
                    foreach (string item2 in list3)
                    {
                        // Checking if subtitleItem starttime and endtime is 0 or not
                        if (subtitleItem.StartTime == 0 && subtitleItem.EndTime == 0)
                        {
                            // Then it will parse
                            if (TryParseTimecodeLine(item2, out int startTc, out int endTc))
                            {
                                
                                subtitleItem.StartTime = startTc;
                                subtitleItem.EndTime = endTc;
                            }
                        }
                        else
                        {
                            // Else it will add line to that to subtitle
                            subtitleItem.Lines.Add(item2);
                        }
                    }

                    // Adding this subtitleItem 
                    if ((subtitleItem.StartTime != 0 || subtitleItem.EndTime != 0) )
                    {
                        list.Add(subtitleItem);
                    }
                }

                // Returning the list of Subtitle Items

                if (list.Any())
                {
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
                if (text == null)
                {
                    break;
                }

                if (string.IsNullOrEmpty(line.Trim()))
                {
                    string text2 = stringBuilder.ToString().TrimEnd();
                    if (!string.IsNullOrEmpty(text2))
                    {
                        yield return text2;
                    }

                    stringBuilder = new StringBuilder();
                }
                else
                {
                    stringBuilder.AppendLine(line);
                }
            }

            if (stringBuilder.Length > 0)
            {
                yield return stringBuilder.ToString();
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
