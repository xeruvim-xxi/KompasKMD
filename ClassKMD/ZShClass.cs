using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassKMD
{
    [Serializable]
    public struct ZSh // структура статичных данных Сварные заводские швы (СЗВ)
    {
        public string TypeSech; // тип сечения
        public int KatetShva;   // катет шва, мм
        public double LenghtSh;    // длина шва, м
        public string Note;     // примечание
    }

    [Serializable]
    public class ZShClass
    {
        // Свойства класса
        public string TypeSech { set; get; } // тип сечения
        public int KatetShva { set; get; }   // катет шва, мм
        public double LenghtSh { set; get; }    // длина шва, м
        public string Note { set; get; }     // примечание

        // Конструктор класса СЗВ
        public ZShClass (ZSh zsh)
        {
            TypeSech = zsh.TypeSech;
            KatetShva = zsh.KatetShva;
            LenghtSh = zsh.LenghtSh;
            Note = zsh.Note;
        }

        // Установить структуру СЗВ
        public void SetStructZSh(ZSh zsh)
        {
            TypeSech = zsh.TypeSech;
            KatetShva = zsh.KatetShva;
            LenghtSh = zsh.LenghtSh;
            Note = zsh.Note;
        }

        // Получить структкру СЗВ
        public ZSh GetStructZSh()
        {
            ZSh zsh = new ZSh();
            zsh.TypeSech = TypeSech;
            zsh.KatetShva = KatetShva;
            zsh.LenghtSh = LenghtSh;
            zsh.Note = Note;
            return zsh;
        }
    }
}
