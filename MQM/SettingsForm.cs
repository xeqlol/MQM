using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace MQM
{
    public partial class SettingsForm : MetroForm
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.Style = Program.MainForm.Style;
            SettingsColorCombobox.Style = SettingsTabControl.Style = this.Style;
            SettingsColorDemonstratePanel.Style = Program.MainForm.MainStyle;

            SettingsColorCombobox.DataSource = Enum.GetValues(typeof(MetroColorStyle));
            SettingsColorCombobox.SelectedItem = Program.MainForm.MainStyle;
            QueryTimeOutNumericbox.Text = Program.MainForm.WebClientTimeout.ToString();
            QueryURLTextbox.Text = Program.MainForm.QueryURL;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Program.MainForm.MainStyle = this.Style =
                (MetroColorStyle) Enum.Parse(typeof (MetroColorStyle), SettingsColorCombobox.SelectedItem.ToString());
            SettingsTabControl.Style = this.Style;
            SettingsColorDemonstratePanel.Style = Program.MainForm.MainStyle;
            Program.MainForm.QueryURL = QueryURLTextbox.Text;
            Program.MainForm.WebClientTimeout = Int32.Parse(QueryTimeOutNumericbox.Text);
            this.Close();
        }

        private void SettingsColorCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SettingsColorDemonstratePanel.Style = (MetroColorStyle)Enum.Parse(typeof(MetroColorStyle), SettingsColorCombobox.SelectedItem.ToString());
        }
    }
}
