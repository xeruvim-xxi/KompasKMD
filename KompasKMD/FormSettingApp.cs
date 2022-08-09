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
using System.Xml;

namespace KompasKMD
{
    public partial class FormSettingApp : Form
    {
        

        SettingAppClass Setting = new SettingAppClass();

        public FormSettingApp()
        {
            InitializeComponent();            

            txtPathFolderProjs.Text = Setting.PathFolderProjs;

            switch (Setting.Environment)
            {
                case 0:
                    rBKompas.Checked = true;
                    break;
            }
        }
          
        private void bSelectFolderProjs_Click(object sender, EventArgs e)
        {
            if (fBD_FolderProjs.ShowDialog() == DialogResult.OK)
            {
                Setting.PathFolderProjs = fBD_FolderProjs.SelectedPath;
                txtPathFolderProjs.Text = Setting.PathFolderProjs;
            }
        }

        private void bSaveSettingApp_Click(object sender, EventArgs e)
        {
            Setting.Save();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                switch (radioButton.Text)
                {
                    case "Компас 3D":
                        Setting.Environment = 0;
                        break;
                }
            }
        }
    }
}
