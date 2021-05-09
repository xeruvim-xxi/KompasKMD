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
    public partial class FormSettingOE : Form
    {
        public FormSettingOE(int indexMarka, SettingMarkaKMD setting)
        {
            InitializeComponent();
            num_KoffSSh.Value = (decimal)(setting.kofSvarka * 100);
            cB_SSh.Checked = !setting.RazSvarka;
            numKoffZinc.Value = (decimal)(setting.kofZinc * 100);
            cB_Zinc.Checked = !setting.ZinkCoat;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bSaveSettingMarka_Click(object sender, EventArgs e)
        {
            if (!TestParam())
            {
                MessageBox.Show("Ошибка при вводе значений коэффициентов.");
                return;
            }
            SettingMarkaKMD setting = new SettingMarkaKMD();
            setting.kofSvarka = (double)(num_KoffSSh.Value / 100);
            setting.RazSvarka = !cB_SSh.Checked;
            setting.kofZinc = (double)(numKoffZinc.Value / 100);
            setting.ZinkCoat = !cB_Zinc.Checked;
            EventProjectClass.EventSettingMarkaHandler(setting); // событие изменения настроек марки
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private bool TestParam()
        {
            double kss = (double)(num_KoffSSh.Value / 100);
            if((kss<0) && (kss >= 1))
            {
                return false;
            }
            double kz = (double)(numKoffZinc.Value / 100);
            if ((kz < 0) && (kz >= 1))
            {
                return false;
            }
            return true;
        }
    }
}
