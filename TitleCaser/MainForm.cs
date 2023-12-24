﻿using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using TitleCase.Helpers;
using TitleCaser.Business;
using TitleCaser.Models;

namespace TitleCaser
{
    public partial class MainForm : Form
    {
        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd);

        private static string[] m_loadFromFilePath = null;

        public MainForm(string[] loadFromFilePath)
        {
            m_loadFromFilePath = loadFromFilePath;
            SetStyle(
               ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint |
               ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            AutoScaleMode = AutoScaleMode.Dpi;

            InitializeComponent();

            this.BringToFront();
            this.Activate();
            this.Focus();
            SetForegroundWindow(this.Handle.ToInt32());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (m_loadFromFilePath != null && m_loadFromFilePath.Length > 0)
            {
                new Thread((ThreadStart)delegate
                {
                    if (File.Exists(m_loadFromFilePath[0]))
                    {
                        if (Path.GetExtension(m_loadFromFilePath[0]).ToLower().In(FileTypes.Text) ||
                            Path.GetExtension(m_loadFromFilePath[0]).ToLower().In(FileTypes.Csv))
                        {
                            SetTitles(Extensions.ReadFileAsUtf8(m_loadFromFilePath[0]));
                        }
                    }

                }).Start();
            }
        }

        internal void ResetForm()
        {
            tbTitles.Clear();
            tbTitles.ScrollBars = ScrollBars.None;

            tbAdditionalAbbr.Clear();
            tbAdditionalAbbr.ScrollBars = ScrollBars.None;

            cbCommonAbbr.Checked = true;
            cbMeasurements.Checked = true;
            cbTyicalLowercase.Checked = true;
            cbRemoveDoubleSymbols.Checked = true;
            cbRemoveStartAndEndQuotes.Checked = true;


            pbPreloader.Visible = false;

            btnProcess.Enabled = true;
            btnSave.Enabled = true;
            btnReset.Enabled = true;
            btnLoad.Enabled = true;
            btnCopyText.Enabled = true;
        }

        internal static Size GetTextDimensions(Control control, Font font, string stringData)
        {
            using (Graphics g = control.CreateGraphics())
            {
                SizeF sizeF = g.MeasureString(stringData, font);
                return new Size((int)Math.Ceiling(sizeF.Width), (int)Math.Ceiling(sizeF.Height));
            }
        }

        private void SetTextBoxDimentions(object sender, EventArgs e)
        {
            Size dimensions = GetTextDimensions((TextBox)sender, ((TextBox)sender).Font, ((TextBox)sender).Text);
            ((TextBox)sender).ScrollBars = dimensions.Height >
                                                ((TextBox)sender).Height ?
                                                ScrollBars.Both : ScrollBars.None;
        }

        #region Delegates

        public delegate void SetProcessingDelegate(bool processing);
        public void SetProcessing(bool processing)
        {
            if (tbTitles.InvokeRequired ||
                tbAdditionalAbbr.InvokeRequired ||
                btnCopyText.InvokeRequired ||
                btnProcess.InvokeRequired ||
                btnReset.InvokeRequired ||
                btnSave.InvokeRequired ||
                btnLoad.InvokeRequired ||
                cbCommonAbbr.InvokeRequired ||
                cbRemoveStartAndEndQuotes.InvokeRequired ||
                cbMeasurements.InvokeRequired ||
                cbRemoveDoubleSymbols.InvokeRequired ||
                cbTyicalLowercase.InvokeRequired ||
                pbPreloader.InvokeRequired)
            {
                var d = new SetProcessingDelegate(SetProcessing);
                Invoke(d, new object[] { processing });
            }
            else
            {
                if (processing)
                {
                    tbTitles.ReadOnly = true;
                    tbAdditionalAbbr.ReadOnly = true;
                    btnCopyText.Enabled = false;
                    btnProcess.Enabled = false;
                    btnReset.Enabled = false;
                    btnSave.Enabled = false;
                    btnLoad.Enabled = false;
                    cbCommonAbbr.Enabled = false;
                    cbRemoveStartAndEndQuotes.Enabled = false;
                    cbMeasurements.Enabled = false;
                    cbRemoveDoubleSymbols.Enabled = false;
                    cbTyicalLowercase.Enabled = false;
                    pbPreloader.Visible = true;
                }
                else
                {
                    tbTitles.ReadOnly = false;
                    tbAdditionalAbbr.ReadOnly = false;
                    btnCopyText.Enabled = true;
                    btnProcess.Enabled = true;
                    btnReset.Enabled = true;
                    btnSave.Enabled = true;
                    btnLoad.Enabled = true;
                    cbCommonAbbr.Enabled = true;
                    btnLoad.Enabled = true;
                    cbRemoveStartAndEndQuotes.Enabled = true;
                    cbMeasurements.Enabled = true;
                    cbRemoveDoubleSymbols.Enabled = true;
                    cbTyicalLowercase.Enabled = true;
                    pbPreloader.Visible = false;
                }
            }
        }

        public delegate void SetTitlesDelegate(string text);
        public void SetTitles(string text)
        {
            if (tbTitles.InvokeRequired)
            {
                var d = new SetTitlesDelegate(SetTitles);
                Invoke(d, new object[] { text });
            }
            else
            {
                tbTitles.Text = text;
            }
        }

        public delegate void SetAdditionalAbbreviationsDelegate(string text);
        public void SetAdditionalAbbreviations(string text)
        {
            if (tbAdditionalAbbr.InvokeRequired)
            {
                var d = new SetAdditionalAbbreviationsDelegate(SetAdditionalAbbreviations);
                Invoke(d, new object[] { text });
            }
            else
            {
                tbAdditionalAbbr.Text = text;
            }
        }

        public delegate void UnselectTextBoxesDelegate();
        public void UnselectTextBoxes()
        {
            if (tbTitles.InvokeRequired ||
                tbAdditionalAbbr.InvokeRequired)
            {
                var d = new UnselectTextBoxesDelegate(UnselectTextBoxes);
                Invoke(d);
            }
            else
            {
                tbTitles.Select(0, 0);
                tbAdditionalAbbr.Select(0, 0);
            }
        }

        #endregion

        #region Events

        private void MainForm_Resize(object sender, EventArgs e)
        {
            SetTextBoxDimentions(tbTitles, null);
            SetTextBoxDimentions(tbAdditionalAbbr, null);
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxDimentions(sender, e);
            btnSave.Enabled = true;
        }

        private void TextBox_DragEnter(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            bool valid = false;

            if (files.Length == 1)
            {
                if (Path.GetExtension(files[0]).ToLower().In(FileTypes.Text) ||
                    Path.GetExtension(files[0]).ToLower().In(FileTypes.Csv))
                {
                    e.Effect = DragDropEffects.Copy;
                    valid = true;
                }
            }

            if (!valid)
                e.Effect = DragDropEffects.None;
        }

        private void TextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length == 1)
            {
                TextBox textBox = sender as TextBox;

                if (textBox.Name == "tbAdditionalAbbr")
                {
                    string text = Extensions.ReadFileAsUtf8(files[0]);
                    textBox.Text = string.Join("\r\n", text.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries))
                                         .Replace("\r\n ", "\r\n");
                }
                else
                {
                    new Thread((ThreadStart)delegate
                    {
                        SetTitles(Extensions.ReadFileAsUtf8(files[0]));

                    }).Start();
                }
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        #region Buttons

