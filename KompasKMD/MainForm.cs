using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KompasKMD
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void bCreateProjectKMD_Click(object sender, EventArgs e)
        {
            FormKMD_Proj FormNewKMD = new FormKMD_Proj(0, this); // форма для нового проекта КМД 
            FormNewKMD.Show();
            this.Visible = false;
        }

        private void bOpenProjectKMD_Click(object sender, EventArgs e)
        {
            FormKMD_Proj FormOpenKMD = new FormKMD_Proj(1, this); //форма для открытия проекта КМД 
            FormOpenKMD.Show();
            this.Visible = false;
        }

        private void bSettingApp_Click(object sender, EventArgs e)
        {
            FormSettingApp FormSetting = new FormSettingApp(); // форма настроек приложения
            if (FormSetting.ShowDialog() == DialogResult.OK)
            {
                return;
            }
        }
    }
}
