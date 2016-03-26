namespace MQM
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.SettingsTabControl = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.QueryTimeOutNumericbox = new System.Windows.Forms.NumericUpDown();
            this.QueryURLTextbox = new System.Windows.Forms.TextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.SettingsColorDemonstratePanel = new MetroFramework.Controls.MetroTile();
            this.SettingsColorCombobox = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.SettingsTabControl.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QueryTimeOutNumericbox)).BeginInit();
            this.metroTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingsTabControl
            // 
            this.SettingsTabControl.Controls.Add(this.metroTabPage1);
            this.SettingsTabControl.Controls.Add(this.metroTabPage2);
            this.SettingsTabControl.Controls.Add(this.metroTabPage3);
            this.SettingsTabControl.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
            this.SettingsTabControl.Location = new System.Drawing.Point(4, 33);
            this.SettingsTabControl.Name = "SettingsTabControl";
            this.SettingsTabControl.SelectedIndex = 0;
            this.SettingsTabControl.Size = new System.Drawing.Size(411, 251);
            this.SettingsTabControl.TabIndex = 0;
            this.SettingsTabControl.UseStyleColors = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.QueryTimeOutNumericbox);
            this.metroTabPage1.Controls.Add(this.QueryURLTextbox);
            this.metroTabPage1.Controls.Add(this.metroLabel2);
            this.metroTabPage1.Controls.Add(this.metroLabel1);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(403, 212);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Общее";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            // 
            // QueryTimeOutNumericbox
            // 
            this.QueryTimeOutNumericbox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QueryTimeOutNumericbox.Location = new System.Drawing.Point(219, 58);
            this.QueryTimeOutNumericbox.Maximum = new decimal(new int[] {
            1800000,
            0,
            0,
            0});
            this.QueryTimeOutNumericbox.Name = "QueryTimeOutNumericbox";
            this.QueryTimeOutNumericbox.Size = new System.Drawing.Size(176, 27);
            this.QueryTimeOutNumericbox.TabIndex = 6;
            // 
            // QueryURLTextbox
            // 
            this.QueryURLTextbox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QueryURLTextbox.Location = new System.Drawing.Point(100, 21);
            this.QueryURLTextbox.Name = "QueryURLTextbox";
            this.QueryURLTextbox.Size = new System.Drawing.Size(295, 27);
            this.QueryURLTextbox.TabIndex = 5;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(-4, 60);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(223, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Таймаут соединения для запроса:";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(-3, 24);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(104, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Адрес запроса:";
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.SettingsColorDemonstratePanel);
            this.metroTabPage2.Controls.Add(this.SettingsColorCombobox);
            this.metroTabPage2.Controls.Add(this.metroLabel3);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(403, 212);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Интерфейс";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            // 
            // SettingsColorDemonstratePanel
            // 
            this.SettingsColorDemonstratePanel.Location = new System.Drawing.Point(367, 22);
            this.SettingsColorDemonstratePanel.Name = "SettingsColorDemonstratePanel";
            this.SettingsColorDemonstratePanel.Size = new System.Drawing.Size(33, 29);
            this.SettingsColorDemonstratePanel.TabIndex = 4;
            // 
            // SettingsColorCombobox
            // 
            this.SettingsColorCombobox.FormattingEnabled = true;
            this.SettingsColorCombobox.ItemHeight = 23;
            this.SettingsColorCombobox.Location = new System.Drawing.Point(121, 22);
            this.SettingsColorCombobox.Name = "SettingsColorCombobox";
            this.SettingsColorCombobox.Size = new System.Drawing.Size(240, 29);
            this.SettingsColorCombobox.TabIndex = 3;
            this.SettingsColorCombobox.SelectedIndexChanged += new System.EventHandler(this.SettingsColorCombobox_SelectedIndexChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(-4, 27);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(121, 19);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "Цвет интерфейса:";
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(403, 212);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "О программе";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(327, 298);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(84, 31);
            this.metroButton2.TabIndex = 2;
            this.metroButton2.Text = "Отмена";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(237, 298);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(84, 31);
            this.metroButton1.TabIndex = 3;
            this.metroButton1.Text = "Сохранить";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 335);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.SettingsTabControl);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.SettingsTabControl.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QueryTimeOutNumericbox)).EndInit();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl SettingsTabControl;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.NumericUpDown QueryTimeOutNumericbox;
        private System.Windows.Forms.TextBox QueryURLTextbox;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox SettingsColorCombobox;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTile SettingsColorDemonstratePanel;
    }
}