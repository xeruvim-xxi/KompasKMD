using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassKMD
{    
    public struct ListRChP // структура статичных данных листов рабочихчертежей деталей
    {
        public string DesignList; // обозначение листа
        public string NameList; // наименование листа
        public string Format; // формат листа
        public int KolParts; // кол-во деталей
        public double MassPart; // масса детали
        public string PathDrawing; //путь к чертежу листа
        public string Note; // примечание
    }

    public class ListRChPClass
    {
        public ListRChP cl_List { set; get; }

        public ListRChPClass(ListRChP k_list)
        {
            cl_List = k_list;
        }
    }
}
