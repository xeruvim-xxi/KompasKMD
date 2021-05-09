using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassKMD
{
    public partial class FormMM : Form
    {
        private bool flag; // flag - флаг режима добавления нового МM(true) и редактирование МM (false)
        private int indexChangedMM;

        public FormMM()  //конструктор формы создания ММ
        {
            InitializeComponent();
            flag = true;
            this.Text = "Редактор данных монтажных метизов - Новый стандартный элемент";
        }

        public FormMM(int indexMM, MM mm) // //конструктор формы редактирования MM
        {
            InitializeComponent();
            flag = false;
            this.Text = "Редактор данных монтажных метизов - Изменить стандартный элемент";
            indexChangedMM = indexMM;
            tb_Name.Text = mm.Name;
            tb_Diameter.Text = mm.Diameter;
            tb_ThicknessPackage.Text = mm.ThicknessPackage.ToString();
            tb_Length.Text = mm.Length.ToString();
            tb_Quantity.Text = mm.Quantity.ToString();
            tb_Mass.Text = mm.Mass.ToString();
            tb_GOST.Text = mm.GOST;
            tb_ClassStrength.Text = mm.ClassStrength;
            tb_Note.Text = mm.Note;
        }

        private void bSaveDataMM_Click(object sender, EventArgs e)
        {
            MM tempMM = new MM();
            if ((tb_Name.Text == "") && (tb_Diameter.Text == "") && (tb_Length.Text == "") && (tb_Mass.Text == "") && (tb_GOST.Text == "") && (tb_ClassStrength.Text == ""))
            {
                MessageBox.Show("Не указаны необходимые параметры! См. Справку ниже...");
                return;
            }
            
            tempMM.Name = tb_Name.Text;
            tempMM.Diameter = tb_Diameter.Text;
            tempMM.ThicknessPackage = Convert.ToDouble(tb_ThicknessPackage.Text);
            tempMM.Length = Convert.ToDouble(tb_Length.Text);
            tempMM.Quantity = Convert.ToInt32(tb_Quantity.Text);
            tempMM.Mass = Convert.ToDouble(tb_Mass.Text);
            tempMM.GOST = tb_GOST.Text;
            tempMM.ClassStrength = tb_ClassStrength.Text;
            tempMM.Note = tb_Note.Text;

            if (flag)
            {
                bool result = EventProjectClass.EventAddMMInMSHandler(tempMM); // событие добавления МM в МС
                if (!result)
                {
                    MessageBox.Show("Стандартный элемент не создан! Причины: С данным параметрами метизы уже существуют.");
                    return;
                }
            }
            else
            {
                bool result = EventProjectClass.EventEditMMInMSHandler(indexChangedMM, tempMM); //событие изменения МM
                if (!result)
                {
                    MessageBox.Show("Стандартный элемент не изменен! Причины: С данным параметрами метизы уже существуют.");
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
