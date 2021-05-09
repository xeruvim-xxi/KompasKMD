//#define __LIGHT_VERSION__
#if (__LIGHT_VERSION__)
	using Kompas6LTAPI5;
#else
using Kompas6API5;
#endif

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Kompas6Constants;
using Kompas6Constants3D;
using KAPITypes;
using KompasAPI7;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swcommands;
using SolidWorks.Interop.swconst;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.InteropServices;
using FuncKompas;
using ClassKMD;
using Vedomosts;
using System.Diagnostics;
using System.Threading;

namespace KompasKMD
{
   
    public partial class FormKMD_Proj  : Form
    {
        LicenseClass license = new LicenseClass();
        SettingAppClass SettingApp = new SettingAppClass();
        KompasObject kompas;
        bool flagKompas = false; // true - есть подлючение, false - нет подключения к Компасу
        MainForm MainF;  //ссылка на родительское окно
        string NameApp = "Компас-КМД Ведомости";
        private ProjectClass currentProj = new ProjectClass(); // текущий проект
        private int indexCurrentMS = -1; // индекс текущей МС
        private int indexCurrentMarka = -1; // индекс текущей марки (ОЭ)


        public FormKMD_Proj(/*KompasObject k,*/ int typeload, MainForm mainF) // конструктор формы (к - ссылка на объкт приложения Компаса, typeload - тип загрузки (0-новый проект, 1 - открыть проект))
        {            
            InitializeComponent();
            //проверка лицензии
            //license.Verify();
            //if (license.KodLic == "FREE_")
            //{
            //    NameApp = "Компас-КМД(TRIAL) Ведомости";
            //}
            //проверка лицензии

            // настройка приложения
            folderProj.SelectedPath = SettingApp.PathFolderProjs;
            oFDOpenFileProj.InitialDirectory = SettingApp.PathFolderProjs;
            oFDIndicatePathDrawingOD.InitialDirectory = SettingApp.PathFolderProjs;
            EventProjectClass.EventValueProgressHandler = new EventProjectClass.EventValueProgress(ChangeProgress);
            // настройка приложения

            MainF = mainF; //ссылка на родительское окно
            TestConnectKompas();
            ///////////////////////

            switch (typeload)
            {
                case 0:
                    this.Text = NameApp+ " - Новый проект";
                    break;
                case 1:
                    oFDOpenFileProj.Filter = "Файл проекта|*.kmdproj";

                    if (oFDOpenFileProj.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = oFDOpenFileProj.FileName;

                        // создаем объект для сериализации
                        BinaryFormatter formatter = new BinaryFormatter();

                        // создаем объект файлового потока
                        FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                        try
                        {
                            // загрузка данных проекта
                            currentProj = (ProjectClass)formatter.Deserialize(fileStream);
                            currentProj.setPathDirProj(Path.GetDirectoryName(fileName));
                        }
                        catch (Exception)
                        {
                            //MessageBox.Show(e.Message);
                            fileStream.Close();
                            MessageBox.Show("Неверная структура файла!");
                            this.Text = NameApp + " - Новый проект";
                            return;
                        }                       

                        // закрытие потока
                        fileStream.Close();

                        LoadProjectData(); // загружаем данные проекта

                        UpdateVedomsts();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось открыть файл проекта!");
                        this.Text = NameApp + " - Новый проект";
                        return;
                    }                    
                    break;
            }            
        }

        private bool TestParamDataProj() // метод проверки необходимых данных проекта
        {
            if (txtFolderProj.Text == "")
            {
                MessageBox.Show("Выберите папку для проекта!");
                return false;
            }
            if (txtShifrProj.Text == "")
            {
                MessageBox.Show("Проект без шифра!");
                return false;
            }
            if (txtNameProj.Text == "")
            {
                MessageBox.Show("Проект без названия!");
                return false;
            }
            return true;
        }

        private void bFolderProj_Click(object sender, EventArgs e) // метод установки папки проекта
        {
            if (folderProj.ShowDialog() == DialogResult.OK)
            {
                txtFolderProj.Text = folderProj.SelectedPath;
            }

        }

        private void bPathDrawingOD_Click(object sender, EventArgs e) // метод установки пути к заглавному листу
        {
            oFDIndicatePathDrawingOD.Filter = "Файл заглавного листа|*.cdw";

            if (oFDIndicatePathDrawingOD.ShowDialog() == DialogResult.OK)
            {
                string fileName = oFDIndicatePathDrawingOD.FileName;
                txtPathDrawingOD.Text = fileName;
            }
        }

        private void MM1_2_CloseForm_Click(object sender, EventArgs e) // закрыть главную форму
        {
            Close();
        }

        private void bUpdateProj_Click(object sender, EventArgs e) // обновить данные проекта
        {
            UpdateVedomsts();
        }

        ///////////////////////////////////

        #region Методы работы с МС в основной форме

        private void bAddMS_Click(object sender, EventArgs e) // добавить МС в проект
        {
            EventProjectClass.EventAddMSInProjectHandler = new EventProjectClass.EventAddMSInProject(currentProj.AddMSInProj);
            FormMS formMS = new FormMS(); //создать новую МС
            if (formMS.ShowDialog() == DialogResult.OK)
            {
                UpdateVedomsts();
                return;
            }            
        }

        private void bEditMS_Click(object sender, EventArgs e) // изменить МС в проекте
        {            
            int indexSelectMC = -1;
            ListView.SelectedListViewItemCollection selectVIMC = this.lV_VedomostMS.SelectedItems;
            if (selectVIMC.Count == 0)
            {
                return;
            }            
            indexSelectMC = currentProj.FindMSOnDesignInProj(selectVIMC[0].SubItems[0].Text);
            EventProjectClass.EventEditMSInProjectHandler = new EventProjectClass.EventEditMSInProject(currentProj.EditMSIProj);
            FormMS formMSEdit = new FormMS(indexSelectMC, currentProj.GetMSInProj(indexSelectMC).getStructMS()); //изменить выбранную МС
            if (formMSEdit.ShowDialog() == DialogResult.OK)
            {
                UpdateVedomsts();
                return;
            }           
        }

        private void bDeleteMS_Click(object sender, EventArgs e) //удаление МС
        {            
            int indexSelectMC =-1;
            ListView.SelectedListViewItemCollection selectVIMC = this.lV_VedomostMS.SelectedItems;
            if (selectVIMC.Count == 0)
            {
                return;
            }
            indexSelectMC = currentProj.FindMSOnDesignInProj(selectVIMC[0].SubItems[0].Text);
            if (indexCurrentMS == indexSelectMC)
            {
                MessageBox.Show("Не возможно удалить текущую монтажную схему!!!");
                return;
            }
            if (!(QuestionDelete()))
            {
                return;
            }
            string desingMS = selectVIMC[0].SubItems[0].Text;
            if (currentProj.DeleteMSInProj(indexSelectMC))
            {
                UpdateVedomsts();
                MessageBox.Show("Монтажная схема " + desingMS + " успешно удалена.");                
                return;
            }
            MessageBox.Show("Монтажная схема " + desingMS + " не удалена.");
        }

        private void TSM_OpenModelMS_Click(object sender, EventArgs e)
        {
            if (flagKompas)
            {
                int indexSelectMC = -1;
                ListView.SelectedListViewItemCollection selectVIMC = this.lV_VedomostMS.SelectedItems;
                if (selectVIMC.Count == 0)
                {
                    return;
                }
                indexSelectMC = currentProj.FindMSOnDesignInProj(selectVIMC[0].SubItems[0].Text);
                KompasClass komp = new KompasClass(kompas, currentProj.getPathDirProj());
                IPart7 part7 = komp.GetPart7(currentProj.GetMSInProj(indexSelectMC).getPathModel());
                if (part7 == null)
                {
                    //MessageBox.Show("Не удалось открыть модель.");
                }
                return;
            }
            MessageBox.Show("Не запушен или подключение к Компасу не состоялось.");
        }

