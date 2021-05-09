using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassKMD
{
    [Serializable]
    public struct DataProj //структура данных проекта
    {
        public string PathDirProj; //путь к папке проекта
        public string Shifr; //шифр проекта
        public string NameObj; //наименование объекта
        public string NameProj; //наименование проекта
        public string NameOrganiz; //наименование организации
        public string Developed; // разработал
        public string Tested; //проверил
        public string Approved; //утвердил
        public string PathDrawing; //путь к чертежу ОД
    }


    [Serializable]
    public class ProjectClass
    {
        private DataProj clDataProject; //структура данных проекта
        List<MountingSchemeClass> ArrayMS = new List<MountingSchemeClass>(); //массив МС проекта
        public int CurrentMSIndex;

        
        #region Методы получения статичных данных проекта
        //методы получения данных проекта (начало)
        public DataProj getStructDataProj() { return clDataProject; } // получить структуру данных проекта
        public string getShifr() { return clDataProject.Shifr; } // получить шифр проекта
        public string getNameObj() { return clDataProject.NameObj; } // получить наименование объекта
        public string getNameProj() { return clDataProject.NameProj; } // получить наименование проекта
        public string getNameOrganiz() { return clDataProject.NameOrganiz; } // получить наименование организации
        public string getDeveloped() { return clDataProject.Developed; } // получить имя разработчика проекта
        public string getTested() { return clDataProject.Tested; } // получить имя проверяющего проект
        public string getApproved() { return clDataProject.Approved; } // получить имя утверждающего проект
        public string getPathDirProj() { return clDataProject.PathDirProj; } // получить путь к папке проекта
        public string getPathDrawing() { return clDataProject.PathDrawing; } // получить путь к чертежу ОД
        //методы получения данных проекта (конец)
        #endregion

        #region Методы установки статичных данных проекта
        //методы установки данных проекта (начало)
        public void setStructDataProj(DataProj dataProj) { clDataProject = dataProj; } //установить структуру данных проекта
        public void setShifr(string shifr) { clDataProject.Shifr = shifr; } //установить шифр проекта
        public void setNameObj(string nameObj) { clDataProject.NameObj = nameObj; } //установить наименование объекта
        public void setNameProj(string nameProj) { clDataProject.NameProj = nameProj; } //установить наименование проекта
        public void setNameOrganiz(string nameOrganiz) { clDataProject.NameOrganiz = nameOrganiz; } //установить наименование организации
        public void setDeveloped(string developed) { clDataProject.Developed = developed; } //установить имя разработчика проекта
        public void setTested(string tested) { clDataProject.Tested = tested; } //установить имя проверяющего проект
        public void setApproved(string approved) { clDataProject.Approved = approved; } //установить имя утверждающего проект
        public void setPathDirProj(string pathDirProj) { clDataProject.PathDirProj = pathDirProj; } //установить путь к папке проекта
        public void setPathDrawing(string pathDrawing) { clDataProject.PathDrawing = pathDrawing; } //установить путь к чертежу ОД
        //методы установки данных проекта (конец)
        #endregion

        #region Методы работы с МС в проекте(добавить, удалить, поиск, получить МС по индексу в массиве МС или обозначению)

        public bool AddMSInProj(MountingScheme MSInProj) //добавить МС в проект
        {
            int index = FindMSOnDesignInProj(MSInProj.DesignMS); // поиск МС с данным обозначением
            if (index == -1) // если нет, то добавляем в массив
            {
                ArrayMS.Add(new MountingSchemeClass(MSInProj));
                CurrentMSIndex = ArrayMS.Count() - 1;
                return true;
            }
            return false;
        }

        public bool EditMSIProj(int indexChangedMS, MountingScheme MSInProj) // изменить МС в проекте
        {            
            if (ArrayMS[indexChangedMS].getDesignMS() == MSInProj.DesignMS)
            {
                ArrayMS[indexChangedMS].setStructMS(MSInProj);
                return true;
            }
            else
            {
                int index = FindMSOnDesignInProj(MSInProj.DesignMS); // поиск МС с данным обозначением
                if (index == -1) // если нет, то добавляем в массив
                {
                    ArrayMS[indexChangedMS].setStructMS(MSInProj);
                    return true;
                }
            }            
            return false;
        }

        public bool DeleteMSInProj(int index) //удалить МС из проекта
        {
            if (ArrayMS.Count() == 0)
            {
                return false;
            }
            if ((index < 0) || (index > ArrayMS.Count()-1))
            {
                return false;
            }
            ArrayMS.RemoveAt(index);
            return true;
        }

        public bool TestIndexMS(int index) //тест существования МС с данным индексом
        {            
            if ((index < 0) || (index > ArrayMS.Count() - 1))
            {
                return false;
            }
            return true;
        }

        public MountingSchemeClass GetMSInProj(int index) //получить МС по индексу в массиве МС
        {
            return ArrayMS[index];
        }

        public MountingSchemeClass GetMSInProj(string desing) //получить МС по обозначению в проекте
        {
            int index = FindMSOnDesignInProj(desing);
            return ArrayMS[index];
        }

        public int FindMSOnDesignInProj(string desing) // найти МС по обозначению в проекте (возвращает индекс в массиве)
        {
            return ArrayMS.FindIndex(x => (x.getDesignMS() == desing));
        }

        public List<MountingSchemeClass> GetArrayMSInProj() // получить массив МС
        {
            return ArrayMS;
        }

        #endregion

    }
}
