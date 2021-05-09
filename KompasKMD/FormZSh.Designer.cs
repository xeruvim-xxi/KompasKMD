namespace ClassKMD
{
    partial class FormZSh
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
            this.txtNote = new System.Windows.Forms.TextBox();
            this.n_Length = new System.Windows.Forms.NumericUpDown();
            this.n_KatetShva = new System.Windows.Forms.NumericUpDown();
            this.txtTypeSech = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bSaveDataList_FormListMsh = new System.Windows.Forms.Button();
            this.bClose_FormListMsh = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n_Length)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_KatetShva)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 250);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(419, 49);
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
            this.richTextBox1.Size = new System.Drawing.Size(413, 30);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "*Поля обязательные для заполнения.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNote);
            this.groupBox1.Controls.Add(this.n_Length);
            this.groupBox1.Controls.Add(this.n_KatetShva);
            this.groupBox1.Controls.Add(this.txtTypeSech);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 192);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Свойства сварного заводского шва:";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(146, 145);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(248, 22);
            this.txtNote.TabIndex = 15;
            // 
            // n_Length
            // 
            this.n_Length.Location = new System.Drawing.Point(146, 105);
            this.n_Length.Name = "n_Length";
            this.n_Length.Size = new System.Drawing.Size(100, 22);
            this.n_Length.TabIndex = 13;
            // 
            // n_KatetShva
            // 
            this.n_KatetShva.Location = new System.Drawing.Point(146, 65);
            this.n_KatetShva.Name = "n_KatetShva";
            this.n_KatetShva.Size = new System.Drawing.Size(100, 22);
            this.n_KatetShva.TabIndex = 11;
            // 
            // txtTypeSech
            // 
            this.txtTypeSech.Location = new System.Drawing.Point(146, 25);
            this.txtTypeSech.Name = "txtTypeSech";
            this.txtTypeSech.Size = new System.Drawing.Size(248, 22);
            this.txtTypeSech.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Примечание";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Длина, м";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Катет шва, мм*:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Тип сечения*:";
            // 
            // bSaveDataList_FormListMsh
            // 
            this.bSaveDataList_FormListMsh.Location = new System.Drawing.Point(137, 219);
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
            this.bClose_FormListMsh.Location = new System.Drawing.Point(277, 219);
            this.bClose_FormListMsh.Name = "bClose_FormListMsh";
            this.bClose_FormListMsh.Size = new System.Drawing.Size(120, 25);
            this.bClose_FormListMsh.TabIndex = 5;
            this.bClose_FormListMsh.Text = "Выйти";
            this.bClose_FormListMsh.UseVisualStyleBackColor = true;
            this.bClose_FormListMsh.Click += new System.EventHandler(this.bClose_FormListMsh_Click);
            // 
            // FormZSh
            // 
            this.AcceptButton = this.bSaveDataList_FormListMsh;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bClose_FormListMsh;
            this.ClientSize = new System.Drawing.Size(419, 299);
            this.Controls.Add(this.bClose_FormListMsh);
            this.Controls.Add(this.bSaveDataList_FormListMsh);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormZSh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор данных сварных заводских швов";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n_Length)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_KatetShva)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bSaveDataList_FormListMsh;
        private System.Windows.Forms.Button bClose_FormListMsh;
        private System.Windows.Forms.TextBox txtTypeSech;
        private System.Windows.Forms.NumericUpDown n_KatetShva;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.NumericUpDown n_Length;
    }
}

