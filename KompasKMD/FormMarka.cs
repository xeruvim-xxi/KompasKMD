using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassKMD;

namespace KompasKMD
{
    public partial class FormMarka : Form
    {
        private bool flag; // flag - флаг режима добавления новой марки (true) и редактирование марки (false)
        private int indexChangedMarka;

        public FormMarka()  //конструктор формы создания новой марки
        {
            InitializeComponent();
            flag = true;
            this.Text = "Редактор данных отправочных элементов - Новый элемент";
            List<ListOE> lists = new List<ListOE>();
            lists = EventProjectClass.EventArrayListOEHandler();
            cbListOE.Items.Clear();
            cbListOE.Items.Add("");
            foreach (ListOE list in lists)
            {
                cbListOE.Items.Add(list.DesignList);
            }
        }

        public FormMarka(int indexMarka, MarkaKMD marka)  //конструктор формы создания новой марки
        {
            InitializeComponent();
            flag = false;
            this.Text = "Редактор данных отправочных элементов - Изменить элемент";
            indexChangedMarka = indexMarka;
            txtDesignMarka.Text = marka.DesignMarka;
            txtNameMarka.Text = marka.NameMarka;
            numOEInMS.Value = marka.KolTInMS;
            txtMassOE.Text = marka.MassMarka.ToString();
            double massAllMarks = marka.KolTInMS * marka.MassMarka;
            txtMassAllOE.Text = massAllMarks.ToString();
            List<ListOE> lists = new List<ListOE>();
            lists = EventProjectClass.EventArrayListOEHandler();
            cbListOE.Items.Clear();
            cbListOE.Items.Add("");
            foreach (ListOE list in lists)
            {
                cbListOE.Items.Add(list.DesignList);
            }
            cbListOE.Text = marka.DesignList;
            txtLinkPathModel.Text = marka.PathModel;
            txtNoteMarka.Text = marka.Note;
        }

        private void bLinkPathModel_Click(object sender, EventArgs e)
        {
            oFDPathModel.Filter = "Файл модели сборки отправочного элемента|*.a3d";
            if (oFDPathModel.ShowDialog() == DialogResult.OK)
            {
                txtLinkPathModel.Text = oFDPathModel.FileName;
            }
        }

        private void bClose_FormMarka_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bSaveDataMarka_Click(object sender, EventArgs e)
        {
            MarkaKMD tempMarka = new MarkaKMD();
            if (txtDesignMarka.Text == "")
            {
                MessageBox.Show("Не указано обозначение! Обязательное поле.");
                return;
            }
            tempMarka.DesignMarka = txtDesignMarka.Text;
            tempMarka.NameMarka = txtNameMarka.Text;
            tempMarka.KolTInMS = Convert.ToInt32(numOEInMS.Value);
            tempMarka.MassMarka = Convert.ToDouble(txtMassOE.Text);
            tempMarka.DesignList = cbListOE.Text;
            tempMarka.PathModel = txtLinkPathModel.Text;
            tempMarka.Note = txtNoteMarka.Text;
            if (flag)
            {
                bool result = EventProjectClass.EventAddMarkaInMSHandler(tempMarka); // событие добавления марки в МС
                if (!result)
                {
                    MessageBox.Show("Отправочный элемент не создан! Причины: ОЭ с данным обозначением уже существует.");
                    return;
                }
            }
            else
            {
                bool result = EventProjectClass.EventEditMarkaInMSHandler(indexChangedMarka, tempMarka); //событие изменения ОЭ
                if (!result)
                {
                    MessageBox.Show("Отправочный элемент не изменен! Причины: ОЭ с данным обозначением уже существует.");
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }

       

    }
}
