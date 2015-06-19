using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AssStyleCopier
{
	public class FileModel
	{
		public string File { get; set; }
		public string FileName { get; set; }
		public string Dir { get; set; }

		public bool IsDuplicateFileName { get; set; }

		public FileModel(string file, bool isDuplicateFileName = false)
		{
			File = file;
			FileName = Path.GetFileName(file);
			Dir = Path.GetDirectoryName(file);

			IsDuplicateFileName = isDuplicateFileName;
		}

		public override string ToString()
		{
			if(IsDuplicateFileName)
				return String.Format("{0} ({1})", FileName, Dir);

			return FileName;
		}
	}

	public class AssStyleCopier
	{
		private static List<FileModel> _files;
		private FileModel _templateFile;

		public AssStyleCopier()
		{
			_files = new List<FileModel>();
		}

		public void SetTemplateFile(string templateFile)
		{
			_templateFile = new FileModel(templateFile);
		}

		public void AddFiles(string[] fileDirs)
		{
			foreach (var fileDir in fileDirs)
			{
				var file = _files.Find(x => x.Dir == fileDir);

				if (file == null)
				{
					file = _files.Find(x => x.FileName == Path.GetFileName(fileDir));

					if (file != null)
					{
						file.IsDuplicateFileName = true;
						_files.Add(new FileModel(fileDir, true));
					}
					else
						_files.Add(new FileModel(fileDir));
				}
				else
					MessageBox.Show(
						String.Format("Файл \n{0} \nуже добавлен!", fileDir));
			}
		}

		public void DeleteFiles(FileModel[] filesToDelete)
		{
			foreach (var file in filesToDelete)
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
			return _templateFile.FileName;
		}

		public FileModel[] GetFiles()
		{
			return _files.ToArray();
		}
	}
}