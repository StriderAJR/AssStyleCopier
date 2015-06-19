using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AssStyleCopier
{
	public partial class MainForm : Form
	{
		private AssStyleCopier _assStyleCopier;

		public MainForm()
		{
			InitializeComponent();
			_assStyleCopier = new AssStyleCopier();
		}

		private void SetOneFileOpenDialogSettings()
		{
			dlgOpenFile.Multiselect = false;
		}

		private void SetMultiFileOpenDialogSettings()
		{
			dlgOpenFile.Multiselect = true;
		}

		private void UpdateFileListBox()
		{
			lbFileList.Items.Clear();
			lbFileList.Items.AddRange(_assStyleCopier.GetFiles());
		}

		private void btnAddFile_Click(object sender, EventArgs e)
		{
			SetMultiFileOpenDialogSettings();

			if (dlgOpenFile.ShowDialog() == DialogResult.OK)
			{
				_assStyleCopier.AddFiles(dlgOpenFile.FileNames);
				UpdateFileListBox();
			}
		}

		private void btnSelectTemplateFile_Click(object sender, EventArgs e)
		{
			SetOneFileOpenDialogSettings();

			if (dlgOpenFile.ShowDialog() == DialogResult.OK)
			{
				_assStyleCopier.SetTemplateFile(dlgOpenFile.FileName);
				tbTemplateFile.Text = _assStyleCopier.GetTemplateFileName();
			}
		}

		private void btnDeleteFile_Click(object sender, EventArgs e)
		{
			var filesToDelete = lbFileList.SelectedItems;
			var filesToDeleteArray = new FileModel[filesToDelete.Count];
			filesToDelete.CopyTo(filesToDeleteArray, 0);
			_assStyleCopier.DeleteFiles(filesToDeleteArray);

			UpdateFileListBox();
		}
	}
}
