using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassKMD
{
    [Serializable]
    public struct ListOE // структура статичных данных листов отправочных элементов (далее ОЭ) МС
    {
        public string DesignList; // обозначение листа
        public string NameList; // наименование листа
        public double Mass;
        public string PathDrawing; //путь к чертежу листа
        public string Note; // примечание
    }

    [Serializable]
    public class ListOEClass
    {
        private ListOE clListOE; // структура данных листа ОЭ

        public ListOEClass(ListOE listOE) //коструктор класса листа ОЭ
        {
            this.clListOE = listOE;
        }
       
        #region Методы получения статичных данных листа
        //методы получения данных листа (начало)
        public ListOE getStructListOE() { return clListOE; } // получить структуру данных листа
        public string getDesignList() { return clListOE.DesignList; } // получить обозначение листа
        public string getNameList() { return clListOE.NameList; } // получить наименование листа
        public double getMass() { return clListOE.Mass; } // получить массу марок на листе
        public string getPathDrawing() { return clListOE.PathDrawing; } // получить путь к чертежу листа
        public string getNote() { return clListOE.Note; } // получить примечание
        //методы получения данных листа (конец)
        #endregion

        #region Методы установки статичных данных листа
        //методы установки данных листа (начало)
        public void setStructListOE(ListOE list) { clListOE = list; } //установить структуру данных листа
        public void setDesignListOE(string designListOE) { clListOE.DesignList = designListOE; } //установить обозначение
        public void setNameListOE(string nameListOE) { clListOE.NameList = nameListOE; } //установить наименование
        public void setMassListOE(double massListOE) { clListOE.Mass = massListOE; } // установить массу
        public void setPathDrawing(string pathDrawing) { clListOE.PathDrawing = pathDrawing; } //установить путь к чертежу листа
        public void setNote(string note) { clListOE.Note = note; } //установить примечание
        //методы установки данных листа (конец)
        #endregion
    }
}
