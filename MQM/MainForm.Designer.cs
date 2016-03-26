namespace MQM
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.QueryComboBox = new MetroFramework.Controls.MetroComboBox();
            this.MakeQueryButton = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SettingsButton = new MetroFramework.Controls.MetroLink();
            this.ArchieveButton = new MetroFramework.Controls.MetroLink();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.ConsoleBox = new System.Windows.Forms.RichTextBox();
            this.QueryEditButton = new MetroFramework.Controls.MetroLink();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // QueryComboBox
            // 
            this.QueryComboBox.FormattingEnabled = true;
            this.QueryComboBox.ItemHeight = 23;
            this.QueryComboBox.Location = new System.Drawing.Point(8, 65);
            this.QueryComboBox.Name = "QueryComboBox";
            this.QueryComboBox.Size = new System.Drawing.Size(418, 29);
            this.QueryComboBox.Style = MetroFramework.MetroColorStyle.Lime;
            this.QueryComboBox.TabIndex = 0;
            // 
            // MakeQueryButton
            // 
            this.MakeQueryButton.Location = new System.Drawing.Point(432, 65);
            this.MakeQueryButton.Name = "MakeQueryButton";
            this.MakeQueryButton.Size = new System.Drawing.Size(98, 29);
            this.MakeQueryButton.TabIndex = 2;
            this.MakeQueryButton.Text = "Выполнить";
            this.MakeQueryButton.Click += new System.EventHandler(this.MakeQueryButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Выберите запрос:";
            // 
            // SettingsButton
            // 
            this.SettingsButton.Location = new System.Drawing.Point(6, 7);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(72, 20);
            this.SettingsButton.TabIndex = 9;
            this.SettingsButton.Text = "Настройки";
            this.SettingsButton.UseStyleColors = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // ArchieveButton
            // 
            this.ArchieveButton.Location = new System.Drawing.Point(84, 7);
            this.ArchieveButton.Name = "ArchieveButton";
            this.ArchieveButton.Size = new System.Drawing.Size(55, 20);
            this.ArchieveButton.TabIndex = 10;
            this.ArchieveButton.Text = "Архив";
            this.ArchieveButton.UseStyleColors = true;
            this.ArchieveButton.Click += new System.EventHandler(this.ArchieveButton_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.ConsoleBox);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(8, 100);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(522, 327);
            this.metroPanel1.TabIndex = 11;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // ConsoleBox
            // 
            this.ConsoleBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConsoleBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConsoleBox.Location = new System.Drawing.Point(3, 3);
            this.ConsoleBox.Name = "ConsoleBox";
            this.ConsoleBox.Size = new System.Drawing.Size(516, 321);
            this.ConsoleBox.TabIndex = 2;
            this.ConsoleBox.Text = "";
            // 
            // QueryEditButton
            // 
            this.QueryEditButton.Location = new System.Drawing.Point(145, 7);
            this.QueryEditButton.Name = "QueryEditButton";
            this.QueryEditButton.Size = new System.Drawing.Size(121, 20);
            this.QueryEditButton.TabIndex = 12;
            this.QueryEditButton.Text = "Редактор запросов";
            this.QueryEditButton.UseStyleColors = true;
            this.QueryEditButton.Click += new System.EventHandler(this.QueryEditButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 438);
            this.Controls.Add(this.QueryEditButton);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.ArchieveButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MakeQueryButton);
            this.Controls.Add(this.QueryComboBox);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.metroPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox QueryComboBox;
        private MetroFramework.Controls.MetroButton MakeQueryButton;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroLink SettingsButton;
        private MetroFramework.Controls.MetroLink ArchieveButton;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.RichTextBox ConsoleBox;
        private MetroFramework.Controls.MetroLink QueryEditButton;
    }
}

