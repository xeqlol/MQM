using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;
using MetroFramework;
using MetroFramework.Forms;

namespace MQM
{
    public partial class EditorForm : MetroForm
    {
        private string openedQueryDirectory;
        private bool isSomethingOpened = false;

        private int startline;
        private int cursorline;
        private int cursorpos;
        private string word;
        private int x;

        private bool back = false;
        private List<string> AutoComplete = new List<string>(); 

        public MetroColorStyle EditorStyle
        {
            set
            {
                this.Style = value;
                QueryNameTextBox.Style = EditorTabControl.Style = this.Style;
            }
        }
        public EditorForm()
        {
            InitializeComponent();
            AddAutoComplete();
            AutocompleteBox.AutoSize = false;
            OpenQueryDialog.Filter = "Файлы запросов (*.query)|*.query";
        }

        private void EditorForm_Load(object sender, EventArgs e)
        {
            OpenQueryDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + @"queries";
            this.Style = Program.MainForm.Style;
            QueryNameTextBox.Style = EditorTabControl.Style = this.Style;
        }

        private void OpenQueryButton_Click(object sender, EventArgs e)
        {
            StreamReader myReader = null;
            if (OpenQueryDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myReader = new StreamReader(OpenQueryDialog.OpenFile())) != null)
                    {
                        using (myReader)
                        {
                            isSomethingOpened = true;
                            QueryEditBox.Enabled = SaveQueryButton.Enabled = QueryNameTextBox.Enabled = true;
                            openedQueryDirectory = Path.GetDirectoryName(OpenQueryDialog.FileName);
                            QueryEditBox.Clear();
                            QueryEditBox.AppendText(myReader.ReadToEnd());
                            QueryNameTextBox.Text = OpenQueryDialog.FileName.Split('\\').Last();

                            myReader.Dispose();
                        }
                    }
                }
                catch (Exception ex)
                {
                    QueryNameTextBox.Text = "Ошибка при открытии файла: " + ex.Message;
                }
            }
        }

        private void EditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            isSomethingOpened = false;
            QueryNameTextBox.Text = "";
            openedQueryDirectory = "";
            QueryEditBox.Text = "";
        }

        private void SaveQueryButton_Click(object sender, EventArgs e)
        {
            if (!isSomethingOpened)
                return;
            QueryEditBox.SaveFile(string.Format(@"{0}\{1}", openedQueryDirectory, QueryNameTextBox.Text), RichTextBoxStreamType.PlainText);
            SaveQueryButton.Enabled = false;
        }

        private void CreateQueryButton_Click(object sender, EventArgs e)
        {
            isSomethingOpened = true;
            QueryEditBox.Enabled = SaveQueryButton.Enabled = QueryNameTextBox.Enabled = true;
            QueryNameTextBox.Text = MakeUniqueFileName(string.Format(@"{0}\{1}", openedQueryDirectory, "new query.query")).Name;
            QueryEditBox.Clear();
            QueryEditBox.AppendText("[MQM]\r\n");
            QueryEditBox.AppendText("fromDate=\r\n");
            QueryEditBox.AppendText("toDate=\r\n");
            QueryEditBox.AppendText("fromTime=\r\n");
            QueryEditBox.AppendText("toTime=\r\n");
            QueryEditBox.AppendText("queryInterval=\r\n");
            QueryEditBox.AppendText("queryBody=");
        }
        public FileInfo MakeUniqueFileName(string path)
        {
            string dir = Path.GetDirectoryName(path);
            string fileName = Path.GetFileNameWithoutExtension(path);
            string fileExt = Path.GetExtension(path);

            for (int i = 1; ; ++i)
            {
                if (!File.Exists(path))
                    return new FileInfo(path);

                path = Path.Combine(dir, string.Format("{0} ({1}){2}", fileName, i, fileExt));
            }
        }
        [DllImport("user32")]
        private extern static int GetCaretPos(out Point p);

        private void QueryEditBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SaveQueryButton.Enabled = true;

                AutocompleteBox.Visible = false;
                AutocompleteBox.Items.Clear();

                startline = QueryEditBox.GetLineFromCharIndex(QueryEditBox.SelectionStart);
                cursorline = QueryEditBox.GetLineFromCharIndex(QueryEditBox.SelectionStart);
                cursorpos = QueryEditBox.SelectionStart;

                while ((QueryEditBox.Text.Substring(cursorpos - 1, 1) != "\t") &&
                       (QueryEditBox.Text.Substring(cursorpos - 1, 1) != " ") &&
                       (QueryEditBox.Text.Substring(cursorpos - 1, 1) != "=") &&
                       (QueryEditBox.Text.Substring(cursorpos - 1, 1) != "-") &&
                       cursorline == startline)
                {
                    cursorpos--;
                    cursorline = QueryEditBox.GetLineFromCharIndex(cursorpos);
                }
                word = cursorline == startline ? QueryEditBox.Text.Substring(cursorpos, QueryEditBox.SelectionStart - cursorpos) : QueryEditBox.Text.Substring(cursorpos + 1, QueryEditBox.SelectionStart - (cursorpos - 1));
                if (cursorline == startline)
                {
                    x = cursorpos - QueryEditBox.GetFirstCharIndexOfCurrentLine();
                }
                else
                {
                    x = cursorpos + 1 - QueryEditBox.GetFirstCharIndexOfCurrentLine();
                }

                int y =
                    QueryEditBox.GetLineFromCharIndex(QueryEditBox.GetFirstCharIndexOfCurrentLine() -
                                                      QueryEditBox.GetLineFromCharIndex(
                                                          QueryEditBox.GetCharIndexFromPosition(new Point(0, 0))));
                Point cp;
                GetCaretPos(out cp);
                cp.Y += 22;
                cp.X = cp.X + AutocompleteBox.Width <= QueryEditBox.Width
                    ? cp.X
                    : QueryEditBox.Width - AutocompleteBox.Width;
                AutocompleteBox.Location = cp;

                foreach (var auto in AutoComplete)
                {
                    if (auto.StartsWith(word) && word != "" && word != " ")
                    {
                        AutocompleteBox.Items.Add(auto);
                    }
                }

                if (AutocompleteBox.Items.Count != 0)
                {
                    AutocompleteBox.Visible = true;
                    AutocompleteBox.SetSelected(0, true);
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void QueryEditBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Tab && AutocompleteBox.Visible) || (e.KeyCode == Keys.Enter && AutocompleteBox.Visible))
            {
                QueryEditBox.SelectedText = AutocompleteBox.SelectedItem.ToString()
                    .Substring(word.Length, AutocompleteBox.SelectedItem.ToString().Length - word.Length);
                e.SuppressKeyPress = true;
                AutocompleteBox.Visible = false;
            }
            else if (e.KeyCode == Keys.Tab && !AutocompleteBox.Visible)
            {
                QueryEditBox.SelectedText = "    ";
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up  && AutocompleteBox.Visible)
            {
                if (AutocompleteBox.SelectedIndex != 0)
                    AutocompleteBox.SetSelected(AutocompleteBox.SelectedIndex - 1, true);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down && AutocompleteBox.Visible)
            {
                if (AutocompleteBox.SelectedIndex != AutocompleteBox.Items.Count - 1)
                    AutocompleteBox.SetSelected(AutocompleteBox.SelectedIndex + 1, true);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Left && AutocompleteBox.Visible)
            {
                AutocompleteBox.Visible = false;
            }
            else if (e.KeyCode == Keys.Right && AutocompleteBox.Visible)
            {
                AutocompleteBox.Visible = false;
            }
            else if (e.KeyCode == Keys.Right && AutocompleteBox.Visible)
            {
                AutocompleteBox.Visible = false;
            }
        }

        private void AutocompleteBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            //if the item state is selected them change the back color 
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          MetroFramework.Drawing.MetroPaint.GetStyleColor(this.Style));//Choose the color

            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Draw the current item text
            e.Graphics.DrawString(AutocompleteBox.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        private void AddAutoComplete()
        {
            AutoComplete.Add("feu0A");
            AutoComplete.Add("feu0B");
            AutoComplete.Add("feu1A");
            AutoComplete.Add("feu1B");
            AutoComplete.Add("feu2A");
            AutoComplete.Add("feu2B");
            AutoComplete.Add("feu3A");
            AutoComplete.Add("feu3B");
            AutoComplete.Add("feu4A");
            AutoComplete.Add("feu4B");
            AutoComplete.Add("feu5A");
            AutoComplete.Add("feu5B");
            AutoComplete.Add("veu0A");
            AutoComplete.Add("veu0B");
            AutoComplete.Add("veu1A");
            AutoComplete.Add("veu1B");
            AutoComplete.Add("veu2A");
            AutoComplete.Add("veu2B");
            AutoComplete.Add("veu3A");
            AutoComplete.Add("veu3B");
            AutoComplete.Add("veu4A");
            AutoComplete.Add("veu4B");
            AutoComplete.Add("veu5A");
            AutoComplete.Add("veu5B");
            AutoComplete.Add("sol_col_T_bakInHot");
            AutoComplete.Add("sol_col_T_bakInCold ");
            AutoComplete.Add("sol_col_T_bak");
            AutoComplete.Add("sol_col_T_bakOutHot");
            AutoComplete.Add("sol_col_T_bakOutCold ");
            AutoComplete.Add("sol_col_R_bakIn");
            AutoComplete.Add("sol_col_R_bakOut");
            AutoComplete.Add("sol_conc_T_bakInHot");
            AutoComplete.Add("sol_conc_T_bakInCold");
            AutoComplete.Add("sol_conc_T_bak");
            AutoComplete.Add("sol_conc_T_bakOutHot");
            AutoComplete.Add("sol_conc_T_bakOutCold");
            AutoComplete.Add("sol_conc_R_bakIn");
            AutoComplete.Add("sol_conc_R_bakOut");
            AutoComplete.Add("tep_nas_T_bakInHot");
            AutoComplete.Add("tep_nas_T_bakInCold ");
            AutoComplete.Add("tep_nas_T_bak");
            AutoComplete.Add("tep_nas_T_bakOutHot");
            AutoComplete.Add("tep_nas_T_bakOutCold");
            AutoComplete.Add("tep_nas_R_bakIn");
            AutoComplete.Add("tep_nas_R_bakOut");
            AutoComplete.Add("tep_nas_blokUpr_A");
            AutoComplete.Add("tep_nas_blokUpr_B");
            AutoComplete.Add("bioTemp");
            AutoComplete.Add("bioPh");
            AutoComplete.Add("bioNasosTime");
            AutoComplete.Add("bioLoadTime");
            AutoComplete.Add("GazChemCom");
            AutoComplete.Add("numOfRev");
            AutoComplete.Add("consumpmeteoTemp");
            AutoComplete.Add("airHumid");
            AutoComplete.Add("pressure");
            AutoComplete.Add("windDir");
            AutoComplete.Add("windSpeed");
            AutoComplete.Add("solRadiation");
        }
    }
}
