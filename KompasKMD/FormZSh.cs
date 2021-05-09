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
    public partial class FormZSh : Form
    {
        private bool flag; // flag - флаг режима добавления нового CШ(true) и редактирование CШ (false)
        private int indexChangedZSh;


        public FormZSh() //конструктор формы создания CШ
        {
            InitializeComponent();
            flag = true;
            this.Text = "Редактор данных сварных заводских швов - Новый шов";
        }

        public FormZSh(int indexZSh, ZSh zsh) // конструктор формы редактирования CШ
        {
            InitializeComponent();
            flag = false;
            this.Text = "Редактор данных сварных заводских швов - Изменить шов";
            indexChangedZSh = indexZSh;
            txtTypeSech.Text = zsh.TypeSech;
            n_KatetShva.Value = zsh.KatetShva;
            n_Length.Value = (decimal)zsh.LenghtSh;
            txtNote.Text = zsh.Note;
        }



        private void bSaveDataList_FormListMsh_Click(object sender, EventArgs e)
        {
            ZSh tempZSh = new ZSh();
            if ((txtTypeSech.Text == "") && (n_KatetShva.Value == 0))
            {
                MessageBox.Show("Не указаны необходимые параметры! См. Справку ниже...");
                return;
            }

            tempZSh.TypeSech = txtTypeSech.Text;
            tempZSh.KatetShva = (int)n_KatetShva.Value;
            tempZSh.LenghtSh = (double)n_Length.Value;
            tempZSh.Note = txtNote.Text;

            if (flag)
            {
                bool result = EventProjectClass.EventAddZShHandler(tempZSh); // событие добавления CШ
                if (!result)
                {
                    MessageBox.Show("Сварной шов не создан! Причины: С данным параметрами шов уже существует. Измените длину.");
                    return;
                }
            }
            else
            {
                bool result = EventProjectClass.EventEditZShHandler(indexChangedZSh, tempZSh); //событие изменения CШ
                if (!result)
                {
                    MessageBox.Show("Сварной шов не изменен! Причины: С данным параметрами шов уже существует.");
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void bClose_FormListMsh_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
