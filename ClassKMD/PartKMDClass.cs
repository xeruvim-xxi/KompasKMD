using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassKMD
{
    [Serializable]
    public struct PartKMD  // структура статичных данных детали КМД
    {
        public int PosInProject; // позиция детали в проекте (сквозная нумерация)
        public int PosInMarka; // позиция детали в марке (марочная нумерация)
        public string DesignPart; // обозначение детали(марка + позиция в марке, пример: ЛК-1_поз.6)
        public string NamePart; // наименование детали (по профилю, по назначению)
        public int KolTInMarka; // Количество в марке (так)
        public int KolNInMarka; // Количество в марке (наоборот)
        public Profile ProfPart; // профиль детали
        public double LengthPart; // длина детали
        public Material MaterialPart; // марка стали, материал
        public double MassPart; // масса детали
        public string PathModel; //путь к модели детали
        public string PathDrawing; //путь к чертежу детали
        public string Note; // примечание
    }

    [Serializable]
    public class PartKMDClass
    {
        private PartKMD clPart; // структура данных детали КМД

        public PartKMDClass(PartKMD Part) //конструктор класса ДЕТАЛИ
        {
            this.clPart = Part;
        }

        #region Методы получения статичных данных детали
        //методы получения данных детали (начало)
        public PartKMD getStructPart() {return clPart; } // получить структуру данных детали
        public int getPosInProject() { return clPart.PosInProject; } // получить позицию детали в проекте
        public int getPosInMarka() { return clPart.PosInMarka; } // получить позицию детали в марке
        public string getDesignPart() { return clPart.DesignPart; } // получить обозначение
        public string getNamePart() { return clPart.NamePart; } // получить наименование
        public int getKolTInMarka() { return clPart.KolTInMarka; } // получить количество в марке (так)
        public int getKolNInMarka() { return clPart.KolNInMarka; } // получить количество в марке (наоборот)
        public Profile getProfPart() { return clPart.ProfPart;} // получить профиль детали
        public double getLengthPart() { return clPart.LengthPart; } // получить длину детали
        public Material getMaterialPart() { return clPart.MaterialPart; } // получить материал
        public double getMassPart() { return clPart.MassPart; } // получить массу детали
        public string getPathModel() { return clPart.PathModel; } // получить путь к модели детали
        public string getPathDrawing() { return clPart.PathDrawing; } // получить путь к чертежу детали
        public string getNote() { return clPart.Note; } // получить примечание
        //методы получения данных детали (конец)
        #endregion

        #region Методы установки статичных данных детали
        //методы установки данных детали (начало)
        public void setStructPart(PartKMD structPart) { clPart=structPart; } // установить структуру данных детали
        public void setPosInProject(int posPart) { clPart.PosInProject=posPart; } // установить позицию детали в проекте
        public void setPosInMarka(int posPart) { clPart.PosInMarka = posPart; } // установить позицию детали в марке
        public void setDesignPart(string designPart) { clPart.DesignPart = designPart; } // установить обозначение
        public void setNamePart(string namePart) { clPart.NamePart = namePart; } // установить наименование
        public void setKolTInMarka(int kolT) { clPart.KolTInMarka=kolT; } // установить количество в марке (так)
        public void setKolNInMarka(int kolN) { clPart.KolNInMarka=kolN; } // установить количество в марке (наоборот)
        public void setProfPart(Profile profPart) { clPart.ProfPart = profPart; } // установить профиль детали
        public void setLengthPart(double length) { clPart.LengthPart = length; } // установить длину детали
        public void setMaterialPart(Material materilPart) { clPart.MaterialPart=materilPart; } // установить материал
        public void setMassPart(double mass) { clPart.MassPart=mass; } // установить массу детали
        public void setPathModel(string pathModel) { clPart.PathModel=pathModel; } // установить путь к модели детали
        public void setPathDrawing(string pathDrawing) { clPart.PathDrawing=pathDrawing; } // установить путь к чертежу детали
        public void setNote(string note) { clPart.Note = note; } //установить примечание
        //методы установки данных детали (конец)
        #endregion


        
       
    }
}
