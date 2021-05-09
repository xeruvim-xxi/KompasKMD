using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassKMD
{
    [Serializable]
    public struct MM // структура статичных данных монтажных метизов (ММ)
    {
        public string Name; // наименование
        public string Diameter; // диаметр
        public double ThicknessPackage; // толщина пакета
        public double Length; // длина
        public int Quantity; // количество
        public double Mass; // вес, кгс
        public string GOST; // ГОСТ
        public string ClassStrength; // класс прочности
        public string Note; // примечание
    }

    [Serializable]
    public class MMClass
    {
        // свойства класса

        public string Name { set; get; } // наименование
        public string Diameter { set; get; } // диаметр
        public double ThicknessPackage { set; get; } // толщина пакета
        public double Length { set; get; } // длина
        public int Quantity { set; get; } // количество
        public double Mass { set; get; } // вес, кгс
        public string GOST { set; get; } // ГОСТ
        public string ClassStrength { set; get; } // класс прочности
        public string Note { set; get; } // примечание

        // свойства класса

        public MMClass (MM mm) // конструктор класса ММ
        {
            Name = mm.Name;
            Diameter = mm.Diameter;
            ThicknessPackage = mm.ThicknessPackage;
            Length = mm.Length;
            Quantity = mm.Quantity;
            Mass = mm.Mass;
            GOST = mm.GOST;
            ClassStrength = mm.ClassStrength;
            Note = mm.Note;
        }

        public void SetStructMM (MM mm) // установить структуру ММ
        {
            Name = mm.Name;
            Diameter = mm.Diameter;
            ThicknessPackage = mm.ThicknessPackage;
            Length = mm.Length;
            Quantity = mm.Quantity;
            Mass = mm.Mass;
            GOST = mm.GOST;
            ClassStrength = mm.ClassStrength;
            Note = mm.Note;
        }

        public MM GetStructMM() // получить структуру ММ
        {
            MM mm = new MM();
            mm.Name = Name;
            mm.Diameter = Diameter;
            mm.ThicknessPackage = ThicknessPackage;
            mm.Length = Length;
            mm.Quantity = Quantity;
            mm.Mass = Mass;
            mm.GOST = GOST;
            mm.ClassStrength = ClassStrength;
            mm.Note = Note;
            return mm;
        }

    }
}
