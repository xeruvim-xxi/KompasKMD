namespace KompasKMD
{
    partial class FormMarka
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numOEInMS = new System.Windows.Forms.NumericUpDown();
            this.cbListOE = new System.Windows.Forms.ComboBox();
            this.bLinkPathModel = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLinkPathModel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chMassAllOE = new System.Windows.Forms.CheckBox();
            this.chMassOE = new System.Windows.Forms.CheckBox();
            this.txtNoteMarka = new System.Windows.Forms.TextBox();
            this.txtMassAllOE = new System.Windows.Forms.TextBox();
            this.txtMassOE = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNameMarka = new System.Windows.Forms.TextBox();
            this.txtDesignMarka = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.bClose_FormMarka = new System.Windows.Forms.Button();
            this.bSaveDataMarka = new System.Windows.Forms.Button();
            this.oFDPathModel = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOEInMS)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numOEInMS);
            this.groupBox1.Controls.Add(this.cbListOE);
            this.groupBox1.Controls.Add(this.bLinkPathModel);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtLinkPathModel);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.chMassAllOE);
            this.groupBox1.Controls.Add(this.chMassOE);
            this.groupBox1.Controls.Add(this.txtNoteMarka);
            this.groupBox1.Controls.Add(this.txtMassAllOE);
            this.groupBox1.Controls.Add(this.txtMassOE);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNameMarka);
            this.groupBox1.Controls.Add(this.txtDesignMarka);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(4, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(748, 423);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Свойства отправочного элемента:";
            // 
            // numOEInMS
            // 
            this.numOEInMS.Location = new System.Drawing.Point(278, 138);
            this.numOEInMS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numOEInMS.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numOEInMS.Name = "numOEInMS";
            this.numOEInMS.Size = new System.Drawing.Size(120, 30);
            this.numOEInMS.TabIndex = 42;
            // 
            // cbListOE
            // 
            this.cbListOE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbListOE.FormattingEnabled = true;
            this.cbListOE.Location = new System.Drawing.Point(195, 277);
            this.cbListOE.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbListOE.Name = "cbListOE";
            this.cbListOE.Size = new System.Drawing.Size(298, 33);
            this.cbListOE.TabIndex = 41;
            // 
            // bLinkPathModel
            // 
            this.bLinkPathModel.Location = new System.Drawing.Point(525, 323);
            this.bLinkPathModel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bLinkPathModel.Name = "bLinkPathModel";
            this.bLinkPathModel.Size = new System.Drawing.Size(180, 38);
            this.bLinkPathModel.TabIndex = 40;
            this.bLinkPathModel.Text = "указать";
            this.bLinkPathModel.UseVisualStyleBackColor = true;
            this.bLinkPathModel.Click += new System.EventHandler(this.bLinkPathModel_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 277);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 25);
            this.label8.TabIndex = 38;
            this.label8.Text = "Лист чертежа:";
            // 
            // txtLinkPathModel
            // 
            this.txtLinkPathModel.Location = new System.Drawing.Point(195, 323);
            this.txtLinkPathModel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLinkPathModel.Name = "txtLinkPathModel";
            this.txtLinkPathModel.ReadOnly = true;
            this.txtLinkPathModel.Size = new System.Drawing.Size(298, 30);
            this.txtLinkPathModel.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 323);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 25);
            this.label7.TabIndex = 36;
            this.label7.Text = "Путь к модели:";
            // 
            // chMassAllOE
            // 
            this.chMassAllOE.AutoSize = true;
            this.chMassAllOE.Enabled = false;
            this.chMassAllOE.Location = new System.Drawing.Point(450, 231);
            this.chMassAllOE.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chMassAllOE.Name = "chMassAllOE";
            this.chMassAllOE.Size = new System.Drawing.Size(184, 29);
            this.chMassAllOE.TabIndex = 35;
            this.chMassAllOE.Text = "расчет вручную";
            this.chMassAllOE.UseVisualStyleBackColor = true;
            this.chMassAllOE.Visible = false;
            // 
            // chMassOE
            // 
            this.chMassOE.AutoSize = true;
            this.chMassOE.Enabled = false;
            this.chMassOE.Location = new System.Drawing.Point(450, 185);
            this.chMassOE.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chMassOE.Name = "chMassOE";
            this.chMassOE.Size = new System.Drawing.Size(184, 29);
            this.chMassOE.TabIndex = 34;
            this.chMassOE.Text = "расчет вручную";
            this.chMassOE.UseVisualStyleBackColor = true;
            this.chMassOE.Visible = false;
            // 
            // txtNoteMarka
            // 
            this.txtNoteMarka.Location = new System.Drawing.Point(195, 369);
            this.txtNoteMarka.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNoteMarka.Name = "txtNoteMarka";
            this.txtNoteMarka.Size = new System.Drawing.Size(508, 30);
            this.txtNoteMarka.TabIndex = 32;
            // 
            // txtMassAllOE
            // 
            this.txtMassAllOE.Location = new System.Drawing.Point(285, 231);
            this.txtMassAllOE.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMassAllOE.Name = "txtMassAllOE";
            this.txtMassAllOE.ReadOnly = true;
            this.txtMassAllOE.Size = new System.Drawing.Size(118, 30);
            this.txtMassAllOE.TabIndex = 31;
            this.txtMassAllOE.Text = "0";
            // 
            // txtMassOE
            // 
            this.txtMassOE.Location = new System.Drawing.Point(285, 185);
            this.txtMassOE.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMassOE.Name = "txtMassOE";
            this.txtMassOE.ReadOnly = true;
            this.txtMassOE.Size = new System.Drawing.Size(118, 30);
            this.txtMassOE.TabIndex = 30;
            this.txtMassOE.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 369);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 25);
            this.label6.TabIndex = 28;
            this.label6.Text = "Примечание:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 231);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(259, 25);
            this.label5.TabIndex = 27;
            this.label5.Text = "Масса всех элементов, кг:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 185);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 25);
            this.label4.TabIndex = 26;
            this.label4.Text = "Масса элемента, кг:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 25);
            this.label3.TabIndex = 25;
            this.label3.Text = "Количество элементов:";
            // 
            // txtNameMarka
            // 
            this.txtNameMarka.Location = new System.Drawing.Point(218, 92);
            this.txtNameMarka.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNameMarka.Name = "txtNameMarka";
            this.txtNameMarka.Size = new System.Drawing.Size(493, 30);
            this.txtNameMarka.TabIndex = 24;
            // 
            // txtDesignMarka
            // 
            this.txtDesignMarka.Location = new System.Drawing.Point(218, 46);
            this.txtDesignMarka.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDesignMarka.Name = "txtDesignMarka";
            this.txtDesignMarka.Size = new System.Drawing.Size(493, 30);
            this.txtDesignMarka.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 25);
            this.label2.TabIndex = 22;
            this.label2.Text = "Наименование:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 25);
            this.label1.TabIndex = 21;
            this.label1.Text = "Обозначение ОЭ*:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(4, 485);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(748, 82);
            this.groupBox2.TabIndex = 1;
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
            this.richTextBox1.Size = new System.Drawing.Size(740, 53);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "*Поля обязательные для заполнения.";
            // 
            // bClose_FormMarka
            // 
            this.bClose_FormMarka.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bClose_FormMarka.Location = new System.Drawing.Point(525, 438);
            this.bClose_FormMarka.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bClose_FormMarka.Name = "bClose_FormMarka";
            this.bClose_FormMarka.Size = new System.Drawing.Size(180, 38);
            this.bClose_FormMarka.TabIndex = 4;
            this.bClose_FormMarka.Text = "Выйти";
            this.bClose_FormMarka.UseVisualStyleBackColor = true;
            this.bClose_FormMarka.Click += new System.EventHandler(this.bClose_FormMarka_Click);
            // 
            // bSaveDataMarka
            // 
            this.bSaveDataMarka.Location = new System.Drawing.Point(285, 438);
            this.bSaveDataMarka.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bSaveDataMarka.Name = "bSaveDataMarka";
            this.bSaveDataMarka.Size = new System.Drawing.Size(180, 38);
            this.bSaveDataMarka.TabIndex = 3;
            this.bSaveDataMarka.Text = "Сохранить";
            this.bSaveDataMarka.UseVisualStyleBackColor = true;
            this.bSaveDataMarka.Click += new System.EventHandler(this.bSaveDataMarka_Click);
            // 
            // FormMarka
            // 
            this.AcceptButton = this.bSaveDataMarka;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bClose_FormMarka;
            this.ClientSize = new System.Drawing.Size(756, 572);
            this.Controls.Add(this.bClose_FormMarka);
            this.Controls.Add(this.bSaveDataMarka);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMarka";
            this.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Text = "Редактор данных отправочных элементов";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOEInMS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bLinkPathModel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLinkPathModel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chMassAllOE;
        private System.Windows.Forms.CheckBox chMassOE;
        private System.Windows.Forms.TextBox txtNoteMarka;
        private System.Windows.Forms.TextBox txtMassAllOE;
        private System.Windows.Forms.TextBox txtMassOE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNameMarka;
        private System.Windows.Forms.TextBox txtDesignMarka;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numOEInMS;
        private System.Windows.Forms.ComboBox cbListOE;
        private System.Windows.Forms.Button bClose_FormMarka;
        private System.Windows.Forms.Button bSaveDataMarka;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.OpenFileDialog oFDPathModel;
    }
}