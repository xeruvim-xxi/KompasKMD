using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ClassKMD
{

    public class SettingAppClass
    {
        public string PathFolderProjs { set; get; } // путь общей папки проектов
        public string PathLibMaterial { set; get; } // путь к библетеке материалов
        public string SufList { set; get; } // суффикс для обозначения листов
        public string SufМS { set; get; } // суффикс для обозначения МС
        public int Environment { set; get; } // среда разработки 0 - Компас; 1 - SolidWorks

        public SettingAppClass()
        {
            Load();
        }

        public void Load() // загрузка настроек  из файла
        {
            string File = "Setting.xml";
            if (!System.IO.File.Exists(File))
            {
                PathFolderProjs = @"C:\";
                Environment = 0;
                return;
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(File);
            PathFolderProjs = doc.ChildNodes[0].SelectSingleNode(@"/settingApp/folderProjects", null).InnerText;
            Environment = Convert.ToInt32(doc.ChildNodes[0].SelectSingleNode(@"/settingApp/environment", null).InnerText);
        }

        public void Save()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(@"<settingApp>
            <folderProjects></folderProjects>
            <environment></environment>
            </settingApp>");
            doc.ChildNodes[0].SelectSingleNode(@"/settingApp/folderProjects", null).InnerText = PathFolderProjs;
            doc.ChildNodes[0].SelectSingleNode(@"/settingApp/environment", null).InnerText = Environment.ToString();
            doc.Save("Setting.xml");
        }
    }
}
