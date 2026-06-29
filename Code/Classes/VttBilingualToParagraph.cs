using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TT_Edit.Forms;

namespace TT_Edit.Classes
{
    // Class for Function 1 - Bilingual VTT to Paragraph
    // Receives a bilingual WEBVTT file and generates a single combined output:
    // 1. English paragraph with markers
    // 2. Translation paragraph with markers
    // 3. WEBVTT template with markers replacing text
    // All combined into one file.
    public class VttBilingualToParagraph
    {
        /* ************** Variables ****************/
        public string path;
        public string name;
        public int lines; // Number of bilingual cues (markers assigned)
        public DateTime date_created;
        public string status = "Pending";

        // Output data
        public string EnglishParagraph { get; private set; }
        public string TranslationParagraph { get; private set; }
        public List<string> VttTemplateLines { get; private set; }

        // Constructor with required fields
        public VttBilingualToParagraph(string _path, string _name)
        {
            this.path = _path;
            this.name = _name;
            VttTemplateLines = new List<string>();
            parseVttFile();
            format_error_check();
        }

        /********************** Functions ******************/
        public void format_error_check()
        {
            if (lines == 0 && string.IsNullOrEmpty(EnglishParagraph))
            {
                status = "Format Error";
            }
        }

        // Function to get export path (base path, without extension)
        public string export_path()
        {
            return BilingualExtractControl.vTTExportfolderPath + "\\" + name;
        }

        // Function to export all outputs into a single file
        public void export()
        {
            string basePath = export_path();
            string directory = Path.GetDirectoryName(basePath);
            string nameWithoutExt = Path.GetFileNameWithoutExtension(name);

            // Combine English paragraph, Translation paragraph, and VTT template into one file
            var combinedContent = new List<string>();

            // Add English paragraph
            if (!string.IsNullOrEmpty(EnglishParagraph))
            {
                combinedContent.Add(EnglishParagraph);
            }

            // Add blank line separator
            combinedContent.Add("");

            // Add Translation paragraph
            if (!string.IsNullOrEmpty(TranslationParagraph))
            {
                combinedContent.Add(TranslationParagraph);
            }

            // Add blank line separator
            combinedContent.Add("");

            // Add WEBVTT template lines (skip any leading WEBVTT header from VttTemplateLines if already present)
            bool webvttHeaderAdded = false;
            foreach (var line in VttTemplateLines)
            {
                if (!webvttHeaderAdded && line.Trim().Equals("WEBVTT", StringComparison.OrdinalIgnoreCase))
                {
                    webvttHeaderAdded = true;
                }
                combinedContent.Add(line);
            }

            // Write single combined file
            File.WriteAllLines(
                Path.Combine(directory, nameWithoutExt + "_Combined.txt"),
                combinedContent,
                Encoding.UTF8
            );
        }

        // Function to check if a line is a VTT timestamp
        private bool IsTimestampLine(string line)
        {
            if (string.IsNullOrEmpty(line)) return false;
            // Match patterns like: 00:00:00.000 --> 00:00:03.770
            return Regex.IsMatch(line, @"^\d{2}:\d{2}:\d{2}\.\d{3}\s*-->\s*\d{2}:\d{2}:\d{2}\.\d{3}$");
        }

        // Function to parse VTT File and produce the three outputs
        public void parseVttFile()
        {
            date_created = File.GetCreationTime(path);
            try
            {
                // Read all lines from the file
                var allLines = File.ReadAllLines(path, Encoding.UTF8).ToList();
                // Start with a full copy for the template
                var templateLines = new List<string>(allLines);

                var englishPara = new StringBuilder();
                var translationPara = new StringBuilder();

                int marker = 0;

                // Find all timestamp line indices to identify cues
                var timestampIndices = new List<int>();
                for (int i = 0; i < allLines.Count; i++)
                {
                    if (IsTimestampLine(allLines[i].Trim()))
                    {
                        timestampIndices.Add(i);
                    }
                }

                // Process each cue (timestamp + its content until next timestamp)
                for (int t = 0; t < timestampIndices.Count; t++)
                {
                    int tsIndex = timestampIndices[t];
                    int nextTsIndex = (t + 1 < timestampIndices.Count) ? timestampIndices[t + 1] : allLines.Count;

                    // Collect non-empty text lines in this cue (excluding @ markers)
                    var textLinesWithIndices = new List<(int index, string text)>();
                    bool isAtCue = false;

                    for (int i = tsIndex + 1; i < nextTsIndex; i++)
                    {
                        string trimmed = allLines[i].Trim();
                        if (!string.IsNullOrEmpty(trimmed))
                        {
                            if (trimmed == "@")
                            {
                                // @ marker cue - treat specially
                                isAtCue = true;
                                break;
                            }
                            textLinesWithIndices.Add((i, trimmed));
                        }
                    }

                    if (isAtCue)
                    {
                        // @ cue: keep as-is in template, no marker assigned
                        continue;
                    }

                    if (textLinesWithIndices.Count >= 2)
                    {
                        // Bilingual cue: first non-empty = English, second = Translation
                        marker++;
                        string englishText = textLinesWithIndices[0].text;
                        string translationText = textLinesWithIndices[1].text;

                        englishPara.Append($"<{marker}> {englishText} ");
                        translationPara.Append($"<{marker}> {translationText} ");

                        // Replace the English and Translation lines in the template with markers
                        templateLines[textLinesWithIndices[0].index] = $"<{marker}>";
                        templateLines[textLinesWithIndices[1].index] = $"<{marker}>";
                    }
                    // else: empty cue or single non-bilingual line - no marker, template stays as-is
                }

                // Store results
                lines = marker;
                EnglishParagraph = englishPara.ToString().Trim();
                TranslationParagraph = translationPara.ToString().Trim();
                // Remove blank/empty lines from the template (keep only non-empty lines)
                VttTemplateLines = templateLines.Where(line => !string.IsNullOrWhiteSpace(line)).ToList();

                if (lines == 0 && string.IsNullOrEmpty(EnglishParagraph))
                {
                    status = "Format Error";
                }
            }
            catch (Exception)
            {
                status = "Format Error";
            }
        }
    }
}
