namespace TitleCaser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.gpOptions = new System.Windows.Forms.GroupBox();
            this.cbRemoveEmptyLines = new System.Windows.Forms.CheckBox();
            this.lblLetters = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.cbDictionaryLookup = new System.Windows.Forms.CheckBox();
            this.cbMaxLettersDictionaryLookup = new System.Windows.Forms.ComboBox();
            this.cbRemoveDoubleSymbols = new System.Windows.Forms.CheckBox();
            this.cbRemoveStartAndEndQuotes = new System.Windows.Forms.CheckBox();
            this.cbTyicalLowercase = new System.Windows.Forms.CheckBox();
            this.cbMeasurements = new System.Windows.Forms.CheckBox();
            this.cbCommonAbbr = new System.Windows.Forms.CheckBox();
            this.pnlTitles = new System.Windows.Forms.Panel();
            this.pbPreloader = new System.Windows.Forms.PictureBox();
            this.lblTitles = new System.Windows.Forms.Label();
            this.pnlAdditionalAbbr = new System.Windows.Forms.Panel();
            this.lblAdditionalAbbr = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnCopyText = new System.Windows.Forms.Button();
            this.tbTitles = new System.Windows.Forms.TextBox();
            this.tbAdditionalAbbr = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tblLayout.SuspendLayout();
            this.gpOptions.SuspendLayout();
            this.pnlTitles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreloader)).BeginInit();
            this.pnlAdditionalAbbr.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblLayout
            // 
            this.tblLayout.BackColor = System.Drawing.Color.White;
            this.tblLayout.ColumnCount = 5;
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.65461F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.34539F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tblLayout.Controls.Add(this.gpOptions, 3, 3);
            this.tblLayout.Controls.Add(this.pnlTitles, 1, 0);
            this.tblLayout.Controls.Add(this.pnlAdditionalAbbr, 3, 0);
            this.tblLayout.Controls.Add(this.panel1, 3, 4);
            this.tblLayout.Controls.Add(this.tbTitles, 1, 1);
            this.tblLayout.Controls.Add(this.tbAdditionalAbbr, 3, 1);
            this.tblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayout.Location = new System.Drawing.Point(0, 0);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.RowCount = 6;
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.23809F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.76191F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayout.Size = new System.Drawing.Size(942, 546);
            this.tblLayout.TabIndex = 0;
            // 
            // gpOptions
            // 
            this.gpOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpOptions.Controls.Add(this.cbRemoveEmptyLines);
            this.gpOptions.Controls.Add(this.lblLetters);
            this.gpOptions.Controls.Add(this.lblMax);
            this.gpOptions.Controls.Add(this.cbDictionaryLookup);
            this.gpOptions.Controls.Add(this.cbMaxLettersDictionaryLookup);
            this.gpOptions.Controls.Add(this.cbRemoveDoubleSymbols);
            this.gpOptions.Controls.Add(this.cbRemoveStartAndEndQuotes);
            this.gpOptions.Controls.Add(this.cbTyicalLowercase);
            this.gpOptions.Controls.Add(this.cbMeasurements);
            this.gpOptions.Controls.Add(this.cbCommonAbbr);
            this.gpOptions.Location = new System.Drawing.Point(536, 236);
            this.gpOptions.Margin = new System.Windows.Forms.Padding(1, 3, 1, 1);
            this.gpOptions.Name = "gpOptions";
            this.gpOptions.Padding = new System.Windows.Forms.Padding(0);
            this.gpOptions.Size = new System.Drawing.Size(385, 247);
            this.gpOptions.TabIndex = 2;
            this.gpOptions.TabStop = false;
            this.gpOptions.Text = "Options";
            // 
            // cbRemoveEmptyLines
            // 
            this.cbRemoveEmptyLines.AutoSize = true;
            this.cbRemoveEmptyLines.Checked = true;
            this.cbRemoveEmptyLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRemoveEmptyLines.Location = new System.Drawing.Point(10, 180);
            this.cbRemoveEmptyLines.Name = "cbRemoveEmptyLines";
            this.cbRemoveEmptyLines.Size = new System.Drawing.Size(150, 21);
            this.cbRemoveEmptyLines.TabIndex = 9;
            this.cbRemoveEmptyLines.Text = "Remove Empty Lines";
            this.cbRemoveEmptyLines.UseVisualStyleBackColor = true;
            this.cbRemoveEmptyLines.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // lblLetters
            // 
            this.lblLetters.AutoSize = true;
            this.lblLetters.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLetters.Location = new System.Drawing.Point(254, 211);
            this.lblLetters.Name = "lblLetters";
            this.lblLetters.Size = new System.Drawing.Size(41, 17);
            this.lblLetters.TabIndex = 8;
            this.lblLetters.Text = "letters";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMax.Location = new System.Drawing.Point(167, 211);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(32, 17);
            this.lblMax.TabIndex = 7;
            this.lblMax.Text = "max";
            // 
            // cbDictionaryLookup
            // 
            this.cbDictionaryLookup.AutoSize = true;
            this.cbDictionaryLookup.Checked = true;
            this.cbDictionaryLookup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDictionaryLookup.Location = new System.Drawing.Point(10, 210);
            this.cbDictionaryLookup.Name = "cbDictionaryLookup";
            this.cbDictionaryLookup.Size = new System.Drawing.Size(135, 21);
            this.cbDictionaryLookup.TabIndex = 6;
            this.cbDictionaryLookup.Text = "Dictionary Lookup";
            this.cbDictionaryLookup.UseVisualStyleBackColor = true;
            this.cbDictionaryLookup.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // cbMaxLettersDictionaryLookup
            // 
            this.cbMaxLettersDictionaryLookup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaxLettersDictionaryLookup.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMaxLettersDictionaryLookup.FormattingEnabled = true;
            this.cbMaxLettersDictionaryLookup.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cbMaxLettersDictionaryLookup.Location = new System.Drawing.Point(208, 208);
            this.cbMaxLettersDictionaryLookup.Name = "cbMaxLettersDictionaryLookup";
            this.cbMaxLettersDictionaryLookup.Size = new System.Drawing.Size(41, 25);
            this.cbMaxLettersDictionaryLookup.TabIndex = 5;
            this.cbMaxLettersDictionaryLookup.SelectedIndexChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // cbRemoveDoubleSymbols
            // 
            this.cbRemoveDoubleSymbols.AutoSize = true;
            this.cbRemoveDoubleSymbols.Checked = true;
            this.cbRemoveDoubleSymbols.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRemoveDoubleSymbols.Location = new System.Drawing.Point(10, 150);
            this.cbRemoveDoubleSymbols.Name = "cbRemoveDoubleSymbols";
            this.cbRemoveDoubleSymbols.Size = new System.Drawing.Size(236, 21);
            this.cbRemoveDoubleSymbols.TabIndex = 4;
            this.cbRemoveDoubleSymbols.Text = "Remove Double Symbols ( \"\", \'\', -- )";
            this.cbRemoveDoubleSymbols.UseVisualStyleBackColor = true;
            this.cbRemoveDoubleSymbols.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // cbRemoveStartAndEndQuotes
            // 
            this.cbRemoveStartAndEndQuotes.AutoSize = true;
            this.cbRemoveStartAndEndQuotes.Checked = true;
            this.cbRemoveStartAndEndQuotes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRemoveStartAndEndQuotes.Location = new System.Drawing.Point(10, 120);
            this.cbRemoveStartAndEndQuotes.Name = "cbRemoveStartAndEndQuotes";
            this.cbRemoveStartAndEndQuotes.Size = new System.Drawing.Size(241, 21);
            this.cbRemoveStartAndEndQuotes.TabIndex = 3;
            this.cbRemoveStartAndEndQuotes.Text = "Remove Start and End Quotes ( \", \' )";
            this.cbRemoveStartAndEndQuotes.UseVisualStyleBackColor = true;
            this.cbRemoveStartAndEndQuotes.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // cbTyicalLowercase
            // 
            this.cbTyicalLowercase.AutoSize = true;
            this.cbTyicalLowercase.Checked = true;
            this.cbTyicalLowercase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTyicalLowercase.Location = new System.Drawing.Point(10, 90);
            this.cbTyicalLowercase.Name = "cbTyicalLowercase";
            this.cbTyicalLowercase.Size = new System.Drawing.Size(313, 21);
            this.cbTyicalLowercase.TabIndex = 2;
            this.cbTyicalLowercase.Text = "Keep Typical Lowercase Words (i.e. of, for, from)";
            this.cbTyicalLowercase.UseVisualStyleBackColor = true;
            this.cbTyicalLowercase.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // cbMeasurements
            // 
            this.cbMeasurements.AutoSize = true;
            this.cbMeasurements.Checked = true;
            this.cbMeasurements.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMeasurements.Location = new System.Drawing.Point(10, 60);
            this.cbMeasurements.Name = "cbMeasurements";
            this.cbMeasurements.Size = new System.Drawing.Size(241, 21);
            this.cbMeasurements.TabIndex = 1;
            this.cbMeasurements.Text = "Format Measurements (i.e. kWh, m²)";
            this.cbMeasurements.UseVisualStyleBackColor = true;
            this.cbMeasurements.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // cbCommonAbbr
            // 
            this.cbCommonAbbr.AutoSize = true;
            this.cbCommonAbbr.Checked = true;
            this.cbCommonAbbr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCommonAbbr.Location = new System.Drawing.Point(10, 29);
            this.cbCommonAbbr.Name = "cbCommonAbbr";
            this.cbCommonAbbr.Size = new System.Drawing.Size(216, 21);
            this.cbCommonAbbr.TabIndex = 0;
            this.cbCommonAbbr.Text = "Process Common Abbreviations";
            this.cbCommonAbbr.UseVisualStyleBackColor = true;
            this.cbCommonAbbr.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // pnlTitles
            // 
            this.pnlTitles.Controls.Add(this.pbPreloader);
            this.pnlTitles.Controls.Add(this.lblTitles);
            this.pnlTitles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTitles.Location = new System.Drawing.Point(15, 0);
            this.pnlTitles.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTitles.Name = "pnlTitles";
            this.pnlTitles.Size = new System.Drawing.Size(505, 59);
            this.pnlTitles.TabIndex = 3;
            // 
            // pbPreloader
            // 
            this.pbPreloader.Image = global::TitleCaser.Properties.Resources.small_preloader;
            this.pbPreloader.Location = new System.Drawing.Point(487, 32);
            this.pbPreloader.Name = "pbPreloader";
            this.pbPreloader.Size = new System.Drawing.Size(20, 20);
            this.pbPreloader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPreloader.TabIndex = 1;
            this.pbPreloader.TabStop = false;
            this.pbPreloader.Visible = false;
            // 
            // lblTitles
            // 
            this.lblTitles.AutoSize = true;
            this.lblTitles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitles.Location = new System.Drawing.Point(0, 0);
            this.lblTitles.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblTitles.Name = "lblTitles";
            this.lblTitles.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.lblTitles.Size = new System.Drawing.Size(357, 46);
            this.lblTitles.TabIndex = 0;
            this.lblTitles.Text = "Type, paste or drag a text file of titles to be formatted here:\r\nOne per line.";
            // 
            // pnlAdditionalAbbr
            // 
            this.pnlAdditionalAbbr.Controls.Add(this.lblAdditionalAbbr);
            this.pnlAdditionalAbbr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAdditionalAbbr.Location = new System.Drawing.Point(535, 0);
            this.pnlAdditionalAbbr.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAdditionalAbbr.Name = "pnlAdditionalAbbr";
            this.pnlAdditionalAbbr.Size = new System.Drawing.Size(387, 59);
            this.pnlAdditionalAbbr.TabIndex = 4;
            // 
            // lblAdditionalAbbr
            // 
            this.lblAdditionalAbbr.AutoSize = true;
            this.lblAdditionalAbbr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAdditionalAbbr.Location = new System.Drawing.Point(0, 0);
            this.lblAdditionalAbbr.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblAdditionalAbbr.Name = "lblAdditionalAbbr";
            this.lblAdditionalAbbr.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.lblAdditionalAbbr.Size = new System.Drawing.Size(273, 46);
            this.lblAdditionalAbbr.TabIndex = 1;
            this.lblAdditionalAbbr.Text = "Additional abbreviations / correct cases here:\r\nOne per line.";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnProcess);
            this.panel1.Controls.Add(this.btnCopyText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(535, 484);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.tblLayout.SetRowSpan(this.panel1, 2);
            this.panel1.Size = new System.Drawing.Size(387, 62);
            this.panel1.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(235, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 35);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLoad.Location = new System.Drawing.Point(156, 13);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(73, 35);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnReset.Location = new System.Drawing.Point(77, 13);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(73, 35);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Location = new System.Drawing.Point(314, 13);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(73, 35);
            this.btnProcess.TabIndex = 2;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.BtnProcess_Click);
            // 
            // btnCopyText
            // 
            this.btnCopyText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCopyText.Location = new System.Drawing.Point(-1, 13);
            this.btnCopyText.Name = "btnCopyText";
            this.btnCopyText.Size = new System.Drawing.Size(73, 35);
            this.btnCopyText.TabIndex = 1;
            this.btnCopyText.Text = "Copy";
            this.btnCopyText.UseVisualStyleBackColor = true;
            this.btnCopyText.Click += new System.EventHandler(this.BtnCopyText_Click);
            // 
            // tbTitles
            // 
            this.tbTitles.AllowDrop = true;
            this.tbTitles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTitles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTitles.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTitles.Location = new System.Drawing.Point(15, 59);
            this.tbTitles.Margin = new System.Windows.Forms.Padding(0);
            this.tbTitles.MaxLength = 999999999;
            this.tbTitles.Multiline = true;
            this.tbTitles.Name = "tbTitles";
            this.tblLayout.SetRowSpan(this.tbTitles, 4);
            this.tbTitles.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbTitles.Size = new System.Drawing.Size(505, 471);
            this.tbTitles.TabIndex = 0;
            this.tbTitles.WordWrap = false;
            this.tbTitles.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.tbTitles.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDrop);
            this.tbTitles.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            // 
            // tbAdditionalAbbr
            // 
            this.tbAdditionalAbbr.AllowDrop = true;
            this.tbAdditionalAbbr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAdditionalAbbr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAdditionalAbbr.Location = new System.Drawing.Point(535, 59);
            this.tbAdditionalAbbr.Margin = new System.Windows.Forms.Padding(0);
            this.tbAdditionalAbbr.Multiline = true;
            this.tbAdditionalAbbr.Name = "tbAdditionalAbbr";
            this.tbAdditionalAbbr.Size = new System.Drawing.Size(387, 169);
            this.tbAdditionalAbbr.TabIndex = 1;
            this.tbAdditionalAbbr.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.tbAdditionalAbbr.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDrop);
            this.tbAdditionalAbbr.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "TitleCase_Config.xml";
            this.saveFileDialog.Filter = "Title Case Config files (*.xml)|*.xml";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "TitleCase_Config.xml";
            this.openFileDialog.Filter = "Title Case Config files (*.xml)|*.xml";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(942, 546);
            this.Controls.Add(this.tblLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(960, 593);
            this.Name = "MainForm";
            this.Text = "TitleCaser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeBegin += new System.EventHandler(this.MainForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.tblLayout.ResumeLayout(false);
            this.tblLayout.PerformLayout();
            this.gpOptions.ResumeLayout(false);
            this.gpOptions.PerformLayout();
            this.pnlTitles.ResumeLayout(false);
            this.pnlTitles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreloader)).EndInit();
            this.pnlAdditionalAbbr.ResumeLayout(false);
            this.pnlAdditionalAbbr.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblLayout;
        private System.Windows.Forms.TextBox tbTitles;
        private System.Windows.Forms.TextBox tbAdditionalAbbr;
        private System.Windows.Forms.GroupBox gpOptions;
        private System.Windows.Forms.CheckBox cbCommonAbbr;
        private System.Windows.Forms.CheckBox cbMeasurements;
        private System.Windows.Forms.CheckBox cbTyicalLowercase;
        private System.Windows.Forms.Panel pnlTitles;
        private System.Windows.Forms.Panel pnlAdditionalAbbr;
        private System.Windows.Forms.Label lblTitles;
        private System.Windows.Forms.Label lblAdditionalAbbr;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCopyText;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.PictureBox pbPreloader;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox cbRemoveStartAndEndQuotes;
        private System.Windows.Forms.CheckBox cbRemoveDoubleSymbols;
        private System.Windows.Forms.ComboBox cbMaxLettersDictionaryLookup;
        private System.Windows.Forms.Label lblLetters;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.CheckBox cbDictionaryLookup;
        private System.Windows.Forms.CheckBox cbRemoveEmptyLines;
    }
}

