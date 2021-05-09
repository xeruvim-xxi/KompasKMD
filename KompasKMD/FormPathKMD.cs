//#define __LIGHT_VERSION__
#if (__LIGHT_VERSION__)
	using Kompas6LTAPI5;
#else
using Kompas6API5;
#endif
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kompas6Constants;
using Kompas6Constants3D;
using KAPITypes;
using KompasAPI7;
using FuncKompas;
using ClassKMD;

namespace KompasKMD
{
    public partial class FormPathKMD : Form
    {
        private bool flag; // flag - флаг режима добавления новой детали (true) и редактирование (false)
        private int indexChangedPart;
        KompasObject kompas5;
        //private int PosPart = 1;

        public FormPathKMD(int pos, KompasObject kompas) //конструктор формы создания детали
        {
            InitializeComponent();
            kompas5 = kompas;
            flag = true;
            this.Text = "Редактор данных деталей ОЭ - Новая деталь";
            numPosPart.Value = pos;
            chMassPart.Checked = false;
        }

        public FormPathKMD(int indexPart, PartKMD part, KompasObject kompas) //конструктор формы изменения детали
        {
            InitializeComponent();
            kompas5 = kompas;
            flag = false;
            this.Text = "Редактор данных деталей ОЭ - Изменить деталь";
            chMassPart.Checked = false;
            indexChangedPart = indexPart;
            numPosPart.Value = part.PosInMarka;
            numKolTPart.Value = part.KolTInMarka;
            numKolNPart.Value = part.KolNInMarka;
            txtProfillePart.Text = part.ProfPart.NameProf;
            numLengthPart.Value = (decimal)part.LengthPart;
            txtMassPart.Text = part.MassPart.ToString();
            txtMaterialPart.Text = part.MaterialPart.Name;
            txtLinkPathModel.Text = part.PathModel;
            txtNote.Text = part.Note;
        }



        private void chMassPart_CheckedChanged(object sender, EventArgs e) // разрешить изменять массу вручную
        {
            if (chMassPart.Checked)
            {
                txtMassPart.ReadOnly = false;
            }
            else
            {
                txtMassPart.ReadOnly = true;
            }
        }

        private void bSaveDataPart_Click(object sender, EventArgs e)
        {
            PartKMD tempPart = new PartKMD();
            if ((txtProfillePart.Text == "") || (txtMaterialPart.Text == ""))
            {
                MessageBox.Show("Не указаны сечение или материал! Обязательные поля.");
                return;
            }

            if ((numKolTPart.Value == 0) && (numKolNPart.Value == 0))
            {
                MessageBox.Show("Количество даталей равно нулю!");
                return;
            }

            tempPart.PosInMarka = (int)numPosPart.Value;
            tempPart.KolTInMarka = (int)numKolTPart.Value;
            tempPart.KolNInMarka = (int)numKolNPart.Value;
            tempPart.ProfPart.NameProf = txtProfillePart.Text;
            tempPart.LengthPart = (double)numLengthPart.Value;
            double masspart = Convert.ToDouble(txtMassPart.Text);
            if (masspart < 0)
            {
                MessageBox.Show("Отрицательная масса :). Поздравляю, Вы выше законов физики!");
                return;
            }
            tempPart.MassPart = masspart;
            tempPart.MaterialPart.Name = txtMaterialPart.Text;
            tempPart.PathModel = txtLinkPathModel.Text;
            tempPart.Note = txtNote.Text;

            if (flag)
            {
                bool result = EventProjectClass.EventAddPartInMarkaHandler(tempPart); // событие добавления детали
                if (!result)
                {
                    MessageBox.Show("Деталь не создана! Причины: Деталь на данной позиции уже существует.");
                    return;
                }
            }
            else
            {
                bool result = EventProjectClass.EventEditPartInMarkaHandler(indexChangedPart, tempPart); //событие изменения детали
                if (!result)
                {
                    MessageBox.Show("Деталь не изменена! Причины: Деталь на данной позиции уже существует.");
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            Close();

        }

        private void bLinkPathModel_Click(object sender, EventArgs e)
        {
            string pathModel = "";
            oFDPathModel.Filter = "Файл модели детали|*.m3d";
            if (oFDPathModel.ShowDialog() == DialogResult.OK)
            {
                pathModel = oFDPathModel.FileName;
                txtLinkPathModel.Text = pathModel;
            } else { return;}

            KompasClass komp = new KompasClass(kompas5, "");
            double mass = komp.GetMassModel(pathModel); // масса в кг
            if (mass == -1)
            {
                MessageBox.Show("Не удалось получить вес детали!");
                return;
            }
            txtMassPart.Text = mass.ToString("N2");
            string[] materialModel = komp.GetMaterialModel(pathModel);
            int KolStr = materialModel.Length;
            if (KolStr == 2)
            {
                txtProfillePart.Text = materialModel[0];
                txtMaterialPart.Text = materialModel[1];
            } else
            {
                txtMaterialPart.Text = materialModel[0];
            }
        }
    }
}
