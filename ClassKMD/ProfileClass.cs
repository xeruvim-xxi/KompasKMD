using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassKMD
{
    [Serializable]
    public struct Profile
    {
        public string NameProf; //наименование профиля
        public int KodProf; // код профиля
        public int KodStandartSize; // код типоразмера
        public double t; // толщина листового металла, 0 - для профиля
        public double b; // ширина листового металла, 0 - для профиля
       // public double L; // длина (для всех профилей)
        public double MassPogMetr; // масса погонного метра профиля
        public double MassSqMetr; // масса квадратного метра профиля
        public string GOST; // ГОСТ профиля
    }

    [Serializable]
    class ProfileClass
    {


    }
}
