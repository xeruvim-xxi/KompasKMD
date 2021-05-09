namespace KompasKMD
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bSettingApp = new System.Windows.Forms.Button();
            this.bOpenProjectKMD = new System.Windows.Forms.Button();
            this.bCreateProjectKMD = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bSettingApp);
            this.groupBox3.Controls.Add(this.bOpenProjectKMD);
            this.groupBox3.Controls.Add(this.bCreateProjectKMD);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 182);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Панель управления:";
            // 
            // bSettingApp
            // 
            this.bSettingApp.Location = new System.Drawing.Point(50, 140);
            this.bSettingApp.Name = "bSettingApp";
            this.bSettingApp.Size = new System.Drawing.Size(150, 30);
            this.bSettingApp.TabIndex = 2;
            this.bSettingApp.Text = "Настройки";
            this.bSettingApp.UseVisualStyleBackColor = true;
            this.bSettingApp.Click += new System.EventHandler(this.bSettingApp_Click);
            // 
            // bOpenProjectKMD
            // 
            this.bOpenProjectKMD.Location = new System.Drawing.Point(30, 80);
            this.bOpenProjectKMD.Name = "bOpenProjectKMD";
            this.bOpenProjectKMD.Size = new System.Drawing.Size(190, 40);
            this.bOpenProjectKMD.TabIndex = 1;
            this.bOpenProjectKMD.Text = "Открыть проект КМД";
            this.bOpenProjectKMD.UseVisualStyleBackColor = true;
            this.bOpenProjectKMD.Click += new System.EventHandler(this.bOpenProjectKMD_Click);
            // 
            // bCreateProjectKMD
            // 
            this.bCreateProjectKMD.Location = new System.Drawing.Point(30, 30);
            this.bCreateProjectKMD.Name = "bCreateProjectKMD";
            this.bCreateProjectKMD.Size = new System.Drawing.Size(190, 40);
            this.bCreateProjectKMD.TabIndex = 0;
            this.bCreateProjectKMD.Text = "Создать проект КМД";
            this.bCreateProjectKMD.UseVisualStyleBackColor = true;
            this.bCreateProjectKMD.Click += new System.EventHandler(this.bCreateProjectKMD_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 182);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Компас-КМД";
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bOpenProjectKMD;
        private System.Windows.Forms.Button bCreateProjectKMD;
        private System.Windows.Forms.Button bSettingApp;
    }
}