        private void TSM_OpenDrawingMS_Click(object sender, EventArgs e)
        {
            if (flagKompas)
            {
                int indexSelectMC = -1;
                ListView.SelectedListViewItemCollection selectVIMC = this.lV_VedomostMS.SelectedItems;
                if (selectVIMC.Count == 0)
                {
                    return;
                }
                indexSelectMC = currentProj.FindMSOnDesignInProj(selectVIMC[0].SubItems[0].Text);
                string pathDraw = currentProj.GetMSInProj(indexSelectMC).getPathDrawing();
                if (pathDraw == "")
                {
                    MessageBox.Show("Не указан путь к файлу чертежа.");
                    return;
                }
                KompasClass komp = new KompasClass(kompas, currentProj.getPathDirProj());
                IKompasDocument2D doc = komp.OpenDrawing(pathDraw);
                if (doc == null)
                {
                    MessageBox.Show("Не удалось открыть чертеж.");
                }
                return;
            }
            MessageBox.Show("Не запушен или подключение к Компасу не состоялось.");
        }

        #endregion

        ///////////////////////////////////

        private void FormKMD_Proj_FormClosed(object sender, FormClosedEventArgs e)
        {            
            MainF.Visible = true;
        }

        private void FormKMD_Proj_FormClosing(object sender, FormClosingEventArgs e)
        {
            string messageBoxText = "Закрыть приложение и сохранить проект?";
            string caption = "Закрытие приложения";
            DialogResult result = MessageBox.Show(messageBoxText, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Yes:
                    SaveProj();
                    e.Cancel = false;
                    return;
                case DialogResult.No:
                    e.Cancel = false;
                    return;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    return;
            }
            return;
        }

        ///////////////////////////////////

        #region Методы работы с листами ОЭ в основной форме

        private void bAddListOE_Click(object sender, EventArgs e) //добавить лист в текущую МС
        {
            int indexMS = indexCurrentMS;
            if (indexMS == -1)
            {
                MessageBox.Show("Не установлена текущая монтажная схема");
                return;
            }
            EventProjectClass.EventAddListInMSHandler = new EventProjectClass.EventAddListInMS(currentProj.GetMSInProj(indexMS).AddListOEInMS);
            FormListOE formListOE = new FormListOE(); // создать новый лист ОЭ
            if (formListOE.ShowDialog() == DialogResult.OK)
            {
                UpdateVedomsts();
                return;
            }
        }        

        private void bEditListOE_Click(object sender, EventArgs e) //изменить лист в текущей МС
        {
            int indexSelectList = -1;
            ListView.SelectedListViewItemCollection selectVIList = this.lV_VedomostListOE.SelectedItems;
            if (selectVIList.Count == 0)
            {
                return;
            }
            int indexMS = indexCurrentMS;
            if (indexMS == -1)
            {
                MessageBox.Show("Не установлена текущая монтажная схема");
                return;
            }
            indexSelectList = currentProj.GetMSInProj(indexMS).FindListOnDesignInMS(selectVIList[0].SubItems[0].Text);
            EventProjectClass.EventEditListInMSHandler = new EventProjectClass.EventEditListInMS(currentProj.GetMSInProj(indexMS).EditListInMS);
            FormListOE formListOEEdit = new FormListOE(indexSelectList, currentProj.GetMSInProj(indexMS).GetListInMS(indexSelectList).getStructListOE()); //изменить выбранный лист
            if (formListOEEdit.ShowDialog() == DialogResult.OK)
            {
                UpdateVedomsts();
                return;
            }
        }        

        private void bDeleteListOE_Click(object sender, EventArgs e) //удаление листа
        {
            int indexSelectList = -1;
            ListView.SelectedListViewItemCollection selectVIList = this.lV_VedomostListOE.SelectedItems;
            if (selectVIList.Count == 0)
            {
                return;
            }
            int indexMS = indexCurrentMS;
            if (indexMS == -1)
            {
                MessageBox.Show("Не установлена текущая монтажная схема");
                return;
            }
            if (!(QuestionDelete()))
            {
                return;
            }
            indexSelectList = currentProj.GetMSInProj(indexMS).FindListOnDesignInMS(selectVIList[0].SubItems[0].Text);
            string desingList= selectVIList[0].SubItems[0].Text;
            if (currentProj.GetMSInProj(indexMS).DeleteListInMS(indexSelectList))
            {
                UpdateVedomsts();
                //MessageBox.Show("Лист ОЭ " + desingList + " успешно удален.");
                return;
            }
            MessageBox.Show("Лист ОЭ " + desingList + " не удален.");
        }

        private void TSM_OpenDrawingListOE_Click(object sender, EventArgs e)
        {
            if (flagKompas)
            {
                int indexSelectList = -1;
                ListView.SelectedListViewItemCollection selectVIList = this.lV_VedomostListOE.SelectedItems;
                if (selectVIList.Count == 0)
                {
                    return;
                }
                int indexMS = indexCurrentMS;
                if (indexMS == -1)
                {
                    MessageBox.Show("Не установлена текущая монтажная схема");
                    return;
                }
                indexSelectList = currentProj.GetMSInProj(indexMS).FindListOnDesignInMS(selectVIList[0].SubItems[0].Text);
                string pathDraw = currentProj.GetMSInProj(indexMS).GetListInMS(indexSelectList).getPathDrawing();
                if (pathDraw == "")
                {
                    MessageBox.Show("Не указан путь к файлу чертежа.");
                    return;
                }
                KompasClass komp = new KompasClass(kompas, currentProj.getPathDirProj());
                IKompasDocument2D doc = komp.OpenDrawing(pathDraw);
                if (doc == null)
                {
                    MessageBox.Show("Не удалось открыть чертеж.");
                }
                return;
            }
            MessageBox.Show("Не запушен или подключение к Компасу не состоялось.");
        }

        #endregion

        ///////////////////////////////////

        #region Методы заполнения ListView, SelectComboBox данными

        private void FillSelectCurrentMS() // заполнение ComboBox выбора текущей МС
        {
            cBSelectCurrentMS.Items.Clear();
            List<MountingSchemeClass> ArrayMS = currentProj.GetArrayMSInProj();
            foreach (MountingSchemeClass ms in ArrayMS)
            {
                cBSelectCurrentMS.Items.Add(ms.getDesignMS());
            }
            if (indexCurrentMS == -1)
            {
                return;
            }
            cBSelectCurrentMS.SelectedIndex = indexCurrentMS;
        }

        private void FillSelectCurrentMarka() // заполнение ComboBox выбора текущей марки
        {
            cBSelectCurrentMarka.Items.Clear();
            if (indexCurrentMS == -1)
            {
                return;
            }
            List<MarkaKMDClass> ArrayMarks = currentProj.GetMSInProj(indexCurrentMS).GetArrayMarks();
            foreach (MarkaKMDClass marka in ArrayMarks)
            {
                cBSelectCurrentMarka.Items.Add(marka.getDesignMarka());
            }
            if (indexCurrentMarka == -1)
            {
                return;
            }
            cBSelectCurrentMarka.SelectedIndex = indexCurrentMarka;

        }

        private void FillVedomostMS(MountingSchemeClass ms) // заполнение Ведомости монтажных схем
        {
            ms.UpdateMass();
            ListViewItem curLV = new ListViewItem(ms.getDesignMS());
            curLV.SubItems.Add(ms.getNameMS());
            curLV.SubItems.Add(ms.getMassMarks().ToString("N2"));
            curLV.SubItems.Add(ms.getMassMetiz().ToString("N2"));
            curLV.SubItems.Add(ms.getMassMontSvarka().ToString("N2"));
            curLV.SubItems.Add(ms.getNote());
            lV_VedomostMS.Items.Add(curLV);
        }

        private void FillVedomostListOE(ListOEClass list) // заполнение Ведомости листов ОЭ
        {
            ListViewItem curLV = new ListViewItem(list.getDesignList());
            curLV.SubItems.Add(list.getNameList());
            curLV.SubItems.Add(list.getMass().ToString("N2"));
            curLV.SubItems.Add(list.getNote());
            lV_VedomostListOE.Items.Add(curLV);
        }

