namespace KompasKMD
{
    partial class FormPathKMD
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.bClose = new System.Windows.Forms.Button();
            this.bSaveDataPart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bSelectMaterial = new System.Windows.Forms.Button();
            this.txtMaterialPart = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numLengthPart = new System.Windows.Forms.NumericUpDown();
            this.bSelectProfilePart = new System.Windows.Forms.Button();
            this.txtProfillePart = new System.Windows.Forms.TextBox();
            this.numKolNPart = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numKolTPart = new System.Windows.Forms.NumericUpDown();
            this.numPosPart = new System.Windows.Forms.NumericUpDown();
            this.bLinkPathModel = new System.Windows.Forms.Button();
            this.txtLinkPathModel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chMassPart = new System.Windows.Forms.CheckBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtMassPart = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.oFDPathModel = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLengthPart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKolNPart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKolTPart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosPart)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 307);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(478, 52);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Справка:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 16);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(472, 33);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "*Поля обязательные для заполнения.\n**Поля заполняются автоматически. При изменени" +
    "и вручную производится проверка.";
            // 
            // bClose
            // 
            this.bClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bClose.Location = new System.Drawing.Point(343, 280);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(120, 25);
            this.bClose.TabIndex = 6;
            this.bClose.Text = "Выйти";
            this.bClose.UseVisualStyleBackColor = true;
            // 
            // bSaveDataPart
            // 
            this.bSaveDataPart.Location = new System.Drawing.Point(203, 280);
            this.bSaveDataPart.Name = "bSaveDataPart";
            this.bSaveDataPart.Size = new System.Drawing.Size(120, 25);
            this.bSaveDataPart.TabIndex = 5;
            this.bSaveDataPart.Text = "Сохранить";
            this.bSaveDataPart.UseVisualStyleBackColor = true;
            this.bSaveDataPart.Click += new System.EventHandler(this.bSaveDataPart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bSelectMaterial);
            this.groupBox1.Controls.Add(this.txtMaterialPart);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.numLengthPart);
            this.groupBox1.Controls.Add(this.bSelectProfilePart);
            this.groupBox1.Controls.Add(this.txtProfillePart);
            this.groupBox1.Controls.Add(this.numKolNPart);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.numKolTPart);
            this.groupBox1.Controls.Add(this.numPosPart);
            this.groupBox1.Controls.Add(this.bLinkPathModel);
            this.groupBox1.Controls.Add(this.txtLinkPathModel);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.chMassPart);
            this.groupBox1.Controls.Add(this.txtNote);
            this.groupBox1.Controls.Add(this.txtMassPart);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 270);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Свойства детали:";
            // 
            // bSelectMaterial
            // 
            this.bSelectMaterial.Location = new System.Drawing.Point(340, 180);
            this.bSelectMaterial.Name = "bSelectMaterial";
            this.bSelectMaterial.Size = new System.Drawing.Size(120, 25);
            this.bSelectMaterial.TabIndex = 30;
            this.bSelectMaterial.Text = "выбрать...";
            this.bSelectMaterial.UseVisualStyleBackColor = true;
            this.bSelectMaterial.Visible = false;
            // 
            // txtMaterialPart
            // 
            this.txtMaterialPart.Location = new System.Drawing.Point(120, 180);
            this.txtMaterialPart.Name = "txtMaterialPart";
            this.txtMaterialPart.Size = new System.Drawing.Size(210, 22);
            this.txtMaterialPart.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 16);
            this.label8.TabIndex = 28;
            this.label8.Text = "Марка стали*:";
            // 
            // numLengthPart
            // 
            this.numLengthPart.DecimalPlaces = 2;
            this.numLengthPart.Location = new System.Drawing.Point(95, 120);
            this.numLengthPart.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numLengthPart.Name = "numLengthPart";
            this.numLengthPart.Size = new System.Drawing.Size(120, 22);
            this.numLengthPart.TabIndex = 27;
            // 
            // bSelectProfilePart
            // 
            this.bSelectProfilePart.Location = new System.Drawing.Point(340, 90);
            this.bSelectProfilePart.Name = "bSelectProfilePart";
            this.bSelectProfilePart.Size = new System.Drawing.Size(120, 25);
            this.bSelectProfilePart.TabIndex = 26;
            this.bSelectProfilePart.Text = "выбрать...";
            this.bSelectProfilePart.UseVisualStyleBackColor = true;
            this.bSelectProfilePart.Visible = false;
            // 
            // txtProfillePart
            // 
            this.txtProfillePart.Location = new System.Drawing.Point(85, 90);
            this.txtProfillePart.Name = "txtProfillePart";
            this.txtProfillePart.Size = new System.Drawing.Size(240, 22);
            this.txtProfillePart.TabIndex = 25;
            // 
            // numKolNPart
            // 
            this.numKolNPart.Location = new System.Drawing.Point(315, 60);
            this.numKolNPart.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numKolNPart.Name = "numKolNPart";
            this.numKolNPart.Size = new System.Drawing.Size(60, 22);
            this.numKolNPart.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(230, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "; Наоборот:";
            // 
            // numKolTPart
            // 
            this.numKolTPart.Location = new System.Drawing.Point(170, 60);
            this.numKolTPart.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numKolTPart.Name = "numKolTPart";
            this.numKolTPart.Size = new System.Drawing.Size(60, 22);
            this.numKolTPart.TabIndex = 22;
            this.numKolTPart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numPosPart
            // 
            this.numPosPart.Location = new System.Drawing.Point(200, 30);
            this.numPosPart.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numPosPart.Name = "numPosPart";
            this.numPosPart.Size = new System.Drawing.Size(60, 22);
            this.numPosPart.TabIndex = 21;
            // 
            // bLinkPathModel
            // 
            this.bLinkPathModel.Location = new System.Drawing.Point(340, 210);
            this.bLinkPathModel.Name = "bLinkPathModel";
            this.bLinkPathModel.Size = new System.Drawing.Size(120, 25);
            this.bLinkPathModel.TabIndex = 19;
            this.bLinkPathModel.Text = "указать";
            this.bLinkPathModel.UseVisualStyleBackColor = true;
            this.bLinkPathModel.Click += new System.EventHandler(this.bLinkPathModel_Click);
            // 
            // txtLinkPathModel
            // 
            this.txtLinkPathModel.Location = new System.Drawing.Point(120, 210);
            this.txtLinkPathModel.Name = "txtLinkPathModel";
            this.txtLinkPathModel.ReadOnly = true;
            this.txtLinkPathModel.Size = new System.Drawing.Size(210, 22);
            this.txtLinkPathModel.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Путь к модели:";
            // 
            // chMassPart
            // 
            this.chMassPart.AutoSize = true;
            this.chMassPart.Location = new System.Drawing.Point(260, 150);
            this.chMassPart.Name = "chMassPart";
            this.chMassPart.Size = new System.Drawing.Size(134, 20);
            this.chMassPart.TabIndex = 14;
            this.chMassPart.Text = "расчет вручную";
            this.chMassPart.UseVisualStyleBackColor = true;
            this.chMassPart.CheckedChanged += new System.EventHandler(this.chMassPart_CheckedChanged);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(120, 240);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(340, 22);
            this.txtNote.TabIndex = 11;
            // 
            // txtMassPart
            // 
            this.txtMassPart.Location = new System.Drawing.Point(140, 150);
            this.txtMassPart.Name = "txtMassPart";
            this.txtMassPart.ReadOnly = true;
            this.txtMassPart.Size = new System.Drawing.Size(100, 22);
            this.txtMassPart.TabIndex = 10;
            this.txtMassPart.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Примечание:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Вес детали, кгс**:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Длина, мм:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Сечение*:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Количество, шт.  - Так:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер детали (позиция)**:";
            // 
            // FormPathKMD
            // 
            this.AcceptButton = this.bSaveDataPart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bClose;
            this.ClientSize = new System.Drawing.Size(484, 362);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.bSaveDataPart);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPathKMD";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Редактор данных деталей отправочных элементов";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLengthPart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKolNPart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKolTPart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPosPart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Button bSaveDataPart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bLinkPathModel;
        private System.Windows.Forms.TextBox txtLinkPathModel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chMassPart;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtMassPart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numPosPart;
        private System.Windows.Forms.NumericUpDown numKolNPart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numKolTPart;
        private System.Windows.Forms.TextBox txtProfillePart;
        private System.Windows.Forms.Button bSelectProfilePart;
        private System.Windows.Forms.NumericUpDown numLengthPart;
        private System.Windows.Forms.TextBox txtMaterialPart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bSelectMaterial;
        private System.Windows.Forms.OpenFileDialog oFDPathModel;
    }
}