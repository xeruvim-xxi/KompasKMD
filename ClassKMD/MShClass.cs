using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassKMD
{
    [Serializable]
    public struct MSh // структура статичных данных Ведомость монтажных швов (МШ)
    {
        public string Marka; // марка элемента
        public int CountElements; // кол-во элементов
        public string TypeShva; // тип шва
        public int TolschShva; // тощина шва
        public double DlinaShva; // длина шва
        public string TypeElectrod; //тип электрода
        public string Note; // примечание
    }

    [Serializable]
    public class MShClass
    {
        private MSh clListMsh; // структура данных листа МШ
        public MShClass(MSh listMsh) //коструктор класса листа МШ
        {
            this.clListMsh = listMsh;
        }

        #region Методы получения статичных данных листа
        //методы получения данных листа (начало)
        public MSh getStructListMsh() { return clListMsh; } // получить структуру данных листа
        public string getMarkaElementa() { return clListMsh.Marka; } // получить обозначение листа
        public int getCountElements() { return clListMsh.CountElements; }   // получить кол-во элементов    
        public string getTypeShva() { return clListMsh.TypeShva; }  // получить тип шва
        public int getTolschShva() { return clListMsh.TolschShva; } // получить толщину шва
        public double getDlinaShva() { return clListMsh.DlinaShva; }   // получить длину шва
        public string getTypeElectrod() { return clListMsh.TypeElectrod; }  // получить тип электрода
        public string getNote() { return clListMsh.Note; } // получить примечание
        //методы получения данных листа (конец)
        #endregion

        #region Методы установки статичных данных листа
        //методы установки данных листа (начало)
        public void setStructListMsh(MSh list) { clListMsh = list; } //установить структуру данных листа
        public void setMarkaElementaListMsh(string markaElementaListMsh) { clListMsh.Marka = markaElementaListMsh; } //установить обозначение
        public void setCountElementsListMsh(int countElementsListMsh) { clListMsh.CountElements = countElementsListMsh; }   //установить кол-во элементов
        public void setTypeShvaListMsh(string typeShvaListMsh) { clListMsh.TypeShva = typeShvaListMsh; }   //установить тип шва
        public void setTolschShvaListMsh(int tolschShvaListMsh) { clListMsh.TolschShva = tolschShvaListMsh; }   //установить толщину шва
        public void setDlinaShvaListMsh(double dlinaShvaListMsh) { clListMsh.DlinaShva = dlinaShvaListMsh; }   //установить длину шва
        public void setTypeElectrodListMsh(string typeElectrodListMsh) { clListMsh.TypeElectrod = typeElectrodListMsh; }   //установить тип электрода
        public void setNote(string note) { clListMsh.Note = note; } //установить примечание
        //методы установки данных листа (конец)
        #endregion
    }
}
