using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using TitleCaser.Helpers;
using TitleCaser.Business;
using TitleCaser.Models;

namespace TitleCaser
{
    public partial class MainForm : Form
    {
        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd);

        private static string[] m_loadFromFilePath = null;
        System.Timers.Timer m_loadFileTimer = null;

        public MainForm(string[] loadFromFilePath)
        {
            m_loadFromFilePath = loadFromFilePath;

            SetStyle(
               ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint |
               ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            AutoScaleMode = AutoScaleMode.Dpi;

            InitializeComponent();

            cbMaxLettersDictionaryLookup.SelectedItem = "4";
            btnSave.Enabled = false;

            this.BringToFront();
            this.Activate();
            this.Focus();

            SetForegroundWindow(this.Handle.ToInt32());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (m_loadFromFilePath != null && m_loadFromFilePath.Length > 0)
            {
                SetProcessing(true);

                m_loadFileTimer = new System.Timers.Timer();
                m_loadFileTimer.Elapsed += new ElapsedEventHandler(LoadFileTimerEvent);
                m_loadFileTimer.Interval = 2000;
                m_loadFileTimer.Enabled = true;
                m_loadFileTimer.Start();
            }
        }

        private void LoadFileTimerEvent(object source, ElapsedEventArgs e)
        {
            m_loadFileTimer.Stop();
            m_loadFileTimer.Enabled = false;

            ThreadPool.QueueUserWorkItem(delegate
            {
                if (File.Exists(m_loadFromFilePath[0]))
                {
                    if (Path.GetExtension(m_loadFromFilePath[0]).ToLower().In(FileTypes.Text) ||
                        Path.GetExtension(m_loadFromFilePath[0]).ToLower().In(FileTypes.Csv))
                    {
                        string titles = Extensions.ReadFileAsUtf8(m_loadFromFilePath[0]);
                        SetTitles(titles);
                        SetProcessing(false);
                    }
                }
            });
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnSave.Enabled)
            {
                var result = MessageBox.Show(
                    "You have unsaved changed. Do you want to save these changes?",
                    "Exit?",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        try
                        {
                            ConfigManager.WriteToXmlFile<ConfigModel>(saveFileDialog.FileName, GetConfigForSave());
                        }
                        catch (Exception ex)
                        {
                            e.Cancel = true;

                            MessageBox.Show(
                               $"Unable to save file. {ex.Message}",
                               "Config File Save Error",
                               MessageBoxButtons.OK);
                        }
                    }
                    else
                        e.Cancel = true;
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }               
            }
        }

        internal void ResetForm()
        {
            tbTitles.Clear();

            tbAdditionalAbbr.Clear();
            tbAdditionalAbbr.ScrollBars = ScrollBars.None;

            cbCommonAbbr.Checked = true;
            cbMeasurements.Checked = true;
            cbTyicalLowercase.Checked = true;
            cbRemoveEmptyLines.Checked = true;
            cbRemoveDoubleSymbols.Checked = true;
            cbRemoveStartAndEndQuotes.Checked = true;
            cbDictionaryLookup.Checked = true;

            SetDictionaryLookup(true);

            cbMaxLettersDictionaryLookup.SelectedItem = "4";
            pbPreloader.Visible = false;

            btnProcess.Enabled = true;
            btnSave.Enabled = true;
            btnReset.Enabled = true;
            btnLoad.Enabled = true;
            btnCopyText.Enabled = true;
        }

        private ConfigModel GetConfigForSave()
        {
            return new ConfigModel
            {
                Titles = tbTitles.Text,
                AdditionalAbbreviations = tbAdditionalAbbr.Text,
                ProcessCommonAbbreviations = cbCommonAbbr.Checked,
                RemoveStartEndEndQuotes = cbRemoveStartAndEndQuotes.Checked,
                FormatMeasurments = cbMeasurements.Checked,
                RemoveDoubleSymbols = cbRemoveDoubleSymbols.Checked,
                KeepTypicalLowercase = cbTyicalLowercase.Checked,
                DictionaryLookup = cbDictionaryLookup.Checked,
                MaxDictionaryLookupLetters = Convert.ToInt32((string)cbMaxLettersDictionaryLookup.SelectedItem),
                RemoveEmptyLines = cbRemoveEmptyLines.Checked
            };
        }

        internal void SetDictionaryLookup(bool enabled)
        {
            cbMaxLettersDictionaryLookup.Enabled = enabled;
            lblLetters.Enabled = enabled;
            lblMax.Enabled = enabled;
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
                cbDictionaryLookup.InvokeRequired ||
                cbMaxLettersDictionaryLookup.InvokeRequired ||
                lblMax.InvokeRequired ||
                lblLetters.InvokeRequired ||
                cbTyicalLowercase.InvokeRequired ||
                cbRemoveEmptyLines.InvokeRequired ||
                pbPreloader.InvokeRequired)
            {
                var d = new SetProcessingDelegate(SetProcessing);
                Invoke(d, new object[] { processing });
            }
            else
            {
                UnselectTextBoxes();

                if (processing)
                {
                    tbTitles.SuspendLayout();
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
                    cbRemoveEmptyLines.Enabled = false;
                    cbDictionaryLookup.Enabled = false;
                    pbPreloader.Visible = true;
                    SetDictionaryLookup(false);
                }
                else
                {
                    tbTitles.ResumeLayout();
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
                    cbRemoveEmptyLines.Enabled = true;
                    pbPreloader.Visible = false;
                    cbDictionaryLookup.Enabled = true;
                    SetDictionaryLookup(cbDictionaryLookup.Checked);
                }

                UnselectTextBoxes();
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
                tbAdditionalAbbr.InvokeRequired ||
                cbMaxLettersDictionaryLookup.InvokeRequired)
            {
                var d = new UnselectTextBoxesDelegate(UnselectTextBoxes);
                Invoke(d);
            }
            else
            {
                tbTitles.Select(0, 0);
                tbAdditionalAbbr.Select(0, 0);
                cbMaxLettersDictionaryLookup.SelectionLength = 0;
                lblTitles.Focus();
            }
        }

        #endregion

        #region Events

        private void MainForm_Resize(object sender, EventArgs e)
        {
            SetTextBoxDimentions(tbAdditionalAbbr, null);
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            SetTextBoxDimentions(tbAdditionalAbbr, null);
            tbTitles.ResumeLayout();
        }

        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {
            tbTitles.SuspendLayout();
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
                    SetProcessing(true);
                    ThreadPool.QueueUserWorkItem(delegate
                    {
                        string titles = Extensions.ReadFileAsUtf8(files[0]);
                        SetTitles(titles);
                        SetProcessing(false);
                    });
                }
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;

            cbMaxLettersDictionaryLookup.Enabled = cbDictionaryLookup.Checked;
            lblMax.Enabled = cbDictionaryLookup.Checked;
            lblLetters.Enabled = cbDictionaryLookup.Checked;

            cbMaxLettersDictionaryLookup.SelectionLength = 0;
            lblTitles.Focus();
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
                        cbDictionaryLookup.Checked = config.DictionaryLookup;
                        cbMaxLettersDictionaryLookup.SelectedItem = config.MaxDictionaryLookupLetters.ToString();
                        cbRemoveEmptyLines.Checked = config.RemoveEmptyLines;

                        SetDictionaryLookup(cbDictionaryLookup.Checked);

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
                    ConfigManager.WriteToXmlFile<ConfigModel>(saveFileDialog.FileName, GetConfigForSave());
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
            bool lookupCommonAbbreviations = cbCommonAbbr.Checked;
            bool removeStartAndEndQuotes = cbRemoveStartAndEndQuotes.Checked;
            bool formatMeasurements = cbMeasurements.Checked;
            bool keepTypicalLowercaseWords = cbTyicalLowercase.Checked;
            bool removeDoubleSymbols = cbRemoveDoubleSymbols.Checked;
            bool removeEmptyLines = cbRemoveEmptyLines.Checked;
            int maxDictionaryLookupLetters = !cbDictionaryLookup.Checked ? 0 : Convert.ToInt32((string)cbMaxLettersDictionaryLookup.SelectedItem);            

            new Thread((ThreadStart)delegate
            {
                var titlesList = titles.Replace("\r", "").Split('\n').ToList();

                additionalAbbreviations = string.Join("\r\n", additionalAbbreviations.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries))
                                                .Replace("\r\n ", "\r\n")
                                                .Replace("\r\n\r\n", "\r\n");

                var additionalAbbreviationsList = additionalAbbreviations.Replace("\r", "").Split('\n').ToList();
                additionalAbbreviationsList.Remove("");
                additionalAbbreviationsList.Remove("\r\n\r\n");

                for (int i = 0; i < additionalAbbreviationsList.Count; i++)
                    additionalAbbreviationsList[i] = additionalAbbreviationsList[i].Trim();

                var options = new TitleCaseConverter.Options
                {
                    AdditionalAbbreviations = additionalAbbreviationsList,
                    LookupCommonAbbreviations = lookupCommonAbbreviations,
                    KeepTypicalAllLowers = keepTypicalLowercaseWords,
                    FormatMeasurements = formatMeasurements,
                    RemoveStartEndQuotesOnClean = removeStartAndEndQuotes,
                    RemoveDoubleSymbolsOnClean = removeStartAndEndQuotes,
                    MaxDictionaryLookupWordLength = maxDictionaryLookupLetters,
                    RemoveEmptyLines = removeEmptyLines
                };

                var formattedTitles = TitleCaseConverter.ToProperTitleCase(titlesList, options);

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
