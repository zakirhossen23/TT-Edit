using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TT_Edit.Classes
{
    // Class for Function 1 Reverse - Paragraph to Bilingual VTT
    // Receives a combined file containing:
    // 1. English paragraph with markers
    // 2. Translation paragraph with markers
    // 3. WEBVTT template with markers replacing text
    // Reconstructs the original bilingual WEBVTT file.
    public class VttParagraphToBilingual
    {
        /* ************** Variables ****************/
        public string path;
        public string name;
        public DateTime date_created;
        public string status = "Pending";

        public List<string> ReconstructedLines = new List<string>();

        // Constructor with required fields
        public VttParagraphToBilingual(string _path, string _name)
        {
            this.path = _path;
            this.name = _name;
            parseCombinedFile();
        }

        /********************** Functions ******************/

        // Function to parse the combined file and reconstruct the VTT
        public void parseCombinedFile()
        {
            date_created = File.GetCreationTime(path);
            try
            {
                var allLines = File.ReadAllLines(path, Encoding.UTF8).ToList();
                
                // 1. Split the combined file into English, Translation, and Template
                int firstBlank = allLines.FindIndex(l => string.IsNullOrWhiteSpace(l));
                if (firstBlank == -1) throw new Exception("Invalid combined file format: Missing first separator");

                var englishLines = allLines.Take(firstBlank).ToList();
                var remainingLines = allLines.Skip(firstBlank + 1).ToList();

                int secondBlank = remainingLines.FindIndex(l => string.IsNullOrWhiteSpace(l));
                if (secondBlank == -1) throw new Exception("Invalid combined file format: Missing second separator");

                var translationLines = remainingLines.Take(secondBlank).ToList();
                var templateLines = remainingLines.Skip(secondBlank + 1).ToList();

                string englishText = string.Join(" ", englishLines);
                string translationText = string.Join(" ", translationLines);

                // 2. Parse paragraphs into maps: <marker> -> text
                var englishMap = ParseParagraph(englishText);
                var translationMap = ParseParagraph(translationText);

                // 3. Reconstruct the VTT template
                ReconstructedLines.Clear();
                
                HashSet<int> markersInCurrentCue = new HashSet<int>();
                bool cueHadContent = false;

                foreach (var line in templateLines)
                {
                    string trimmed = line.Trim();
                    if (IsTimestampLine(trimmed))
                    {
                        // Handle spacing before the next cue
                        if (ReconstructedLines.Count > 0)
                        {
                            if (cueHadContent)
                            {
                                // Cue had text: add one separator blank line
                                if (!string.IsNullOrWhiteSpace(ReconstructedLines.Last()))
                                {
                                    ReconstructedLines.Add("");
                                }
                            }
                            else
                            {
                                // Cue was empty: add two blank lines (content + separator)
                                ReconstructedLines.Add("");
                                ReconstructedLines.Add("");
                            }
                        }

                        markersInCurrentCue.Clear();
                        cueHadContent = false;
                        ReconstructedLines.Add(line);
                    }
                    else if (Regex.IsMatch(trimmed, @"^<(\d+)>$"))
                    {
                        int marker = int.Parse(Regex.Match(trimmed, @"^<(\d+)>$").Groups[1].Value);
                        
                        if (!markersInCurrentCue.Contains(marker))
                        {
                            // First occurrence -> English
                            string text = englishMap.ContainsKey(marker) ? englishMap[marker] : $"<{marker}>";
                            ReconstructedLines.Add(text);
                            markersInCurrentCue.Add(marker);
                            if (!string.IsNullOrWhiteSpace(text)) cueHadContent = true;
                        }
                        else
                        {
                            // Second occurrence -> Translation
                            string text = translationMap.ContainsKey(marker) ? translationMap[marker] : $"<{marker}>";
                            if (ReconstructedLines.Count > 0 && !string.IsNullOrWhiteSpace(ReconstructedLines.Last()))
                            {
                                ReconstructedLines.Add("");
                            }
                            ReconstructedLines.Add(text);
                            if (!string.IsNullOrWhiteSpace(text)) cueHadContent = true;
                        }
                    }
                    else
                    {
                        // Keep other lines, but collapse consecutive empty lines
                        if (string.IsNullOrWhiteSpace(line) && ReconstructedLines.Count > 0 && string.IsNullOrWhiteSpace(ReconstructedLines.Last()))
                        {
                        }
                        else
                        {

                            if (cueHadContent)
                            {
                                // Cue had text: add one separator blank line
                                if (!string.IsNullOrWhiteSpace(ReconstructedLines.Last()))
                                {
                                    ReconstructedLines.Add("");
                                }
                            }
                            ReconstructedLines.Add(line);
                            if (!string.IsNullOrWhiteSpace(line)) cueHadContent = true;
                        }
                    }
                }

                // Handle the very last cue
                if (ReconstructedLines.Count > 0)
                {
                    if (cueHadContent)
                    {
                        if (!string.IsNullOrWhiteSpace(ReconstructedLines.Last()))
                        {
                            ReconstructedLines.Add("");
                        }
                    }
                    else
                    {
                        ReconstructedLines.Add("");
                        ReconstructedLines.Add("");
                    }
                }

            }
            catch (Exception)
            {
                status = "Format Error";
            }
        }

        private Dictionary<int, string> ParseParagraph(string text)
        {
            var map = new Dictionary<int, string>();
            // Regex to find <n> followed by text until the next <m> or end of string
            var matches = Regex.Matches(text, @"<(\d+)>\s*([^<]+)");
            foreach (Match match in matches)
            {
                int marker = int.Parse(match.Groups[1].Value);
                string content = match.Groups[2].Value.Trim();
                map[marker] = content;
            }
            return map;
        }

        private bool IsTimestampLine(string line)
        {
            if (string.IsNullOrEmpty(line)) return false;
            return Regex.IsMatch(line, @"^\d{2}:\d{2}:\d{2}\.\d{3}\s*-->\s*\d{2}:\d{2}:\d{2}\.\d{3}$");
        }

        public string export_path()
        {
            // This will be set by the Control
            return ""; 
        }

        public void export(string exportFolderPath)
        {
            string fileName = Path.GetFileNameWithoutExtension(name) + "_Reconstructed.vtt";
            string fullPath = Path.Combine(exportFolderPath, fileName);
            File.WriteAllLines(fullPath, ReconstructedLines, Encoding.UTF8);
        }
    }
}
