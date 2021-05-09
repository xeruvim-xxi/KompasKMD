using System;
using System.IO;
using System.Security.Cryptography;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KompasKMD
{
    class LicenseClass
    {
        public string Key { get; private set; }
        public string Login { get; private set; }
        DateTime DateInstall;
        DateTime DateSys;
        public string KodLic { get; private set; }

        public void Verify()
        {
            string File = "license.xml";
            if (!System.IO.File.Exists(File))
            {
                KodLic = "FREE_";
                MessageBox.Show("Не найден файл лицензии.");
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(File);
            string sig = "";
            string Signature = "";
            try
            {
                string login = doc.ChildNodes[0].SelectSingleNode(@"/license/l1", null).InnerText;
                Signature = doc.ChildNodes[0].SelectSingleNode(@"/license/l2", null).InnerText;
                DirectoryInfo dirApp = new DirectoryInfo(Directory.GetCurrentDirectory());
                this.DateInstall = dirApp.CreationTime;
                string dateI = dirApp.CreationTime.ToString();
                DirectoryInfo dir = new DirectoryInfo(Environment.SystemDirectory);
                this.DateSys = dir.CreationTime;
                string dateS = dir.CreationTime.ToString();
                this.Key = Signature;
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] data = System.Text.Encoding.UTF8.GetBytes(login + dateI + dateS + "КМД_КОМПАС");
                byte[] hash = md5.ComputeHash(data);
                string s = Convert.ToBase64String(hash);
                byte[] data1 = System.Text.Encoding.UTF8.GetBytes(login + s + "КМД_КОМПАС");
                byte[] hash1 = md5.ComputeHash(data1);
                sig = Convert.ToBase64String(hash1);
                this.Login = login;
                KodLic = "FULL_";
            }
            catch (Exception)
            {
                MessageBox.Show("Лицензия не подтверждена.");
                KodLic = "FREE_";
            }

            if (sig != Signature)
            {
                MessageBox.Show("Лицензия не подтверждена.");
                KodLic = "FREE_";
            }
            if (DateTime.Now < this.DateInstall)
            {
                MessageBox.Show("Лицензия не подтверждена.");
                KodLic = "FREE_";
            }

        }

        public string  GetSerialNumber(string log)
        {
            string File = "license.xml";
            if (System.IO.File.Exists(File))
            {
                return "No";
            }
            Login = log;            
            DirectoryInfo dirApp = new DirectoryInfo(Directory.GetCurrentDirectory());
            DateInstall = dirApp.CreationTime;
            string dateI = DateInstall.ToString();             
            DirectoryInfo dir = new DirectoryInfo(Environment.SystemDirectory);
            DateSys = dir.CreationTime;
            string dateS = DateSys.ToString();
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(log + dateI + dateS + "КМД_КОМПАС");
            byte[] hash = md5.ComputeHash(data);
            return Convert.ToBase64String(hash);
        }

        public void ActiveLicense(string key)
        {
            string File = "license.xml";
            if (System.IO.File.Exists(File))
            {
                MessageBox.Show("Файл лицензии уже существует.");
                return;
            }
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(@"<license>
            <l1></l1>
            <l2></l2>
            </license>");
            doc.ChildNodes[0].SelectSingleNode(@"/license/l1", null).InnerText = Login;
            doc.ChildNodes[0].SelectSingleNode(@"/license/l2", null).InnerText = key;
            doc.Save("license.xml");
        }        
    }
}
