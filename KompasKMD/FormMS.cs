using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassKMD;

namespace KompasKMD
{
    public partial class FormMS : Form
    {
        private bool flag; // flag - флаг режима добавления новой МС (true) и редактирование МС (false)
        private int indexChangedMS;
        public FormMS() //конструктор формы создания МС
        {
            InitializeComponent();
            flag = true;
            this.Text = "Редактор данных монтажных схем - Новая монтажная схема";
            txtMassMK_FormMS.Text = "0";
            txtMassMM_FormMS.Text = "0";
            txtMassMSh_FormMS.Text = "0";           
        }

        public FormMS(int indexMS, MountingScheme mc) //конструктор формы редактирования МС
        {
            InitializeComponent();
            flag = false;
            this.Text = "Редактор данных монтажных схем - Изменить монтажную схему";
            indexChangedMS = indexMS;
            txtDesignMS_FormMS.Text = mc.DesignMS;
            //txtDesignMS_FormMS.ReadOnly = true;
            txtNameMS_FormMS.Text = mc.NameMS;
            txtMassMK_FormMS.Text = mc.MassMarks.ToString();
            txtMassMM_FormMS.Text = mc.MassMetiz.ToString();
            txtMassMSh_FormMS.Text = mc.MassMontSvarka.ToString();
            txtLinkPathModel.Text = mc.PathModel;
            txtLinkPathDrawing.Text = mc.PathDrawing;
            txtNoteMS_FormMS.Text = mc.Note;
        }

        private void bClose_FormMS_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bSaveDataMS_FormMS_Click(object sender, EventArgs e)
        {
                                   
                MountingScheme tempMS = new MountingScheme();
                if (txtDesignMS_FormMS.Text == "")
                {
                    MessageBox.Show("Не указано обозначение! Обязательное поле.");
                    return;
                }
                tempMS.DesignMS = txtDesignMS_FormMS.Text;
                tempMS.NameMS = txtNameMS_FormMS.Text;
                tempMS.MassMarks = Convert.ToDouble(txtMassMK_FormMS.Text);
                tempMS.MassMetiz = Convert.ToDouble(txtMassMM_FormMS.Text);
                tempMS.MassMontSvarka = Convert.ToDouble(txtMassMSh_FormMS.Text);
                tempMS.PathModel = txtLinkPathModel.Text;
                tempMS.PathDrawing = txtLinkPathDrawing.Text;
                tempMS.Note = txtNoteMS_FormMS.Text;
            if (flag)
            {
                bool result = EventProjectClass.EventAddMSInProjectHandler(tempMS); // событие добавления МС в проект
                if (!result)
                {
                    MessageBox.Show("Монтажная схема не создана! Причины: Монтажная схема с данным обозначением уже существует.");
                    return;
                }
            }
            else
            {
                bool result = EventProjectClass.EventEditMSInProjectHandler(indexChangedMS, tempMS); //событие изменения МС
                if (!result)
                {
                    MessageBox.Show("Монтажная схема не изменена! Причины: Монтажная схема с данным обозначением уже существует.");
                    return;
                }
            }
            
            this.DialogResult = DialogResult.OK;
            Close();            
        }        

        private void bLinkPathModel_Click(object sender, EventArgs e)
        {
            oFDPathModelDrawingMS.Filter = "Файл модели сборки МС|*.a3d";
            if (oFDPathModelDrawingMS.ShowDialog() == DialogResult.OK)
            {                
                txtLinkPathModel.Text = oFDPathModelDrawingMS.FileName;
            }
        }

        private void bLinkPathDrawing_Click(object sender, EventArgs e)
        {
            oFDPathModelDrawingMS.Filter = "Файл чертежа МС|*.cdw";
            if (oFDPathModelDrawingMS.ShowDialog() == DialogResult.OK)
            {                
                txtLinkPathDrawing.Text = oFDPathModelDrawingMS.FileName;
            }
        }

        private void chMassMK_FormMS_CheckedChanged(object sender, EventArgs e)
        {
            if (chMassMK_FormMS.Checked)
            {
                txtMassMK_FormMS.ReadOnly = false;
            }
            else
            {
                txtMassMK_FormMS.ReadOnly = true;
            }
        }

        private void chMassMM_FormMS_CheckedChanged(object sender, EventArgs e)
        {

            if (chMassMM_FormMS.Checked)
            {
                txtMassMM_FormMS.ReadOnly = false;
            }
            else
            {
                txtMassMM_FormMS.ReadOnly = true;
            }
        }

        private void chMassMSh_FormMS_CheckedChanged(object sender, EventArgs e)
        {
            if (chMassMSh_FormMS.Checked)
            {
                txtMassMSh_FormMS.ReadOnly = false;
            }
            else
            {
                txtMassMSh_FormMS.ReadOnly = true;
            }

        }
    }
}