        private void FillVedomostOEonMS(MarkaKMDClass marka) // заполнение Ведомости ОЭ по схеме
        {
            ListViewItem curLV = new ListViewItem(marka.getDesignMarka());
            curLV.SubItems.Add(marka.getNameMarka());
            int kolMarka = marka.getKolTInMS();
            curLV.SubItems.Add(kolMarka.ToString());
            double massMarka = marka.getMassMarka()+marka.getMassZavodSvarka()+marka.getMassZinc();
            curLV.SubItems.Add(massMarka.ToString("N2"));
            double massAllMarka = kolMarka * massMarka;
            curLV.SubItems.Add(massAllMarka.ToString("N2"));
            curLV.SubItems.Add(marka.getDesignList());
            curLV.SubItems.Add(marka.getNote());
            lV_VedomostOEonMS.Items.Add(curLV);
        }

        private void FillVedomostMSh(MShClass msh) // заполнение Ведомости монтажных швов
        {
            ListViewItem curLV = new ListViewItem(msh.getMarkaElementa());
            int kolOE = msh.getCountElements();
            curLV.SubItems.Add(kolOE.ToString());            
            string TypeTolshina = msh.getTypeShva() + " " + msh.getTolschShva().ToString();
            curLV.SubItems.Add(TypeTolshina);
            double length = msh.getDlinaShva();
            double lengthAll = (double)(length * kolOE);
            curLV.SubItems.Add(length.ToString("N2"));
            curLV.SubItems.Add(lengthAll.ToString("N2"));
            curLV.SubItems.Add(msh.getTypeElectrod());
            curLV.SubItems.Add(msh.getNote());
            lV_VedomostMSh.Items.Add(curLV);
        }

        private void FillVedomostMM(MMClass mm) // заполнение Ведомости монтажных метизов
        {
            ListViewItem curLV = new ListViewItem(mm.GetStructMM().Name+" "+ mm.GetStructMM().Diameter);
            curLV.SubItems.Add(mm.GetStructMM().ThicknessPackage.ToString());
            curLV.SubItems.Add(mm.GetStructMM().Length.ToString());
            curLV.SubItems.Add(mm.GetStructMM().Quantity.ToString());
            curLV.SubItems.Add(mm.GetStructMM().Mass.ToString());
            curLV.SubItems.Add(mm.GetStructMM().GOST);
            curLV.SubItems.Add(mm.GetStructMM().ClassStrength);
            curLV.SubItems.Add(mm.GetStructMM().Note);
            lV_VedomostMM.Items.Add(curLV);
        }

        private void FilllVSpecifOE(PartKMDClass part) //заполнение спецификации деталей
        {
            ListViewItem curLV = new ListViewItem(part.getPosInMarka().ToString());
            int KolT = part.getKolTInMarka();
            curLV.SubItems.Add(KolT.ToString());
            int KolN = part.getKolNInMarka();
            curLV.SubItems.Add(KolN.ToString());
            Profile prof = part.getProfPart();
            curLV.SubItems.Add(prof.NameProf);
            double length = part.getLengthPart();
            curLV.SubItems.Add(length.ToString());
            double massPart = part.getMassPart();
            curLV.SubItems.Add(massPart.ToString("N2"));
            double massAllParts = (KolT + KolN) * massPart;
            curLV.SubItems.Add(massAllParts.ToString("N2"));
            Material material = part.getMaterialPart();
            curLV.SubItems.Add(material.Name);
            curLV.SubItems.Add(part.getNote());
            lVSpecifOE.Items.Add(curLV);
        }

        private void FillVedomostZSh(ZShClass zsh) // заполнение Ведомости заводский сварных швов
        {
            ListViewItem curLV = new ListViewItem(zsh.TypeSech);
            curLV.SubItems.Add(zsh.KatetShva.ToString());
            curLV.SubItems.Add(zsh.LenghtSh.ToString());
            curLV.SubItems.Add(zsh.Note);
            lV_VedomostSvarZavodSh.Items.Add(curLV);
        }


        private void ClearVedomosts()  // очистка ведомостей
        {
            lV_VedomostMS.Items.Clear();
            lV_VedomostListOE.Items.Clear();
            lV_VedomostOEonMS.Items.Clear();
            lV_VedomostMSh.Items.Clear();
            lV_VedomostMM.Items.Clear();
            lVSpecifOE.Items.Clear();
            lV_VedomostSvarZavodSh.Items.Clear();
        }

        private void UpdateVedomsts()  // обновить ведомости
        {
            ClearVedomosts();
            FillSelectCurrentMS();
            FillSelectCurrentMarka();

            List<MountingSchemeClass> ArrayMSInProj = new List<MountingSchemeClass>();
            ArrayMSInProj = currentProj.GetArrayMSInProj();
            if (ArrayMSInProj == null)
            {
                return;
            }
            ArrayMSInProj.ForEach(FillVedomostMS);
            if (indexCurrentMS == -1)
            {
                return;
            }
            if (currentProj.TestIndexMS(indexCurrentMS))
            {
                List<ListOEClass> ListOEInCurrMS = new List<ListOEClass>();
                ListOEInCurrMS = currentProj.GetMSInProj(indexCurrentMS).GetArrayListOE();
                if (!(ListOEInCurrMS == null))
                {
                    ListOEInCurrMS.Sort(delegate (ListOEClass list1, ListOEClass list2) {
                        string[] txtL1 = list1.getDesignList().Split(new char[] {' '});
                        string[] txtL2 = list2.getDesignList().Split(new char[] { ' ' });
                        int c1 = Convert.ToInt32(txtL1[1]);
                        int c2 = Convert.ToInt32(txtL2[1]);
                        if (c1 == c2) { return 0; };
                        if (c1 < c2) { return -1; };
                        return 1;
                    });
                    ListOEInCurrMS.ForEach(FillVedomostListOE);
                }

                List<MarkaKMDClass> ArrMarksInCurrMS = new List<MarkaKMDClass>();
                ArrMarksInCurrMS = currentProj.GetMSInProj(indexCurrentMS).GetArrayMarks();
                if (!(ArrMarksInCurrMS == null))
                {
                    ArrMarksInCurrMS.Sort(delegate (MarkaKMDClass marka1, MarkaKMDClass marka2)
                    {
                        return marka1.getDesignMarka().CompareTo(marka2.getDesignMarka());
                    });
                    ArrMarksInCurrMS.ForEach(FillVedomostOEonMS);
                }

                List<MShClass> ArrMShInCurrMS = new List<MShClass>();
                ArrMShInCurrMS = currentProj.GetMSInProj(indexCurrentMS).GetArrayMsh();
                if (!(ArrMShInCurrMS == null))
                {
                    ArrMShInCurrMS.ForEach(FillVedomostMSh);
                }

                List<MMClass> ArrMMInCurrMS = new List<MMClass>();
                ArrMMInCurrMS = currentProj.GetMSInProj(indexCurrentMS).GetArrayMM();
                if (!(ArrMMInCurrMS == null))
                {
                    ArrMMInCurrMS.ForEach(FillVedomostMM);
                }


                if (indexCurrentMarka == -1) { return; }

                if (currentProj.GetMSInProj(indexCurrentMS).TestIndexMarka(indexCurrentMarka))
                {
                    List<PartKMDClass> ArrPartsMarka = new List<PartKMDClass>();
                    ArrPartsMarka = currentProj.GetMSInProj(indexCurrentMS).GetMarkaInMS(indexCurrentMarka).GetArrayParts();
                    if (!(ArrPartsMarka == null))
                    {
                        ArrPartsMarka.Sort(delegate (PartKMDClass part1, PartKMDClass part2)
                        {
                            return part1.getPosInMarka().CompareTo(part2.getPosInMarka());
                        });
                        ArrPartsMarka.ForEach(FilllVSpecifOE);
                    }
                    List<ZShClass> ArrZSh = new List<ZShClass>();
                    ArrZSh = currentProj.GetMSInProj(indexCurrentMS).GetMarkaInMS(indexCurrentMarka).GetArrayZSh();
                    if (!(ArrZSh == null))
                    {
                        ArrZSh.ForEach(FillVedomostZSh);
                    }
                }
            }
        }

        #endregion

        ///////////////////////////////////

        #region Методы работы с отправочными элементами (марками) в основной форме

