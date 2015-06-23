using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
			var filesToDeleteArray = new SsaFile[filesToDelete.Count];
			filesToDelete.CopyTo(filesToDeleteArray, 0);
			_assStyleCopier.DeleteFiles(filesToDeleteArray);

			UpdateFileListBox();
		}

		private void DisplayStyle(SsaStyle style)
		{
			rtbStyleComparison.Clear();

			foreach (var styleItem in style.StyleValues)
			{
				string myString = String.Format("{0,-20} {1} {2}", styleItem.Key, styleItem.Value, Environment.NewLine);
				rtbStyleComparison.AppendText(myString);
			}
		}

		private void DisplayStyleComparison(SsaStyle templateStyle, SsaStyle style, StyleCompareResult compareResult)
		{
			rtbStyleComparison.Clear();

			if (compareResult == StyleCompareResult.Equal ||
			    compareResult == StyleCompareResult.TemplateUnique ||
			    compareResult == StyleCompareResult.NonTemplateUnique)
				DisplayStyle(templateStyle);
			else
			{
				int i = 0;
				foreach (var key in style.StyleValues.Keys)
				{
					string myString;
					if (templateStyle.StyleValues[key] == style.StyleValues[key])
					{
						myString = String.Format("{0,-20} {1} {2}", key, templateStyle.StyleValues[key], Environment.NewLine);

						rtbStyleComparison.SelectionColor = Color.Black;
					}
					else
					{
						myString = String.Format("{0,-20} {1} ({2}) {3}",
							key, templateStyle.StyleValues[key], style.StyleValues[key], Environment.NewLine);

						rtbStyleComparison.SelectionColor = Color.Red;
					}


					int length = rtbStyleComparison.TextLength;
					rtbStyleComparison.AppendText(myString);
					rtbStyleComparison.SelectionStart = length;
					rtbStyleComparison.SelectionLength = myString.Length;

					i++;
				}
			}
		}
		
		private void DisplayStyles(SsaStylesComparison stylesComparison)
		{
			lvStyles.Items.Clear();

			const string templateUniqueStyleToolTip = "Unique template style";
			const string nonTemplateUniqueStyleToolTip = "Unique ass style";
			const string notEqualStyleToolTip = "Style differs from the template one";
			const string equalStyleToolTip = "Style is identical to template style";

			foreach (var styleComparison in stylesComparison.Comparison)
			{
				if (styleComparison.Value == StyleCompareResult.TemplateUnique)
				{
					lvStyles.Items.Add(styleComparison.Key.StyleName);
					lvStyles.Items[lvStyles.Items.Count - 1].ImageIndex = 2;
					lvStyles.Items[lvStyles.Items.Count - 1].ToolTipText = templateUniqueStyleToolTip;
				}

				if (styleComparison.Value == StyleCompareResult.NonTemplateUnique)
				{
					lvStyles.Items.Add(styleComparison.Key.StyleName);
					lvStyles.Items[lvStyles.Items.Count - 1].ImageIndex = 3;
					lvStyles.Items[lvStyles.Items.Count - 1].ToolTipText = nonTemplateUniqueStyleToolTip;
				}

				if (styleComparison.Value == StyleCompareResult.NotEqual)
				{
					lvStyles.Items.Add(styleComparison.Key.StyleName);
					lvStyles.Items[lvStyles.Items.Count - 1].ImageIndex = 1;
					lvStyles.Items[lvStyles.Items.Count - 1].ToolTipText = notEqualStyleToolTip;
				}

				if (styleComparison.Value == StyleCompareResult.Equal)
				{
					lvStyles.Items.Add(styleComparison.Key.StyleName);
					lvStyles.Items[lvStyles.Items.Count - 1].ImageIndex = 0;
					lvStyles.Items[lvStyles.Items.Count - 1].ToolTipText = equalStyleToolTip;
				}
			}
		}

		private void lbFileList_SelectedValueChanged(object sender, EventArgs e)
		{
			var selectedFile = (SsaFile) lbFileList.Items[lbFileList.SelectedIndex];
			var stylesComparison =_assStyleCopier.GetStylesComparison(selectedFile);

			if(stylesComparison != null)
				DisplayStyles(stylesComparison);
			else
				MessageBox.Show("There no style comparisons for this file.", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void lvStyles_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selectedFile = (SsaFile)lbFileList.Items[lbFileList.SelectedIndex];
			var stylesComparison = _assStyleCopier.GetStylesComparison(selectedFile);

			if (lvStyles.SelectedItems.Count != 0)
			{
				var selectedStyleName = lvStyles.SelectedItems[0].Text;

				var styleComparison = stylesComparison.Comparison.FirstOrDefault(x => x.Key.StyleName == selectedStyleName);
				SsaStyle style = styleComparison.Key;
				StyleCompareResult compareResult = styleComparison.Value;

				SsaStyle templateStyle = _assStyleCopier.GetTemplateFileStyles()
					.FirstOrDefault(x => x.StyleName == selectedStyleName);

				DisplayStyleComparison(templateStyle, style, compareResult);
			}
		}

		private void btnCopyStyles_Click(object sender, EventArgs e)
		{
			_assStyleCopier.CopyStyles();
			_assStyleCopier.ReloadFiles();

			lbFileList_SelectedValueChanged(null, null);
		}
	}
}