        private void BtnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure you want to reset and clear the form?",
                "Reset Form?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information) == DialogResult.Yes)
            {
                ResetForm();
            }
        }

        private void BtnCopyText_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbTitles.Text);
            MessageBox.Show(
                "The titles have been copied to your clipboard.",
                "Titles Copied",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            bool cont;
            if (btnSave.Enabled)
            {
                if (MessageBox.Show(
                    "You have made changed to the form. You will lose these changes when loading a configuration file. Click 'Yes' to continue.",
                    "Unsaved Changes", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    cont = true;
                }
                else
                    cont = false;
            }
            else
                cont = true;

            if (cont)
            {
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        var config = ConfigManager.ReadFromXmlFile<ConfigModel>(openFileDialog.FileName);

                        tbTitles.Text = config.Titles;
                        tbAdditionalAbbr.Text = config.AdditionalAbbreviations;
                        cbCommonAbbr.Checked = config.ProcessCommonAbbreviations;
                        cbRemoveStartAndEndQuotes.Checked = config.RemoveStartEndEndQuotes;
                        cbMeasurements.Checked = config.FormatMeasurments;
                        cbRemoveDoubleSymbols.Checked = config.RemoveDoubleSymbols;
                        cbTyicalLowercase.Checked = config.KeepTypicalLowercase;

                        btnSave.Enabled = false;
                        UnselectTextBoxes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                           $"Unable to open file. Possible corruption or wrong file selected: {ex.Message}",
                           "Config File Load Error",
                           MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    var config = new ConfigModel
                    {
                        Titles = tbTitles.Text,
                        AdditionalAbbreviations = tbAdditionalAbbr.Text,
                        ProcessCommonAbbreviations = cbCommonAbbr.Checked,
                        RemoveStartEndEndQuotes = cbRemoveStartAndEndQuotes.Checked,
                        FormatMeasurments = cbMeasurements.Checked,
                        RemoveDoubleSymbols = cbRemoveDoubleSymbols.Checked,
                        KeepTypicalLowercase = cbTyicalLowercase.Checked
                    };

                    ConfigManager.WriteToXmlFile<ConfigModel>(saveFileDialog.FileName, config);
                    btnSave.Enabled = false;
                    UnselectTextBoxes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                       $"Unable to save file. {ex.Message}",
                       "Config File Save Error",
                       MessageBoxButtons.OK);
                }
            }
        }

        private void BtnProcess_Click(object sender, EventArgs e)
        {
            SetProcessing(true);

            string titles = tbTitles.Text;
            string additionalAbbreviations = tbAdditionalAbbr.Text.Trim();
            bool processCommonAbbreviations = cbCommonAbbr.Checked;
            bool removeStartAndEndQuotes = cbRemoveStartAndEndQuotes.Checked;
            bool formatMeasurements = cbMeasurements.Checked;
            bool keepTypicalLowercaseWords = cbTyicalLowercase.Checked;
            bool removeDoubleSymbols = cbRemoveDoubleSymbols.Checked;

            new Thread((ThreadStart)delegate
            {
                var titlesList = titles.Replace("\r", "").Split('\n').ToList();
                titlesList.Remove("");

                additionalAbbreviations = string.Join("\r\n", additionalAbbreviations.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries))
                                                .Replace("\r\n ", "\r\n")
                                                .Replace("\r\n\r\n", "\r\n");

                var additionalAbbreviationsList = additionalAbbreviations.Replace("\r", "").Split('\n').ToList();
                additionalAbbreviationsList.Remove("");
                additionalAbbreviationsList.Remove("\r\n\r\n");

                for (int i = 0; i < additionalAbbreviationsList.Count; i++)
                    additionalAbbreviationsList[i] = additionalAbbreviationsList[i].Trim();

                var formattedTitles = TitleCaseConverter.ToProperTitleCase(
                    titlesList,
                    additionalAbbreviationsList,
                    processCommonAbbreviations,
                    keepTypicalLowercaseWords,
                    formatMeasurements,
                    removeStartAndEndQuotes,
                    removeDoubleSymbols);

                SetAdditionalAbbreviations(String.Join("\r\n", additionalAbbreviationsList));
                SetTitles(String.Join("\r\n", formattedTitles));

                UnselectTextBoxes();
                SetProcessing(false);

            }).Start();
        }

        #endregion

        #endregion
    }
}
