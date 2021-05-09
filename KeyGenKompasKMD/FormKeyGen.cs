using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyGenKompasKMD
{
    public partial class FormKeyGen : Form
    {
        public FormKeyGen()
        {
            InitializeComponent();
        }

        private void bGenKeyApp_Click(object sender, EventArgs e)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(txtLogin.Text + txtSerialNumber.Text + "КМД_КОМПАС");
            byte[] hash = md5.ComputeHash(data);
            txtKeyApp.Text = Convert.ToBase64String(hash);
        }
    }
}
