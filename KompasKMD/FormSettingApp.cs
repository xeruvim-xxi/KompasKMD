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
        LicenseClass lic = new LicenseClass();

        SettingAppClass Setting = new SettingAppClass();

        public FormSettingApp()
        {
            InitializeComponent();
            string File = "license.xml";
            if (!System.IO.File.Exists(File))
            {                
                return;
            }
            lic.Verify();
            txtLogin.Text = lic.Login;
            txtKeyApp.Text = lic.Key;

            txtPathFolderProjs.Text = Setting.PathFolderProjs;

            switch (Setting.Environment)
            {
                case 0:
                    rBKompas.Checked = true;
                    break;
            }
        }

        private void linkKompasKMD_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://kompas-kmd.ru");
        }

        private void bGenSerialNumberApp_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == "")
            {
                MessageBox.Show("Введите email.");
                return;
            }
            string serialNum = lic.GetSerialNumber(txtLogin.Text);
            switch (serialNum)
            {
                case "No":
                    MessageBox.Show("Файл лицензии существует!");
                    bGenSerialNumberApp.Enabled = false;
                    txtKeyApp.ReadOnly = false;
                    bActiveKey.Enabled = true;
                    break;
                default:
                    txtSerialNumber.Text = serialNum;
                    txtKeyApp.ReadOnly = false;
                    bActiveKey.Enabled = true;
                    break; 
            }
        }

        private void bActiveKey_Click(object sender, EventArgs e)
        {
            lic.ActiveLicense(txtKeyApp.Text);

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
