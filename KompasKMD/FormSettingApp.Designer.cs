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
            this.tPLicense = new System.Windows.Forms.TabPage();
            this.bActiveKey = new System.Windows.Forms.Button();
            this.bGenSerialNumberApp = new System.Windows.Forms.Button();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.linkKompasKMD = new System.Windows.Forms.LinkLabel();
            this.txtKeyApp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.tPLicense.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TCSettingApp
            // 
            this.TCSettingApp.Controls.Add(this.tPCommonSetting);
            this.TCSettingApp.Controls.Add(this.tPLicense);
            this.TCSettingApp.Dock = System.Windows.Forms.DockStyle.Top;
            this.TCSettingApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TCSettingApp.Location = new System.Drawing.Point(3, 3);
            this.TCSettingApp.Name = "TCSettingApp";
            this.TCSettingApp.SelectedIndex = 0;
            this.TCSettingApp.Size = new System.Drawing.Size(528, 236);
            this.TCSettingApp.TabIndex = 0;
            // 
            // tPCommonSetting
            // 
            this.tPCommonSetting.Controls.Add(this.bSaveSettingApp);
            this.tPCommonSetting.Controls.Add(this.tabControl1);
            this.tPCommonSetting.Location = new System.Drawing.Point(4, 25);
            this.tPCommonSetting.Name = "tPCommonSetting";
            this.tPCommonSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tPCommonSetting.Size = new System.Drawing.Size(520, 207);
            this.tPCommonSetting.TabIndex = 0;
            this.tPCommonSetting.Text = "Общие настройки:";
            this.tPCommonSetting.UseVisualStyleBackColor = true;
            // 
            // bSaveSettingApp
            // 
            this.bSaveSettingApp.Location = new System.Drawing.Point(400, 170);
            this.bSaveSettingApp.Name = "bSaveSettingApp";
            this.bSaveSettingApp.Size = new System.Drawing.Size(90, 25);
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
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(514, 160);
            this.tabControl1.TabIndex = 0;
            // 
            // tPFolders
            // 
            this.tPFolders.Controls.Add(this.bSelectFolderProjs);
            this.tPFolders.Controls.Add(this.txtPathFolderProjs);
            this.tPFolders.Controls.Add(this.label4);
            this.tPFolders.Location = new System.Drawing.Point(4, 25);
            this.tPFolders.Name = "tPFolders";
            this.tPFolders.Padding = new System.Windows.Forms.Padding(3);
            this.tPFolders.Size = new System.Drawing.Size(506, 131);
            this.tPFolders.TabIndex = 0;
            this.tPFolders.Text = "Каталоги:";
            this.tPFolders.UseVisualStyleBackColor = true;
            // 
            // bSelectFolderProjs
            // 
            this.bSelectFolderProjs.Location = new System.Drawing.Point(470, 20);
            this.bSelectFolderProjs.Name = "bSelectFolderProjs";
            this.bSelectFolderProjs.Size = new System.Drawing.Size(30, 22);
            this.bSelectFolderProjs.TabIndex = 2;
            this.bSelectFolderProjs.Text = "...";
            this.bSelectFolderProjs.UseVisualStyleBackColor = true;
            this.bSelectFolderProjs.Click += new System.EventHandler(this.bSelectFolderProjs_Click);
            // 
            // txtPathFolderProjs
            // 
            this.txtPathFolderProjs.Location = new System.Drawing.Point(130, 20);
            this.txtPathFolderProjs.Name = "txtPathFolderProjs";
            this.txtPathFolderProjs.Size = new System.Drawing.Size(330, 22);
            this.txtPathFolderProjs.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Папка проектов:";
            // 
            // tPEnvironment
            // 
            this.tPEnvironment.Controls.Add(this.groupBox1);
            this.tPEnvironment.Location = new System.Drawing.Point(4, 25);
            this.tPEnvironment.Name = "tPEnvironment";
            this.tPEnvironment.Padding = new System.Windows.Forms.Padding(3);
            this.tPEnvironment.Size = new System.Drawing.Size(506, 131);
            this.tPEnvironment.TabIndex = 4;
            this.tPEnvironment.Text = "Среда разработки:";
            this.tPEnvironment.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rBKompas);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rBKompas
            // 
            this.rBKompas.AutoSize = true;
            this.rBKompas.Checked = true;
            this.rBKompas.Location = new System.Drawing.Point(10, 20);
            this.rBKompas.Name = "rBKompas";
            this.rBKompas.Size = new System.Drawing.Size(94, 20);
            this.rBKompas.TabIndex = 0;
            this.rBKompas.TabStop = true;
            this.rBKompas.Text = "Компас 3D";
            this.rBKompas.UseVisualStyleBackColor = true;
            this.rBKompas.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // tPLibs
            // 
            this.tPLibs.Controls.Add(this.label5);
            this.tPLibs.Location = new System.Drawing.Point(4, 25);
            this.tPLibs.Name = "tPLibs";
            this.tPLibs.Padding = new System.Windows.Forms.Padding(3);
            this.tPLibs.Size = new System.Drawing.Size(506, 131);
            this.tPLibs.TabIndex = 1;
            this.tPLibs.Text = "Библиотеки:";
            this.tPLibs.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(201, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Данный раздел в разработке";
            // 
            // tPDesignDefault
            // 
            this.tPDesignDefault.Controls.Add(this.label6);
            this.tPDesignDefault.Location = new System.Drawing.Point(4, 25);
            this.tPDesignDefault.Name = "tPDesignDefault";
            this.tPDesignDefault.Size = new System.Drawing.Size(506, 131);
            this.tPDesignDefault.TabIndex = 2;
            this.tPDesignDefault.Text = "Обозначения:";
            this.tPDesignDefault.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(78, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Данный раздел в разработке";
            // 
            // tPOther
            // 
            this.tPOther.Controls.Add(this.label7);
            this.tPOther.Location = new System.Drawing.Point(4, 25);
            this.tPOther.Name = "tPOther";
            this.tPOther.Size = new System.Drawing.Size(506, 131);
            this.tPOther.TabIndex = 3;
            this.tPOther.Text = "Прочее:";
            this.tPOther.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(78, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(201, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Данный раздел в разработке";
            // 
            // tPLicense
            // 
            this.tPLicense.Controls.Add(this.bActiveKey);
            this.tPLicense.Controls.Add(this.bGenSerialNumberApp);
            this.tPLicense.Controls.Add(this.txtLogin);
            this.tPLicense.Controls.Add(this.label3);
            this.tPLicense.Controls.Add(this.linkKompasKMD);
            this.tPLicense.Controls.Add(this.txtKeyApp);
            this.tPLicense.Controls.Add(this.label2);
            this.tPLicense.Controls.Add(this.txtSerialNumber);
            this.tPLicense.Controls.Add(this.label1);
            this.tPLicense.Location = new System.Drawing.Point(4, 25);
            this.tPLicense.Name = "tPLicense";
            this.tPLicense.Padding = new System.Windows.Forms.Padding(3);
            this.tPLicense.Size = new System.Drawing.Size(520, 207);
            this.tPLicense.TabIndex = 1;
            this.tPLicense.Text = "Лицензия";
            this.tPLicense.UseVisualStyleBackColor = true;
            // 
            // bActiveKey
            // 
            this.bActiveKey.Location = new System.Drawing.Point(85, 140);
            this.bActiveKey.Name = "bActiveKey";
            this.bActiveKey.Size = new System.Drawing.Size(350, 25);
            this.bActiveKey.TabIndex = 3;
            this.bActiveKey.Text = "Активировать ключ";
            this.bActiveKey.UseVisualStyleBackColor = true;
            this.bActiveKey.Click += new System.EventHandler(this.bActiveKey_Click);
            // 
            // bGenSerialNumberApp
            // 
            this.bGenSerialNumberApp.Location = new System.Drawing.Point(85, 110);
            this.bGenSerialNumberApp.Name = "bGenSerialNumberApp";
            this.bGenSerialNumberApp.Size = new System.Drawing.Size(350, 25);
            this.bGenSerialNumberApp.TabIndex = 2;
            this.bGenSerialNumberApp.Text = "Сгенерировать серийный номер";
            this.bGenSerialNumberApp.UseVisualStyleBackColor = true;
            this.bGenSerialNumberApp.Click += new System.EventHandler(this.bGenSerialNumberApp_Click);
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(150, 20);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(210, 22);
            this.txtLogin.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Email*:";
            // 
            // linkKompasKMD
            // 
            this.linkKompasKMD.AutoSize = true;
            this.linkKompasKMD.Location = new System.Drawing.Point(125, 176);
            this.linkKompasKMD.Name = "linkKompasKMD";
            this.linkKompasKMD.Size = new System.Drawing.Size(249, 16);
            this.linkKompasKMD.TabIndex = 4;
            this.linkKompasKMD.TabStop = true;
            this.linkKompasKMD.Text = "Сайт для регистрации kompas-kmd.ru";
            this.linkKompasKMD.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkKompasKMD_LinkClicked);
            // 
            // txtKeyApp
            // 
            this.txtKeyApp.Location = new System.Drawing.Point(150, 80);
            this.txtKeyApp.Name = "txtKeyApp";
            this.txtKeyApp.Size = new System.Drawing.Size(360, 22);
            this.txtKeyApp.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ключ приложения**:";
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Location = new System.Drawing.Point(150, 50);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.ReadOnly = true;
            this.txtSerialNumber.Size = new System.Drawing.Size(360, 22);
            this.txtSerialNumber.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Серийный номер:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 246);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(528, 53);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Справка:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 16);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(522, 34);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "*Логин указанный при регистрации на сайте kompas-kmd.ru.\n**Ключ полученный на сай" +
    "те.";
            // 
            // FormSettingApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 302);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.TCSettingApp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettingApp";
            this.Padding = new System.Windows.Forms.Padding(3);
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
            this.tPLicense.ResumeLayout(false);
            this.tPLicense.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TCSettingApp;
        private System.Windows.Forms.TabPage tPCommonSetting;
        private System.Windows.Forms.TabPage tPLicense;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKeyApp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkKompasKMD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bActiveKey;
        private System.Windows.Forms.Button bGenSerialNumberApp;
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
        private System.Windows.Forms.TextBox txtLogin;
    }
}