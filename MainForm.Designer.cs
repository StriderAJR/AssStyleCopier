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
			this.lbFileList = new System.Windows.Forms.ListBox();
			this.tbTemplateFile = new System.Windows.Forms.TextBox();
			this.lblTemplateFile = new System.Windows.Forms.Label();
			this.lblFileList = new System.Windows.Forms.Label();
			this.btnSelectTemplateFile = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.btnAddFile = new System.Windows.Forms.Button();
			this.btnDeleteFile = new System.Windows.Forms.Button();
			this.lblComparison = new System.Windows.Forms.Label();
			this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// lbFileList
			// 
			this.lbFileList.FormattingEnabled = true;
			this.lbFileList.HorizontalScrollbar = true;
			this.lbFileList.Location = new System.Drawing.Point(12, 91);
			this.lbFileList.Name = "lbFileList";
			this.lbFileList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lbFileList.Size = new System.Drawing.Size(505, 420);
			this.lbFileList.TabIndex = 0;
			// 
			// tbTemplateFile
			// 
			this.tbTemplateFile.Location = new System.Drawing.Point(12, 25);
			this.tbTemplateFile.Name = "tbTemplateFile";
			this.tbTemplateFile.Size = new System.Drawing.Size(505, 20);
			this.tbTemplateFile.TabIndex = 1;
			// 
			// lblTemplateFile
			// 
			this.lblTemplateFile.AutoSize = true;
			this.lblTemplateFile.Location = new System.Drawing.Point(12, 9);
			this.lblTemplateFile.Name = "lblTemplateFile";
			this.lblTemplateFile.Size = new System.Drawing.Size(144, 13);
			this.lblTemplateFile.TabIndex = 2;
			this.lblTemplateFile.Text = "Выберите эталонный файл";
			// 
			// lblFileList
			// 
			this.lblFileList.AutoSize = true;
			this.lblFileList.Location = new System.Drawing.Point(12, 75);
			this.lblFileList.Name = "lblFileList";
			this.lblFileList.Size = new System.Drawing.Size(122, 13);
			this.lblFileList.TabIndex = 3;
			this.lblFileList.Text = "Файлы для сравнения";
			// 
			// btnSelectTemplateFile
			// 
			this.btnSelectTemplateFile.Location = new System.Drawing.Point(523, 25);
			this.btnSelectTemplateFile.Name = "btnSelectTemplateFile";
			this.btnSelectTemplateFile.Size = new System.Drawing.Size(29, 23);
			this.btnSelectTemplateFile.TabIndex = 4;
			this.btnSelectTemplateFile.Text = "...";
			this.btnSelectTemplateFile.UseVisualStyleBackColor = true;
			this.btnSelectTemplateFile.Click += new System.EventHandler(this.btnSelectTemplateFile_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(623, 25);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(298, 486);
			this.textBox2.TabIndex = 5;
			// 
			// btnAddFile
			// 
			this.btnAddFile.Location = new System.Drawing.Point(523, 91);
			this.btnAddFile.Name = "btnAddFile";
			this.btnAddFile.Size = new System.Drawing.Size(75, 23);
			this.btnAddFile.TabIndex = 6;
			this.btnAddFile.Text = "Добавить";
			this.btnAddFile.UseVisualStyleBackColor = true;
			this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
			// 
			// btnDeleteFile
			// 
			this.btnDeleteFile.Location = new System.Drawing.Point(523, 120);
			this.btnDeleteFile.Name = "btnDeleteFile";
			this.btnDeleteFile.Size = new System.Drawing.Size(75, 23);
			this.btnDeleteFile.TabIndex = 7;
			this.btnDeleteFile.Text = "Удалить";
			this.btnDeleteFile.UseVisualStyleBackColor = true;
			this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
			// 
			// lblComparison
			// 
			this.lblComparison.AutoSize = true;
			this.lblComparison.Location = new System.Drawing.Point(620, 9);
			this.lblComparison.Name = "lblComparison";
			this.lblComparison.Size = new System.Drawing.Size(62, 13);
			this.lblComparison.TabIndex = 8;
			this.lblComparison.Text = "Сравнение";
			// 
			// dlgOpenFile
			// 
			this.dlgOpenFile.DefaultExt = "ass";
			this.dlgOpenFile.RestoreDirectory = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(933, 636);
			this.Controls.Add(this.lblComparison);
			this.Controls.Add(this.btnDeleteFile);
			this.Controls.Add(this.btnAddFile);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.btnSelectTemplateFile);
			this.Controls.Add(this.lblFileList);
			this.Controls.Add(this.lblTemplateFile);
			this.Controls.Add(this.tbTemplateFile);
			this.Controls.Add(this.lbFileList);
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
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button btnAddFile;
		private System.Windows.Forms.Button btnDeleteFile;
		private System.Windows.Forms.Label lblComparison;
		private System.Windows.Forms.OpenFileDialog dlgOpenFile;
	}
}

