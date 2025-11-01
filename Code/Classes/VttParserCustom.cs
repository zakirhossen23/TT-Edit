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
    public class VttParserCustom
    {
        // Delimiters can be used inbetween timecodes
        private readonly string[] _delimiters = new string[3]
      {
            "-->",
            "- >",
            "->"
      };

        // Regex to match VTT timecode lines like: 00:00:33.030 --> 00:00:38.530
        private readonly Regex _timecodeRegex = new Regex(@"^\s*(\d{2}:\d{2}:\d{2}\.\d{3})\s*-->\s*(\d{2}:\d{2}:\d{2}\.\d{3})\s*$", RegexOptions.Compiled);

        // Function to parse VTT file
        public List<SubtitleItemCustom> ParseStream(Stream vttStream, Encoding encoding, List<String> _lineLists=null )
        {
            if ((!vttStream.CanRead || !vttStream.CanSeek) && _lineLists == null)
            {
                throw new ArgumentException($"Stream must be seekable and readable in a subtitles parser. Operation interrupted; isSeekable: {vttStream.CanSeek} - isReadable: {vttStream.CanSeek}");
            }
            List<string> list2;
            if (_lineLists == null)
            {

                vttStream.Position = 0L;
                StreamReader reader = new StreamReader(vttStream, encoding, detectEncodingFromByteOrderMarks: true);
             

                // Getting all the string lines form the Vtt files
                list2 = GetVttSubTitleParts(reader).ToList();
            }
            else
            {
                list2 = _lineLists;
            }
            List<SubtitleItemCustom> list = new List<SubtitleItemCustom>();


            if (list2.Any())
            {

                // Iterating Trimmed list
                SubtitleItemCustom subtitleItem = new SubtitleItemCustom();
                StringBuilder stringBuilder = new StringBuilder();
                int newLineCount = 0;
                // Iterating all the lines
                foreach (string item in list2)
                {
                    string item2 = item;
                    if (item != null)
                        item2 = item.Trim();
                    if (subtitleItem.StartEndString != null && subtitleItem.StartEndString.ToString() != "")
                    {

                        if (item2 != null && item2 != "" && !item2.StartsWith("\u200B") && item2.Length != 2)
                        {
                            if (newLineCount == 0)
                            {
                                stringBuilder.AppendLine(item2);
                                newLineCount = 0;
                            }
                            else if (newLineCount > 0 && stringBuilder.Length >0)
                            {
                                if (stringBuilder.ToString().TrimEnd() != "")
                                    subtitleItem.Lines.Add(stringBuilder.ToString().TrimEnd());
                                stringBuilder = new StringBuilder();
                                newLineCount = 0;
                                stringBuilder.AppendLine(item2);
                            }
                            else if (newLineCount == 1 && stringBuilder.Length ==0)
                            {
                                throw new FormatException("Format Error.");
                            }


                        }
                        else
                        {
                            // Else it will add line to that to subtitle
                            newLineCount++;
                        }
                    }

                    // Use regex to detect timecode lines instead of splitting by delimiters
                    var m = _timecodeRegex.Match(item2 ?? string.Empty);
                    if (m.Success)
                    {
                        // Adding this subtitleItem 
                        if ((subtitleItem.StartEndString != null && subtitleItem.StartEndString.ToString() != ""))
                        {

                            list.Add(subtitleItem);
                        }
                        newLineCount = 0;
                        subtitleItem = new SubtitleItemCustom();
                        stringBuilder = new StringBuilder();
                        subtitleItem.StartEndString = item2;
                    }


                }
                // Adding this subtitleItem 
                if ((subtitleItem.StartEndString != ""))
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


    }
}
