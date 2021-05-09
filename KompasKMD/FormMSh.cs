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
    public partial class FormMSh : Form
    {
        private bool flag; // flag - флаг режима добавления нового МШ(true) и редактирование МШ (false)
        private int indexChangedMSh;

        public FormMSh() //конструктор формы создания МШ
        {
            InitializeComponent();
            flag = true;
            this.Text = "Редактор данных монтажных швов - Новый шов";
            List<MarkaKMD> marks = new List<MarkaKMD>();
            marks = EventProjectClass.EventArrayMarksHandler();
            cBMarka.Items.Clear();
            foreach (MarkaKMD marka in marks)
            {
                cBMarka.Items.Add(marka.DesignMarka);
            }
        }

        public FormMSh(int indexMSh, MSh msh) // //конструктор формы редактирования МШ
        {
            InitializeComponent();
            flag = false;
            this.Text = "Редактор данных монтажных швов - Изменить шов";
            indexChangedMSh = indexMSh;
            List<MarkaKMD> marks = new List<MarkaKMD>();
            marks = EventProjectClass.EventArrayMarksHandler();
            cBMarka.Items.Clear();
            foreach (MarkaKMD marka in marks)
            {
                cBMarka.Items.Add(marka.DesignMarka);
            }            
            cBMarka.Text = msh.Marka;
            n_KolElem.Text = msh.CountElements.ToString();
            txtTypeShva.Text = msh.TypeShva;
            n_thick.Text = msh.TolschShva.ToString();
            n_length.Text = msh.DlinaShva.ToString();
            txtTypeELect.Text = msh.TypeElectrod;
            txtNote.Text = msh.Note;
        }

        private void bClose_FormListMsh_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bSaveDataList_FormListMsh_Click(object sender, EventArgs e)
        {
            MSh tempMSh = new MSh();
            if ((cBMarka.Text == "") && (txtTypeShva.Text == "") && (n_thick.Value==0) && (n_length.Value == 0))
            {
                MessageBox.Show("Не указаны необходимые параметры! См. Справку ниже...");
                return;
            }

            tempMSh.Marka = cBMarka.Text;
            tempMSh.CountElements = (int)n_KolElem.Value;
            tempMSh.TypeShva = txtTypeShva.Text;
            tempMSh.TolschShva = (int)n_thick.Value;
            tempMSh.DlinaShva = (double)n_length.Value;
            tempMSh.TypeElectrod = txtTypeELect.Text;
            tempMSh.Note = txtNote.Text;
            
            if (flag)
            {
                bool result = EventProjectClass.EventAddMShInMSHandler(tempMSh); // событие добавления МШ в МС
                if (!result)
                {
                    MessageBox.Show("Монтажный шов не создан! Причины:С данным параметрами шов уже существует. Измените длину.");
                    return;
                }
            }
            else
            {
                bool result = EventProjectClass.EventEditMShInMSHandler(indexChangedMSh, tempMSh); //событие изменения МШ
                if (!result)
                {
                    MessageBox.Show("Монтажный шов не изменен! Причины:С данным параметрами шов уже существует.");
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
