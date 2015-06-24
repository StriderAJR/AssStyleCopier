using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AssStyleCopier
{
	public class SsaFile
	{
		public string FullPath { get; set; }
		public string FileName { get; set; }
		public string Dir { get; set; }

		public bool IsDuplicateFileName { get; set; }

		public List<SsaStyle> Styles { get; set; }

		public SsaFile(string fullPath, bool isDuplicateFileName = false)
		{
			FullPath = fullPath;
			FileName = Path.GetFileName(fullPath);
			Dir = Path.GetDirectoryName(fullPath);

			IsDuplicateFileName = isDuplicateFileName;
		}

		public override string ToString()
		{
			if (IsDuplicateFileName)
				return String.Format("{0} ({1})", FileName, Dir);

			return FileName;
		}
	}

	public class SsaStyle
	{
		public string StyleName { get; set; }
		public Dictionary<string, string> StyleValues { get; set; }

		public int LineIndex { get; set; }

		public SsaStyle()
		{
			StyleValues = new Dictionary<string, string>();
		}
	}

	public enum StyleCompareResult
	{
		Equal,
		NotEqual,
		TemplateUnique,
		NonTemplateUnique
	}

	public class SsaStylesComparison
	{
		private SsaFile _templateSsaFile;
		private SsaFile _ssaFile;

		public Dictionary<SsaStyle, StyleCompareResult> Comparison { get; set; }

		public bool IsThisFileComparison(SsaFile file)
		{
			return file == _ssaFile;
		}

		public SsaStylesComparison(SsaFile templateFile, SsaFile file)
		{
			_templateSsaFile = templateFile;
			_ssaFile = file;

			Comparison = new Dictionary<SsaStyle, StyleCompareResult>();
			file.Styles.ForEach(x => Comparison.Add(x, StyleCompareResult.NonTemplateUnique));

			var templateStyles = templateFile.Styles;
			var styles = file.Styles;

			foreach (SsaStyle tStyle in templateStyles)
			{
				var style = styles.Find(x => x.StyleName == tStyle.StyleName);
				if (style != null)
				{
					Comparison[style] = StyleCompareResult.Equal;

					foreach (var styleParam in style.StyleValues.Keys)
					{
						if (style.StyleValues[styleParam] != tStyle.StyleValues[styleParam])
						{
							Comparison[style] = StyleCompareResult.NotEqual;
							break;
						}
					}
				}
				else
				{
					Comparison.Add(tStyle, StyleCompareResult.TemplateUnique);
				}
			}
		}
	}

	public class AssStyleCopier
	{
		private static List<SsaFile> _files;
		private SsaFile _templateSsaFile;

		private const string StylesLine = "[V4 Styles]";
		private const string StylesLineNew = "[V4+ Styles]";
		private const string EventLine = "[Events]";
		private const char Separator = ',';

		private const string FormatLabel = "Format:";
		private const string StyleLabel = "Style:";

		public List<SsaStylesComparison> StylesComparisons { get; private set; }

		public AssStyleCopier()
		{
			_files = new List<SsaFile>();
			StylesComparisons = new List<SsaStylesComparison>();
		}

		public void SetTemplateFile(string templateFile)
		{
			_templateSsaFile = new SsaFile(templateFile);
			_templateSsaFile.Styles = ParseStyles(_templateSsaFile.FullPath);

			if (_files.Any())
			{
				StylesComparisons.Clear();
				_files.ForEach(x => StylesComparisons.Add(new SsaStylesComparison(_templateSsaFile, x)));
			}
		}

		public void AddFiles(string[] fileFullPaths)
		{
			foreach (var fullPath in fileFullPaths)
			{
				if(_templateSsaFile != null)
					if (fullPath == _templateSsaFile.FullPath)
					{
						MessageBox.Show(
							String.Format("File \n{0} \nhas already been added as template!", fullPath));

						continue;
					}

				var file = _files.Find(x => x.FullPath == fullPath);

				if (file == null)
				{
					file = _files.Find(x => x.FileName == Path.GetFileName(fullPath));

					if (file != null)
					{
						file.IsDuplicateFileName = true;

						SsaFile temp = new SsaFile(fullPath, true);
						temp.Styles = ParseStyles(temp.FullPath);
						_files.Add(temp);

						if (_templateSsaFile != null)
							StylesComparisons.Add(new SsaStylesComparison(_templateSsaFile, temp));
					}
					else
					{
						SsaFile temp = new SsaFile(fullPath);
						temp.Styles = ParseStyles(temp.FullPath);
						_files.Add(temp);

						if (_templateSsaFile != null)
							StylesComparisons.Add(new SsaStylesComparison(_templateSsaFile, temp));
					}
				}
				else
					MessageBox.Show(
						String.Format("File \n{0} \nhas already been added!", fullPath));
			}
		}

		public void DeleteFiles(SsaFile[] ssaFilesToDelete)
		{
			foreach (var file in ssaFilesToDelete)
			{
				if (file.IsDuplicateFileName)
				{
					var duplicates = _files.FindAll(x => x.FileName == file.FileName).ToList();

					if (duplicates.Count == 2)
					{
						duplicates.ForEach(x => x.IsDuplicateFileName = false);
					}
				}

				_files.Remove(file);
			}
		}

		public string GetTemplateFileName()
		{
			return _templateSsaFile.FileName;
		}

		public string GetTemplateFileFullPath()
		{
			return _templateSsaFile.FullPath;
		}

		public List<SsaStyle> GetTemplateFileStyles()
		{
			return _templateSsaFile.Styles;
		}

		public SsaFile[] GetFiles()
		{
			return _files.ToArray();
		}

		public SsaStylesComparison GetStylesComparison(SsaFile file)
		{
			return StylesComparisons.FirstOrDefault(x => x.IsThisFileComparison(file));
		}

		public List<SsaStyle> ParseStyles(string fullPath)
		{
			if (!File.Exists(fullPath))
			{
				throw new Exception(
					String.Format("File {0} doesn't exist. Can't extract styles.", fullPath));
			}

			FileStream fileStream = new FileStream(fullPath, FileMode.Open);
			var styles = ParseStyles(fileStream, Encoding.Default);
			fileStream.Close();
			return styles;
		}

		public List<SsaStyle> ParseStyles(Stream ssaStream, Encoding encoding)
		{
			// test if stream if readable and seekable (just a check, should be good)
			if (!ssaStream.CanRead || !ssaStream.CanSeek)
			{
				var message = string.Format("Stream must be seekable and readable in a subtitles parser. " +
								   "Operation interrupted; isSeekable: {0} - isReadable: {1}",
								   ssaStream.CanSeek, ssaStream.CanSeek);
				throw new ArgumentException(message);
			}

			// seek the beginning of the stream
			ssaStream.Position = 0;

			var reader = new StreamReader(ssaStream, encoding, true);

			var line = reader.ReadLine();
			var lineNumber = 1;
			// read the line until the [Styles] section
			while (line != null && (line != StylesLine && line != StylesLineNew))
			{
				line = reader.ReadLine();
				lineNumber++;
			}

			if (line == null)
			{
				var message = string.Format("We reached line '{0}' with line number #{1} without finding to " +
											"Styles section ({2})", line, lineNumber, StylesLine);
				throw new ArgumentException(message);
			}

			var styles = new List<SsaStyle>();

			// we are at the styles section
			var formatLine = reader.ReadLine();
			lineNumber++;

			if (string.IsNullOrEmpty(formatLine))
			{
				var message = string.Format("The header line after the line '{0}' was null -> " +
											"no need to continue parsing", line);
				throw new ArgumentException(message);
			}

			if (formatLine.IndexOf(FormatLabel) == -1)
			{
				var message = string.Format("Wrong header line syntax at the line '{0}'", line);
				throw new ArgumentException(message);
			}
			string formatHeaderString = formatLine.Replace(FormatLabel, "");

			string[] formatKeys = formatHeaderString.Split(Separator).Select(x => x.Trim()).ToArray();

			line = reader.ReadLine();
			lineNumber++;
			while (line != null && line != EventLine)
			{
				if (line != "")
				{
					if (line.IndexOf(StyleLabel) == -1)
					{
						var message = string.Format("Wrong style line syntax at the line '{0}'", lineNumber);
						throw new ArgumentException(message);
					}

					string styleLine = line.Replace(StyleLabel, "");

					string[] styleValues = styleLine.Split(Separator).Select(x => x.Trim()).ToArray();

					if (formatKeys.Count() != styleValues.Count())
					{
						var message = string.Format("Style at line '{0}' has less parameters than the format string.", line);
						throw new ArgumentException(message);
					}

					SsaStyle style = new SsaStyle();
					style.LineIndex = lineNumber;
					for (int i = 0; i < formatKeys.Count(); i++)
					{
						if (formatKeys[i] == "Name")
							style.StyleName = styleValues[i];
						else
							style.StyleValues.Add(formatKeys[i], styleValues[i]);
					}
					styles.Add(style);
				}
				line = reader.ReadLine();
				lineNumber++;
			}

			return styles;
		}

		private string GetStyleString(SsaStyle style)
		{
			var line = StyleLabel + " ";
			line += style.StyleName + ",";

			int i = 0;
			foreach (var styleItem in style.StyleValues)
			{
				line += styleItem.Value;
				if (i < style.StyleValues.Count - 1)
					line += ",";
				i++;
			}

			return line;
		}

		public void CopyStyles(bool copyMissingStylesFromTemplate)
		{
			foreach (var file in _files)
			{
				string[] lines = File.ReadAllLines(file.FullPath);

				SsaStylesComparison ssaComparison = StylesComparisons.FirstOrDefault(x => x.IsThisFileComparison(file));

				foreach (var styleComparison in ssaComparison.Comparison)
				{
					if (styleComparison.Value == StyleCompareResult.NotEqual)
					{
						SsaStyle templateStyle = 
							_templateSsaFile.Styles.FirstOrDefault(x => x.StyleName == styleComparison.Key.StyleName);

						if (templateStyle != null)
						{
							lines[styleComparison.Key.LineIndex - 1] = GetStyleString(templateStyle);
						}
					}

					if(copyMissingStylesFromTemplate)
						if (styleComparison.Value == StyleCompareResult.TemplateUnique)
						{
							SsaStyle templateStyle =
								_templateSsaFile.Styles.FirstOrDefault(x => x.StyleName == styleComparison.Key.StyleName);

							if (templateStyle != null)
							{
								List<string> tempLines = lines.ToList();
								int index = tempLines.IndexOf(StylesLine);

								if (index == -1)
									index = tempLines.IndexOf(StylesLineNew);

								if (index == -1)
									throw new ArgumentException("Couldn't find Styles section");

							
								int indexToInsert = index + _templateSsaFile.Styles.Count + 1;
								tempLines.Insert(indexToInsert + 1, GetStyleString(templateStyle));

								lines = tempLines.ToArray();
							}
						}
				}

				File.WriteAllLines(file.FullPath, lines);
			}
		}

		public void ReloadFiles()
		{
			StylesComparisons.Clear();

			foreach (var file in _files)
			{
				file.Styles = ParseStyles(file.FullPath);

				if (_templateSsaFile != null)
					StylesComparisons.Add(new SsaStylesComparison(_templateSsaFile, file));
			}
		}
	}
}