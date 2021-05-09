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
    public partial class FormListOE : Form
    {
        private bool flag; // flag - флаг режима добавления нового листа (true) и редактирование листа (false)
        private int indexChangedList;

        public FormListOE() //конструктор формы создания листа
        {
            InitializeComponent();
            flag = true;
            this.Text = "Редактор данных листов отправочных элементов - Новый лист";
            txtMassMKOnList_FormListOE.Text = "0";            
        }


        public FormListOE(int indexList, ListOE list) //конструктор формы редактирования листа
        {
            InitializeComponent();
            flag = false;
            this.Text = "Редактор данных листов отправочных элементов - Изменить лист";
            indexChangedList = indexList;
            txtDesignList_FormListOE.Text = list.DesignList;
            txtNameList_FormListOE.Text = list.NameList;
            txtMassMKOnList_FormListOE.Text = list.Mass.ToString();
            txtLinkPathDrawing.Text = list.PathDrawing;
            txtNoteList_FormListOE.Text = list.Note;
        }

        private void bClose_FormListOE_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bSaveDataList_FormListOE_Click(object sender, EventArgs e)
        {
            ListOE tempList = new ListOE();
            if (txtDesignList_FormListOE.Text == "")
            {
                MessageBox.Show("Не указано обозначение! Обязательное поле.");
                return;
            }
            tempList.DesignList = txtDesignList_FormListOE.Text;
            tempList.NameList = txtNameList_FormListOE.Text;
            tempList.Mass = Convert.ToDouble(txtMassMKOnList_FormListOE.Text);
            tempList.PathDrawing = txtLinkPathDrawing.Text;
            tempList.Note = txtNoteList_FormListOE.Text;
            if (flag)
            {
                bool result = EventProjectClass.EventAddListInMSHandler(tempList); // событие добавления листа в МС
                if (!result)
                {
                    MessageBox.Show("Лист ОЭ не создан! Причины: Лист с данным обозначением уже существует.");
                    return;
                }
            }
            else
            {
                bool result = EventProjectClass.EventEditListInMSHandler(indexChangedList, tempList); //событие изменения листа
                if (!result)
                {
                    MessageBox.Show("Лист не изменен! Причины: Лист с данным обозначением уже существует.");
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void bLinkPathDrawing_Click(object sender, EventArgs e)
        {
            oFDPathDrawingListOE.Filter = "Файл чертежа листа|*.cdw";
            if (oFDPathDrawingListOE.ShowDialog() == DialogResult.OK)
            {
                txtLinkPathDrawing.Text = oFDPathDrawingListOE.FileName;
            }
        }
    }
}
