using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TT_Edit.Classes
{
    public class SubtitleItemCommas
    {
      public string StartEndString
        {
            get;
            set;
        }
        public List<string> Lines
        {
            get;
            set;
        }

        public SubtitleItemCommas()
        {
            Lines = new List<string>();
        }

        public override string ToString()
        {
            return string.Format( format: "{0}: {1}", arg0: StartEndString, arg1: string.Join(Environment.NewLine, Lines));
        }
    }

    // Class to Parse VTT
    public class VttParserComma
    {
        // Delimiters can be used inbetween timecodes
        private readonly string[] _delimiters = new string[3]
      {
            "-->",
            "- >",
            "->"
      };

        // Regex to match VTT timecode lines like: 00:00:33.030 --> 00:00:38.530
        private readonly Regex _timecodeRegex = new Regex(@"^\s*(\d{2}:\d{2}:\d{2}\.\d{3})\s*-+\s*>\s*(\d{2}:\d{2}:\d{2}\.\d{3})\s*$", RegexOptions.Compiled);

        // Function to parse VTT file
        public List<SubtitleItemCommas> ParseStream(Stream vttStream, Encoding encoding)
        {
            if (!vttStream.CanRead || !vttStream.CanSeek)
            {
                throw new ArgumentException($"Stream must be seekable and readable in a subtitles parser. Operation interrupted; isSeekable: {vttStream.CanSeek} - isReadable: {vttStream.CanSeek}");
            }

            vttStream.Position = 0L;
            StreamReader reader = new StreamReader(vttStream, encoding, detectEncodingFromByteOrderMarks: true);
            List<SubtitleItemCommas> list = new List<SubtitleItemCommas>();


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
                    SubtitleItemCommas subtitleItem = new SubtitleItemCommas();
                    foreach (string item2 in list3)
                    {
                        // Checking if subtitleItem starttime and endtime is 0 or not
                        if (subtitleItem.StartEndString == null || subtitleItem.StartEndString == "")
                        {
                            // Use regex to detect timecode lines instead of splitting by delimiters
                            if (_timecodeRegex.IsMatch(item2))
                            {
                                subtitleItem.StartEndString = item2;
                            }
                        }
                        else
                        {
                            // Else it will add line to that to subtitle
                            subtitleItem.Lines.Add(item2);
                        }
                    }

                    // Adding this subtitleItem 
                    if ((subtitleItem.StartEndString != "" && subtitleItem.StartEndString != null) )
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


    }
}
