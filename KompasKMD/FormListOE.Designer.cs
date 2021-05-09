namespace KompasKMD
{
    partial class FormListOE
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
            this.txtNameList_FormListOE = new System.Windows.Forms.TextBox();
            this.txtDesignList_FormListOE = new System.Windows.Forms.TextBox();
            this.bLinkPathDrawing = new System.Windows.Forms.Button();
            this.txtLinkPathDrawing = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chMassMKOnList_FormListOE = new System.Windows.Forms.CheckBox();
            this.txtNoteList_FormListOE = new System.Windows.Forms.TextBox();
            this.txtMassMKOnList_FormListOE = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.bSaveDataList_FormListOE = new System.Windows.Forms.Button();
            this.bClose_FormListOE = new System.Windows.Forms.Button();
            this.oFDPathDrawingListOE = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNameList_FormListOE);
            this.groupBox1.Controls.Add(this.txtDesignList_FormListOE);
            this.groupBox1.Controls.Add(this.bLinkPathDrawing);
            this.groupBox1.Controls.Add(this.txtLinkPathDrawing);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.chMassMKOnList_FormListOE);
            this.groupBox1.Controls.Add(this.txtNoteList_FormListOE);
            this.groupBox1.Controls.Add(this.txtMassMKOnList_FormListOE);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 180);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Свойства листа отправочных элементов:";
            // 
            // txtNameList_FormListOE
            // 
            this.txtNameList_FormListOE.Location = new System.Drawing.Point(130, 60);
            this.txtNameList_FormListOE.Name = "txtNameList_FormListOE";
            this.txtNameList_FormListOE.Size = new System.Drawing.Size(330, 22);
            this.txtNameList_FormListOE.TabIndex = 30;
            // 
            // txtDesignList_FormListOE
            // 
            this.txtDesignList_FormListOE.Location = new System.Drawing.Point(130, 30);
            this.txtDesignList_FormListOE.Name = "txtDesignList_FormListOE";
            this.txtDesignList_FormListOE.Size = new System.Drawing.Size(330, 22);
            this.txtDesignList_FormListOE.TabIndex = 29;
            // 
            // bLinkPathDrawing
            // 
            this.bLinkPathDrawing.Location = new System.Drawing.Point(345, 120);
            this.bLinkPathDrawing.Name = "bLinkPathDrawing";
            this.bLinkPathDrawing.Size = new System.Drawing.Size(120, 25);
            this.bLinkPathDrawing.TabIndex = 28;
            this.bLinkPathDrawing.Text = "указать";
            this.bLinkPathDrawing.UseVisualStyleBackColor = true;
            this.bLinkPathDrawing.Click += new System.EventHandler(this.bLinkPathDrawing_Click);
            // 
            // txtLinkPathDrawing
            // 
            this.txtLinkPathDrawing.Location = new System.Drawing.Point(130, 120);
            this.txtLinkPathDrawing.Name = "txtLinkPathDrawing";
            this.txtLinkPathDrawing.ReadOnly = true;
            this.txtLinkPathDrawing.Size = new System.Drawing.Size(200, 22);
            this.txtLinkPathDrawing.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 16);
            this.label8.TabIndex = 26;
            this.label8.Text = "Путь к чертежу:";
            // 
            // chMassMKOnList_FormListOE
            // 
            this.chMassMKOnList_FormListOE.AutoSize = true;
            this.chMassMKOnList_FormListOE.Enabled = false;
            this.chMassMKOnList_FormListOE.Location = new System.Drawing.Point(330, 90);
            this.chMassMKOnList_FormListOE.Name = "chMassMKOnList_FormListOE";
            this.chMassMKOnList_FormListOE.Size = new System.Drawing.Size(134, 20);
            this.chMassMKOnList_FormListOE.TabIndex = 25;
            this.chMassMKOnList_FormListOE.Text = "расчет вручную";
            this.chMassMKOnList_FormListOE.UseVisualStyleBackColor = true;
            this.chMassMKOnList_FormListOE.Visible = false;
            // 
            // txtNoteList_FormListOE
            // 
            this.txtNoteList_FormListOE.Location = new System.Drawing.Point(130, 150);
            this.txtNoteList_FormListOE.Name = "txtNoteList_FormListOE";
            this.txtNoteList_FormListOE.Size = new System.Drawing.Size(330, 22);
            this.txtNoteList_FormListOE.TabIndex = 24;
            // 
            // txtMassMKOnList_FormListOE
            // 
            this.txtMassMKOnList_FormListOE.Location = new System.Drawing.Point(230, 90);
            this.txtMassMKOnList_FormListOE.Name = "txtMassMKOnList_FormListOE";
            this.txtMassMKOnList_FormListOE.ReadOnly = true;
            this.txtMassMKOnList_FormListOE.Size = new System.Drawing.Size(80, 22);
            this.txtMassMKOnList_FormListOE.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 16);
            this.label6.TabIndex = 22;
            this.label6.Text = "Примечание:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "Вес конструкций на листе, кгс:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Наименование:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Обозначение*:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 220);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(498, 49);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Справка:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 16);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(492, 30);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "*Поля обязательные для заполнения.";
            // 
            // bSaveDataList_FormListOE
            // 
            this.bSaveDataList_FormListOE.Location = new System.Drawing.Point(203, 190);
            this.bSaveDataList_FormListOE.Name = "bSaveDataList_FormListOE";
            this.bSaveDataList_FormListOE.Size = new System.Drawing.Size(120, 25);
            this.bSaveDataList_FormListOE.TabIndex = 1;
            this.bSaveDataList_FormListOE.Text = "Сохранить";
            this.bSaveDataList_FormListOE.UseVisualStyleBackColor = true;
            this.bSaveDataList_FormListOE.Click += new System.EventHandler(this.bSaveDataList_FormListOE_Click);
            // 
            // bClose_FormListOE
            // 
            this.bClose_FormListOE.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bClose_FormListOE.Location = new System.Drawing.Point(343, 190);
            this.bClose_FormListOE.Name = "bClose_FormListOE";
            this.bClose_FormListOE.Size = new System.Drawing.Size(120, 25);
            this.bClose_FormListOE.TabIndex = 3;
            this.bClose_FormListOE.Text = "Выйти";
            this.bClose_FormListOE.UseVisualStyleBackColor = true;
            this.bClose_FormListOE.Click += new System.EventHandler(this.bClose_FormListOE_Click);
            // 
            // FormListOE
            // 
            this.AcceptButton = this.bSaveDataList_FormListOE;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bClose_FormListOE;
            this.ClientSize = new System.Drawing.Size(504, 272);
            this.Controls.Add(this.bClose_FormListOE);
            this.Controls.Add(this.bSaveDataList_FormListOE);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormListOE";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Редактор листов отправочных элементов";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bLinkPathDrawing;
        private System.Windows.Forms.TextBox txtLinkPathDrawing;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chMassMKOnList_FormListOE;
        private System.Windows.Forms.TextBox txtNoteList_FormListOE;
        private System.Windows.Forms.TextBox txtMassMKOnList_FormListOE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesignList_FormListOE;
        private System.Windows.Forms.TextBox txtNameList_FormListOE;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button bSaveDataList_FormListOE;
        private System.Windows.Forms.Button bClose_FormListOE;
        private System.Windows.Forms.OpenFileDialog oFDPathDrawingListOE;
    }
}