        private void bAddMarkaOEonMS_Click(object sender, EventArgs e) // добавить марку в МС
        {
            int indexMS = indexCurrentMS;
            if (indexMS == -1)
            {
                MessageBox.Show("Не установлена текущая монтажная схема");
                return;
            }
            EventProjectClass.EventAddMarkaInMSHandler = new EventProjectClass.EventAddMarkaInMS(currentProj.GetMSInProj(indexMS).AddMarkaInMS);
            EventProjectClass.EventArrayListOEHandler = new EventProjectClass.EventArrayListOE(currentProj.GetMSInProj(indexCurrentMS).GetArrayListOEStruct);
            FormMarka formNewMarka = new FormMarka(); // создать новую марку
            if (formNewMarka.ShowDialog() == DialogResult.OK)
            {
                UpdateVedomsts();
                return;
            }
        }

        private void TSM_AddOEonSelectOE_OEonMS_Click(object sender, EventArgs e)
        {
            int indexSelectMarka = -1;
            ListView.SelectedListViewItemCollection selectVIMarka = this.lV_VedomostOEonMS.SelectedItems;
            if (selectVIMarka.Count == 0)
            {
                return;
            }
            int indexMS = indexCurrentMS;
            if (indexMS == -1)
            {
                MessageBox.Show("Не установлена текущая монтажная схема");
                return;
            }
            indexSelectMarka = currentProj.GetMSInProj(indexMS).FindMarkaOnDesignInMS(selectVIMarka[0].SubItems[0].Text);
            MarkaKMDClass SampleMarka = currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexSelectMarka);
            int i = 0;
            string desingNewMarka = "Копия марки " + SampleMarka.getDesignMarka() + "_" + i.ToString();
            while (!(currentProj.GetMSInProj(indexMS).AddByTypeMarkaInMS(SampleMarka, desingNewMarka)))
            {
                i++;
                desingNewMarka = "Копия марки " + SampleMarka.getDesignMarka() + "_" + i.ToString();
            }
            UpdateVedomsts();
        }

