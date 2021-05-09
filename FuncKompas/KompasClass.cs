using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


namespace FuncKompas
{
   
    public class KompasClass
    {
        KompasObject Kompas = null;

        string DirProj = "";

        public KompasClass(KompasObject kompas, string dirproj) // конструктор класса
        {
            Kompas = kompas;
            DirProj = dirproj;
        }

        public IDocuments TestKompas7() // тест на поключение к компасу
        {
            if (Kompas == null)
            {
                //MessageBox.Show("Не удалось подключить интерфейс Компас. Проверьте, запущен ли Компас.");
                return null;
            }

            IApplication kompas7 = Kompas.ksGetApplication7();
            if (kompas7 == null)
            {
                //MessageBox.Show("Не удалось подключить интерфейс Компас.App7.");
                return null;
            }

            IDocuments docs7 = kompas7.Documents;
            if (docs7 == null)
            {
                //MessageBox.Show("Не удалось подключить интерфейс Компас.IDocuments.");
                return null;
            }

            return docs7;
        }

        public IPart7 GetPart7(string pathModel) // открыть модель и получить интерфейс IPart7 по пути к модели
        {
            IDocuments docs7 = TestKompas7();
            if (docs7 == null)
            {
                //MessageBox.Show("Не удалось подключить интерфейс Компас.IDocuments.");
                return null;
            }

            if (!File.Exists(pathModel))
            {
                //MessageBox.Show("Не удалось найти файл " + Path.GetFileName(pathModel) + ".");
                return null;
            }

            IKompasDocument3D doc = (IKompasDocument3D)docs7.Open(pathModel, true, false);

            if (doc == null)
            {
                //MessageBox.Show("Не удалось открыть докумемент.");
                return null;
            }

            doc.Active = true;

            IPart7 part = doc.TopPart;
            if (part == null)
            {
                //MessageBox.Show("Не удалось подключить интерфейс Компас.IPart7.");
                return null;
            }
            return part;
        }

        public bool ClosePart(IPart7  part) // закрыть модель
        {
            IDocuments docs7 = TestKompas7();            
            IKompasDocument3D doc = (IKompasDocument3D)docs7.Open(part.FileName, true, false);
            doc.Active = true;
            if (doc == null)
            {
                return false;
            }            
            return doc.Close(DocumentCloseOptions.kdSaveChanges);
        }

        public double GetMassModel(string pathModel) // получить массу из модели (не удалось код -1)
        {
            double MassModel = 0;

            IPart7 part = GetPart7(pathModel);
            if (part == null)
            {
                return -1;
            }

            MassModel = part.Mass / 1000; // масса в кг

            return MassModel;
        }

        public string[] GetMaterialModel(string pathModel) // получить материал из модели
        {
            string strMaterial = "";

            IPart7 part = GetPart7(pathModel);
            if (part == null)
            {
                return null;
            }

            strMaterial = part.Material;

            string[] ArrStr = strMaterial.Split(';');

            int KolStr = ArrStr.Length;
            if (KolStr == 2)
            {
                ArrStr[0] = ArrStr[0].Replace("$d", " ");
                ArrStr[0] = ArrStr[0].Trim();
                ArrStr[1] = ArrStr[1].Replace("$", "");
                ArrStr[1] = ArrStr[1].Trim();
            }

            return ArrStr;
        }

        public IKompasDocument2D OpenDrawing(string pathDrawing) // открыть чертеж в компасе
        {
            IDocuments docs7 = TestKompas7();
            if (docs7 == null)
            {
                //MessageBox.Show("Не удалось подключить интерфейс Компас.IDocuments.");
                return null;
            }

            if (!File.Exists(pathDrawing))
            {
                pathDrawing = DirProj + Path.DirectorySeparatorChar + "Чертежи" + Path.DirectorySeparatorChar + Path.GetFileName(pathDrawing);
                if (!File.Exists(pathDrawing))
                {
                    MessageBox.Show("Не удалось найти файл " + Path.GetFileName(pathDrawing) + ".");
                    return null;
                }
            }

            IKompasDocument2D doc2d = (IKompasDocument2D)docs7.Open(pathDrawing, true, false);

            if (doc2d == null)
            {
                MessageBox.Show("Не удалось открыть докумемент.");
                return null;
            }

            doc2d.Active = true;

            return doc2d;
        }

        public ksStamp GetStamp(IKompasDocument2D doc)
        {
            ksDocument2D doc2d = (ksDocument2D)Kompas.TransferInterface(doc, (int)ksAPITypeEnum.ksAPI5Auto, 0);
            if (doc2d == null)
            {
               // MessageBox.Show("Не удалось преобразовать в интерфейс ksDocument2D.");
                return null;
            }
            ksStamp stamp = doc2d.GetStamp();            
            if (stamp == null)
            {
                return null;
            }
            return stamp;
        }

        public ksTextItemParam TextItemParam(string str)
        {
            ksTextItemParam textIP = Kompas.GetParamStruct((short)StructType2DEnum.ko_TextItemParam);
            textIP.Init();
            textIP.s = str;
            return textIP;
        }

        public bool CloseDrawing(IKompasDocument2D doc2D)
        {
            if (doc2D.Close(DocumentCloseOptions.kdSaveChanges))
            {
                return true;
            }
            return false;
        }

