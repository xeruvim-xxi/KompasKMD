using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ClassKMD
{
    [Serializable]
    public struct MountingScheme // структура статичных данных монтажной схемы (далее МС)
    {
        public string DesignMS; // обозначение схемы
        public string NameMS; // наименование схемы
        public double MassMarks; // масса всех марок (конструкции)
        public double MassMetiz; // масса метизов
        public double MassMontSvarka; //масса монтажных сварных швов
        public string PathModel; //путь к модели МС
        public string PathDrawing; //путь к чертежу МС
        public string Note; // примечание
    }

    [Serializable]
    public class MountingSchemeClass
    {
        ///////////////////////////////////
        // переменные класса
        private MountingScheme clMS; // структура данных МС
        private List<MarkaKMDClass> ArrayMarks = new List<MarkaKMDClass>(); // массив марок МС
        private List<ListOEClass>ArrayListOE = new List<ListOEClass>(); // массив листов отправочных элементов (марок)
        [NonSerialized]
        private List<ListRChPClass> ArrayListParts = new List<ListRChPClass>(); //массив листов деталей

        private List<MShClass> ArrayMSh = new List<MShClass>(); // массив монтажных швов
        private List<MMClass> ArrayMM = new List<MMClass>(); // массив монтажных метизов
        public int CurrentListOEIndex, CurrentMarkaIndex, CurrentMShIndex, CurrentMMIndex = -1;

        ///////////////////////////////////

        public MountingSchemeClass(MountingScheme MS) //конструктор класса МC
        {
            this.clMS = MS;
        }

        ///////////////////////////////////

        #region Методы получения статичных данных МС
        //методы получения данных МС (начало)
        public MountingScheme getStructMS() { return clMS; } // получить структуру данных МСМ
        public string getDesignMS() { return clMS.DesignMS; } // получить обозначение
        public string getNameMS() { return clMS.NameMS; } // получить наименование
        public double getMassMarks() { return clMS.MassMarks; } // получить массу марок
        public double getMassMetiz() { return clMS.MassMetiz; } // получить массу метизов
        public double getMassMontSvarka() { return clMS.MassMontSvarka; } // получить массу монтажных сварных швов
        public string getPathModel() { return clMS.PathModel; } // получить путь к модели МС
        public string getPathDrawing() { return clMS.PathDrawing; } // получить путь к чертежу МС
        public string getNote() { return clMS.Note; } // получить примечание
        //методы получения данных МС (конец)
        #endregion

        ///////////////////////////////////

        #region Методы установки статичных данных МС
        //методы установки данных МС (начало)
        public void setStructMS(MountingScheme ms) { clMS = ms; } //установить структуру данных МС
        public void setDesignMS(string designMS) { clMS.DesignMS = designMS; } //установить обозначение
        public void setNameMS(string nameMS) { clMS.NameMS = nameMS; } //установить наименование
        public void setPathModel(string pathModel) { clMS.PathModel = pathModel; } //установить путь к модели МС
        public void setPathDrawing(string pathDrawing) { clMS.PathDrawing = pathDrawing; } //установить путь к чертежу МС
        public void setNote(string note) { clMS.Note = note; } //установить примечание
        //методы установки данных МС (конец)
        #endregion

        ///////////////////////////////////

        #region Методы работы с марками в МС(добавить, удалить, поиск, получить марку по индексу в массиве марок)

        public bool AddMarkaInMS(MarkaKMD MarkaInMS) //добавить марку в МС
        {
            int index = FindMarkaOnDesignInMS(MarkaInMS.DesignMarka); // поиск марки в МС
            if (index == -1) // если нет, то добавляем в массив
            {
                ArrayMarks.Add(new MarkaKMDClass(MarkaInMS));
                CurrentMarkaIndex = ArrayMarks.Count() - 1;
                return true;
            }
            return false;            
        }

        public bool AddByTypeMarkaInMS(MarkaKMDClass sampleMarka, string desingMarka) //добавить марку в МС по образцу
        {
            int index = FindMarkaOnDesignInMS(desingMarka); // поиск марки в МС
            if (index == -1) // если нет, то добавляем в массив
            {
                MarkaKMD structMarka = sampleMarka.getStructMarka();
                structMarka.DesignMarka = desingMarka;
                ArrayMarks.Add(new MarkaKMDClass(structMarka));
                CurrentMarkaIndex = ArrayMarks.Count() - 1;
                int indexNewMarka = CurrentMarkaIndex;
                GetMarkaInMS(indexNewMarka).SetSrtuctSetting(sampleMarka.GetStructSetting());
                foreach (PartKMDClass part in sampleMarka.GetArrayParts())
                {
                    GetMarkaInMS(indexNewMarka).AddPartInMarka(part.getStructPart());
                }
                foreach (ZShClass zsh in sampleMarka.GetArrayZSh())
                {
                    GetMarkaInMS(indexNewMarka).AddZShInMarka(zsh.GetStructZSh());
                }
                GetMarkaInMS(indexNewMarka).LastPos = sampleMarka.LastPos;
                foreach (int pos in sampleMarka.ArrayFreePos)
                {
                    GetMarkaInMS(indexNewMarka).ArrayFreePos.Add(pos);
                }
                GetMarkaInMS(indexNewMarka).CurrentPartIndex = sampleMarka.CurrentPartIndex;
                GetMarkaInMS(indexNewMarka).CurrentZShIndex = sampleMarka.CurrentZShIndex;
                return true;
            }
            return false;
        }

        public bool EditMarkaInMS(int indexChangedMarka, MarkaKMD MarkaInMS) // изменить марку в МС
        {
            if (ArrayMarks[indexChangedMarka].getDesignMarka() == MarkaInMS.DesignMarka)
            {
                ArrayMarks[indexChangedMarka].setStructMarka(MarkaInMS);
                return true;
            }
            else
            {
                int index = FindMarkaOnDesignInMS(MarkaInMS.DesignMarka); // поиск марки в МС с данным обозначением
                if (index == -1) // если нет, то добавляем в массив
                {
                    ArrayMarks[indexChangedMarka].setStructMarka(MarkaInMS);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteMarkaInMS(int index) //удалить марку из МС
        {
            if (ArrayMarks.Count() == 0)
            {
                return false;
            }
            if ((index < 0) || (index > ArrayMarks.Count() - 1))
            {
                return false;
            }
            ArrayMarks.RemoveAt(index);
            return true;
        }

        public bool TestIndexMarka(int index) //тест существования марки с данным индексом
        {
            if ((index < 0) || (index > ArrayMarks.Count() - 1))
            {
                return false;
            }
            return true;
        }

        public MarkaKMDClass GetMarkaInMS(int index) //получить марку по индексу в массиве марок
        {
            return ArrayMarks[index];
        }

        public MarkaKMDClass GetMarkaInMS(string desing) //получить марку по обозначению
        {
            int index = FindMarkaOnDesignInMS(desing);
            return ArrayMarks[index];
        }

        public List<MarkaKMDClass> GetArrayMarks() //получить массив марок
        {
            return ArrayMarks;
        }

        public List<MarkaKMD> GetArrayMarksStruct()  //получить массив структуры марок
        {
            List<MarkaKMD> marksStruct = new List<MarkaKMD>();
            foreach (MarkaKMDClass marka in ArrayMarks)
            {
                marksStruct.Add(marka.getStructMarka());
            }
            return marksStruct;
        }

        public int FindMarkaOnDesignInMS(string desing) // найти марку по обозначению в МС (возвращает индекс в массиве)
        {
            return ArrayMarks.FindIndex(x => (x.getDesignMarka() == desing));
        }        

        #endregion

        ///////////////////////////////////

        #region Методы работы с листами в МС(добавить, изменить, удалить, поиск листов)

        public bool AddListOEInMS(ListOE ListOEInMS) // добавить лист ОЭ в МС
        {
            int index = FindListOnDesignInMS(ListOEInMS.DesignList); // поиск листа в МС
            if (index == -1) // если нет, то добавляем в массив
            {
                ArrayListOE.Add(new ListOEClass(ListOEInMS));
                CurrentListOEIndex = ArrayListOE.Count() - 1;
                return true;
            }
            return false;
        }

        public bool EditListInMS(int indexChangedList, ListOE ListOEInMS) // изменить лист в МС
        {
            if (ArrayListOE[indexChangedList].getDesignList() == ListOEInMS.DesignList)
            {
                ArrayListOE[indexChangedList].setStructListOE(ListOEInMS);
                return true;
            }
            else
            {
                int index = FindListOnDesignInMS(ListOEInMS.DesignList); // поиск листа в МС с данным обозначением
                if (index == -1) // если нет, то добавляем в массив
                {
                    ArrayListOE[indexChangedList].setStructListOE(ListOEInMS);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteListInMS(int index) //удалить лист из МС
        {
            if (ArrayListOE.Count() == 0)
            {
                return false;
            }
            if ((index < 0) || (index > ArrayListOE.Count() - 1))
            {
                return false;
            }
            ArrayListOE.RemoveAt(index);
            return true;
        }

        public bool TestIndexListOE(int index) //тест существования листа с данным индексом
        {
            if ((index < 0) || (index > ArrayListOE.Count() - 1))
            {
                return false;
            }
            return true;
        }

        public ListOEClass GetListInMS(int index) //получить лист по индексу в массиве листов
        {
            return ArrayListOE[index];
        }

        public ListOEClass GetListInMS(string desing) //получить лист по обозначению
        {
            int index = FindListOnDesignInMS(desing);
            return ArrayListOE[index];
        }

        public List<ListOEClass> GetArrayListOE() //получить массив листов
        {
            return ArrayListOE;
        }

        public List<ListOE> GetArrayListOEStruct()  //получить массив структуры листов
        {
            List<ListOE> listOEStruct = new List<ListOE>();
            foreach (ListOEClass list in ArrayListOE)
            {
                listOEStruct.Add(list.getStructListOE());
            }
            return listOEStruct;
        }

        public int FindListOnDesignInMS(string desing) // найти лист по обозначению в МС (возвращает индекс в массиве)
        {
            return ArrayListOE.FindIndex(x => (x.getDesignList() == desing));
        }

        #endregion

        ///////////////////////////////////

        #region Методы работы с листами рабочих РЧД

        public List<ListRChPClass> GetArrayListParts()
        {
            return ArrayListParts;
        } 

        public void GenerateArrListParts()
        {
            if (ArrayListParts == null)
            {
                ArrayListParts = new List<ListRChPClass>();
            }
            foreach (MarkaKMDClass marka in ArrayMarks)
            {
                foreach (PartKMDClass part in marka.GetArrayParts())
                {
                    ListRChP s_ListPart = new ListRChP();
                    bool b_s = false;
                    int i = 0;
                    if (!(ArrayListParts == null)) {
                        foreach (ListRChPClass l in ArrayListParts)
                        {
                            if (l.cl_List.NameList == ("Деталь " + part.getPosInMarka().ToString("000")))
                            {
                                s_ListPart = l.cl_List;
                                b_s = true;
                                s_ListPart.KolParts = s_ListPart.KolParts + marka.getKolTInMS() * (part.getKolTInMarka() + part.getKolNInMarka());
                                break;
                            }
                            i = i + 1;
                        }
                    }
                    if (!b_s)
                    {
                        s_ListPart.DesignList = this.getDesignMS() + "-" + part.getPosInMarka().ToString("0000");
                        s_ListPart.NameList = "Деталь " + part.getPosInMarka().ToString("000");
                        s_ListPart.Format = "А4";
                        s_ListPart.KolParts = marka.getKolTInMS() * (part.getKolTInMarka() + part.getKolNInMarka());
                        s_ListPart.MassPart = part.getMassPart();
                        ArrayListParts.Add(new ListRChPClass(s_ListPart));
                    }
                    else
                    {
                        ArrayListParts[i] = new ListRChPClass(s_ListPart);
                    }
                }
            }
        }
       

        #endregion

        ///////////////////////////////////

        #region Методы работы с МШ в МС(добавить, изменить, удалить, поиск МШ)

        public bool AddMShInMS(MSh MShInMS) // добавить МШ в МС
        {
            int index = FindMShInMS(MShInMS.Marka, MShInMS.TypeShva, MShInMS.TolschShva); // поиск МШ в МС
            if (index == -1) // если нет, то добавляем в массив
            {
                ArrayMSh.Add(new MShClass(MShInMS));
                CurrentMShIndex = ArrayMSh.Count() - 1;
                return true;
            }
            return false;
        }

        public bool EditMShInMS(int indexChangedMSh, MSh MShInMS) // изменить МШ в МС
        {
            if ((ArrayMSh[indexChangedMSh].getMarkaElementa() == MShInMS.Marka) && (ArrayMSh[indexChangedMSh].getTypeShva() == MShInMS.TypeShva) && (ArrayMSh[indexChangedMSh].getTolschShva() == MShInMS.TolschShva))
            {
                ArrayMSh[indexChangedMSh].setStructListMsh(MShInMS);
                return true;
            }
            else
            {
                int index = FindMShInMS(MShInMS.Marka, MShInMS.TypeShva, MShInMS.TolschShva); // поиск МШ в МС с данным параметрами
                if (index == -1) // если нет, то добавляем в массив
                {
                    ArrayMSh[indexChangedMSh].setStructListMsh(MShInMS);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteMShInMS(int index) //удалить МШ из МС
        {
            if (ArrayMSh.Count() == 0)
            {
                return false;
            }
            if ((index < 0) || (index > ArrayMSh.Count() - 1))
            {
                return false;
            }
            ArrayMSh.RemoveAt(index);
            return true;
        }

        public bool TestIndexMSh(int index) //тест существования МШ с данным индексом
        {
            if ((index < 0) || (index > ArrayMSh.Count() - 1))
            {
                return false;
            }
            return true;
        }

        public MShClass GetMShInMS(int index) //получить МШ по индексу в массиве ArrayMSh
        {
            return ArrayMSh[index];
        }

        public MShClass GetMShInMS(string desingMarka, string typeShva, int tolschShva) //получить МШ по параметрам
        {
            int index = FindMShInMS(desingMarka, typeShva, tolschShva);
            return ArrayMSh[index];
        }

        public List<MShClass> GetArrayMsh() //получить массив МШ
        {
            return ArrayMSh;
        }

        public List<MSh> GetArrayMShStruct()  //получить массив структуры МШ
        {
            List<MSh> ArrayMShStruct = new List<MSh>();
            foreach (MShClass msh in ArrayMSh)
            {
                ArrayMShStruct.Add(msh.getStructListMsh());
            }
            return ArrayMShStruct;
        }

        public int FindMShInMS(string desingMarka, string typeShva, int tolschShva) // найти МШ в МС (возвращает индекс в массиве)
        {
            if (ArrayMSh == null) { return -1; }
            return ArrayMSh.FindIndex(x => ((x.getMarkaElementa() == desingMarka) && (x.getTypeShva()==typeShva) && (x.getTolschShva()==tolschShva)));
        }

        #endregion

        ///////////////////////////////////

        #region Методы работы с ММ в МС(добавить, изменить, удалить, поиск МM)

        public bool AddMMInMS(MM MMInMS) // добавить МM в МС
        {
            int index = FindMMInMS(MMInMS); // поиск МШ в МС
            if (index == -1) // если нет, то добавляем в массив
            {
                ArrayMM.Add(new MMClass(MMInMS));
                CurrentMMIndex = ArrayMM.Count() - 1;
                return true;
            }
            return false;
        }

        public bool EditMMInMS(int indexChangedMM, MM MMInMS) // изменить ММ в МС
        {
            if ((ArrayMM[indexChangedMM].GetStructMM().Name == MMInMS.Name) && (ArrayMM[indexChangedMM].GetStructMM().Diameter == MMInMS.Diameter) && (ArrayMM[indexChangedMM].GetStructMM().Length == MMInMS.Length) && (ArrayMM[indexChangedMM].GetStructMM().GOST == MMInMS.GOST) && (ArrayMM[indexChangedMM].GetStructMM().ClassStrength == MMInMS.ClassStrength))
            {
                ArrayMM[indexChangedMM].SetStructMM(MMInMS);
                return true;
            }
            else
            {
                int index = FindMMInMS(MMInMS); // поиск МM в МС с данным параметрами
                if (index == -1) // если нет, то добавляем в массив
                {
                    ArrayMM[indexChangedMM].SetStructMM(MMInMS);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteMMInMS(int index) //удалить МM из МС
        {
            if (ArrayMM.Count() == 0)
            {
                return false;
            }
            if ((index < 0) || (index > ArrayMM.Count() - 1))
            {
                return false;
            }
            ArrayMM.RemoveAt(index);
            return true;
        }

        public bool TestIndexMM(int index) //тест существования МM с данным индексом
        {
            if ((index < 0) || (index > ArrayMM.Count() - 1))
            {
                return false;
            }
            return true;
        }

        public MMClass GetMMInMS(int index) //получить МM по индексу в массиве ArrayMM
        {
            return ArrayMM[index];
        }

        public MMClass GetMMInMS(MM mm) //получить МШ по отличительным параметрам
        {
            int index = FindMMInMS(mm);
            return ArrayMM[index];
        }

        public List<MMClass> GetArrayMM() //получить массив МM
        {
            return ArrayMM;
        }

        public List<MM> GetArrayMMStruct()  //получить массив структуры MM
        {
            List<MM> ArrayMMStruct = new List<MM>();
            foreach (MMClass mm in ArrayMM)
            {
                ArrayMMStruct.Add(mm.GetStructMM());
            }
            return ArrayMMStruct;
        }

        public int FindMMInMS(MM structMM) // найти ММ в МС (возвращает индекс в массиве)
        {
            if (ArrayMM == null) { return -1; }
            return ArrayMM.FindIndex(x => ((x.GetStructMM().Name == structMM.Name) && (x.GetStructMM().Diameter == structMM.Diameter) && (x.GetStructMM().Length == structMM.Length) && (x.GetStructMM().GOST == structMM.GOST) && (x.GetStructMM().ClassStrength == structMM.ClassStrength)));
        }

        #endregion     

        ///////////////////////////////////

        #region Методы для расчета массы конструкции, метизов, сварных монтажных швов

        public void UpdateMass() // обновление массы всех марок в МС
        {
            clMS.MassMarks = 0;
            ArrayMarks.ForEach(RaschetMassMarks);
            UpdateMassListOE();
        }

        private void RaschetMassMarks(MarkaKMDClass marka)
        {
            marka.UpdateMass();
            clMS.MassMarks += (marka.getMassMarka() + marka.getMassZavodSvarka() + marka.getMassZinc()) * marka.getKolTInMS();            
        }

        private void UpdateMassListOE() // обновление массы листов
        {            
            foreach (ListOEClass list in ArrayListOE)
            {
                string designList = list.getDesignList();
                double massList = 0;
                if (designList == ""){break;}
                foreach (MarkaKMDClass marka in ArrayMarks)
                {
                    if (designList == marka.getDesignList())
                    {
                        massList += (marka.getMassMarka() + marka.getMassZavodSvarka() + marka.getMassZinc())*marka.getKolTInMS();
                    }
                }
                list.setMassListOE(massList);
            }
        }

        #endregion

        ///////////////////////////////////
    }
}
