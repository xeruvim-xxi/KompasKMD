using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassKMD
{
    [Serializable]
    public struct Material
    {
        public string Name; // наименование материала
        public string GOST; // ГОСТ материала
        public double Density; //плотность материала в г/куб.мм
    }

    [Serializable]
    class MaterialClass
    {
    }
}
