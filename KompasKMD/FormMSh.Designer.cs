namespace ClassKMD
{
    partial class FormMSh
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cBMarka = new System.Windows.Forms.ComboBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtTypeELect = new System.Windows.Forms.TextBox();
            this.n_length = new System.Windows.Forms.NumericUpDown();
            this.n_thick = new System.Windows.Forms.NumericUpDown();
            this.n_KolElem = new System.Windows.Forms.NumericUpDown();
            this.txtTypeShva = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bSaveDataList_FormListMsh = new System.Windows.Forms.Button();
            this.bClose_FormListMsh = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n_length)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_thick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_KolElem)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 305);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(484, 49);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Справка:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 16);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(478, 30);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "*Поля обязательные для заполнения.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBMarka);
            this.groupBox1.Controls.Add(this.txtNote);
            this.groupBox1.Controls.Add(this.txtTypeELect);
            this.groupBox1.Controls.Add(this.n_length);
            this.groupBox1.Controls.Add(this.n_thick);
            this.groupBox1.Controls.Add(this.n_KolElem);
            this.groupBox1.Controls.Add(this.txtTypeShva);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 256);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Свойства монтажного шва:";
            // 
            // cBMarka
            // 
            this.cBMarka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBMarka.FormattingEnabled = true;
            this.cBMarka.Location = new System.Drawing.Point(187, 28);
            this.cBMarka.Name = "cBMarka";
            this.cBMarka.Size = new System.Drawing.Size(167, 24);
            this.cBMarka.TabIndex = 16;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(187, 223);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(268, 22);
            this.txtNote.TabIndex = 15;
            // 
            // txtTypeELect
            // 
            this.txtTypeELect.Location = new System.Drawing.Point(187, 190);
            this.txtTypeELect.Name = "txtTypeELect";
            this.txtTypeELect.Size = new System.Drawing.Size(268, 22);
            this.txtTypeELect.TabIndex = 14;
            // 
            // n_length
            // 
            this.n_length.Location = new System.Drawing.Point(187, 158);
            this.n_length.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.n_length.Name = "n_length";
            this.n_length.Size = new System.Drawing.Size(120, 22);
            this.n_length.TabIndex = 13;
            // 
            // n_thick
            // 
            this.n_thick.Location = new System.Drawing.Point(187, 125);
            this.n_thick.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.n_thick.Name = "n_thick";
            this.n_thick.Size = new System.Drawing.Size(120, 22);
            this.n_thick.TabIndex = 12;
            // 
            // n_KolElem
            // 
            this.n_KolElem.Location = new System.Drawing.Point(187, 59);
            this.n_KolElem.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.n_KolElem.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.n_KolElem.Name = "n_KolElem";
            this.n_KolElem.Size = new System.Drawing.Size(120, 22);
            this.n_KolElem.TabIndex = 11;
            this.n_KolElem.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtTypeShva
            // 
            this.txtTypeShva.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.txtTypeShva.Location = new System.Drawing.Point(187, 91);
            this.txtTypeShva.Name = "txtTypeShva";
            this.txtTypeShva.Size = new System.Drawing.Size(268, 22);
            this.txtTypeShva.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Примечание:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Тип электрода:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Длина, м*:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Толщина, мм*:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Тип*:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Количество элементов:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Марка элемента*:";
            // 
            // bSaveDataList_FormListMsh
            // 
            this.bSaveDataList_FormListMsh.Location = new System.Drawing.Point(198, 277);
            this.bSaveDataList_FormListMsh.Name = "bSaveDataList_FormListMsh";
            this.bSaveDataList_FormListMsh.Size = new System.Drawing.Size(120, 25);
            this.bSaveDataList_FormListMsh.TabIndex = 4;
            this.bSaveDataList_FormListMsh.Text = "Сохранить";
            this.bSaveDataList_FormListMsh.UseVisualStyleBackColor = true;
            this.bSaveDataList_FormListMsh.Click += new System.EventHandler(this.bSaveDataList_FormListMsh_Click);
            // 
            // bClose_FormListMsh
            // 
            this.bClose_FormListMsh.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bClose_FormListMsh.Location = new System.Drawing.Point(338, 277);
            this.bClose_FormListMsh.Name = "bClose_FormListMsh";
            this.bClose_FormListMsh.Size = new System.Drawing.Size(120, 25);
            this.bClose_FormListMsh.TabIndex = 5;
            this.bClose_FormListMsh.Text = "Выйти";
            this.bClose_FormListMsh.UseVisualStyleBackColor = true;
            this.bClose_FormListMsh.Click += new System.EventHandler(this.bClose_FormListMsh_Click);
            // 
            // FormMSh
            // 
            this.AcceptButton = this.bSaveDataList_FormListMsh;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bClose_FormListMsh;
            this.ClientSize = new System.Drawing.Size(484, 354);
            this.Controls.Add(this.bClose_FormListMsh);
            this.Controls.Add(this.bSaveDataList_FormListMsh);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMSh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор данных монтажных швов";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n_length)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_thick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_KolElem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bSaveDataList_FormListMsh;
        private System.Windows.Forms.Button bClose_FormListMsh;
        private System.Windows.Forms.TextBox txtTypeShva;
        private System.Windows.Forms.NumericUpDown n_thick;
        private System.Windows.Forms.NumericUpDown n_KolElem;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtTypeELect;
        private System.Windows.Forms.NumericUpDown n_length;
        private System.Windows.Forms.ComboBox cBMarka;
    }
}

