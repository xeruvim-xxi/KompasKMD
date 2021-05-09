using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ClassKMD
{
    [Serializable]
    public struct MarkaKMD  // структура статичных данных марки КМД
    {
        public string DesignMarka; // обозначение марки
        public string NameMarka; // наименование марки
        public double MassMarka; // масса марки (только элементов конструкции)
        public double MassZavodSvarka; // масса заводских сварных швов (итог)
        public int KolTInMS; // Количество в МС (так)
      //  public int KolNInMS; // Количество в МС (наоборот)
      //  public double MassMontagSvarka; // масса монтажных сварных швов (расчет по длине и катету)
      //  public double LengthZavodSvarka; // длина заводских сварных швов м (итог)
      //  public double LengthMontagSvarka; // длина монтажных сварных швов м
        public double MassZinc; // масса покрытия цинком
      //  public double AreaCoverage; // площадь покрытия в кв.м
        public string PathModel; //путь к модели сборки марки
       // public string PathDrawing; //путь к чертежу сборки марки
        public string DesignList; //обозначение листа на котором располагается элемент
        public string Note; // примечание
    }

    [Serializable]
    public struct SettingMarkaKMD // настройки марки КМД
    {
        public double kofSvarka; // коффицент сварных швов
        public bool RazSvarka; // осуществлять расчет веса сварочных швов: да, нет
        public double kofZinc; // коффицент наплава цинка
        public bool ZinkCoat; // осуществяется покрытие цинком: да, нет
    }    

    [Serializable]
    public class MarkaKMDClass
    {        

        private MarkaKMD clMarkaKMD; // структура данных марки КМД
        private SettingMarkaKMD clSetting; // структура данных настроек марки КМД
        private List<PartKMDClass> ArrayParts = new List<PartKMDClass>(); // массив деталей марки
        private List<ZShClass> ArrayZSh = new List<ZShClass>(); // массив ЗСШ
        public int LastPos=0; //последняя занятая позиция в марке
        public List<int> ArrayFreePos = new List<int>(); // массив удаленный промежуточных позиций
        public int CurrentPartIndex = -1; // индекс текущей детали
        public int CurrentZShIndex = -1; // индекс текущего СШ
        

        public MarkaKMDClass(MarkaKMD Marka) //конструктор класса МАРКИ
        {
            this.clMarkaKMD = Marka;
            clSetting.kofSvarka = 0.01d; // коффицент сварных швов (по умолчанию)
            clSetting.RazSvarka = true;
            clSetting.kofZinc = 0.06d; // коффицент наплава цинка (по умолчанию)
            clSetting.ZinkCoat = true; // осуществяется покрытие цинком (по умолчанию)
        }

        #region Методы получения статичных данных марки
        //методы получения данных марки (начало)
        public MarkaKMD getStructMarka() { return clMarkaKMD; } // получить структуру данных марки
        public string getDesignMarka() { return clMarkaKMD.DesignMarka; } // получить обозначение
        public string getNameMarka() { return clMarkaKMD.NameMarka; } // получить наименование
        public double getMassMarka() { return clMarkaKMD.MassMarka; } // получить массу марки
        public double getMassZavodSvarka() { return clMarkaKMD.MassZavodSvarka; } // получить массу заводских швов
        public int getKolTInMS() { return clMarkaKMD.KolTInMS; } // получить количество в МС (так)
       // public int getKolNInMS() { return clMarkaKMD.KolNInMS; } // получить количество в МС (наоборот)
        public double getMassZinc() { return clMarkaKMD.MassZinc; } // получить массу покрытия цинком
        public string getPathModel() { return clMarkaKMD.PathModel; } // получить путь к модели сборки марки
       // public string getPathDrawing() { return clMarkaKMD.PathDrawing; } // получить путь к чертежу сборки марки
        public string getDesignList() { return clMarkaKMD.DesignList; } // получить обозначение листа на котором располагается элемент
        public string getNote() { return clMarkaKMD.Note; } // получить примечание

        //методы получения данных марки (конец)
        #endregion

        #region Методы установки статичных данных марки
        //методы установки данных марки (начало)
        public void setStructMarka(MarkaKMD marka) { clMarkaKMD = marka;} //установить структуру данных марки
        public void setDesignMarka(string designMarka) { clMarkaKMD.DesignMarka = designMarka; } //установить обозначение
        public void setNameMarka(string nameMarka) { clMarkaKMD.NameMarka = nameMarka; } //установить наименование
        public void setKolTInMS(int kolT) { clMarkaKMD.KolTInMS = kolT; } // установить количество в МС (так)
       // public void setKolNInMS(int kolN) { clMarkaKMD.KolNInMS = kolN; } // установить количество в МС (наоборот)
        public void setPathModel(string pathModel) { clMarkaKMD.PathModel = pathModel; } //установить путь к модели сборки марки
       // public void setPathDrawing(string pathDrawing) { clMarkaKMD.PathDrawing = pathDrawing; } //установить путь к чертежу сборки марки
        public void setDesignList(string list) { clMarkaKMD.DesignList = list; } //установить обозначение листа на котором располагается элемент
        public void setNote(string note) { clMarkaKMD.Note = note; } //установить примечание
                                                                     //методы установки данных марки (конец)
        #endregion

        #region Методы работы с настройками марки КМД

        public void SetSrtuctSetting (SettingMarkaKMD setting) // установить структуру настроек марки
        {
            clSetting = setting;
        }

        public void SetKofSvarka (double kofSvarka) // установить коффицент сварных швов
        {
            clSetting.kofSvarka = kofSvarka;
        }

        public void SetRazSvarka(bool razSvarka) // осуществлять расчет веса сварочных швов: да, нет
        {
            clSetting.RazSvarka = razSvarka;
        }

        public void SetKofZinc(double kofZinc) // установить коффицент наплава цинка
        {
            clSetting.kofZinc = kofZinc;
        }

        public void SetZinkCoat (bool zinkCoat) // осуществяется покрытие цинком: да, нет
        {
            clSetting.ZinkCoat = zinkCoat;
        }

        public SettingMarkaKMD GetStructSetting() // получить структуру настроек марки
        {
            return clSetting;
        }

        #endregion

        #region Методы работы с деталями марки (добавить, удалить, поиск, получить деталь по индексу в массиве деталей)

        public int GetFreePos() // получить свободную позицию
        {
            if (ArrayFreePos.Count == 0)
            {
                return LastPos + 1;
            }
            ArrayFreePos.Sort();
            return ArrayFreePos[0];
        }

        public bool AddPartInMarka(PartKMD PartInMarka) //добавить деталь в марку
        {
            int index = FindPartOnPosInMarka(PartInMarka.PosInMarka); // поиск детали по позиции
            if (index == -1) // если нет, то добавляем в массив
            {
                ArrayParts.Add(new PartKMDClass(PartInMarka));
                UpdateMass();
                CurrentPartIndex = ArrayParts.Count() - 1;
                if (PartInMarka.PosInMarka < LastPos)
                {
                    for (int i = 0; i < ArrayFreePos.Count(); i++)
                    {
                        if (ArrayFreePos[i] == PartInMarka.PosInMarka)
                        {
                            ArrayFreePos.RemoveAt(i);
                            break;
                        }
                    }
                }
                else
                {
                    LastPos = PartInMarka.PosInMarka;
                }
                return true;
            }
            return false; 
        }

        public bool EditPartInMarka(int indexChangedPart, PartKMD PartInMarka) // изменить деталь в марке
        {

            if (ArrayParts[indexChangedPart].getPosInMarka() == PartInMarka.PosInMarka)
            {
                ArrayParts[indexChangedPart].setStructPart(PartInMarka);
                UpdateMass();
                return true;
            }
            else
            {
                int oldPos = ArrayParts[indexChangedPart].getPosInMarka();
                int index = FindPartOnPosInMarka(PartInMarka.PosInMarka); // поиск детали в марке по позиции
                if (index == -1) // если нет, то добавляем в массив
                {
                    ArrayParts[indexChangedPart].setStructPart(PartInMarka);
                    UpdateMass();
                    if (PartInMarka.PosInMarka < LastPos)
                    {
                        for (int i = 0; i < ArrayFreePos.Count(); i++)
                        {
                            if (ArrayFreePos[i] == PartInMarka.PosInMarka)
                            {
                                ArrayFreePos.RemoveAt(i);
                                if (oldPos == LastPos)
                                {
                                    LastPos = LastPos - 1;
                                }
                                else
                                {
                                    ArrayFreePos.Add(oldPos);
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        LastPos = PartInMarka.PosInMarka;
                    }
                    return true;
                }
            }
            return false;
        }

        public bool DeletePartInMarka(int index) //удалить деталь из марки
        {
            if (ArrayParts.Count() == 0)
            {
                return false;
            }
            if ((index < 0) || (index > ArrayParts.Count() - 1))
            {
                return false;
            }
            if (ArrayParts[index].getPosInMarka() == LastPos)
            {
                LastPos = LastPos - 1;
            }
            else
            {
                ArrayFreePos.Add(ArrayParts[index].getPosInMarka());
            }
            ArrayParts.RemoveAt(index);
            UpdateMass();
            return true;
        }

        public PartKMDClass GetPartInMarka(int index) //получить деталь по индексу в массиве деталей
        {
            return ArrayParts[index];
        }

        public List<PartKMDClass> GetArrayParts() // получить массив деталей
        {
            return ArrayParts;
        }

        public int FindPartOnPosInMarka(int pos) // найти деталь по позиции в марке (возвращает индекс в массиве)
        {
            return ArrayParts.FindIndex(x => (x.getPosInMarka()==pos));
        }

        public int FindPartOnPosInProject(int pos) // найти деталь по позиции в проекте (возвращает индекс в массиве)
        {
            return ArrayParts.FindIndex(x => (x.getPosInProject() == pos));
        }

        #endregion

        #region Методы работы с ЗСШ

        public bool AddZShInMarka(ZSh ZShInMarka) // добавить СШ в марку
        {
            int index = FindZSh(ZShInMarka.TypeSech, ZShInMarka.KatetShva); // поиск CШ в марке
            if (index == -1) // если нет, то добавляем в массив
            {
                ArrayZSh.Add(new ZShClass(ZShInMarka));
                CurrentZShIndex = ArrayZSh.Count() - 1;
                return true;
            }
            return false;
        }

        public bool EditZShInMarka(int indexChangedZSh, ZSh ZShInMarka) // изменить CШ в марке
        {
            if ((ArrayZSh[indexChangedZSh].TypeSech == ZShInMarka.TypeSech) && (ArrayZSh[indexChangedZSh].KatetShva == ZShInMarka.KatetShva))
            {
                ArrayZSh[indexChangedZSh].SetStructZSh(ZShInMarka);
                return true;
            }
            else
            {
                int index = FindZSh(ZShInMarka.TypeSech, ZShInMarka.KatetShva); // поиск CШ в марке с данным параметрами
                if (index == -1) // если нет, то добавляем в массив
                {
                    ArrayZSh[indexChangedZSh].SetStructZSh(ZShInMarka);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteZShInMarka(int index) //удалить CШ из марки
        {
            if (ArrayZSh.Count() == 0)
            {
                return false;
            }
            if ((index < 0) || (index > ArrayZSh.Count() - 1))
            {
                return false;
            }
            ArrayZSh.RemoveAt(index);
            return true;
        }

        public bool TestIndexZSh(int index) //тест существования CШ с данным индексом
        {
            if ((index < 0) || (index > ArrayZSh.Count() - 1))
            {
                return false;
            }
            return true;
        }

        public ZShClass GetZShInMarka(int index) //получить CШ по индексу в массиве ArrayZSh
        {
            return ArrayZSh[index];
        }

        public ZShClass GetZShInMarka(string type, int katet) //получить CШ по параметрам
        {
            int index = FindZSh(type, katet);
            return ArrayZSh[index];
        }

        public List<ZShClass> GetArrayZSh() //получить массив CШ
        {
            return ArrayZSh;
        }

        public List<ZSh> GetArrayZShStruct()  //получить массив структуры CШ
        {
            List<ZSh> ArrayZShStruct = new List<ZSh>();
            foreach (ZShClass zsh in ArrayZSh)
            {
                ArrayZShStruct.Add(zsh.GetStructZSh());
            }
            return ArrayZShStruct;
        }

        public int FindZSh(string type, int katet) // найти СШ в Марке (возвращает индекс в массиве)
        {
            if (ArrayZSh == null) { return -1; }
            return ArrayZSh.FindIndex(x => ((x.TypeSech == type) && (x.KatetShva == katet)));
        }


        #endregion

        #region Методы расчета веса

        public void UpdateMass() // обновление массы
        {
            clMarkaKMD.MassMarka = 0;
            ArrayParts.ForEach(RaschetMass);
        }

        private void RaschetMass(PartKMDClass part)
        {
            clMarkaKMD.MassMarka += part.getMassPart()*(part.getKolTInMarka()+part.getKolNInMarka());
            if (clSetting.RazSvarka)
            {
                clMarkaKMD.MassZavodSvarka = clMarkaKMD.MassMarka * clSetting.kofSvarka;
            } else
            {
                clMarkaKMD.MassZavodSvarka = 0;
            }
            if (clSetting.ZinkCoat)
            {
                clMarkaKMD.MassZinc = (clMarkaKMD.MassMarka + clMarkaKMD.MassZavodSvarka) * clSetting.kofZinc;
            } else
            {
                clMarkaKMD.MassZinc = 0;
            }
            
        }

        #endregion

    }
}
