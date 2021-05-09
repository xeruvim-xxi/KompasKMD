using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncKompas;
//#define __LIGHT_VERSION__
#if (__LIGHT_VERSION__)
	using Kompas6LTAPI5;
#else
using Kompas6API5;
#endif
using Kompas6Constants;
using Kompas6Constants3D;
using KAPITypes;
using KompasAPI7;
using System.Windows.Forms;
using ClassKMD;

namespace Vedomosts
{
    public struct SpecifMaterial
    {
        public string prof;
        public string steel;
        public double mass;
    }

    public struct ListPart
    {
        public string DesignList;
        public string NamePart;
        public string FormatList;
        public int KolParts;
        public double MassPart;
    }

    public class ClassVedomosts
    {
        KompasClass kompasClass = null;

        double currTable_X = 0; // координата X текущей таблицы
        double currTable_Y = 0; // координата Y текущей таблицы
        //public int currPosList = 0;

        public ClassVedomosts(KompasClass kompClass)
        {
            this.kompasClass = kompClass;
        }

        #region Работа с ведомостями ОЭ

        #region Работа со спецификацией деталей ОЭ

        private bool CaptionTableSpecifOE(IDrawingTables Tables) // заголовок таблицы спецификации марки
        {
            IDrawingTable DrawingTable = Tables.Add(3, 11, 10, 15, ksTableTileLayoutEnum.ksTTLNotCreate);
            if (DrawingTable == null)
            {
                //MessageBox.Show("Не удалось получить интерфейс IDrawingTable.");
                return false;
            }
            DrawingTable.X = (double)currTable_X;
            DrawingTable.Y = (double)currTable_Y;
            this.currTable_Y = currTable_Y - 35;
            ITable Table = (ITable)DrawingTable;
            if (Table == null)
            {
                //MessageBox.Show("Не удалось получить интерфейс ITable.");
                return false;
            }
            // установка границы            
            ((ICellBoundaries)(Table.get_Range(0, 0, 3, 11)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
            ((ICellBoundaries)(Table.get_Range(0, 0, 0, 11)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBBottomBorder] = ksCurveStyleEnum.ksCSNormal;
            // установка границы   
            // установка размеров таблицы и объединение ячеек             
            ((ICellFormat)Table.get_Cell(0, 1)).Width = 10;
            ((ICellFormat)Table.get_Cell(0, 2)).Width = 7.5;
            ((ICellFormat)Table.get_Cell(0, 3)).Width = 7.5;
            ((ICellFormat)Table.get_Cell(0, 4)).Width = 35;
            ((ICellFormat)Table.get_Cell(0, 5)).Width = 20;
            ((ICellFormat)Table.get_Cell(0, 8)).Width = 12;
            ((ICellFormat)Table.get_Cell(0, 9)).Width = 18;
            ((ICellFormat)Table.get_Cell(0, 10)).Width = 30;
            Table.get_Range(0, 0, 0, 10).CombineCells();
            Table.get_Range(1, 0, 2, 0).CombineCells();
            Table.get_Range(1, 1, 2, 1).CombineCells();
            Table.get_Range(1, 2, 1, 3).CombineCells();
            Table.get_Range(1, 4, 2, 4).CombineCells();
            Table.get_Range(1, 5, 2, 5).CombineCells();
            Table.get_Range(1, 6, 1, 8).CombineCells();
            Table.get_Range(1, 9, 2, 9).CombineCells();
            Table.get_Range(1, 10, 2, 10).CombineCells();
            ((ICellFormat)Table.get_Cell(0, 0)).Height = 10;
            ((ICellFormat)Table.get_Cell(1, 2)).Height = 10;
            ((ICellFormat)Table.get_Cell(2, 2)).Height = 15;
            DrawingTable.FixedCellsSize = true;
            // DrawingTable.Update();
            // установка размеров таблицы и объединение ячеек           
            // стили текста таблицы
            ((ICellFormat)Table.get_Range(0, 0, 0, 10)).TextStyle = (int)ksTextStyleEnum.ksTSTableCell;
            // стили текста таблицы
            // установка текста
            ((IText)(Table.get_Cell(0, 0).Text)).Str = "Спецификация";
            ((IText)(Table.get_Cell(1, 0).Text)).Str = "Марка\nэлемента";
            ((IText)(Table.get_Cell(1, 1).Text)).Str = "№\nдетали";
            ((IText)(Table.get_Cell(1, 2).Text)).Str = "Кол-во шт.";
            ((IText)(Table.get_Cell(2, 2).Text)).Str = "т";
            ((IText)(Table.get_Cell(2, 3).Text)).Str = "н";
            ((IText)(Table.get_Cell(1, 4).Text)).Str = "Сечение";
            ((IText)(Table.get_Cell(1, 5).Text)).Str = "Длина,\nмм";
            ((IText)(Table.get_Cell(1, 6).Text)).Str = "Вес, кгс";
            ((IText)(Table.get_Cell(2, 6).Text)).Str = "одной\nдетали";
            ((IText)(Table.get_Cell(2, 7).Text)).Str = "всех";
            ((IText)(Table.get_Cell(2, 8).Text)).Str = "элемента";
            ((IText)(Table.get_Cell(1, 9).Text)).Str = "Марка\nстали";
            ((IText)(Table.get_Cell(1, 10).Text)).Str = "Примечание";
            // установка текста
            DrawingTable.Update();
            return true;
        }

        private bool CreateTableSpecifOE(IDrawingTables Tables, MarkaKMDClass marka) // создать таблицу спецификации марки
        {
            SettingMarkaKMD setting = new SettingMarkaKMD();
            setting = marka.GetStructSetting();
            string desingMarka = marka.getDesignMarka();
            double massMarka = marka.getMassMarka();
            double massSvarka = marka.getMassZavodSvarka();
            double massZinc = marka.getMassZinc();
            List<PartKMDClass> ArrayParts = new List<PartKMDClass>();
            ArrayParts = marka.GetArrayParts(); // получить массив деталей
            int kolPart = ArrayParts.Count;
            int kolCR = kolPart;
            int rowS = 0, rowZ = 0;

            if (kolPart == 0) { return false; }
            if (Tables.Count == 0) // если в коллекции нет таблиц, создать шапку
            {
                if (!(CaptionTableSpecifOE(Tables))) { return false; }
            }                       
            if (setting.RazSvarka)
            {
                kolCR = kolCR + 1;
                rowS = kolCR - 1;
            }
            if (setting.ZinkCoat)
            {
                kolCR = kolCR + 1;
                rowZ = kolCR - 1;
            }
            IDrawingTable DrawingTable = Tables.Add(kolCR, 11, 8, 15, ksTableTileLayoutEnum.ksTTLNotCreate);
            if (DrawingTable == null)
            {
                //MessageBox.Show("Не удалось получить интерфейс IDrawingTable.");
                return false;
            }
            DrawingTable.X = this.currTable_X;
            DrawingTable.Y = this.currTable_Y;

            ITable Table = (ITable)DrawingTable;
            if (Table == null)
            {
                ////MessageBox.Show("Не удалось получить интерфейс ITable.");
                return false;
            }
            // установка размеров таблицы и объединение ячеек
            ((ICellFormat)Table.get_Cell(0, 1)).Width = 10;
            ((ICellFormat)Table.get_Cell(0, 2)).Width = 7.5;
            ((ICellFormat)Table.get_Cell(0, 3)).Width = 7.5;
            ((ICellFormat)Table.get_Cell(0, 4)).Width = 35;
            ((ICellFormat)Table.get_Cell(0, 5)).Width = 20;
            ((ICellFormat)Table.get_Cell(0, 8)).Width = 12;
            ((ICellFormat)Table.get_Cell(0, 9)).Width = 18;
            ((ICellFormat)Table.get_Cell(0, 10)).Width = 30;

            Table.get_Range(0, 0, kolCR-1, 0).CombineCells();
            Table.get_Range(0, 8, kolCR-1, 8).CombineCells();
            if (setting.RazSvarka)
            {
                Table.get_Range(rowS, 1, rowS, 4).CombineCells();
            }
            if (setting.ZinkCoat)
            {
                Table.get_Range(rowZ, 1, rowZ, 4).CombineCells();
            }

            ((ICellFormat)Table.get_Cell(0, 1)).Height = 8;
            // установка размеров таблицы и объединение ячеек
            DrawingTable.FixedCellsSize = true;
            // установка границы
            ((ICellBoundaries)(Table.get_Range(0, 0, kolCR-1, 10)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
            // установка границы
            // стили текста таблицы
            ((ICellFormat)Table.get_Range(0, 0, 0, 10)).TextStyle = (int)ksTextStyleEnum.ksTSTableCell;
            // стили текста таблицы
            // установка текста
            ((IText)(Table.get_Cell(0, 0).Text)).Str = desingMarka;
            DrawingTable.Update();
            ((IText)(Table.get_Cell(0, 8).Text)).Str = (massMarka + massSvarka + massZinc).ToString("N0");

            if (setting.RazSvarka)
            {
                ((IText)(Table.get_Cell(rowS, 1).Text)).Str = "Наплавленный металл";
                ((IText)(Table.get_Cell(rowS, 7).Text)).Str = massSvarka.ToString("N2");
            }
            if (setting.ZinkCoat)
            {
                ((IText)(Table.get_Cell(rowZ, 1).Text)).Str = "Цинк";
                ((IText)(Table.get_Cell(rowZ, 7).Text)).Str = massZinc.ToString("N2");
            }
            
            int lastPosList = 0;
            for (int i = 0; i < kolPart; i++)
            {
                lastPosList = ArrayParts[i].getPosInMarka();
                ((IText)(Table.get_Cell(i, 1).Text)).Str = (lastPosList).ToString();
                int kolT = ArrayParts[i].getKolTInMarka();
                if (kolT == 0)
                {
                    ((IText)(Table.get_Cell(i, 2).Text)).Str = "";
                }
                else
                {
                    ((IText)(Table.get_Cell(i, 2).Text)).Str = kolT.ToString();
                }
                int kolN = ArrayParts[i].getKolNInMarka();
                if (kolN == 0)
                {
                    ((IText)(Table.get_Cell(i, 3).Text)).Str = "";
                }
                else
                {
                    ((IText)(Table.get_Cell(i, 3).Text)).Str = kolN.ToString();
                }
                ((IText)(Table.get_Cell(i, 4).Text)).Str = ArrayParts[i].getProfPart().NameProf;
                ((IText)(Table.get_Cell(i, 5).Text)).Str = ArrayParts[i].getLengthPart().ToString("N1");
                double massP = ArrayParts[i].getMassPart();
                ((IText)(Table.get_Cell(i, 6).Text)).Str = massP.ToString("N2");
                double massAll = massP * (kolT + kolN);
                ((IText)(Table.get_Cell(i, 7).Text)).Str = massAll.ToString("N1");
                ((IText)(Table.get_Cell(i, 9).Text)).Str = ArrayParts[i].getMaterialPart().Name;
                ((IText)(Table.get_Cell(i, 10).Text)).Str = ArrayParts[i].getNote();
            }
            // currPosList = lastPosList;
            // установка текста
            this.currTable_Y = (double)(this.currTable_Y - 8 * (kolCR));
            DrawingTable.Update();
            return true;
        }

        #endregion

        #region Работа с ведомостью ОЭ

        private bool CreateTableVedomostOEonList(IDrawingTables Tables, List<MarkaKMDClass> ArrayMarksOnList) // создать таблицу ведомости отправочных элементов на листе
        {
            int kolMarks = ArrayMarksOnList.Count;
            if (kolMarks == 0)
            {
                return false;
            }
            double massAllMarks = 0;
            IDrawingTable DrawingTable = Tables.Add(kolMarks + 4, 4, 8, 20, ksTableTileLayoutEnum.ksTTLNotCreate);
            if (DrawingTable == null)
            {
                //MessageBox.Show("Не удалось получить интерфейс IDrawingTable.");
                return false;
            }

            DrawingTable.X = this.currTable_X + 100;
            DrawingTable.Y = this.currTable_Y;

            ITable Table = (ITable)DrawingTable;
            if (Table == null)
            {
                //MessageBox.Show("Не удалось получить интерфейс ITable.");
                return false;
            }
            // установка размеров таблицы и объединение ячеек
            ((ICellFormat)Table.get_Cell(0, 2)).Width = 25;
            Table.get_Range(0, 0, 0, 3).CombineCells();
            Table.get_Range(1, 0, 2, 0).CombineCells();
            Table.get_Range(1, 1, 2, 1).CombineCells();
            Table.get_Range(1, 2, 1, 3).CombineCells();
            Table.get_Range(kolMarks + 3, 0, kolMarks + 3, 2).CombineCells();
            ((ICellFormat)Table.get_Cell(0, 0)).Height = 10;
            ((ICellFormat)Table.get_Cell(1, 2)).Height = 15;
            ((ICellFormat)Table.get_Cell(2, 2)).Height = 20;
            // установка размеров таблицы и объединение ячеек
            DrawingTable.FixedCellsSize = true;
            // стили текста таблицы
            ((ICellFormat)Table.get_Range(0, 0, kolMarks + 3, 3)).TextStyle = (int)ksTextStyleEnum.ksTSTableCell;
            // стили текста таблицы
            // установка границы
            ((ICellBoundaries)(Table.get_Range(0, 0, 2, 3)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
            ((ICellBoundaries)(Table.get_Range(0, 0, kolMarks + 3, 3)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
            // установка границы
            // установка текста шапки таблицы
            ((IText)(Table.get_Cell(0, 0).Text)).Str = "Ведомость отправочных элементов";
            ((IText)(Table.get_Cell(1, 0).Text)).Str = "Марка\nэлемента";
            ((IText)(Table.get_Cell(1, 1).Text)).Str = "Кол-во шт.";
            ((IText)(Table.get_Cell(1, 2).Text)).Str = "Вес, кгс";
            ((IText)(Table.get_Cell(2, 2).Text)).Str = "одного\nэлемента";
            ((IText)(Table.get_Cell(2, 3).Text)).Str = "всех";
            ((IText)(Table.get_Cell(kolMarks + 3, 0).Text)).Str = "Итого:";
            // установка текста шапки таблицы

            // заполнение таблицы

            int i = 3;
            int i_p = 0;

            foreach (MarkaKMDClass marka in ArrayMarksOnList)
            {
                i_p = i_p + 1;
                EventProjectClass.EventValueProgressHandler((i_p*100)/ kolMarks);
                ((IText)(Table.get_Cell(i, 0).Text)).Str = marka.getDesignMarka();
                int kolOE = marka.getKolTInMS();
                ((IText)(Table.get_Cell(i, 1).Text)).Str = kolOE.ToString();
                double massMarka = marka.getMassMarka() + marka.getMassZavodSvarka() + marka.getMassZinc();
                ((IText)(Table.get_Cell(i, 2).Text)).Str = massMarka.ToString("N0");
                ((IText)(Table.get_Cell(i, 3).Text)).Str = (massMarka * kolOE).ToString("N0");
                massAllMarks = massAllMarks + (massMarka * kolOE);
                i = i + 1;
            }

            ((IText)(Table.get_Cell(kolMarks + 3, 3).Text)).Str = massAllMarks.ToString("N0");

            // заполнение таблицы       
            //DrawingTable.X = this.currTable_X + 100;
           // DrawingTable.Y = -(35+kolM*2*8+kolP*8);
            DrawingTable.Update();
            EventProjectClass.EventValueProgressHandler(0);
            return true;
        }

        #endregion

        #region Работа с СЗШ

        private bool CreateTableZSh(IDrawingTables Tables, List<MarkaKMDClass> ArrayMarksOnList) // создать таблицу СЗШ
        {
            int kolMarks = ArrayMarksOnList.Count;
            if (kolMarks == 0)
            {
                return false;
            }

            return true;
        }

        #endregion

        public void CreateTablesOnList(MountingSchemeClass ms, int indexList) // создать таблицы на листе с данным индексом 
        {
            if (ms == null) { return; }

            if (!(ms.TestIndexListOE(indexList)))
            {
                //MessageBox.Show("Листа с данным индексом не существует.");
                return;
            }

            ListOEClass list = new ListOEClass(ms.GetListInMS(indexList).getStructListOE());
            string pathDrawing = list.getPathDrawing();

            if (pathDrawing == "")
            {
                MessageBox.Show("Не указан путь к листу.");
                return;
            }

            IKompasDocument2D doc2d = kompasClass.OpenDrawing(pathDrawing);
            if (doc2d == null)
            {
                MessageBox.Show("Не удалось открыть файл " + Path.GetFileName(pathDrawing) + ".");
                return;
            }

            ksStamp stamp = kompasClass.GetStamp(doc2d);
            if (stamp == null)
            {
                //MessageBox.Show("Не удалось подключить интерфейс IStamp.");
                return;
            }

            if (stamp.ksOpenStamp()==1)
            {
                stamp.ksColumnNumber(2);

                stamp.ksTextLine(kompasClass.TextItemParam(ms.getDesignMS()));

                stamp.ksCloseStamp();
            }

            ISheetFormat SheetFormat = kompasClass.GetSheetFormatDrawing(doc2d); // получить интерфейс формата чертежа
            if (SheetFormat == null)
            {
                //MessageBox.Show("Не удалось подключить интерфейс ISheetFormat.");
                return;
            }

            //MessageBox.Show("Формат листа " + SheetFormat.Format.ToString() + ".");
            // MessageBox.Show("Ориентация формата листа " + SheetFormat.VerticalOrientation.ToString() + ".");

            IDrawingTables Tables = kompasClass.GetTables(doc2d, "Ведомости"); // коллекция таблиц
            if (Tables == null)
            {
                //MessageBox.Show("Не удалось получить интерфейс IDrawingTables.");
                return;
            }

            if (!(Tables.Count == 0)) // удаление имеющихся таблиц
            {
                int kolTables = Tables.Count;
                //MessageBox.Show("На чертеже " + kolTables.ToString() + " таблиц(ы).");
                for (int i_t = kolTables - 1; i_t>= 0; i_t--)
                {
                    IDrawingTable t = (IDrawingTable)Tables[i_t];
                    t.Delete();
                    t.Update();
                }
            }

            List<MarkaKMDClass> ArrayMarksOnList = new List<MarkaKMDClass>(); // массив марок МС

            foreach (MarkaKMDClass marka in ms.GetArrayMarks())
            {
                if (marka.getDesignList() == list.getDesignList())
                {
                    ArrayMarksOnList.Add(marka);
                }
            }

            int kolMarks = ArrayMarksOnList.Count;
            if (kolMarks == 0)
            {
                return;
            }
            currTable_X = -185;
            currTable_Y = 0;
            int i = 0;
            foreach (MarkaKMDClass marka in ArrayMarksOnList)
            {
                i = i + 1;
                EventProjectClass.EventValueProgressHandler((i*100)/kolMarks);
                if (!(CreateTableSpecifOE(Tables, marka)))
                {
                    MessageBox.Show("Ошибка при создании спецификации деталей.");
                    return;
                }
            }

            EventProjectClass.EventValueProgressHandler(0);

            if (!(CreateTableVedomostOEonList(Tables, ArrayMarksOnList)))
            {
                MessageBox.Show("Ошибка при создании ведомости отправочных элементов.");
                return;
            }

            if (!(CreateSpecifMaterial(Tables, ArrayMarksOnList)))
            {
                MessageBox.Show("Ошибка при создании cпецификация металлопроката.");
                return;
            }

            kompasClass.SaveCDW_in_Rastr(doc2d);
            kompasClass.CloseDrawing(doc2d);
            EventProjectClass.EventValueProgressHandler(0);
        }

        #endregion

        #region Работа с ведомостями на листе общих данных (ОД)

        public void CreateTablesOD(ProjectClass proj) // создать ведомости на листе ОД
        {

            if (proj == null) { return; }
            string pathDrawing = proj.getPathDrawing();

            if (pathDrawing == "")
            {
                MessageBox.Show("Не указан путь к листу.");
                return;
            }            

            IKompasDocument2D doc2d = kompasClass.OpenDrawing(pathDrawing);
            if (doc2d == null)
            {
                MessageBox.Show("Не удалось открыть файл " + Path.GetFileName(pathDrawing) + ".");
                return;
            }

            ksStamp stamp = kompasClass.GetStamp(doc2d);
            if (stamp == null)
            {
                //MessageBox.Show("Не удалось подключить интерфейс IStamp.");
                return;
            }

            if (stamp.ksOpenStamp() == 1)
            {
                stamp.ksColumnNumber(2);

                stamp.ksTextLine(kompasClass.TextItemParam(proj.getShifr()));

                stamp.ksCloseStamp();
            }

            ISheetFormat SheetFormat = kompasClass.GetSheetFormatDrawing(doc2d); // получить интерфейс формат чертежа
            if (SheetFormat == null)
            {
                //MessageBox.Show("Не удалось подключить интерфейс ISheetFormat.");
                return;
            }

            IDrawingTables Tables = kompasClass.GetTables(doc2d, "Ведомости ОД"); // коллекция таблиц
            if (Tables == null)
            {
                //MessageBox.Show("Не удалось получить интерфейс IDrawingTables.");
                return;
            }

            if (!(Tables.Count == 0)) // удаление имеющихся таблиц
            {
                int kolTables = Tables.Count;
                for (int i = kolTables - 1; i >= 0; i--)
                {
                    IDrawingTable t = (IDrawingTable)Tables[i];
                    t.Delete();
                    t.Update();
                }
            }

            currTable_X = 0;
            currTable_Y = 0;
            List<ListOEClass> ArrayListsOE = new List<ListOEClass>(); // массив листов
            List<MountingSchemeClass> ArrayMS = new List<MountingSchemeClass>(); // массив МС

            ArrayMS = proj.GetArrayMSInProj();
            foreach (MountingSchemeClass ms in ArrayMS)
            {
                foreach (ListOEClass list in ms.GetArrayListOE())
                {
                    ArrayListsOE.Add(list);                                       
                }
            }

            if (!(CreateVedomostMS(Tables, ArrayMS)))
            {
                MessageBox.Show("Ошибка при создании ведомости монтажных схем.");
                return;
            }

            if (!(CreateVedomostListsOE(Tables, ArrayListsOE, 60)))
            {
                MessageBox.Show("Ошибка при создании ведомости листов отправочных элементов.");
            }


        }

        private bool CreateVedomostMS(IDrawingTables Tables, List<MountingSchemeClass> ArrayMS) // создать ведомости МС
        {
            int kolMS = ArrayMS.Count;
            if (kolMS == 0)
            {
                return false;
            }
            double massAllK = 0, massAllM = 0, massAllS = 0;
            IDrawingTable DrawingTable = Tables.Add(kolMS + 4, 6, 8, 20, ksTableTileLayoutEnum.ksTTLNotCreate);
            if (DrawingTable == null)
            {
                //MessageBox.Show("Не удалось получить интерфейс IDrawingTable.");
                return false;
            }
            DrawingTable.X = this.currTable_X;
            DrawingTable.Y = this.currTable_Y;
            ITable Table = (ITable)DrawingTable;

            if (Table == null)
            {
                //MessageBox.Show("Не удалось получить интерфейс ITable.");
                return false;
            }

            // установка размеров таблицы и объединение ячеек
            ((ICellFormat)Table.get_Cell(0, 1)).Width = 80;
            ((ICellFormat)Table.get_Cell(0, 2)).Width = 25;
            ((ICellFormat)Table.get_Cell(0, 3)).Width = 15;
            ((ICellFormat)Table.get_Cell(0, 5)).Width = 25;
            Table.get_Range(0, 0, 0, 5).CombineCells();
            Table.get_Range(1, 2, 1, 4).CombineCells();
            Table.get_Range(1, 5, 2, 5).CombineCells();
            Table.get_Range(kolMS + 3, 0, kolMS + 1, 1).CombineCells();
            Table.get_Range(1, 0, 2, 0).CombineCells();
            Table.get_Range(1, 1, 2, 1).CombineCells();
            ((ICellFormat)Table.get_Cell(0, 0)).Height = 10;
            ((ICellFormat)Table.get_Cell(1, 2)).Height = 10;
            ((ICellFormat)Table.get_Cell(2, 2)).Height = 20;
            ((ICellFormat)Table.get_Cell(kolMS + 3, 0)).Height = 10;
            // установка размеров таблицы и объединение ячеек
            DrawingTable.FixedCellsSize = true;
            // стили текста таблицы
            ((ICellFormat)Table.get_Range(0, 0, kolMS + 3, 5)).TextStyle = (int)ksTextStyleEnum.ksTSTableCell;
            // стили текста таблицы
            // установка границы
            ((ICellBoundaries)(Table.get_Range(0, 0, 0, 5)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
            ((ICellBoundaries)(Table.get_Range(1, 0, 2, 5)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
            ((ICellBoundaries)(Table.get_Range(kolMS + 3, 0, kolMS + 3, 5)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
            ((ICellBoundaries)(Table.get_Range(0, 0, kolMS + 3, 5)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
            // установка границы
            // установка текста шапки таблицы
            ((IText)(Table.get_Cell(0, 0).Text)).Str = "Ведомость монтажных схем";
            ((IText)(Table.get_Cell(1, 0).Text)).Str = "Обозначение\nлиста";
            ((IText)(Table.get_Cell(1, 1).Text)).Str = "Наименование схемы";
            ((IText)(Table.get_Cell(1, 2).Text)).Str = "Вес, кгс";
            ((IText)(Table.get_Cell(2, 2).Text)).Str = "конст-\nрукции";
            ((IText)(Table.get_Cell(2, 3).Text)).Str = "мети-\nзов";
            ((IText)(Table.get_Cell(2, 4).Text)).Str = "свар-\nных\nмонт.\nшвов";
            ((IText)(Table.get_Cell(1, 5).Text)).Str = "Примечание";
            ((IText)(Table.get_Cell(kolMS + 3, 0).Text)).Str = "Итого:";
            // установка текста шапки таблицы

            // заполнение таблицы
            int i = 3;
            int i_p = 0;

            foreach (MountingSchemeClass ms in ArrayMS)
            {
                i_p = i_p + 1;
                EventProjectClass.EventValueProgressHandler((i_p * 100) / kolMS);
                ((IText)(Table.get_Cell(i, 0).Text)).Str = ms.getDesignMS();
                ((IText)(Table.get_Cell(i, 1).Text)).Str = ms.getNameMS();
                double massK = ms.getMassMarks();
                ((IText)(Table.get_Cell(i, 2).Text)).Str = massK.ToString("N1");
                double massM = ms.getMassMetiz();
                ((IText)(Table.get_Cell(i, 3).Text)).Str = massM.ToString("N1");
                double massS = ms.getMassMontSvarka();
                ((IText)(Table.get_Cell(i, 4).Text)).Str = massS.ToString("N1");
                ((IText)(Table.get_Cell(i, 5).Text)).Str = ms.getNote();
                massAllK = massAllK + massK;
                massAllM = massAllM + massM;
                massAllS = massAllS + massS;
                i = i + 1;
            }

            ((IText)(Table.get_Cell(kolMS + 3, 2).Text)).Str = massAllK.ToString("N0");
            ((IText)(Table.get_Cell(kolMS + 3, 3).Text)).Str = massAllM.ToString("N0");
            ((IText)(Table.get_Cell(kolMS + 3, 4).Text)).Str = massAllS.ToString("N0");

            // заполнение таблицы       
            //DrawingTable.X = this.currTable_X + 100;
            this.currTable_Y = this.currTable_Y - (kolMS*8 + 50);
            DrawingTable.Update();
            EventProjectClass.EventValueProgressHandler(0);
            return true;
        }

        private bool CreateVedomostListsOE(IDrawingTables Tables, List<ListOEClass> ArrayListsOE, int maxrow) // создать ведомости листов ОЭ
        {            
            #region Таблица данных
            int kolAllLists = ArrayListsOE.Count;
            if (kolAllLists == 0)
            {
                return false;
            }
            double massAllLists = 0;

            int kolTables = 0;
            int kolEndLists = 0;

            if (kolAllLists% maxrow == 0)
            {
                kolTables = kolAllLists / maxrow;
            } else
            {
                kolTables = kolAllLists / maxrow + 1;
                kolEndLists = kolAllLists - (kolTables - 1) * maxrow;
            }
            
            for (int j =0; j<kolTables; j++)
            {
                int kolLists = maxrow;
                if ((j + 1) == kolTables)
                {
                    if (kolEndLists == 0)
                    {
                        kolLists = maxrow;
                    } else
                    {
                        kolLists = kolEndLists;
                    }                    
                }

                #region Таблица-заголовок (шапка)
                // заголовок таблицы (шапка)
                IDrawingTable DrawingCaptionTable = Tables.Add(2, 4, 10, 20, ksTableTileLayoutEnum.ksTTLNotCreate);
                if (DrawingCaptionTable == null)
                {
                    //MessageBox.Show("Не удалось получить интерфейс IDrawingTable.");
                    return false;
                }
                DrawingCaptionTable.X = this.currTable_X+j*185;
                DrawingCaptionTable.Y = this.currTable_Y;
                ITable CaptionTable = (ITable)DrawingCaptionTable;
                if (CaptionTable == null)
                {
                    //MessageBox.Show("Не удалось получить интерфейс ITable.");
                    return false;
                }
            // установка размеров таблицы и объединение ячеек
            ((ICellFormat)CaptionTable.get_Cell(0, 1)).Width = 120;
                ((ICellFormat)CaptionTable.get_Cell(0, 3)).Width = 25;
                CaptionTable.get_Range(0, 0, 0, 3).CombineCells();
                ((ICellFormat)CaptionTable.get_Cell(0, 0)).Height = 10;
                ((ICellFormat)CaptionTable.get_Cell(1, 0)).Height = 20;
                // установка размеров таблицы и объединение ячеек
                DrawingCaptionTable.FixedCellsSize = true;
                // стили текста таблицы
                ((ICellFormat)CaptionTable.get_Range(0, 0, 1, 3)).TextStyle = (int)ksTextStyleEnum.ksTSTableCell;
                // стили текста таблицы
                // установка границы
                ((ICellBoundaries)(CaptionTable.get_Range(0, 0, 0, 3)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
                ((ICellBoundaries)(CaptionTable.get_Range(1, 0, 1, 3)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
                // установка границы
                // установка текста шапки таблицы
                if (kolTables == 1)
                {
                    ((IText)(CaptionTable.get_Cell(0, 0).Text)).Str = "Ведомость листов отправочных элементов";
                }
                else
                {
                    if (j == 0)
                    {
                        ((IText)(CaptionTable.get_Cell(0, 0).Text)).Str = "Ведомость листов отправочных элементов (начало)";
                    }
                    else
                    {
                        if ((j + 1) == kolTables)
                        {
                            ((IText)(CaptionTable.get_Cell(0, 0).Text)).Str = "Ведомость листов отправочных элементов (окончание)";
                        }
                        else
                        {
                            ((IText)(CaptionTable.get_Cell(0, 0).Text)).Str = "Ведомость листов отправочных элементов (продолжение)";
                        }
                    }
                }
                ((IText)(CaptionTable.get_Cell(1, 0).Text)).Str = "Обозначение\nлиста";
                ((IText)(CaptionTable.get_Cell(1, 1).Text)).Str = "Наименование";
                ((IText)(CaptionTable.get_Cell(1, 2).Text)).Str = "Вес, кгс";
                ((IText)(CaptionTable.get_Cell(1, 3).Text)).Str = "Примечание";
                DrawingCaptionTable.Update();
                // установка текста шапки таблицы
                // заголовок таблицы (шапка)
                #endregion

                IDrawingTable DrawingTable = Tables.Add(kolLists, 4, 8, 20, ksTableTileLayoutEnum.ksTTLNotCreate);
                if (DrawingTable == null)
                {
                    //MessageBox.Show("Не удалось получить интерфейс IDrawingTable.");
                    return false;
                }
                DrawingTable.X = this.currTable_X+j*185;
                DrawingTable.Y = this.currTable_Y-30;
                ITable Table = (ITable)DrawingTable;

                if (Table == null)
                {
                    //MessageBox.Show("Не удалось получить интерфейс ITable.");
                    return false;
                }

                // установка размеров таблицы и объединение ячеек
                ((ICellFormat)Table.get_Cell(0, 1)).Width = 120;
                ((ICellFormat)Table.get_Cell(0, 3)).Width = 25;
                ((ICellFormat)Table.get_Cell(0, 0)).Height = 8;
                // установка размеров таблицы и объединение ячеек
                DrawingTable.FixedCellsSize = true;
                // стили текста таблицы
                ((ICellFormat)Table.get_Range(0, 0, kolLists, 3)).TextStyle = (int)ksTextStyleEnum.ksTSTableCell;
                // стили текста таблицы
                // установка границы
                ((ICellBoundaries)(Table.get_Range(0, 0, kolLists, 3)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
                // установка границы

                // заполнение таблицы
                int i_p = 0;
                for (int m = 0; m < kolLists; m++)
                {
                    i_p = i_p + 1;
                    EventProjectClass.EventValueProgressHandler((i_p * 100) / kolLists);
                    ((IText)(Table.get_Cell(m, 0).Text)).Str = ArrayListsOE[(j* maxrow) +m].getDesignList();
                    ((IText)(Table.get_Cell(m, 1).Text)).Str = ArrayListsOE[(j * maxrow) + m].getNameList();
                    double massList = ArrayListsOE[(j * maxrow) + m].getMass();
                    ((IText)(Table.get_Cell(m, 2).Text)).Str = massList.ToString("N1");
                    massAllLists = massAllLists + massList;
                }
                DrawingTable.Update();
                EventProjectClass.EventValueProgressHandler(0);
                // заполнение таблицы   
            }

            // таблица данные
            #endregion

            #region Таблица итого
            // таблица итого

            IDrawingTable DrawingAllMassTable = Tables.Add(1, 4, 8, 20, ksTableTileLayoutEnum.ksTTLNotCreate);
            if (DrawingAllMassTable == null)
            {
                //MessageBox.Show("Не удалось получить интерфейс IDrawingTable.");
                return false;
            }
            DrawingAllMassTable.X = this.currTable_X+(kolTables-1)*185;
            this.currTable_X = DrawingAllMassTable.X + 185;
            if (kolEndLists == 0)
            {
                DrawingAllMassTable.Y = this.currTable_Y - maxrow*8-30;
            }
            else
            {
                DrawingAllMassTable.Y = this.currTable_Y - kolEndLists * 8-30;
            }            
            ITable AllMassTable = (ITable)DrawingAllMassTable;
            if (AllMassTable == null)
            {
                //MessageBox.Show("Не удалось получить интерфейс ITable.");
                return false;
            }
            // установка размеров таблицы и объединение ячеек
            ((ICellFormat)AllMassTable.get_Cell(0, 1)).Width = 120;
            ((ICellFormat)AllMassTable.get_Cell(0, 3)).Width = 25;
            ((ICellFormat)AllMassTable.get_Cell(0, 0)).Height = 10;
            AllMassTable.get_Range(0, 0, 0, 1).CombineCells();
            // установка размеров таблицы и объединение ячеек
            DrawingAllMassTable.FixedCellsSize = true;
            // стили текста таблицы
            ((ICellFormat)AllMassTable.get_Range(0, 0, 0, 3)).TextStyle = (int)ksTextStyleEnum.ksTSTableCell;
            // стили текста таблицы
            // установка границы
            ((ICellBoundaries)(AllMassTable.get_Range(0, 0, 0, 3)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
            ((ICellBoundaries)(AllMassTable.get_Range(0, 0, 0, 1)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
            // установка границы
            ((IText)(AllMassTable.get_Cell(0, 0).Text)).Str = "Итого, кгс";
            ((IText)(AllMassTable.get_Cell(0, 1).Text)).Str = massAllLists.ToString("N0");
            DrawingAllMassTable.Update();
            // таблица итого
            #endregion
            return true;
        }

        #endregion

        #region Работа с ведомостями МС

        public void CreateTablesMS(MountingSchemeClass ms) // создать ведомостей на МС
        {
            if (ms == null) { return; }
            string pathDrawing = ms.getPathDrawing();

            if (pathDrawing == "")
            {
                MessageBox.Show("Не указан путь к листу.");
                return;
            }

            IKompasDocument2D doc2d = kompasClass.OpenDrawing(pathDrawing);
            if (doc2d == null)
            {
                MessageBox.Show("Не удалось открыть файл " + Path.GetFileName(pathDrawing) + ".");
                return;
            }

            ksStamp stamp = kompasClass.GetStamp(doc2d);
            if (stamp == null)
            {
                //MessageBox.Show("Не удалось подключить интерфейс IStamp.");
                return;
            }

            if (stamp.ksOpenStamp() == 1)
            {
                stamp.ksColumnNumber(2);

                stamp.ksTextLine(kompasClass.TextItemParam(ms.getDesignMS()));

                stamp.ksCloseStamp();
            }

            ISheetFormat SheetFormat = kompasClass.GetSheetFormatDrawing(doc2d); // получить интерфейс формат чертежа
            if (SheetFormat == null)
            {
                //MessageBox.Show("Не удалось подключить интерфейс ISheetFormat.");
                return;
            }

            IDrawingTables Tables = kompasClass.GetTables(doc2d, "Ведомости МС"); // коллекция таблиц
            if (Tables == null)
            {
                //MessageBox.Show("Не удалось получить интерфейс IDrawingTables.");
                return;
            }

            if (!(Tables.Count == 0)) // удаление имеющихся таблиц
            {
                int kolTables = Tables.Count;
                //MessageBox.Show("На чертеже " + kolTables.ToString() + " таблиц(ы).");
                for (int i = kolTables - 1; i >= 0; i--)
                {
                    IDrawingTable t = (IDrawingTable)Tables[i];
                    t.Delete();
                    t.Update();
                }
            }

            List<MarkaKMDClass> ArrayMarks = new List<MarkaKMDClass>();
            ArrayMarks = ms.GetArrayMarks();

            int kolmarks = ArrayMarks.Count;
            if (kolmarks == 0)
            {
                return;
            }

            currTable_X = 0;
            currTable_Y = 0;

            if (!(CreateVedomostMarksInMS(Tables, ArrayMarks, 60)))
            {
                MessageBox.Show("Ошибка при создании ведомости отправочных элементов по схеме.");
                return;
            }

            if (!(CreateSpecifMaterial(Tables, ArrayMarks)))
            {
                MessageBox.Show("Ошибка при создании cпецификация металлопроката.");
                return;
            }

            List<MShClass> ArrayMSh = new List<MShClass>();

            ArrayMSh = ms.GetArrayMsh();
            int kolmsh = ArrayMSh.Count;
            if (kolmsh != 0)
            {
                if (!(CreateVedomostMSh(Tables, ArrayMSh)))
                {
                    //MessageBox.Show("Ошибка при создании ведомости монтажных швов.");                    
                }
            }

            List<MMClass> ArrayMM = new List<MMClass>();
            ArrayMM = ms.GetArrayMM();
            int kolmm = ArrayMM.Count;
            if (kolmm != 0)
            {
                if (!(CreateVedomostMM(Tables, ArrayMM)))
                {
                    //MessageBox.Show("Ошибка при создании ведомости монтажных метизов.");
                }
            }

            //kompasClass.CloseDrawing(doc2d);
        }

        private bool CreateVedomostMarksInMS(IDrawingTables Tables, List<MarkaKMDClass> ArrayMarks, int maxrow) // создать ведомости ОЭ по схеме
        {
            #region Таблица данных
            int kolAllMarks = ArrayMarks.Count;
            if (kolAllMarks == 0)
            {
                return false;
            }
            double massAll = 0;

            int kolTables = 0;
            int kolEndMarks = 0;

            if (kolAllMarks % maxrow == 0)
            {
                kolTables = kolAllMarks / maxrow;
            }
            else
            {
                kolTables = kolAllMarks / maxrow + 1;
                kolEndMarks = kolAllMarks - (kolTables - 1) * maxrow;
            }
            for (int j = 0; j < kolTables; j++)
            {
                int kolMarks = maxrow;
                if ((j + 1) == kolTables)
                {
                    if (kolEndMarks == 0)
                    {
                        kolMarks = maxrow;
                    }
                    else
                    {
                        kolMarks = kolEndMarks;
                    }
                }

                #region Таблица-заголовок (шапка)
                IDrawingTable DrawingCaptionTable = Tables.Add(3, 7, 10, 20, ksTableTileLayoutEnum.ksTTLNotCreate);
                if (DrawingCaptionTable == null)
                {
                    //MessageBox.Show("Не удалось получить интерфейс IDrawingTable.");
                    return false;
                }
                DrawingCaptionTable.X = this.currTable_X+j*185;
                DrawingCaptionTable.Y = this.currTable_Y;
                ITable CaptionTable = (ITable)DrawingCaptionTable;

                if (CaptionTable == null)
                {
                    //MessageBox.Show("Не удалось получить интерфейс ITable.");
                    return false;
                }

            // установка размеров таблицы и объединение ячеек
            ((ICellFormat)CaptionTable.get_Cell(0, 1)).Width = 70;
                ((ICellFormat)CaptionTable.get_Cell(0, 2)).Width = 15;
                ((ICellFormat)CaptionTable.get_Cell(0, 3)).Width = 15;
                ((ICellFormat)CaptionTable.get_Cell(0, 6)).Width = 25;
                CaptionTable.get_Range(0, 0, 0, 6).CombineCells();
                CaptionTable.get_Range(1, 0, 2, 0).CombineCells();
                CaptionTable.get_Range(1, 1, 2, 1).CombineCells();
                CaptionTable.get_Range(1, 2, 2, 2).CombineCells();
                CaptionTable.get_Range(1, 3, 1, 4).CombineCells();
                CaptionTable.get_Range(1, 5, 2, 5).CombineCells();
                CaptionTable.get_Range(1, 6, 2, 6).CombineCells();
                ((ICellFormat)CaptionTable.get_Cell(0, 0)).Height = 10;
                ((ICellFormat)CaptionTable.get_Cell(1, 3)).Height = 10;
                ((ICellFormat)CaptionTable.get_Cell(2, 3)).Height = 20;
                // установка размеров таблицы и объединение ячеек
                DrawingCaptionTable.FixedCellsSize = true;
                // стили текста таблицы
                ((ICellFormat)CaptionTable.get_Range(0, 0, 2, 6)).TextStyle = (int)ksTextStyleEnum.ksTSTableCell;
                // стили текста таблицы
                // установка границы
                ((ICellBoundaries)(CaptionTable.get_Range(0, 0, 0, 6)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
                ((ICellBoundaries)(CaptionTable.get_Range(1, 0, 2, 6)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
                ((ICellBoundaries)(CaptionTable.get_Range(0, 0, 2, 6)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
                // установка границы
                // установка текста шапки таблицы
                if (kolTables == 1)
                {
                    ((IText)(CaptionTable.get_Cell(0, 0).Text)).Str = "Ведомость отправочных элементов по схеме";
                } else
                {
                    if (j == 0)
                    {
                        ((IText)(CaptionTable.get_Cell(0, 0).Text)).Str = "Ведомость отправочных элементов по схеме (начало)";
                    } else
                    {
                        if ((j + 1) == kolTables)
                        {
                            ((IText)(CaptionTable.get_Cell(0, 0).Text)).Str = "Ведомость отправочных элементов по схеме (окончание)";
                        } else
                        {
                            ((IText)(CaptionTable.get_Cell(0, 0).Text)).Str = "Ведомость отправочных элементов по схеме (продолжение)";
                        }
                    }
                }
                
                ((IText)(CaptionTable.get_Cell(1, 0).Text)).Str = "Марка\nэлемен-\nта";
                ((IText)(CaptionTable.get_Cell(1, 1).Text)).Str = "Наименование\nэлемента";
                ((IText)(CaptionTable.get_Cell(1, 2).Text)).Str = "Кол-во\nэле-\nмен-\nтов";
                ((IText)(CaptionTable.get_Cell(1, 3).Text)).Str = "Вес, кгс";
                ((IText)(CaptionTable.get_Cell(2, 3).Text)).Str = "эле-\nмента";
                ((IText)(CaptionTable.get_Cell(2, 4).Text)).Str = "всех\nэлемен-\nтов";
                ((IText)(CaptionTable.get_Cell(1, 5).Text)).Str = "№ листа";
                ((IText)(CaptionTable.get_Cell(1, 6).Text)).Str = "Примечание";
                DrawingCaptionTable.Update();
                // установка текста шапки таблицы
                #endregion

                IDrawingTable DrawingTable = Tables.Add(kolMarks, 7, 8, 20, ksTableTileLayoutEnum.ksTTLNotCreate);
                if (DrawingTable == null)
                {
                    //MessageBox.Show("Не удалось получить интерфейс IDrawingTable.");
                    return false;
                }
                DrawingTable.X = this.currTable_X+j*185;
                DrawingTable.Y = this.currTable_Y-40;
                ITable Table = (ITable)DrawingTable;

                if (Table == null)
                {
                    //MessageBox.Show("Не удалось получить интерфейс ITable.");
                    return false;
                }

                // установка размеров таблицы и объединение ячеек
                ((ICellFormat)Table.get_Cell(0, 1)).Width = 70;
                ((ICellFormat)Table.get_Cell(0, 2)).Width = 15;
                ((ICellFormat)Table.get_Cell(0, 3)).Width = 15;
                ((ICellFormat)Table.get_Cell(0, 6)).Width = 25;
                ((ICellFormat)Table.get_Cell(0, 0)).Height = 8;
                // установка размеров таблицы и объединение ячеек
                DrawingTable.FixedCellsSize = true;
                // стили текста таблицы
                ((ICellFormat)Table.get_Range(0, 0, kolMarks, 6)).TextStyle = (int)ksTextStyleEnum.ksTSTableCell;
                // стили текста таблицы
                // установка границы
                ((ICellBoundaries)(Table.get_Range(0, 0, kolMarks, 6)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
                // установка границы

                // заполнение таблицы
                int i_p = 0;
                for (int m = 0; m < kolMarks; m++)
                {
                    i_p = i_p + 1;
                    EventProjectClass.EventValueProgressHandler((i_p*100)/kolMarks);
                    ((IText)(Table.get_Cell(m, 0).Text)).Str = ArrayMarks[(j * maxrow) + m].getDesignMarka();
                    ((IText)(Table.get_Cell(m, 1).Text)).Str = ArrayMarks[(j * maxrow) + m].getNameMarka();
                    int kolM = ArrayMarks[(j * maxrow) + m].getKolTInMS();
                    ((IText)(Table.get_Cell(m, 2).Text)).Str = kolM.ToString();
                    double massM = ArrayMarks[(j * maxrow) + m].getMassMarka() + ArrayMarks[(j * maxrow) + m].getMassZavodSvarka() + ArrayMarks[(j * maxrow) + m].getMassZinc();
                    ((IText)(Table.get_Cell(m, 3).Text)).Str = massM.ToString("N1");
                    double massM_all = massM * kolM;
                    ((IText)(Table.get_Cell(m, 4).Text)).Str = massM_all.ToString("N1");
                    ((IText)(Table.get_Cell(m, 5).Text)).Str = ArrayMarks[(j * maxrow) + m].getDesignList();
                    ((IText)(Table.get_Cell(m, 6).Text)).Str = ArrayMarks[(j * maxrow) + m].getNote();
                    massAll = massAll + massM_all;
                }
                // заполнение таблицы
                DrawingTable.Update();
                EventProjectClass.EventValueProgressHandler(0);
            }
                #endregion

            #region Таблица итого
            IDrawingTable DrawingAllMassTable = Tables.Add(1, 7, 8, 20, ksTableTileLayoutEnum.ksTTLNotCreate);
            if (DrawingAllMassTable == null)
            {
                //MessageBox.Show("Не удалось получить интерфейс IDrawingTable.");
                return false;
            }
            DrawingAllMassTable.X = this.currTable_X + (kolTables - 1) * 185;
            this.currTable_X = DrawingAllMassTable.X + 185;
            if (kolEndMarks == 0)
            {
                DrawingAllMassTable.Y = this.currTable_Y - maxrow * 8-40;
            }
            else
            {
                DrawingAllMassTable.Y = this.currTable_Y - kolEndMarks * 8-40;
            }
            ITable AllMassTable = (ITable)DrawingAllMassTable;

            if (AllMassTable == null)
            {
                //MessageBox.Show("Не удалось получить интерфейс ITable.");
                return false;
            }

            // установка размеров таблицы и объединение ячеек
            ((ICellFormat)AllMassTable.get_Cell(0, 1)).Width = 70;
            ((ICellFormat)AllMassTable.get_Cell(0, 2)).Width = 15;
            ((ICellFormat)AllMassTable.get_Cell(0, 3)).Width = 15;
            ((ICellFormat)AllMassTable.get_Cell(0, 6)).Width = 25;
            AllMassTable.get_Range(0, 0, 0, 3).CombineCells();
            ((ICellFormat)AllMassTable.get_Cell(0, 0)).Height = 10;
            // установка размеров таблицы и объединение ячеек
            DrawingAllMassTable.FixedCellsSize = true;
            // стили текста таблицы
            ((ICellFormat)AllMassTable.get_Range(0, 0, 0, 6)).TextStyle = (int)ksTextStyleEnum.ksTSTableCell;
            // стили текста таблицы
            // установка границы
            ((ICellBoundaries)(AllMassTable.get_Range(0, 0, 0, 6)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
            // установка границы
            // установка текста шапки таблицы
            ((IText)(AllMassTable.get_Cell(0, 0).Text)).Str = "Итого:";
            ((IText)(AllMassTable.get_Cell(0, 1).Text)).Str = massAll.ToString("N0");
            DrawingAllMassTable.Update();
            // установка текста шапки таблицы
            #endregion            
            return true;
        }

        private bool CreateVedomostMSh(IDrawingTables Tables, List<MShClass> ArrayMSh) // создать ведомости СМШ
        {
            int kolMSh = ArrayMSh.Count;
            if (kolMSh == 0)
            {
                return false;
            }
            IDrawingTable DrawingTable = Tables.Add(kolMSh + 3, 7, 8, 25, ksTableTileLayoutEnum.ksTTLNotCreate);
            if (DrawingTable == null)
            {
                //MessageBox.Show("Не удалось получить интерфейс IDrawingTable.");
                return false;
            }
            DrawingTable.X = this.currTable_X;
            DrawingTable.Y = this.currTable_Y;
            ITable Table = (ITable)DrawingTable;

            if (Table == null)
            {
                //MessageBox.Show("Не удалось получить интерфейс ITable.");
                return false;
            }

            // установка размеров таблицы и объединение ячеек
            ((ICellFormat)Table.get_Cell(0, 0)).Width = 20;
            ((ICellFormat)Table.get_Cell(0, 1)).Width = 20;
            ((ICellFormat)Table.get_Cell(0, 6)).Width = 45;
            Table.get_Range(0, 0, 0, 6).CombineCells();
            Table.get_Range(1, 0, 2, 0).CombineCells();
            Table.get_Range(1, 1, 2, 1).CombineCells();
            Table.get_Range(1, 2, 2, 2).CombineCells();
            Table.get_Range(1, 3, 1, 4).CombineCells();
            Table.get_Range(1, 5, 2, 5).CombineCells();
            Table.get_Range(1, 6, 2, 6).CombineCells();
            ((ICellFormat)Table.get_Cell(0, 0)).Height = 10;
            ((ICellFormat)Table.get_Cell(1, 3)).Height = 10;
            ((ICellFormat)Table.get_Cell(2, 3)).Height = 20;
            // установка размеров таблицы и объединение ячеек
            DrawingTable.FixedCellsSize = true;
            // стили текста таблицы
            ((ICellFormat)Table.get_Range(0, 0, kolMSh + 2, 6)).TextStyle = (int)ksTextStyleEnum.ksTSTableCell;
            // стили текста таблицы
            // установка границы
            ((ICellBoundaries)(Table.get_Range(0, 0, 0, 6)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
            ((ICellBoundaries)(Table.get_Range(1, 0, 2, 6)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
            ((ICellBoundaries)(Table.get_Range(0, 0, kolMSh + 2, 6)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
            // установка границы
            // установка текста шапки таблицы
            ((IText)(Table.get_Cell(0, 0).Text)).Str = "Ведомость монтажных швов";
            ((IText)(Table.get_Cell(1, 0).Text)).Str = "Марка\nэлемен-\nта";
            ((IText)(Table.get_Cell(1, 1).Text)).Str = "Кол-во\nэлемен-\nтов";
            ((IText)(Table.get_Cell(1, 2).Text)).Str = "Тип и\nтолщина\nшва\nмм";
            ((IText)(Table.get_Cell(1, 3).Text)).Str = "Длина шва, м";
            ((IText)(Table.get_Cell(2, 3).Text)).Str = "на одном\nэлементе";
            ((IText)(Table.get_Cell(2, 4).Text)).Str = "на\nвсех";
            ((IText)(Table.get_Cell(1, 5).Text)).Str = "Тип\nэлектро-\nдов";
            ((IText)(Table.get_Cell(1, 6).Text)).Str = "Примечание";
            // установка текста шапки таблицы

            // заполнение таблицы
            int i = 3;
            int i_p = 0;
            foreach (MShClass msh in ArrayMSh)
            {
                i_p = i_p + 1;
                EventProjectClass.EventValueProgressHandler((i_p * 100) / kolMSh);
                ((IText)(Table.get_Cell(i, 0).Text)).Str = msh.getMarkaElementa();
                int kolE = msh.getCountElements();
                ((IText)(Table.get_Cell(i, 1).Text)).Str = kolE.ToString();
                ((IText)(Table.get_Cell(i, 2).Text)).Str = msh.getTypeShva() + " &34" + msh.getTolschShva().ToString();
                double lsh = msh.getDlinaShva();
                ((IText)(Table.get_Cell(i, 3).Text)).Str = lsh.ToString("N1");
                double lsh_all = lsh * kolE;
                ((IText)(Table.get_Cell(i, 4).Text)).Str = lsh_all.ToString("N1");
                ((IText)(Table.get_Cell(i, 5).Text)).Str = msh.getTypeElectrod();
                ((IText)(Table.get_Cell(i, 6).Text)).Str = msh.getNote();
                i = i + 1;
            }
            // заполнение таблицы       
            //DrawingTable.X = this.currTable_X + 100;
            this.currTable_Y = this.currTable_Y - (kolMSh * 8 + 40);
            DrawingTable.Update();
            EventProjectClass.EventValueProgressHandler(0);

            return true;
        }

        private bool CreateVedomostMM(IDrawingTables Tables, List<MMClass> ArrayMM) // создать ведомости ММ
        {
            int kolMM = ArrayMM.Count;
            if (kolMM == 0)
            {
                return false;
            }
            IDrawingTable DrawingTable = Tables.Add(kolMM + 2, 8, 8, 20, ksTableTileLayoutEnum.ksTTLNotCreate);
            if (DrawingTable == null)
            {
                //MessageBox.Show("Не удалось получить интерфейс IDrawingTable.");
                return false;
            }
            DrawingTable.X = this.currTable_X;
            DrawingTable.Y = this.currTable_Y;
            ITable Table = (ITable)DrawingTable;

            if (Table == null)
            {
                //MessageBox.Show("Не удалось получить интерфейс ITable.");
                return false;
            }

            // установка размеров таблицы и объединение ячеек
            ((ICellFormat)Table.get_Cell(0, 0)).Width = 40;
            ((ICellFormat)Table.get_Cell(0, 4)).Width = 15;
            ((ICellFormat)Table.get_Cell(0, 5)).Width = 25;
            ((ICellFormat)Table.get_Cell(0, 7)).Width = 25;
            Table.get_Range(0, 0, 0, 7).CombineCells();
            ((ICellFormat)Table.get_Cell(0, 0)).Height = 10;
            ((ICellFormat)Table.get_Cell(1, 0)).Height = 20;
            // установка размеров таблицы и объединение ячеек
            DrawingTable.FixedCellsSize = true;
            // стили текста таблицы
            ((ICellFormat)Table.get_Range(0, 0, kolMM + 1, 7)).TextStyle = (int)ksTextStyleEnum.ksTSTableCell;
            // стили текста таблицы
            // установка границы
            ((ICellBoundaries)(Table.get_Range(0, 0, 0, 7)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
            ((ICellBoundaries)(Table.get_Range(1, 0, 1, 7)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
            ((ICellBoundaries)(Table.get_Range(0, 0, kolMM + 1, 7)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
            // установка границы
            // установка текста шапки таблицы
            ((IText)(Table.get_Cell(0, 0).Text)).Str = "Ведомость монтажных метизов (постоянных)";
            ((IText)(Table.get_Cell(1, 0).Text)).Str = "Наименование\nи диаметр";
            ((IText)(Table.get_Cell(1, 1).Text)).Str = "Толщина\nпакета\nмм";
            ((IText)(Table.get_Cell(1, 2).Text)).Str = "Длина\nмм";
            ((IText)(Table.get_Cell(1, 3).Text)).Str = "Кол-во\nшт.";
            ((IText)(Table.get_Cell(1, 4).Text)).Str = "Вес\nкгс";
            ((IText)(Table.get_Cell(1, 5).Text)).Str = "ГОСТ";
            ((IText)(Table.get_Cell(1, 6).Text)).Str = "Класс\nпроч-\nности\nболта";
            ((IText)(Table.get_Cell(1, 7).Text)).Str = "Примечание";
            // установка текста шапки таблицы

            // заполнение таблицы
            int i = 2;
            int i_p = 0;
            foreach (MMClass mm in ArrayMM)
            {
                i_p = i_p + 1;
                EventProjectClass.EventValueProgressHandler((i_p * 100) / kolMM);
                ((IText)(Table.get_Cell(i, 0).Text)).Str = mm.Name + " " + mm.Diameter;
                ((IText)(Table.get_Cell(i, 1).Text)).Str = mm.ThicknessPackage.ToString("N2");
                ((IText)(Table.get_Cell(i, 2).Text)).Str = mm.Length.ToString("N2");
                ((IText)(Table.get_Cell(i, 3).Text)).Str = mm.Quantity.ToString();
                ((IText)(Table.get_Cell(i, 4).Text)).Str = mm.Mass.ToString("N2");
                ((IText)(Table.get_Cell(i, 5).Text)).Str = mm.GOST;
                ((IText)(Table.get_Cell(i, 6).Text)).Str = mm.ClassStrength;
                ((IText)(Table.get_Cell(i, 7).Text)).Str = mm.Note;
                i = i + 1;
            }
            // заполнение таблицы       
            //DrawingTable.X = this.currTable_X + 100;
            this.currTable_Y = this.currTable_Y - (kolMM * 8 + 30);
            DrawingTable.Update();
            EventProjectClass.EventValueProgressHandler(0);
            return true;
        }
        

        #endregion

        #region Материальная спецификация

        private bool CreateSpecifMaterial(IDrawingTables Tables, List<MarkaKMDClass> ArrayMarks) // создать материальную специцикацию
        {
            List<SpecifMaterial> ArraySpecifMaterials = new List<SpecifMaterial>();
            foreach (MarkaKMDClass marka in ArrayMarks)
            {
                foreach (PartKMDClass part in marka.GetArrayParts())
                {
                    string prof = part.getProfPart().NameProf.Trim();
                    if (prof.First() == '-')
                    {
                        string[] arrProj = prof.Split(new char[] { 'х' });
                        prof = arrProj[0];
                       // MessageBox.Show("Толщина листа: " + prof);
                    }
                    string steel = part.getMaterialPart().Name;
                    double mass = part.getMassPart()*(part.getKolNInMarka()+part.getKolTInMarka())*marka.getKolTInMS();
                    SpecifMaterial specif = new SpecifMaterial();
                    bool flag = false;
                    for (int i = 0; i < ArraySpecifMaterials.Count; i++)
                    {
                        specif.prof = ArraySpecifMaterials[i].prof;
                        specif.steel = ArraySpecifMaterials[i].steel;
                        if ((specif.prof == prof) && (specif.steel == steel))
                        {
                            specif.mass = ArraySpecifMaterials[i].mass;
                            specif.mass = specif.mass + mass;
                            ArraySpecifMaterials[i] = specif;
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        specif.prof = prof;
                        specif.steel = steel;
                        specif.mass = mass;
                        ArraySpecifMaterials.Add(specif);
                    }                    
                } 
            }

            ArraySpecifMaterials.Sort(delegate (SpecifMaterial m1, SpecifMaterial m2)
            {
                return m1.prof.CompareTo(m2.prof);
            });

            // отрисовка таблицы
            int kol = ArraySpecifMaterials.Count;
            int row = kol + 3;
            IDrawingTable DrawingTable = Tables.Add(row, 3, 8, 20, ksTableTileLayoutEnum.ksTTLNotCreate);
            if (DrawingTable == null)
            {
                //MessageBox.Show("Не удалось получить интерфейс IDrawingTable.");
                return false;
            }
            DrawingTable.X = this.currTable_X;
            DrawingTable.Y = this.currTable_Y;

            ITable Table = (ITable)DrawingTable;
            if (Table == null)
            {
                //MessageBox.Show("Не удалось получить интерфейс ITable.");
                return false;
            }
            // установка размеров таблицы и объединение ячеек
            ((ICellFormat)Table.get_Cell(0, 0)).Width = 40;
            ((ICellFormat)Table.get_Cell(0, 1)).Width = 30;
            ((ICellFormat)Table.get_Cell(0, 2)).Width = 20;

            Table.get_Range(0, 0, 0, 2).CombineCells();
            Table.get_Range(row-1, 0, row-1, 1).CombineCells();
            ((ICellFormat)Table.get_Cell(0, 0)).Height = 10;
            // установка размеров таблицы и объединение ячеек
            DrawingTable.FixedCellsSize = true;
            // установка границы
            ((ICellBoundaries)(Table.get_Range(0, 0, row - 1, 2)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
            ((ICellBoundaries)(Table.get_Range(0, 0, 0, 2)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
            ((ICellBoundaries)(Table.get_Range(1, 0, 1, 2)).CellsBoundaries).LineStyle[ksCellBoundariesEnum.ksCBExternalBorders] = ksCurveStyleEnum.ksCSNormal;
            // установка границы
            // стили текста таблицы
            ((ICellFormat)Table.get_Range(0, 0, row - 1, 2)).TextStyle = (int)ksTextStyleEnum.ksTSTableCell;
            // стили текста таблицы
            // установка текста
            // установка текста шапки таблицы
            ((IText)(Table.get_Cell(0, 0).Text)).Str = "Спецификация металлопроката";
            ((IText)(Table.get_Cell(1, 0).Text)).Str = "Профиль, ГОСТ или ТУ";
            ((IText)(Table.get_Cell(1, 1).Text)).Str = "Марка стали";
            ((IText)(Table.get_Cell(1, 2).Text)).Str = "Вес, кгс";
            ((IText)(Table.get_Cell(row-1, 0).Text)).Str = "Всего, кгс";
            // установка текста шапки таблицы
            double massAll = 0;
            int i_p = 0;
            for (int i = 0; i < kol; i++)
            {
                i_p = i_p + 1;
                EventProjectClass.EventValueProgressHandler((i_p * 100) / kol);
                ((IText)(Table.get_Cell(i + 2, 0).Text)).Str = ArraySpecifMaterials[i].prof;
                ((IText)(Table.get_Cell(i + 2, 1).Text)).Str = ArraySpecifMaterials[i].steel;
                massAll = massAll + ArraySpecifMaterials[i].mass;
                ((IText)(Table.get_Cell(i + 2, 2).Text)).Str = ArraySpecifMaterials[i].mass.ToString("N1");
            }            
            ((IText)(Table.get_Cell(row - 1, 2).Text)).Str = massAll.ToString("N1");
            // установка текста
            this.currTable_Y = (double)(this.currTable_Y - 8 * (row+2)-10);
            DrawingTable.Update();
            EventProjectClass.EventValueProgressHandler(0);
            return true;
        }

        #endregion
    }
}
