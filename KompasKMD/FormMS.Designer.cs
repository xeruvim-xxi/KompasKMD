﻿namespace KompasKMD
{
    partial class FormMS
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
            this.bLinkPathDrawing = new System.Windows.Forms.Button();
            this.bLinkPathModel = new System.Windows.Forms.Button();
            this.txtLinkPathDrawing = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLinkPathModel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chMassMSh_FormMS = new System.Windows.Forms.CheckBox();
            this.chMassMM_FormMS = new System.Windows.Forms.CheckBox();
            this.chMassMK_FormMS = new System.Windows.Forms.CheckBox();
            this.txtNoteMS_FormMS = new System.Windows.Forms.TextBox();
            this.txtMassMSh_FormMS = new System.Windows.Forms.TextBox();
            this.txtMassMM_FormMS = new System.Windows.Forms.TextBox();
            this.txtMassMK_FormMS = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNameMS_FormMS = new System.Windows.Forms.TextBox();
            this.txtDesignMS_FormMS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bSaveDataMS_FormMS = new System.Windows.Forms.Button();
            this.oFDPathModelDrawingMS = new System.Windows.Forms.OpenFileDialog();
            this.bClose_FormMS = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bLinkPathDrawing);
            this.groupBox1.Controls.Add(this.bLinkPathModel);
            this.groupBox1.Controls.Add(this.txtLinkPathDrawing);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtLinkPathModel);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.chMassMSh_FormMS);
            this.groupBox1.Controls.Add(this.chMassMM_FormMS);
            this.groupBox1.Controls.Add(this.chMassMK_FormMS);
            this.groupBox1.Controls.Add(this.txtNoteMS_FormMS);
            this.groupBox1.Controls.Add(this.txtMassMSh_FormMS);
            this.groupBox1.Controls.Add(this.txtMassMM_FormMS);
            this.groupBox1.Controls.Add(this.txtMassMK_FormMS);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNameMS_FormMS);
            this.groupBox1.Controls.Add(this.txtDesignMS_FormMS);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 270);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Свойства монтажной схемы:";
            // 
            // bLinkPathDrawing
            // 
            this.bLinkPathDrawing.Location = new System.Drawing.Point(340, 210);
            this.bLinkPathDrawing.Name = "bLinkPathDrawing";
            this.bLinkPathDrawing.Size = new System.Drawing.Size(120, 25);
            this.bLinkPathDrawing.TabIndex = 20;
            this.bLinkPathDrawing.Text = "указать";
            this.bLinkPathDrawing.UseVisualStyleBackColor = true;
            this.bLinkPathDrawing.Click += new System.EventHandler(this.bLinkPathDrawing_Click);
            // 
            // bLinkPathModel
            // 
            this.bLinkPathModel.Location = new System.Drawing.Point(340, 180);
            this.bLinkPathModel.Name = "bLinkPathModel";
            this.bLinkPathModel.Size = new System.Drawing.Size(120, 25);
            this.bLinkPathModel.TabIndex = 19;
            this.bLinkPathModel.Text = "указать";
            this.bLinkPathModel.UseVisualStyleBackColor = true;
            this.bLinkPathModel.Click += new System.EventHandler(this.bLinkPathModel_Click);
            // 
            // txtLinkPathDrawing
            // 
            this.txtLinkPathDrawing.Location = new System.Drawing.Point(130, 210);
            this.txtLinkPathDrawing.Name = "txtLinkPathDrawing";
            this.txtLinkPathDrawing.ReadOnly = true;
            this.txtLinkPathDrawing.Size = new System.Drawing.Size(200, 22);
            this.txtLinkPathDrawing.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "Путь к чертежу:";
            // 
            // txtLinkPathModel
            // 
            this.txtLinkPathModel.Location = new System.Drawing.Point(130, 180);
            this.txtLinkPathModel.Name = "txtLinkPathModel";
            this.txtLinkPathModel.ReadOnly = true;
            this.txtLinkPathModel.Size = new System.Drawing.Size(200, 22);
            this.txtLinkPathModel.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Путь к модели:";
            // 
            // chMassMSh_FormMS
            // 
            this.chMassMSh_FormMS.AutoSize = true;
            this.chMassMSh_FormMS.Location = new System.Drawing.Point(310, 150);
            this.chMassMSh_FormMS.Name = "chMassMSh_FormMS";
            this.chMassMSh_FormMS.Size = new System.Drawing.Size(134, 20);
            this.chMassMSh_FormMS.TabIndex = 14;
            this.chMassMSh_FormMS.Text = "расчет вручную";
            this.chMassMSh_FormMS.UseVisualStyleBackColor = true;
            this.chMassMSh_FormMS.CheckedChanged += new System.EventHandler(this.chMassMSh_FormMS_CheckedChanged);
            // 
            // chMassMM_FormMS
            // 
            this.chMassMM_FormMS.AutoSize = true;
            this.chMassMM_FormMS.Location = new System.Drawing.Point(310, 120);
            this.chMassMM_FormMS.Name = "chMassMM_FormMS";
            this.chMassMM_FormMS.Size = new System.Drawing.Size(134, 20);
            this.chMassMM_FormMS.TabIndex = 13;
            this.chMassMM_FormMS.Text = "расчет вручную";
            this.chMassMM_FormMS.UseVisualStyleBackColor = true;
            this.chMassMM_FormMS.CheckedChanged += new System.EventHandler(this.chMassMM_FormMS_CheckedChanged);
            // 
            // chMassMK_FormMS
            // 
            this.chMassMK_FormMS.AutoSize = true;
            this.chMassMK_FormMS.Enabled = false;
            this.chMassMK_FormMS.Location = new System.Drawing.Point(310, 90);
            this.chMassMK_FormMS.Name = "chMassMK_FormMS";
            this.chMassMK_FormMS.Size = new System.Drawing.Size(134, 20);
            this.chMassMK_FormMS.TabIndex = 12;
            this.chMassMK_FormMS.Text = "расчет вручную";
            this.chMassMK_FormMS.UseVisualStyleBackColor = true;
            this.chMassMK_FormMS.Visible = false;
            this.chMassMK_FormMS.CheckedChanged += new System.EventHandler(this.chMassMK_FormMS_CheckedChanged);
            // 
            // txtNoteMS_FormMS
            // 
            this.txtNoteMS_FormMS.Location = new System.Drawing.Point(120, 240);
            this.txtNoteMS_FormMS.Name = "txtNoteMS_FormMS";
            this.txtNoteMS_FormMS.Size = new System.Drawing.Size(340, 22);
            this.txtNoteMS_FormMS.TabIndex = 11;
            // 
            // txtMassMSh_FormMS
            // 
            this.txtMassMSh_FormMS.Location = new System.Drawing.Point(190, 150);
            this.txtMassMSh_FormMS.Name = "txtMassMSh_FormMS";
            this.txtMassMSh_FormMS.ReadOnly = true;
            this.txtMassMSh_FormMS.Size = new System.Drawing.Size(80, 22);
            this.txtMassMSh_FormMS.TabIndex = 10;
            // 
            // txtMassMM_FormMS
            // 
            this.txtMassMM_FormMS.Location = new System.Drawing.Point(215, 120);
            this.txtMassMM_FormMS.Name = "txtMassMM_FormMS";
            this.txtMassMM_FormMS.ReadOnly = true;
            this.txtMassMM_FormMS.Size = new System.Drawing.Size(80, 22);
            this.txtMassMM_FormMS.TabIndex = 9;
            // 
            // txtMassMK_FormMS
            // 
            this.txtMassMK_FormMS.Location = new System.Drawing.Point(170, 90);
            this.txtMassMK_FormMS.Name = "txtMassMK_FormMS";
            this.txtMassMK_FormMS.ReadOnly = true;
            this.txtMassMK_FormMS.Size = new System.Drawing.Size(80, 22);
            this.txtMassMK_FormMS.TabIndex = 8;
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
            this.label5.Size = new System.Drawing.Size(172, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Вес монтажных швов, кгс:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Вес монтажных метизов, кгс:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Вес конструкции, кгс:";
            // 
            // txtNameMS_FormMS
            // 
            this.txtNameMS_FormMS.Location = new System.Drawing.Point(130, 60);
            this.txtNameMS_FormMS.Name = "txtNameMS_FormMS";
            this.txtNameMS_FormMS.Size = new System.Drawing.Size(330, 22);
            this.txtNameMS_FormMS.TabIndex = 3;
            // 
            // txtDesignMS_FormMS
            // 
            this.txtDesignMS_FormMS.Location = new System.Drawing.Point(130, 30);
            this.txtDesignMS_FormMS.Name = "txtDesignMS_FormMS";
            this.txtDesignMS_FormMS.Size = new System.Drawing.Size(330, 22);
            this.txtDesignMS_FormMS.TabIndex = 2;
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
            // bSaveDataMS_FormMS
            // 
            this.bSaveDataMS_FormMS.Location = new System.Drawing.Point(203, 280);
            this.bSaveDataMS_FormMS.Name = "bSaveDataMS_FormMS";
            this.bSaveDataMS_FormMS.Size = new System.Drawing.Size(120, 25);
            this.bSaveDataMS_FormMS.TabIndex = 1;
            this.bSaveDataMS_FormMS.Text = "Сохранить";
            this.bSaveDataMS_FormMS.UseVisualStyleBackColor = true;
            this.bSaveDataMS_FormMS.Click += new System.EventHandler(this.bSaveDataMS_FormMS_Click);
            // 
            // bClose_FormMS
            // 
            this.bClose_FormMS.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bClose_FormMS.Location = new System.Drawing.Point(343, 280);
            this.bClose_FormMS.Name = "bClose_FormMS";
            this.bClose_FormMS.Size = new System.Drawing.Size(120, 25);
            this.bClose_FormMS.TabIndex = 2;
            this.bClose_FormMS.Text = "Выйти";
            this.bClose_FormMS.UseVisualStyleBackColor = true;
            this.bClose_FormMS.Click += new System.EventHandler(this.bClose_FormMS_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 310);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(498, 49);
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
            this.richTextBox1.Size = new System.Drawing.Size(492, 30);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "*Поля обязательные для заполнения.";
            // 
            // FormMS
            // 
            this.AcceptButton = this.bSaveDataMS_FormMS;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bClose_FormMS;
            this.ClientSize = new System.Drawing.Size(504, 362);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bClose_FormMS);
            this.Controls.Add(this.bSaveDataMS_FormMS);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMS";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Редактор данных монтажных схем";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNameMS_FormMS;
        private System.Windows.Forms.TextBox txtDesignMS_FormMS;
        private System.Windows.Forms.TextBox txtNoteMS_FormMS;
        private System.Windows.Forms.TextBox txtMassMSh_FormMS;
        private System.Windows.Forms.TextBox txtMassMM_FormMS;
        private System.Windows.Forms.TextBox txtMassMK_FormMS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chMassMSh_FormMS;
        private System.Windows.Forms.CheckBox chMassMM_FormMS;
        private System.Windows.Forms.CheckBox chMassMK_FormMS;
        private System.Windows.Forms.TextBox txtLinkPathDrawing;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLinkPathModel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bSaveDataMS_FormMS;
        private System.Windows.Forms.OpenFileDialog oFDPathModelDrawingMS;
        private System.Windows.Forms.Button bLinkPathDrawing;
        private System.Windows.Forms.Button bLinkPathModel;
        private System.Windows.Forms.Button bClose_FormMS;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}