namespace KompasKMD
{
    partial class FormSettingOE
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
            this.cB_SSh = new System.Windows.Forms.CheckBox();
            this.num_KoffSSh = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numKoffZinc = new System.Windows.Forms.NumericUpDown();
            this.cB_Zinc = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.bSaveSettingMarka = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_KoffSSh)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKoffZinc)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cB_SSh);
            this.groupBox1.Controls.Add(this.num_KoffSSh);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сварные швы:";
            // 
            // cB_SSh
            // 
            this.cB_SSh.AutoSize = true;
            this.cB_SSh.Location = new System.Drawing.Point(10, 50);
            this.cB_SSh.Name = "cB_SSh";
            this.cB_SSh.Size = new System.Drawing.Size(149, 20);
            this.cB_SSh.TabIndex = 2;
            this.cB_SSh.Text = "не брать в расчет*";
            this.cB_SSh.UseVisualStyleBackColor = true;
            // 
            // num_KoffSSh
            // 
            this.num_KoffSSh.Location = new System.Drawing.Point(230, 20);
            this.num_KoffSSh.Name = "num_KoffSSh";
            this.num_KoffSSh.Size = new System.Drawing.Size(70, 22);
            this.num_KoffSSh.TabIndex = 1;
            this.num_KoffSSh.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Коэффициент сварных швов, %:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numKoffZinc);
            this.groupBox2.Controls.Add(this.cB_Zinc);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(3, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 80);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Покрытие:";
            // 
            // numKoffZinc
            // 
            this.numKoffZinc.Location = new System.Drawing.Point(230, 20);
            this.numKoffZinc.Name = "numKoffZinc";
            this.numKoffZinc.Size = new System.Drawing.Size(70, 22);
            this.numKoffZinc.TabIndex = 2;
            this.numKoffZinc.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // cB_Zinc
            // 
            this.cB_Zinc.AutoSize = true;
            this.cB_Zinc.Location = new System.Drawing.Point(10, 50);
            this.cB_Zinc.Name = "cB_Zinc";
            this.cB_Zinc.Size = new System.Drawing.Size(154, 20);
            this.cB_Zinc.TabIndex = 1;
            this.cB_Zinc.Text = "не брать в расчет**";
            this.cB_Zinc.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Коэффициент цинка, %:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBox1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 199);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(328, 90);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Справка:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 16);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(322, 71);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "*Учет веса и отображение наплавленный металл в чертеже марке не производиться.\n**" +
    "Учет веса и отображение цинка в чертеже марке не производиться.\n";
            // 
            // bSaveSettingMarka
            // 
            this.bSaveSettingMarka.Location = new System.Drawing.Point(100, 170);
            this.bSaveSettingMarka.Name = "bSaveSettingMarka";
            this.bSaveSettingMarka.Size = new System.Drawing.Size(100, 25);
            this.bSaveSettingMarka.TabIndex = 5;
            this.bSaveSettingMarka.Text = "Сохранить";
            this.bSaveSettingMarka.UseVisualStyleBackColor = true;
            this.bSaveSettingMarka.Click += new System.EventHandler(this.bSaveSettingMarka_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(230, 170);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(100, 25);
            this.bCancel.TabIndex = 6;
            this.bCancel.Text = "Отмена";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // FormSettingOE
            // 
            this.AcceptButton = this.bSaveSettingMarka;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(334, 292);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSaveSettingMarka);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettingOE";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Настройки марки";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_KoffSSh)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKoffZinc)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cB_SSh;
        private System.Windows.Forms.NumericUpDown num_KoffSSh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numKoffZinc;
        private System.Windows.Forms.CheckBox cB_Zinc;
        private System.Windows.Forms.Button bSaveSettingMarka;
        private System.Windows.Forms.Button bCancel;
    }
}