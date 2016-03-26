namespace MQM
{
    partial class EditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            this.EditorTabControl = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.QueryNameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.SaveQueryButton = new MetroFramework.Controls.MetroButton();
            this.CreateQueryButton = new MetroFramework.Controls.MetroButton();
            this.OpenQueryButton = new MetroFramework.Controls.MetroButton();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.AutocompleteBox = new System.Windows.Forms.ListBox();
            this.QueryEditBox = new System.Windows.Forms.RichTextBox();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.OpenQueryDialog = new System.Windows.Forms.OpenFileDialog();
            this.EditorTabControl.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditorTabControl
            // 
            this.EditorTabControl.Controls.Add(this.metroTabPage1);
            this.EditorTabControl.Controls.Add(this.metroTabPage2);
            this.EditorTabControl.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
            this.EditorTabControl.Location = new System.Drawing.Point(3, 33);
            this.EditorTabControl.Name = "EditorTabControl";
            this.EditorTabControl.SelectedIndex = 0;
            this.EditorTabControl.Size = new System.Drawing.Size(648, 417);
            this.EditorTabControl.TabIndex = 0;
            this.EditorTabControl.TabStop = false;
            this.EditorTabControl.UseStyleColors = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.QueryNameTextBox);
            this.metroTabPage1.Controls.Add(this.SaveQueryButton);
            this.metroTabPage1.Controls.Add(this.CreateQueryButton);
            this.metroTabPage1.Controls.Add(this.OpenQueryButton);
            this.metroTabPage1.Controls.Add(this.metroPanel1);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(640, 378);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Редактор";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            // 
            // QueryNameTextBox
            // 
            this.QueryNameTextBox.Enabled = false;
            this.QueryNameTextBox.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.QueryNameTextBox.Location = new System.Drawing.Point(0, 9);
            this.QueryNameTextBox.Name = "QueryNameTextBox";
            this.QueryNameTextBox.Size = new System.Drawing.Size(376, 29);
            this.QueryNameTextBox.TabIndex = 17;
            this.QueryNameTextBox.TabStop = false;
            this.QueryNameTextBox.UseStyleColors = true;
            // 
            // SaveQueryButton
            // 
            this.SaveQueryButton.Enabled = false;
            this.SaveQueryButton.Location = new System.Drawing.Point(556, 9);
            this.SaveQueryButton.Name = "SaveQueryButton";
            this.SaveQueryButton.Size = new System.Drawing.Size(81, 29);
            this.SaveQueryButton.TabIndex = 16;
            this.SaveQueryButton.TabStop = false;
            this.SaveQueryButton.Text = "Сохранить";
            this.SaveQueryButton.Click += new System.EventHandler(this.SaveQueryButton_Click);
            // 
            // CreateQueryButton
            // 
            this.CreateQueryButton.Location = new System.Drawing.Point(472, 9);
            this.CreateQueryButton.Name = "CreateQueryButton";
            this.CreateQueryButton.Size = new System.Drawing.Size(78, 29);
            this.CreateQueryButton.TabIndex = 15;
            this.CreateQueryButton.TabStop = false;
            this.CreateQueryButton.Text = "Создать";
            this.CreateQueryButton.Click += new System.EventHandler(this.CreateQueryButton_Click);
            // 
            // OpenQueryButton
            // 
            this.OpenQueryButton.Location = new System.Drawing.Point(382, 9);
            this.OpenQueryButton.Name = "OpenQueryButton";
            this.OpenQueryButton.Size = new System.Drawing.Size(84, 29);
            this.OpenQueryButton.TabIndex = 14;
            this.OpenQueryButton.TabStop = false;
            this.OpenQueryButton.Text = "Открыть";
            this.OpenQueryButton.Click += new System.EventHandler(this.OpenQueryButton_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.AutocompleteBox);
            this.metroPanel1.Controls.Add(this.QueryEditBox);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 49);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(637, 326);
            this.metroPanel1.TabIndex = 13;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // AutocompleteBox
            // 
            this.AutocompleteBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AutocompleteBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.AutocompleteBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AutocompleteBox.FormattingEnabled = true;
            this.AutocompleteBox.ItemHeight = 21;
            this.AutocompleteBox.Location = new System.Drawing.Point(371, 161);
            this.AutocompleteBox.Name = "AutocompleteBox";
            this.AutocompleteBox.ScrollAlwaysVisible = true;
            this.AutocompleteBox.Size = new System.Drawing.Size(250, 149);
            this.AutocompleteBox.TabIndex = 2;
            this.AutocompleteBox.TabStop = false;
            this.AutocompleteBox.Visible = false;
            this.AutocompleteBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.AutocompleteBox_DrawItem);
            // 
            // QueryEditBox
            // 
            this.QueryEditBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.QueryEditBox.Enabled = false;
            this.QueryEditBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QueryEditBox.Location = new System.Drawing.Point(3, 3);
            this.QueryEditBox.Name = "QueryEditBox";
            this.QueryEditBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.QueryEditBox.Size = new System.Drawing.Size(631, 320);
            this.QueryEditBox.TabIndex = 1;
            this.QueryEditBox.TabStop = false;
            this.QueryEditBox.Text = "";
            this.QueryEditBox.WordWrap = false;
            this.QueryEditBox.TextChanged += new System.EventHandler(this.QueryEditBox_TextChanged);
            this.QueryEditBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QueryEditBox_KeyDown);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.metroPanel2);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(640, 378);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Справка";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            // 
            // metroPanel2
            // 
            this.metroPanel2.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel2.Controls.Add(this.richTextBox1);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(0, 17);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(640, 358);
            this.metroPanel2.TabIndex = 13;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(634, 352);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // OpenQueryDialog
            // 
            this.OpenQueryDialog.FileName = "openFileDialog1";
            this.OpenQueryDialog.RestoreDirectory = true;
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 450);
            this.Controls.Add(this.EditorTabControl);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditorForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.Text = "EditorForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditorForm_FormClosing);
            this.Load += new System.EventHandler(this.EditorForm_Load);
            this.EditorTabControl.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.metroTabPage2.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl EditorTabControl;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.RichTextBox QueryEditBox;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private MetroFramework.Controls.MetroTextBox QueryNameTextBox;
        private MetroFramework.Controls.MetroButton SaveQueryButton;
        private MetroFramework.Controls.MetroButton CreateQueryButton;
        private MetroFramework.Controls.MetroButton OpenQueryButton;
        private System.Windows.Forms.OpenFileDialog OpenQueryDialog;
        private System.Windows.Forms.ListBox AutocompleteBox;
    }
}