        public ISheetFormat GetSheetFormatDrawing(IKompasDocument2D doc2d) // получить интерфейс формат чертежа
        {

            ILayoutSheets LayoutSheets = doc2d.LayoutSheets; // коллекция листов
            if (LayoutSheets == null)
            {
               // MessageBox.Show("Не удалось подключить интерфейс ILayoutSheets.");
                return null;
            }
            ILayoutSheet LayoutSheet = (ILayoutSheet)LayoutSheets[0]; // лист оформления
            if (LayoutSheet == null)
            {
                //MessageBox.Show("Не удалось подключить интерфейс ILayoutSheet.");
                return null;
            }
            ISheetFormat SheetFormat = LayoutSheet.Format; // интерфейс формата листа
            if (SheetFormat == null)
            {
               // MessageBox.Show("Не удалось подключить интерфейс ISheetFormat.");
                return null;
            }
            /*ksDocumentFormatEnum formatLayout = SheetFormat.Format; // формат листа (значение)
            format = (int)formatLayout;
            long H = (long)SheetFormat.FormatHeight;
            long W = (long)SheetFormat.FormatWidth;
            MessageBox.Show("Высота формата: " + H.ToString() + "; Ширина формата: "+W.ToString());*/
            return SheetFormat;
        }

        public IDrawingTables GetTables(IKompasDocument2D doc2d, string NameView) // получить интерфейс коллекции таблиц (входной параметр: имя вида расположения таблицы)
        {
            IViewsAndLayersManager ViewsManadger = doc2d.ViewsAndLayersManager; // менеджер видов и слоев
            if (ViewsManadger == null)
            {
                //MessageBox.Show("Не удалось получить интерфейс IViewsAndLayersManager.");
                return null;
            }
            IViews views = ViewsManadger.Views; // коллекция видов
            if (views == null)
            {
               // MessageBox.Show("Не удалось получить интерфейс IViews.");
                return null;
            }
            IView viewSpecif = views.get_View(NameView); // вид с ведомостями
            if (viewSpecif == null)
            {
                viewSpecif = views.Add(LtViewType.vt_Normal);
                if (viewSpecif == null)
                {
                    //MessageBox.Show("Не удалось получить интерфейс IView.");
                    return null;
                }
                viewSpecif.Name = NameView;
                viewSpecif.X = 0;
                viewSpecif.Y = 0;
                if (!(viewSpecif.Update()))
                {
                    MessageBox.Show("Не удалось обновить вид.");
                    return null;
                }
            }
            viewSpecif.Current = true;
            viewSpecif.Update();

            ISymbols2DContainer ContainerTables = (ISymbols2DContainer)viewSpecif; // контейнер таблиц
            if (ContainerTables == null)
            {
                //MessageBox.Show("Не удалось получить интерфейс ISymbols2DContainer.");
                return null;
            }
            IDrawingTables Tables = ContainerTables.DrawingTables; // коллекция таблиц
            if (Tables == null)
            {
                //MessageBox.Show("Не удалось получить интерфейс IDrawingTables.");
                return null;
            }
            return Tables;
        }

        public string GetFormatDrawing(string pathDrawing)
        {
            IKompasDocument2D doc = OpenDrawing(pathDrawing);
            ISheetFormat sheetformat = GetSheetFormatDrawing(doc);
            if (sheetformat == null) return "не определен";
            ksDocumentFormatEnum format = sheetformat.Format;
            long formatMultiplicity = sheetformat.FormatMultiplicity;
            string str_formatMultiplicity = "";
            if (formatMultiplicity > 1)
            {
                str_formatMultiplicity = "x" + formatMultiplicity.ToString();
            }
            switch (format)
            {
                case ksDocumentFormatEnum.ksFormatA0:
                    return "А0"+ str_formatMultiplicity;
                case ksDocumentFormatEnum.ksFormatA1:
                    return "А1" + str_formatMultiplicity;
                case ksDocumentFormatEnum.ksFormatA2:
                    return "А2" + str_formatMultiplicity;
                case ksDocumentFormatEnum.ksFormatA3:
                    return "А3" + str_formatMultiplicity;
                case ksDocumentFormatEnum.ksFormatA4:
                    return "А4" + str_formatMultiplicity;
                case ksDocumentFormatEnum.ksFormatA5:
                    return "А5" + str_formatMultiplicity;
                case ksDocumentFormatEnum.ksFormatUser:
                    return sheetformat.FormatWidth.ToString()+"x"+ sheetformat.FormatHeight.ToString();
                default:
                    return "не определен";
            }
        }

        public bool SaveCDW_in_Rastr(IKompasDocument2D doc7)
        {
            ksDocument2D doc = (ksDocument2D)Kompas.TransferInterface(doc7, (int)ksAPITypeEnum.ksAPI5Auto, 0);
            DocumentParam docP = (DocumentParam)Kompas.GetParamStruct((short)StructType2DEnum.ko_DocumentParam);
            if (docP == null)
            {
                //Kompas.ksMessage("Не удалось получить интерфейс DocumentParam");
                return false;
            }
            int t = doc.ksGetObjParam(doc.reference, docP);
            string filename = docP.fileName;
            filename = filename.Substring(0, filename.Length - 4);
            RasterFormatParam formatRasret = doc.RasterFormatParam();
            //if (formatRasret.Init())
            //{
            //    kompas.ksMessage("Обнулились параметры RasterFormatParam");
            //}            
            formatRasret.format = 2;
            formatRasret.colorBPP = 24;
            formatRasret.colorType = 1;
            formatRasret.extResolution = 300;
            formatRasret.extScale = 1;
            formatRasret.greyScale = false;
            formatRasret.onlyThinLine = false;
            formatRasret.multiPageOutput = false;
            string fileTiff_f = filename + ".jpg";
            if (!doc.SaveAsToRasterFormat(fileTiff_f, formatRasret))
                {
                    return false;
                }
            return true;
        }

    }
}
