namespace AssStyleCopier
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.lbFileList = new System.Windows.Forms.ListBox();
			this.tbTemplateFile = new System.Windows.Forms.TextBox();
			this.lblTemplateFile = new System.Windows.Forms.Label();
			this.lblFileList = new System.Windows.Forms.Label();
			this.btnSelectTemplateFile = new System.Windows.Forms.Button();
			this.btnAddFile = new System.Windows.Forms.Button();
			this.btnDeleteFile = new System.Windows.Forms.Button();
			this.lblComparison = new System.Windows.Forms.Label();
			this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
			this.rtbStyleComparison = new System.Windows.Forms.RichTextBox();
			this.lblFoundStyles = new System.Windows.Forms.Label();
			this.lvStyles = new System.Windows.Forms.ListView();
			this.ilStyleCompareResultIcons = new System.Windows.Forms.ImageList(this.components);
			this.btnCopyStyles = new System.Windows.Forms.Button();
			this.cbCopyMissingStylesFromTemplate = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// lbFileList
			// 
			this.lbFileList.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lbFileList.FormattingEnabled = true;
			this.lbFileList.HorizontalScrollbar = true;
			this.lbFileList.Location = new System.Drawing.Point(12, 66);
			this.lbFileList.Name = "lbFileList";
			this.lbFileList.Size = new System.Drawing.Size(240, 199);
			this.lbFileList.TabIndex = 0;
			this.lbFileList.SelectedValueChanged += new System.EventHandler(this.lbFileList_SelectedValueChanged);
			// 
			// tbTemplateFile
			// 
			this.tbTemplateFile.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tbTemplateFile.Location = new System.Drawing.Point(12, 27);
			this.tbTemplateFile.Name = "tbTemplateFile";
			this.tbTemplateFile.Size = new System.Drawing.Size(240, 20);
			this.tbTemplateFile.TabIndex = 1;
			// 
			// lblTemplateFile
			// 
			this.lblTemplateFile.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblTemplateFile.AutoSize = true;
			this.lblTemplateFile.Location = new System.Drawing.Point(12, 11);
			this.lblTemplateFile.Name = "lblTemplateFile";
			this.lblTemplateFile.Size = new System.Drawing.Size(105, 13);
			this.lblTemplateFile.TabIndex = 2;
			this.lblTemplateFile.Text = "Choose template file:";
			// 
			// lblFileList
			// 
			this.lblFileList.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblFileList.AutoSize = true;
			this.lblFileList.Location = new System.Drawing.Point(12, 50);
			this.lblFileList.Name = "lblFileList";
			this.lblFileList.Size = new System.Drawing.Size(104, 13);
			this.lblFileList.TabIndex = 3;
			this.lblFileList.Text = "Ass files to compare:";
			// 
			// btnSelectTemplateFile
			// 
			this.btnSelectTemplateFile.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnSelectTemplateFile.Location = new System.Drawing.Point(255, 24);
			this.btnSelectTemplateFile.Name = "btnSelectTemplateFile";
			this.btnSelectTemplateFile.Size = new System.Drawing.Size(29, 23);
			this.btnSelectTemplateFile.TabIndex = 4;
			this.btnSelectTemplateFile.Text = "...";
			this.btnSelectTemplateFile.UseVisualStyleBackColor = true;
			this.btnSelectTemplateFile.Click += new System.EventHandler(this.btnSelectTemplateFile_Click);
			// 
			// btnAddFile
			// 
			this.btnAddFile.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnAddFile.Location = new System.Drawing.Point(255, 66);
			this.btnAddFile.Name = "btnAddFile";
			this.btnAddFile.Size = new System.Drawing.Size(75, 23);
			this.btnAddFile.TabIndex = 6;
			this.btnAddFile.Text = "Add";
			this.btnAddFile.UseVisualStyleBackColor = true;
			this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
			// 
			// btnDeleteFile
			// 
			this.btnDeleteFile.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnDeleteFile.Location = new System.Drawing.Point(255, 95);
			this.btnDeleteFile.Name = "btnDeleteFile";
			this.btnDeleteFile.Size = new System.Drawing.Size(75, 23);
			this.btnDeleteFile.TabIndex = 7;
			this.btnDeleteFile.Text = "Delete";
			this.btnDeleteFile.UseVisualStyleBackColor = true;
			this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
			// 
			// lblComparison
			// 
			this.lblComparison.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblComparison.AutoSize = true;
			this.lblComparison.Location = new System.Drawing.Point(12, 277);
			this.lblComparison.Name = "lblComparison";
			this.lblComparison.Size = new System.Drawing.Size(90, 13);
			this.lblComparison.TabIndex = 8;
			this.lblComparison.Text = "Style comparison:";
			// 
			// dlgOpenFile
			// 
			this.dlgOpenFile.DefaultExt = "ass";
			this.dlgOpenFile.RestoreDirectory = true;
			// 
			// rtbStyleComparison
			// 
			this.rtbStyleComparison.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.rtbStyleComparison.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.rtbStyleComparison.Location = new System.Drawing.Point(12, 293);
			this.rtbStyleComparison.Name = "rtbStyleComparison";
			this.rtbStyleComparison.Size = new System.Drawing.Size(592, 333);
			this.rtbStyleComparison.TabIndex = 10;
			this.rtbStyleComparison.Text = "";
			// 
			// lblFoundStyles
			// 
			this.lblFoundStyles.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblFoundStyles.AutoSize = true;
			this.lblFoundStyles.Location = new System.Drawing.Point(367, 11);
			this.lblFoundStyles.Name = "lblFoundStyles";
			this.lblFoundStyles.Size = new System.Drawing.Size(69, 13);
			this.lblFoundStyles.TabIndex = 8;
			this.lblFoundStyles.Text = "Found styles:";
			// 
			// lvStyles
			// 
			this.lvStyles.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lvStyles.AutoArrange = false;
			this.lvStyles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvStyles.HideSelection = false;
			this.lvStyles.LargeImageList = this.ilStyleCompareResultIcons;
			this.lvStyles.Location = new System.Drawing.Point(370, 27);
			this.lvStyles.MultiSelect = false;
			this.lvStyles.Name = "lvStyles";
			this.lvStyles.ShowGroups = false;
			this.lvStyles.ShowItemToolTips = true;
			this.lvStyles.Size = new System.Drawing.Size(234, 238);
			this.lvStyles.SmallImageList = this.ilStyleCompareResultIcons;
			this.lvStyles.TabIndex = 15;
			this.lvStyles.UseCompatibleStateImageBehavior = false;
			this.lvStyles.View = System.Windows.Forms.View.List;
			this.lvStyles.SelectedIndexChanged += new System.EventHandler(this.lvStyles_SelectedIndexChanged);
			// 
			// ilStyleCompareResultIcons
			// 
			this.ilStyleCompareResultIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilStyleCompareResultIcons.ImageStream")));
			this.ilStyleCompareResultIcons.TransparentColor = System.Drawing.Color.Transparent;
			this.ilStyleCompareResultIcons.Images.SetKeyName(0, "check.png");
			this.ilStyleCompareResultIcons.Images.SetKeyName(1, "cross.png");
			this.ilStyleCompareResultIcons.Images.SetKeyName(2, "Arrow Up.png");
			this.ilStyleCompareResultIcons.Images.SetKeyName(3, "Arrow Down.png");
			this.ilStyleCompareResultIcons.Images.SetKeyName(4, "Arrow Left.png");
			this.ilStyleCompareResultIcons.Images.SetKeyName(5, "Arrow Right.png");
			// 
			// btnCopyStyles
			// 
			this.btnCopyStyles.Location = new System.Drawing.Point(269, 681);
			this.btnCopyStyles.Name = "btnCopyStyles";
			this.btnCopyStyles.Size = new System.Drawing.Size(87, 27);
			this.btnCopyStyles.TabIndex = 16;
			this.btnCopyStyles.Text = "Copy styles";
			this.btnCopyStyles.UseVisualStyleBackColor = true;
			this.btnCopyStyles.Click += new System.EventHandler(this.btnCopyStyles_Click);
			// 
			// cbCopyMissingStylesFromTemplate
			// 
			this.cbCopyMissingStylesFromTemplate.AutoSize = true;
			this.cbCopyMissingStylesFromTemplate.Checked = true;
			this.cbCopyMissingStylesFromTemplate.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbCopyMissingStylesFromTemplate.Location = new System.Drawing.Point(12, 687);
			this.cbCopyMissingStylesFromTemplate.Name = "cbCopyMissingStylesFromTemplate";
			this.cbCopyMissingStylesFromTemplate.Size = new System.Drawing.Size(182, 17);
			this.cbCopyMissingStylesFromTemplate.TabIndex = 17;
			this.cbCopyMissingStylesFromTemplate.Text = "Copy missing styles from template";
			this.cbCopyMissingStylesFromTemplate.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(616, 720);
			this.Controls.Add(this.cbCopyMissingStylesFromTemplate);
			this.Controls.Add(this.btnCopyStyles);
			this.Controls.Add(this.lvStyles);
			this.Controls.Add(this.rtbStyleComparison);
			this.Controls.Add(this.lblFoundStyles);
			this.Controls.Add(this.lblComparison);
			this.Controls.Add(this.btnDeleteFile);
			this.Controls.Add(this.btnAddFile);
			this.Controls.Add(this.btnSelectTemplateFile);
			this.Controls.Add(this.lblFileList);
			this.Controls.Add(this.lblTemplateFile);
			this.Controls.Add(this.tbTemplateFile);
			this.Controls.Add(this.lbFileList);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AssStyleCopier";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox lbFileList;
		private System.Windows.Forms.TextBox tbTemplateFile;
		private System.Windows.Forms.Label lblTemplateFile;
		private System.Windows.Forms.Label lblFileList;
		private System.Windows.Forms.Button btnSelectTemplateFile;
		private System.Windows.Forms.Button btnAddFile;
		private System.Windows.Forms.Button btnDeleteFile;
		private System.Windows.Forms.Label lblComparison;
		private System.Windows.Forms.OpenFileDialog dlgOpenFile;
		private System.Windows.Forms.RichTextBox rtbStyleComparison;
		private System.Windows.Forms.Label lblFoundStyles;
		private System.Windows.Forms.ListView lvStyles;
		private System.Windows.Forms.ImageList ilStyleCompareResultIcons;
		private System.Windows.Forms.Button btnCopyStyles;
		private System.Windows.Forms.CheckBox cbCopyMissingStylesFromTemplate;
	}
}

