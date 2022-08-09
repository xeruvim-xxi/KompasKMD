namespace KompasKMD
{
    partial class FormSettingApp
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
            this.TCSettingApp = new System.Windows.Forms.TabControl();
            this.tPCommonSetting = new System.Windows.Forms.TabPage();
            this.bSaveSettingApp = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tPFolders = new System.Windows.Forms.TabPage();
            this.bSelectFolderProjs = new System.Windows.Forms.Button();
            this.txtPathFolderProjs = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tPEnvironment = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rBKompas = new System.Windows.Forms.RadioButton();
            this.tPLibs = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.tPDesignDefault = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.tPOther = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.fBD_FolderProjs = new System.Windows.Forms.FolderBrowserDialog();
            this.TCSettingApp.SuspendLayout();
            this.tPCommonSetting.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tPFolders.SuspendLayout();
            this.tPEnvironment.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tPLibs.SuspendLayout();
            this.tPDesignDefault.SuspendLayout();
            this.tPOther.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TCSettingApp
            // 
            this.TCSettingApp.Controls.Add(this.tPCommonSetting);
            this.TCSettingApp.Dock = System.Windows.Forms.DockStyle.Top;
            this.TCSettingApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TCSettingApp.Location = new System.Drawing.Point(4, 5);
            this.TCSettingApp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TCSettingApp.Name = "TCSettingApp";
            this.TCSettingApp.SelectedIndex = 0;
            this.TCSettingApp.Size = new System.Drawing.Size(793, 363);
            this.TCSettingApp.TabIndex = 0;
            // 
            // tPCommonSetting
            // 
            this.tPCommonSetting.Controls.Add(this.bSaveSettingApp);
            this.tPCommonSetting.Controls.Add(this.tabControl1);
            this.tPCommonSetting.Location = new System.Drawing.Point(4, 34);
            this.tPCommonSetting.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tPCommonSetting.Name = "tPCommonSetting";
            this.tPCommonSetting.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tPCommonSetting.Size = new System.Drawing.Size(785, 325);
            this.tPCommonSetting.TabIndex = 0;
            this.tPCommonSetting.Text = "Общие настройки:";
            this.tPCommonSetting.UseVisualStyleBackColor = true;
            // 
            // bSaveSettingApp
            // 
            this.bSaveSettingApp.Location = new System.Drawing.Point(600, 262);
            this.bSaveSettingApp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bSaveSettingApp.Name = "bSaveSettingApp";
            this.bSaveSettingApp.Size = new System.Drawing.Size(135, 38);
            this.bSaveSettingApp.TabIndex = 1;
            this.bSaveSettingApp.Text = "Сохранить";
            this.bSaveSettingApp.UseVisualStyleBackColor = true;
            this.bSaveSettingApp.Click += new System.EventHandler(this.bSaveSettingApp_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tPFolders);
            this.tabControl1.Controls.Add(this.tPEnvironment);
            this.tabControl1.Controls.Add(this.tPLibs);
            this.tabControl1.Controls.Add(this.tPDesignDefault);
            this.tabControl1.Controls.Add(this.tPOther);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(4, 5);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(777, 246);
            this.tabControl1.TabIndex = 0;
            // 
            // tPFolders
            // 
            this.tPFolders.Controls.Add(this.bSelectFolderProjs);
            this.tPFolders.Controls.Add(this.txtPathFolderProjs);
            this.tPFolders.Controls.Add(this.label4);
            this.tPFolders.Location = new System.Drawing.Point(4, 34);
            this.tPFolders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tPFolders.Name = "tPFolders";
            this.tPFolders.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tPFolders.Size = new System.Drawing.Size(769, 208);
            this.tPFolders.TabIndex = 0;
            this.tPFolders.Text = "Каталоги:";
            this.tPFolders.UseVisualStyleBackColor = true;
            // 
            // bSelectFolderProjs
            // 
            this.bSelectFolderProjs.Location = new System.Drawing.Point(705, 31);
            this.bSelectFolderProjs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bSelectFolderProjs.Name = "bSelectFolderProjs";
            this.bSelectFolderProjs.Size = new System.Drawing.Size(45, 34);
            this.bSelectFolderProjs.TabIndex = 2;
            this.bSelectFolderProjs.Text = "...";
            this.bSelectFolderProjs.UseVisualStyleBackColor = true;
            this.bSelectFolderProjs.Click += new System.EventHandler(this.bSelectFolderProjs_Click);
            // 
            // txtPathFolderProjs
            // 
            this.txtPathFolderProjs.Location = new System.Drawing.Point(195, 31);
            this.txtPathFolderProjs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPathFolderProjs.Name = "txtPathFolderProjs";
            this.txtPathFolderProjs.Size = new System.Drawing.Size(493, 30);
            this.txtPathFolderProjs.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Папка проектов:";
            // 
            // tPEnvironment
            // 
            this.tPEnvironment.Controls.Add(this.groupBox1);
            this.tPEnvironment.Location = new System.Drawing.Point(4, 34);
            this.tPEnvironment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tPEnvironment.Name = "tPEnvironment";
            this.tPEnvironment.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tPEnvironment.Size = new System.Drawing.Size(769, 208);
            this.tPEnvironment.TabIndex = 4;
            this.tPEnvironment.Text = "Среда разработки:";
            this.tPEnvironment.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rBKompas);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(761, 198);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rBKompas
            // 
            this.rBKompas.AutoSize = true;
            this.rBKompas.Checked = true;
            this.rBKompas.Location = new System.Drawing.Point(15, 31);
            this.rBKompas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rBKompas.Name = "rBKompas";
            this.rBKompas.Size = new System.Drawing.Size(138, 29);
            this.rBKompas.TabIndex = 0;
            this.rBKompas.TabStop = true;
            this.rBKompas.Text = "Компас 3D";
            this.rBKompas.UseVisualStyleBackColor = true;
            this.rBKompas.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // tPLibs
            // 
            this.tPLibs.Controls.Add(this.label5);
            this.tPLibs.Location = new System.Drawing.Point(4, 34);
            this.tPLibs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tPLibs.Name = "tPLibs";
            this.tPLibs.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tPLibs.Size = new System.Drawing.Size(769, 208);
            this.tPLibs.TabIndex = 1;
            this.tPLibs.Text = "Библиотеки:";
            this.tPLibs.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(117, 88);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(286, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "Данный раздел в разработке";
            // 
            // tPDesignDefault
            // 
            this.tPDesignDefault.Controls.Add(this.label6);
            this.tPDesignDefault.Location = new System.Drawing.Point(4, 34);
            this.tPDesignDefault.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tPDesignDefault.Name = "tPDesignDefault";
            this.tPDesignDefault.Size = new System.Drawing.Size(769, 208);
            this.tPDesignDefault.TabIndex = 2;
            this.tPDesignDefault.Text = "Обозначения:";
            this.tPDesignDefault.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(117, 88);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(286, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "Данный раздел в разработке";
            // 
            // tPOther
            // 
            this.tPOther.Controls.Add(this.label7);
            this.tPOther.Location = new System.Drawing.Point(4, 34);
            this.tPOther.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tPOther.Name = "tPOther";
            this.tPOther.Size = new System.Drawing.Size(769, 208);
            this.tPOther.TabIndex = 3;
            this.tPOther.Text = "Прочее:";
            this.tPOther.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(117, 88);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(286, 25);
            this.label7.TabIndex = 2;
            this.label7.Text = "Данный раздел в разработке";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(4, 378);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(793, 82);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Справка:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(4, 24);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(785, 53);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "*Логин указанный при регистрации на сайте kompas-kmd.ru.\n**Ключ полученный на сай" +
    "те.";
            // 
            // FormSettingApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 465);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.TCSettingApp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettingApp";
            this.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Text = "Настройки";
            this.TCSettingApp.ResumeLayout(false);
            this.tPCommonSetting.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tPFolders.ResumeLayout(false);
            this.tPFolders.PerformLayout();
            this.tPEnvironment.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tPLibs.ResumeLayout(false);
            this.tPLibs.PerformLayout();
            this.tPDesignDefault.ResumeLayout(false);
            this.tPDesignDefault.PerformLayout();
            this.tPOther.ResumeLayout(false);
            this.tPOther.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TCSettingApp;
        private System.Windows.Forms.TabPage tPCommonSetting;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tPFolders;
        private System.Windows.Forms.Button bSelectFolderProjs;
        private System.Windows.Forms.TextBox txtPathFolderProjs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tPLibs;
        private System.Windows.Forms.Button bSaveSettingApp;
        private System.Windows.Forms.TabPage tPDesignDefault;
        private System.Windows.Forms.TabPage tPOther;
        private System.Windows.Forms.FolderBrowserDialog fBD_FolderProjs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tPEnvironment;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rBKompas;
    }
}