        private void bEditMarkaOEonMS_Click(object sender, EventArgs e) // изменить марку в МС
        {
            int indexSelectMarka = -1;
            ListView.SelectedListViewItemCollection selectVIMarka = this.lV_VedomostOEonMS.SelectedItems;
            if (selectVIMarka.Count == 0)
            {
                return;
            }
            int indexMS = indexCurrentMS;
            if (indexMS == -1)
            {
                MessageBox.Show("Не установлена текущая монтажная схема");
                return;
            }
            indexSelectMarka = currentProj.GetMSInProj(indexMS).FindMarkaOnDesignInMS(selectVIMarka[0].SubItems[0].Text);
            EventProjectClass.EventEditMarkaInMSHandler = new EventProjectClass.EventEditMarkaInMS(currentProj.GetMSInProj(indexMS).EditMarkaInMS);
            EventProjectClass.EventArrayListOEHandler = new EventProjectClass.EventArrayListOE(currentProj.GetMSInProj(indexCurrentMS).GetArrayListOEStruct);
            FormMarka formEditMarka = new FormMarka(indexSelectMarka, currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexSelectMarka).getStructMarka()); //изменить выбранный ОЭ
            if (formEditMarka.ShowDialog() == DialogResult.OK)
            {
                UpdateVedomsts();
                return;
            }
        }        

        private void bDeleteMarkaOEonMS_Click(object sender, EventArgs e) // удалить марку из МС
        {    
            int indexSelectMarka = -1;
            ListView.SelectedListViewItemCollection selectVIMarka = this.lV_VedomostOEonMS.SelectedItems;
            if (selectVIMarka.Count == 0)
            {
                return;
            }
            int indexMS = indexCurrentMS;
            if (indexMS == -1)
            {
                MessageBox.Show("Не установлена текущая монтажная схема");
                return;
            }
            indexSelectMarka = currentProj.GetMSInProj(indexMS).FindMarkaOnDesignInMS(selectVIMarka[0].SubItems[0].Text);
            if (indexCurrentMarka == indexSelectMarka)
            {
                MessageBox.Show("Не возможно удалить текущий отправочный элемент!!!");
                return;
            }
            if (!(QuestionDelete()))
            {
                return;
            }
            string desingMarka = selectVIMarka[0].SubItems[0].Text;
            if (currentProj.GetMSInProj(indexMS).DeleteMarkaInMS(indexSelectMarka))
            {
                UpdateVedomsts();
                //MessageBox.Show("Отправочный элемент " + desingMarka + " успешно удален.");
                return;
            }
            MessageBox.Show("Отправочный элемент " + desingMarka + " не удален.");
        }

        private void bSettingMarka_Click(object sender, EventArgs e) // настройки марки
        {
            //string path = Process.GetCurrentProcess().MainModule.FileName;
            int indexSelectMarka = -1;
            ListView.SelectedListViewItemCollection selectVIMarka = this.lV_VedomostOEonMS.SelectedItems;
            if (selectVIMarka.Count == 0)
            {
                return;
            }
            int indexMS = indexCurrentMS;
            if (indexMS == -1)
            {
                MessageBox.Show("Не установлена текущая монтажная схема");
                return;
            }
            indexSelectMarka = currentProj.GetMSInProj(indexMS).FindMarkaOnDesignInMS(selectVIMarka[0].SubItems[0].Text);
            EventProjectClass.EventSettingMarkaHandler = new EventProjectClass.EventSettingMarka(currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexSelectMarka).SetSrtuctSetting);
            FormSettingOE formSettingMarka = new FormSettingOE(indexSelectMarka, currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexSelectMarka).GetStructSetting()); // настройки ОЭ
            if (formSettingMarka.ShowDialog() == DialogResult.OK)
            {
                SettingMarkaKMD setting = new SettingMarkaKMD();
                setting = currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexSelectMarka).GetStructSetting();
                //MessageBox.Show("Настройки марки: " + (setting.kofSvarka*100).ToString() +"%; "+ setting.RazSvarka.ToString() +"; " + (setting.kofZinc*100).ToString() + "%; " + setting.ZinkCoat.ToString() + ".");
                UpdateVedomsts();
                return;
            }
        }

        private void TSM_OpenModel_OEonMS_Click(object sender, EventArgs e)
        {
            if (flagKompas)
            {
                int indexSelectMarka = -1;
                ListView.SelectedListViewItemCollection selectVIMarka = this.lV_VedomostOEonMS.SelectedItems;
                if (selectVIMarka.Count == 0)
                {
                    return;
                }
                int indexMS = indexCurrentMS;
                if (indexMS == -1)
                {
                    MessageBox.Show("Не установлена текущая монтажная схема");
                    return;
                }
                indexSelectMarka = currentProj.GetMSInProj(indexMS).FindMarkaOnDesignInMS(selectVIMarka[0].SubItems[0].Text);
                string pathModel = currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexSelectMarka).getPathModel();
                if (pathModel == "")
                {
                    MessageBox.Show("Не указан путь к файлу модели.");
                    return;
                }
                KompasClass komp = new KompasClass(kompas, currentProj.getPathDirProj());
                IPart7 part7 = komp.GetPart7(pathModel);
                if (part7 == null)
                {
                    MessageBox.Show("Не удалось открыть модель.");
                }
                return;
            }
            MessageBox.Show("Не запушен или подключение к Компасу не состоялось.");
        }

        private void TSM_OpenDrawing_OEonMS_Click(object sender, EventArgs e)
        {
            if (flagKompas)
            {
                int indexSelectMarka = -1;
                ListView.SelectedListViewItemCollection selectVIMarka = this.lV_VedomostOEonMS.SelectedItems;
                if (selectVIMarka.Count == 0)
                {
                    return;
                }
                int indexMS = indexCurrentMS;
                if (indexMS == -1)
                {
                    MessageBox.Show("Не установлена текущая монтажная схема");
                    return;
                }
                indexSelectMarka = currentProj.GetMSInProj(indexMS).FindMarkaOnDesignInMS(selectVIMarka[0].SubItems[0].Text);
                string designList = currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexSelectMarka).getDesignList();
                int indexList = currentProj.GetMSInProj(indexMS).FindListOnDesignInMS(designList);
                if (indexList == -1)
                {
                    MessageBox.Show("Не указан лист расположения ОЭ.");
                    return;
                }
                string pathDraw = currentProj.GetMSInProj(indexMS).GetListInMS(indexList).getPathDrawing();
                if (pathDraw == "")
                {
                    MessageBox.Show("Не указан путь к файлу чертежа.");
                    return;
                }
                KompasClass komp = new KompasClass(kompas, currentProj.getPathDirProj());
                IKompasDocument2D doc = komp.OpenDrawing(pathDraw);
                if (doc == null)
                {
                    MessageBox.Show("Не удалось открыть чертеж.");
                }
                return;
            }
            MessageBox.Show("Не запушен или подключение к Компасу не состоялось.");
        }

        #endregion

        private void SaveProj() // функция сохранение проекта
        {
            if (!TestParamDataProj())
            {
                return;
            }

            DataProj tempData;
            tempData.PathDirProj = txtFolderProj.Text;
            tempData.Shifr = txtShifrProj.Text;
            tempData.NameObj = txtNameObjStroit.Text;
            tempData.NameProj = txtNameProj.Text;
            tempData.NameOrganiz = txtNameOrganiz.Text;
            tempData.Developed = txtDeveloped.Text;
            tempData.Tested = txtTested.Text;
            tempData.Approved = txtApproved.Text;
            tempData.PathDrawing = txtPathDrawingOD.Text;
            currentProj.setStructDataProj(tempData);
            this.Text = NameApp + " - " + currentProj.getShifr() + " _ " + currentProj.getNameProj();

            // создаем объект для сериализации
            BinaryFormatter formatter = new BinaryFormatter();

            string fileName = currentProj.getPathDirProj() + "\\" + currentProj.getShifr() + " _ " + currentProj.getNameProj() + ".kmdproj";

            // создаем объект файлового потока
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            // сериализация
            formatter.Serialize(fileStream, currentProj);

            // закрытие потока
            fileStream.Close();
        }

        private void bSaveProj_Click(object sender, EventArgs e) // сохранение проекта
        {
            SaveProj();
        }

        ///////////////////////////////////

        private void LoadProjectData() // загрузка данных проекта
        {
            txtFolderProj.Text = currentProj.getPathDirProj();
            txtShifrProj.Text = currentProj.getShifr();
            txtNameObjStroit.Text = currentProj.getNameObj();
            txtNameProj.Text = currentProj.getNameProj();
            txtNameOrganiz.Text = currentProj.getNameOrganiz();
            txtDeveloped.Text = currentProj.getDeveloped();
            txtTested.Text = currentProj.getTested();
            txtApproved.Text = currentProj.getApproved();
            txtPathDrawingOD.Text = currentProj.getPathDrawing();
            this.Text = NameApp + " - " + currentProj.getShifr() + " _ " + currentProj.getNameProj();
        }

        /////////////////////////////////

        private void TSMI_ConnectSredaModel_Click(object sender, EventArgs e)
        {
           TestConnectKompas();
        }

        private void TestConnectKompas()  // подключение к Компасу
        {
            try
            {
                kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
                flagKompas = true;
                tSSL_SredaModel.Text = "Компас 3D - подключен";
                //MessageBox.Show("Связь с Компасом 3D установлена.");
            }
            catch
            {
                tSSL_SredaModel.Text = "Компас 3D - нет связи";
                //MessageBox.Show("Не удалось подключиться к Компас 3D. Запустите его.");
                flagKompas = false;
            }
        }

        /////////////////////////////////

        private bool QuestionDelete() // вопрос при удалении
        {
            string messageBoxText = "Вы уверены?";
            string caption = "Удаление элемента";
            DialogResult result = MessageBox.Show(messageBoxText, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question,  MessageBoxDefaultButton.Button2);
            switch (result)
            {
                case DialogResult.Yes:
                    return true;
                case DialogResult.No:
                    return false;
            }
            return false;
        }

        /////////////////////////////////

        #region Методы работы с  деталями отправочных элементов в основной форме

        private void bAddPartMarka_Click(object sender, EventArgs e) // добавить деталь в ОЭ
        {
            int indexMS = indexCurrentMS;
            if (indexMS == -1)
            {
                MessageBox.Show("Не установлена текущая монтажная схема");
                return;
            }
            int indexMarka = indexCurrentMarka;
            if (indexMarka == -1)
            {
                MessageBox.Show("Не установлен текущий отправочный элемент");
                return;
            }
            EventProjectClass.EventAddPartInMarkaHandler = new EventProjectClass.EventAddPartInMarka(currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexMarka).AddPartInMarka);
            int FreePosPart = currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexMarka).GetFreePos();
            FormPathKMD formNewPart = new FormPathKMD(FreePosPart, kompas); // создать новую деталь вызов формы
            if (formNewPart.ShowDialog() == DialogResult.OK)
            {
                UpdateVedomsts();                
                return;
            }
        }

        private void bEditPartMarka_Click(object sender, EventArgs e) // изменить деталь
        {
            int indexSelectPart = -1;
            ListView.SelectedListViewItemCollection selectVIPart = this.lVSpecifOE.SelectedItems;
            if (selectVIPart.Count == 0)
            {
                return;
            }
            int indexMS = indexCurrentMS;
            if (indexMS == -1)
            {
                MessageBox.Show("Не установлена текущая монтажная схема");
                return;
            }
            int indexMarka = indexCurrentMarka;
            if (indexMarka == -1)
            {
                MessageBox.Show("Не установлен текущий отправочный элемент");
                return;
            }
            indexSelectPart = currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexMarka).FindPartOnPosInMarka(Convert.ToInt32(selectVIPart[0].SubItems[0].Text));
            EventProjectClass.EventEditPartInMarkaHandler = new EventProjectClass.EventEditPartInMarka(currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexMarka).EditPartInMarka);
            FormPathKMD formEditPart = new FormPathKMD(indexSelectPart, currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexMarka).GetPartInMarka(indexSelectPart).getStructPart(), kompas); //изменить выбранный ОЭ
            if (formEditPart.ShowDialog() == DialogResult.OK)
            {
                UpdateVedomsts();            
                return;
            }
        }

        private void bDeletePartMarka_Click(object sender, EventArgs e)  // удалить деталь
        {  
            int indexSelectPart = -1;
            ListView.SelectedListViewItemCollection selectVIPart = this.lVSpecifOE.SelectedItems;
            if (selectVIPart.Count == 0)
            {
                return;
            }
            int indexMS = indexCurrentMS;
            if (indexMS == -1)
            {
                MessageBox.Show("Не установлена текущая монтажная схема");
                return;
            }
            int indexMarka = indexCurrentMarka;
            if (indexMarka == -1)
            {
                MessageBox.Show("Не установлен текущий отправочный элемент");
                return;
            }
            if (!(QuestionDelete()))
            {
                return;
            }
            indexSelectPart = currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexMarka).FindPartOnPosInMarka(Convert.ToInt32(selectVIPart[0].SubItems[0].Text));
            string posPart = selectVIPart[0].SubItems[0].Text;
            if (currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexMarka).DeletePartInMarka(indexSelectPart))
            {
                UpdateVedomsts();
                //MessageBox.Show("Деталь поз." + posPart + " успешна удалена.");
                return;
            }
            MessageBox.Show("Деталь поз." + posPart + " не удалена.");
        }



        #endregion

        private void cBSelectCurrentMS_SelectedIndexChanged(object sender, EventArgs e) // установить текущую МС
        {
            int indexSelectMC = cBSelectCurrentMS.SelectedIndex;
           // MessageBox.Show("Обозначение выбранной МС: " + cBSelectCurrentMS.Items[indexSelectMC].ToString());
            int indexMS = currentProj.FindMSOnDesignInProj(cBSelectCurrentMS.Items[indexSelectMC].ToString());
            
            if (!(currentProj.TestIndexMS(indexMS)))
            {
                indexCurrentMS = -1;
                indexCurrentMarka = -1;
                UpdateVedomsts();
                return;
            }
            if (indexCurrentMS == indexMS)
            {
                return;
            }
            indexCurrentMS = indexMS;
            indexCurrentMarka = -1;
            currentProj.GetMSInProj(indexCurrentMS).GenerateArrListParts();
            UpdateVedomsts();
        }

        private void cBSelectCurrentMarka_SelectedIndexChanged(object sender, EventArgs e) // установить текущую марку
        {
            if (indexCurrentMS == -1)
            {
                return;
            }

            int indexSelectMarka = cBSelectCurrentMarka.SelectedIndex;
            int indexMarka = currentProj.GetMSInProj(indexCurrentMS).FindMarkaOnDesignInMS(cBSelectCurrentMarka.Items[indexSelectMarka].ToString());
            if (!(currentProj.GetMSInProj(indexCurrentMS).TestIndexMarka(indexMarka)))
            {
                indexCurrentMarka = -1;
                UpdateVedomsts();
                return;
            }
            if (indexCurrentMarka == indexMarka)
            {
                return;
            }
            indexCurrentMarka = indexMarka;
            UpdateVedomsts();
        }

        


        #region Методы работы с МШ в основной форме

        private void bAddMSh_Click(object sender, EventArgs e) // добавить МШ
        {
            int indexMS = indexCurrentMS;
            if (indexMS == -1)
            {
                MessageBox.Show("Не установлена текущая монтажная схема");
                return;
            }
            EventProjectClass.EventAddMShInMSHandler = new EventProjectClass.EventAddMShInMS(currentProj.GetMSInProj(indexMS).AddMShInMS);
            EventProjectClass.EventArrayMarksHandler = new EventProjectClass.EventArrayMarks(currentProj.GetMSInProj(indexCurrentMS).GetArrayMarksStruct);
            FormMSh formMSh = new FormMSh(); // создать новый лист ОЭ
            if (formMSh.ShowDialog() == DialogResult.OK)
            {
                UpdateVedomsts();
                return;
            }
        }

        private void bEditMSh_Click(object sender, EventArgs e) // изменить МШ
        {
            int indexSelectMSh = -1;
            ListView.SelectedListViewItemCollection selectVIMSh = this.lV_VedomostMSh.SelectedItems;
            if (selectVIMSh.Count == 0)
            {
                return;
            }
            int indexMS = indexCurrentMS;
            if (indexMS == -1)
            {
                MessageBox.Show("Не установлена текущая монтажная схема");
                return;
            }
            string marka = selectVIMSh[0].SubItems[0].Text;
            string typeAndTolshinaMSh = selectVIMSh[0].SubItems[2].Text;
            typeAndTolshinaMSh = typeAndTolshinaMSh.Trim();
            string[] TypeTolshina = typeAndTolshinaMSh.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (TypeTolshina.Length != 2)
            {
                MessageBox.Show("Не удалось получить данные о типе и толщине шва.");
                return;
            }
            indexSelectMSh = currentProj.GetMSInProj(indexMS).FindMShInMS(marka, TypeTolshina[0], Int32.Parse(TypeTolshina[1]));
            EventProjectClass.EventEditMShInMSHandler = new EventProjectClass.EventEditMShInMS(currentProj.GetMSInProj(indexMS).EditMShInMS);
            EventProjectClass.EventArrayMarksHandler = new EventProjectClass.EventArrayMarks(currentProj.GetMSInProj(indexCurrentMS).GetArrayMarksStruct);
            FormMSh formMShEdit = new FormMSh(indexSelectMSh, currentProj.GetMSInProj(indexMS).GetMShInMS(indexSelectMSh).getStructListMsh()); //изменить выбранный МШ
            if (formMShEdit.ShowDialog() == DialogResult.OK)
            {
                UpdateVedomsts();
                return;
            }
        }

        private void bDeleteMSh_Click(object sender, EventArgs e) // удалить МШ
        {
            int indexSelectMSh = -1;
            ListView.SelectedListViewItemCollection selectVIMSh = this.lV_VedomostMSh.SelectedItems;
            if (selectVIMSh.Count == 0)
            {
                return;
            }
            int indexMS = indexCurrentMS;
            if (indexMS == -1)
            {
                MessageBox.Show("Не установлена текущая монтажная схема");
                return;
            }
            if (!(QuestionDelete()))
            {
                return;
            }
            string marka = selectVIMSh[0].SubItems[0].Text;
            string typeAndTolshinaMSh = selectVIMSh[0].SubItems[2].Text;
            typeAndTolshinaMSh = typeAndTolshinaMSh.Trim();
            string[] TypeTolshina = typeAndTolshinaMSh.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (TypeTolshina.Length != 2)
            {
                MessageBox.Show("Не удалось получить данные о типе и толщине шва.");
                return;
            }
            indexSelectMSh = currentProj.GetMSInProj(indexMS).FindMShInMS(marka, TypeTolshina[0], Int32.Parse(TypeTolshina[1]));
            if (currentProj.GetMSInProj(indexMS).DeleteMShInMS(indexSelectMSh))
            {
                UpdateVedomsts();
                MessageBox.Show("Монтажный шов успешно удален.");
                return;
            }
            MessageBox.Show("Монтажный шов не удален.");
        }

        #endregion

        #region Методы работы с таблицами Компаса

        private void bCreateTablesList_Click(object sender, EventArgs e) // создать таблицы на выбранном листе
        {
            if (flagKompas)
            {
                KompasClass komp = new KompasClass(kompas, currentProj.getPathDirProj());
                ClassVedomosts vedomost = new ClassVedomosts(komp);
                int indexSelectList = -1;
                ListView.SelectedListViewItemCollection selectVIList = this.lV_VedomostListOE.SelectedItems;
                if (selectVIList.Count == 0)
                {
                    return;
                }
                if (indexCurrentMS == -1)
                {
                    MessageBox.Show("Не установлена текущая монтажная схема");
                    return;
                }
                EventProjectClass.EventValueProgressHandler = new EventProjectClass.EventValueProgress(ChangeProgress);
                indexSelectList = currentProj.GetMSInProj(indexCurrentMS).FindListOnDesignInMS(selectVIList[0].SubItems[0].Text);
                vedomost.CreateTablesOnList(currentProj.GetMSInProj(indexCurrentMS), indexSelectList);
                ChangeProgress(0);
                return;
            }

            MessageBox.Show("Не запушен Комапас или подключение не состоялось.");
        }

        private void bCreateTablesAllLists_Click(object sender, EventArgs e)
        {
            if (license == null)
            {
                MessageBox.Show("Отсутствует лицензия!");
                return;
            }
            if (license.KodLic != "FULL_")
            {
                MessageBox.Show("Приобретите лицезию на полную версию приложения Компас-КМД!");
                return;
            }
            if (flagKompas)
            {
                KompasClass komp = new KompasClass(kompas, currentProj.getPathDirProj());
                ClassVedomosts vedomost = new ClassVedomosts(komp);
                if (indexCurrentMS == -1)
                {
                    MessageBox.Show("Не установлена текущая монтажная схема");
                    return;
                }

                int kolList = currentProj.GetMSInProj(indexCurrentMS).GetArrayListOE().Count;
                for (int i = 0; i < kolList; i++)
                {
                    //vedomost.currPosList = 0;
                    vedomost.CreateTablesOnList(currentProj.GetMSInProj(indexCurrentMS), i);
                }
                return;
            }

            MessageBox.Show("Не запушен Комапас или подключение не состоялось.");
        }

        private void cM_V_MS_Opening(object sender, CancelEventArgs e)
        {

        }

        private void bCreateVedomostMS_Click(object sender, EventArgs e) // создать таблицы на МС
        {
            if (license == null)
            {
                MessageBox.Show("Отсутствует лицензия!");
                return;
            }
            if (license.KodLic != "FULL_")
            {
                MessageBox.Show("Приобретите лицезию на полную версию приложения Компас-КМД!");
                return;
            }
            if (flagKompas)
            {
                KompasClass komp = new KompasClass(kompas, currentProj.getPathDirProj());
                ClassVedomosts vedomostMS = new ClassVedomosts(komp);
                int indexSelectMC = -1;
                ListView.SelectedListViewItemCollection selectVIMC = this.lV_VedomostMS.SelectedItems;
                if (selectVIMC.Count == 0)
                {
                    return;
                }
                indexSelectMC = currentProj.FindMSOnDesignInProj(selectVIMC[0].SubItems[0].Text);
                vedomostMS.CreateTablesMS(currentProj.GetMSInProj(indexSelectMC));
                return;
            }

            MessageBox.Show("Не запушен Комапас или подключение не состоялось.");
        }

        private void bCreateVedomostOD_Click(object sender, EventArgs e) // создать ведомости на заглавном листе
        {
            if (license == null)
            {
                MessageBox.Show("Отсутствует лицензия!");
                return;
            }
            if (license.KodLic != "FULL_")
            {
                MessageBox.Show("Приобретите лицезию на полную версию приложения Компас-КМД!");
                return;
            }
            if (flagKompas)
            {
                KompasClass komp = new KompasClass(kompas, currentProj.getPathDirProj());
                ClassVedomosts vedomostOD = new ClassVedomosts(komp);
                vedomostOD.CreateTablesOD(currentProj);
                return;
            }

            MessageBox.Show("Не запушен Комапас или подключение не состоялось.");
        }

        #endregion

        #region Методы работы с CШ в основной форме

        private void bAddSvarZavodSh_Click(object sender, EventArgs e) // создать сварной шов
        {
            int indexMS = indexCurrentMS;
            if (indexMS == -1)
            {
                MessageBox.Show("Не установлена текущая монтажная схема");
                return;
            }
            int indexMarka = indexCurrentMarka;
            if (indexMarka == -1)
            {
                MessageBox.Show("Не установлен текущий отправочный элемент");
                return;
            }
            EventProjectClass.EventAddZShHandler = new EventProjectClass.EventAddZSh(currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexMarka).AddZShInMarka);
            FormZSh formNewZSh = new FormZSh(); // создать новый сварной шов
            if (formNewZSh.ShowDialog() == DialogResult.OK)
            {
                UpdateVedomsts();
                return;
            }
        }

        private void bEditSvarZavodSh_Click(object sender, EventArgs e) // изменить сварной шов
        {
            int indexSelectZSh = -1;
            ListView.SelectedListViewItemCollection selectVIZSh = this.lV_VedomostSvarZavodSh.SelectedItems;
            if (selectVIZSh.Count == 0)
            {
                return;
            }
            int indexMS = indexCurrentMS;
            if (indexMS == -1)
            {
                MessageBox.Show("Не установлена текущая монтажная схема");
                return;
            }
            int indexMarka = indexCurrentMarka;
            if (indexMarka == -1)
            {
                MessageBox.Show("Не установлен текущий отправочный элемент");
                return;
            }
            indexSelectZSh = currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexMarka).FindZSh(selectVIZSh[0].SubItems[0].Text, Convert.ToInt32(selectVIZSh[0].SubItems[1].Text));
            EventProjectClass.EventEditZShHandler = new EventProjectClass.EventEditZSh(currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexMarka).EditZShInMarka);
            FormZSh formEditZSh = new FormZSh(indexSelectZSh, currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexMarka).GetZShInMarka(indexSelectZSh).GetStructZSh()); //изменить выбранный СШ
            if (formEditZSh.ShowDialog() == DialogResult.OK)
            {
                UpdateVedomsts();
                return;
            }
        }

        private void bDeleteSvarZavodSh_Click(object sender, EventArgs e)
        {
            int indexSelectZSh = -1;
            ListView.SelectedListViewItemCollection selectVIZSh = this.lV_VedomostSvarZavodSh.SelectedItems;
            if (selectVIZSh.Count == 0)
            {
                return;
            }
            int indexMS = indexCurrentMS;
            if (indexMS == -1)
            {
                MessageBox.Show("Не установлена текущая монтажная схема");
                return;
            }
            int indexMarka = indexCurrentMarka;
            if (indexMarka == -1)
            {
                MessageBox.Show("Не установлен текущий отправочный элемент");
                return;
            }
            if (!(QuestionDelete()))
            {
                return;
            }
            indexSelectZSh = currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexMarka).FindZSh(selectVIZSh[0].SubItems[0].Text, Convert.ToInt32(selectVIZSh[0].SubItems[1].Text));
            string typeZSh = selectVIZSh[0].SubItems[0].Text;
            if (currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexMarka).DeleteZShInMarka(indexSelectZSh))
            {
                UpdateVedomsts();
                //MessageBox.Show("Сварной шов " + typeZSh + " успешна удален.");
                return;
            }
            MessageBox.Show("Сварной шов " + typeZSh + " не удален.");
        }


        #endregion

        #region Методы работы с МM в основной форме

        private void bAddMM_Click(object sender, EventArgs e) // добавить МM
        {
            int indexMS = indexCurrentMS;
            if (indexMS == -1)
            {
                MessageBox.Show("Не установлена текущая монтажная схема");
                return;
            }
            EventProjectClass.EventAddMMInMSHandler = new EventProjectClass.EventAddMMInMS(currentProj.GetMSInProj(indexMS).AddMMInMS);
            FormMM formMM= new FormMM(); // создать новый лист ОЭ
            if (formMM.ShowDialog() == DialogResult.OK)
            {
                UpdateVedomsts();
                return;
            }
        }

        private void bEditMM_Click(object sender, EventArgs e) // изменить МM
        {
            int indexSelectMM = -1;
            ListView.SelectedListViewItemCollection selectVIMM = this.lV_VedomostMM.SelectedItems;
            if (selectVIMM.Count == 0)
            {
                return;
            }
            int indexMS = indexCurrentMS;
            if (indexMS == -1)
            {
                MessageBox.Show("Не установлена текущая монтажная схема");
                return;
            }
            string name_diameter = selectVIMM[0].SubItems[0].Text;
            name_diameter = name_diameter.Trim();
            string[] Name_Diameter = name_diameter.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (Name_Diameter.Length != 2)
            {
                MessageBox.Show("Не удалось получить данные о наименовании и диаметре стандартного элемента.");
                return;
            }
            MM tempMM = new MM();
            tempMM.Name = Name_Diameter[0];
            tempMM.Diameter = Name_Diameter[1];
            tempMM.ThicknessPackage = Convert.ToDouble(selectVIMM[0].SubItems[1].Text);
            tempMM.Length = Convert.ToDouble(selectVIMM[0].SubItems[2].Text);
            tempMM.Quantity = Convert.ToInt32(selectVIMM[0].SubItems[3].Text);
            tempMM.Mass = Convert.ToDouble(selectVIMM[0].SubItems[4].Text);
            tempMM.GOST = selectVIMM[0].SubItems[5].Text;
            tempMM.ClassStrength = selectVIMM[0].SubItems[6].Text;
            tempMM.Note = selectVIMM[0].SubItems[7].Text;
            indexSelectMM = currentProj.GetMSInProj(indexMS).FindMMInMS(tempMM);
            EventProjectClass.EventEditMMInMSHandler = new EventProjectClass.EventEditMMInMS(currentProj.GetMSInProj(indexMS).EditMMInMS);
            FormMM formMMEdit = new FormMM(indexSelectMM, currentProj.GetMSInProj(indexMS).GetMMInMS(indexSelectMM).GetStructMM()); //изменить выбранный МM
            if (formMMEdit.ShowDialog() == DialogResult.OK)
            {
                UpdateVedomsts();
                return;
            }
        }

        private void bDeleteMM_Click(object sender, EventArgs e) // удалить МM
        {
            int indexSelectMM = -1;
            ListView.SelectedListViewItemCollection selectVIMM = this.lV_VedomostMM.SelectedItems;
            if (selectVIMM.Count == 0)
            {
                return;
            }
            int indexMS = indexCurrentMS;
            if (indexMS == -1)
            {
                MessageBox.Show("Не установлена текущая монтажная схема");
                return;
            }
            if (!(QuestionDelete()))
            {
                return;
            }
            string name_diameter = selectVIMM[0].SubItems[0].Text;
            name_diameter = name_diameter.Trim();
            string[] Name_Diameter = name_diameter.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (Name_Diameter.Length != 2)
            {
                MessageBox.Show("Не удалось получить данные о наименовании и диаметре стандартного элемента.");
                return;
            }
            MM tempMM = new MM();
            tempMM.Name = Name_Diameter[0];
            tempMM.Diameter = Name_Diameter[1];
            tempMM.ThicknessPackage = Convert.ToDouble(selectVIMM[0].SubItems[1].Text);
            tempMM.Length = Convert.ToDouble(selectVIMM[0].SubItems[2].Text);
            tempMM.Quantity = Convert.ToInt32(selectVIMM[0].SubItems[3].Text);
            tempMM.Mass = Convert.ToDouble(selectVIMM[0].SubItems[4].Text);
            tempMM.GOST = selectVIMM[0].SubItems[5].Text;
            tempMM.ClassStrength = selectVIMM[0].SubItems[6].Text;
            tempMM.Note = selectVIMM[0].SubItems[7].Text;
            indexSelectMM = currentProj.GetMSInProj(indexMS).FindMMInMS(tempMM);
            if (currentProj.GetMSInProj(indexMS).DeleteMMInMS(indexSelectMM))
            {
                UpdateVedomsts();
                //MessageBox.Show("Стандартный элемент успешно удален.");
                return;
            }
            MessageBox.Show("Стандартный элемент не удален.");
        }
        #endregion

        /////////////////////////////////

        #region Методы работы со сторкой Статус-панели

        public void ChangeProgress (int value)
        {
            tlPB_ProgressApp1.Value = value;
            //Thread.Sleep(500);
        }
        #endregion
        private void TSMI_SpOE_OpenModel_Click(object sender, EventArgs e)
        {
            if (flagKompas)
            {
                int indexSelectPart = -1;
                ListView.SelectedListViewItemCollection selectVIPart = this.lVSpecifOE.SelectedItems;
                if (selectVIPart.Count == 0)
                {
                    return;
                }
                int indexMS = indexCurrentMS;
                if (indexMS == -1)
                {
                    MessageBox.Show("Не установлена текущая монтажная схема");
                    return;
                }
                int indexOE = indexCurrentMarka;
                if (indexOE == -1)
                {
                    MessageBox.Show("Не установлен текущий отправочный элемент");
                    return;
                }
                indexSelectPart = currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexCurrentMarka).FindPartOnPosInMarka(Convert.ToInt32(selectVIPart[0].SubItems[0].Text));
                string pathModel = currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexCurrentMarka).GetPartInMarka(indexSelectPart).getPathModel();
                if (pathModel == "")
                {
                    MessageBox.Show("Не указан путь к файлу модели.");
                    return;
                }
                KompasClass komp = new KompasClass(kompas, currentProj.getPathDirProj());
                IPart7 part7 = komp.GetPart7(pathModel);
                if (part7 == null)
                {
                    MessageBox.Show("Не удалось открыть модель.");
                    return;
                }
                return;
            }
            MessageBox.Show("Не запушен или подключение к Компасу не состоялось.");
        }

        private void TSMI_SpOE_UpdateMassPart_Click(object sender, EventArgs e)
        {

            if (flagKompas)
            {
                int indexSelectPart = -1;
                ListView.SelectedListViewItemCollection selectVIPart = this.lVSpecifOE.SelectedItems;
                if (selectVIPart.Count == 0)
                {
                    return;
                }
                int indexMS = indexCurrentMS;
                if (indexMS == -1)
                {
                    MessageBox.Show("Не установлена текущая монтажная схема");
                    return;
                }
                int indexOE = indexCurrentMarka;
                if (indexOE == -1)
                {
                    MessageBox.Show("Не установлен текущий отправочный элемент");
                    return;
                }
                indexSelectPart = currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexCurrentMarka).FindPartOnPosInMarka(Convert.ToInt32(selectVIPart[0].SubItems[0].Text));
                string pathModel = currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexCurrentMarka).GetPartInMarka(indexSelectPart).getPathModel();
                if (pathModel == "")
                {
                    MessageBox.Show("Не указан путь к файлу модели.");
                    return;
                }
                KompasClass komp = new KompasClass(kompas, currentProj.getPathDirProj());
                IPart7 part7 = komp.GetPart7(pathModel);
                if (part7 == null)
                {
                    MessageBox.Show("Не удалось открыть модель.");
                    return;
                }
                double massPart = komp.GetMassModel(pathModel);
                if (massPart == -1) return;
                currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexCurrentMarka).GetPartInMarka(indexSelectPart).setMassPart(massPart);;
                if (komp.ClosePart(part7))
                {
                    UpdateVedomsts();
                    return;
                }
                MessageBox.Show("Не удалось обновить массу модели.");
                return;
            }
            MessageBox.Show("Не запушен или подключение к Компасу не состоялось.");
        }

        private void bUpdateMassAllParts_Click(object sender, EventArgs e)
        {

            if (flagKompas)
            {
                int indexMS = indexCurrentMS;
                if (indexMS == -1)
                {
                    MessageBox.Show("Не установлена текущая монтажная схема");
                    return;
                }
                int indexOE = indexCurrentMarka;
                if (indexOE == -1)
                {
                    MessageBox.Show("Не установлен текущий отправочный элемент");
                    return;
                }                
                //EventProjectClass.EventValueProgressHandler = new EventProjectClass.EventValueProgress(ChangeProgress);
                List<PartKMDClass> ArrParts = new List<PartKMDClass>();
                ArrParts = currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexCurrentMarka).GetArrayParts();
                int kolPart = ArrParts.Count;
                int i = 0;
                KompasClass komp = new KompasClass(kompas, currentProj.getPathDirProj());
                foreach (PartKMDClass part in ArrParts)
                {
                    i = i + 1;
                    ChangeProgress((i * 100) / kolPart);                    
                    string pathModel = part.getPathModel();
                    if (pathModel == "") continue;
                    IPart7 part7 = komp.GetPart7(pathModel);
                    if (part7 == null) continue;
                    part7.RebuildModel(true);
                    double massPart = komp.GetMassModel(pathModel);
                    if (massPart == -1) continue;
                    int indexPart = currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexCurrentMarka).FindPartOnPosInMarka(part.getPosInMarka());
                    currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexCurrentMarka).GetPartInMarka(indexPart).setMassPart(massPart);
                    komp.ClosePart(part7);                    
                }
                UpdateVedomsts();
                ChangeProgress(0);
                return;
            }
            MessageBox.Show("Не запушен или подключение к Компасу не состоялось.");
        }

        private void bUpdateMassAllOE_Click(object sender, EventArgs e)
        {
            if (flagKompas)
            {
                int indexMS = indexCurrentMS;
                if (indexMS == -1)
                {
                    MessageBox.Show("Не установлена текущая монтажная схема");
                    return;
                }

                List<MarkaKMDClass> ArrMarks = new List<MarkaKMDClass>();
                ArrMarks = currentProj.GetMSInProj(indexMS).GetArrayMarks();
                int kolMarks = ArrMarks.Count;
                int i = 0;
                foreach (MarkaKMDClass marka in ArrMarks)
                {
                    i = i + 1;
                    ChangeProgress((i * 100) / kolMarks);
                    List<PartKMDClass> ArrParts = new List<PartKMDClass>();
                    ArrParts = marka.GetArrayParts();
                    int indexMarka = currentProj.GetMSInProj(indexMS).FindMarkaOnDesignInMS(marka.getDesignMarka());
                    KompasClass komp = new KompasClass(kompas, currentProj.getPathDirProj());
                    foreach (PartKMDClass part in ArrParts)
                    {
                        string pathModel = part.getPathModel();
                        if (pathModel == "") continue;
                        IPart7 part7 = komp.GetPart7(pathModel);
                        if (part7 == null) continue;
                        part7.RebuildModel(true);
                        double massPart = komp.GetMassModel(pathModel);
                        if (massPart == -1) continue;
                        int indexPart = currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexMarka).FindPartOnPosInMarka(part.getPosInMarka());
                        currentProj.GetMSInProj(indexMS).GetMarkaInMS(indexMarka).GetPartInMarka(indexPart).setMassPart(massPart);
                        komp.ClosePart(part7);
                    }
                }
                UpdateVedomsts();
                ChangeProgress(0);
                return;
            }
            MessageBox.Show("Не запушен или подключение к Компасу не состоялось.");
        }
    }
}
