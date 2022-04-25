using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace ComputerModellingLib
{
    public static class FileWriter
    {
        //Путь включает в себя имя файла
        public static bool CreateCSVfileAndWrite(List<Controller> controllers, int expertsCount, string Path)
        {
            StreamWriter streamWriter;
            try
            {
                streamWriter = new StreamWriter(Path, false, Encoding.UTF8);
            }
            catch
            {
                return false;
            }
            string expertsStr = "";
            string propertygroupTab = ";";
            for (int i = 1; i <= expertsCount; i++)
            {
                expertsStr += "\"Эксперт " + i + "\"" + ";";
                propertygroupTab += ";";
            }

            foreach (Controller controller in controllers)
            {
                //название контроллера
                streamWriter.WriteLine("\"" + controller.ControllerName + "\"" + ";");

                //заголовок таблицы свойств
                streamWriter.WriteLine("\"Название группы свойств\"" + ";" + "\"Название свойства\"" + ";" + expertsStr + "\"сумма оценок\"" + ";" + "\"ai \"" + ";" + "\" ∑ai \"" + ";" + "\" Wi \""); ;
                foreach (PropertyGroup propertyGroup in controller.PropertyGroups)
                {
                    //название группы свойств
                    streamWriter.WriteLine("\"" + propertyGroup.PropetyGroupName + "\"" + ";" + ";" + propertygroupTab + ";" + propertyGroup.PropertyesAverageExpertAssessmentsSum);
                    foreach (Property property in propertyGroup.Properties)
                    {
                        //название свойсвта
                        string propertyInfo = ";" + "\"" + property.Name;
                        if (property.Reversed)
                        {
                            propertyInfo += "*";
                        }
                        propertyInfo += "\"" + ";";
                        //оценки экспертов
                        foreach (int i in property.ExpertAssessments)
                        {
                            propertyInfo += i + ";";
                        }

                        propertyInfo += property.SumOfExpertAssessments + ";" + property.AverageExpertAssessment + ";;" + property.AdditiveEstimate;
                        streamWriter.WriteLine(propertyInfo);
                        //дополнительная информация
                    }
                }
                streamWriter.WriteLine();
            }

            streamWriter.WriteLine();
            streamWriter.WriteLine("\"Название контроллера\"" + ";" + "\"Аддитивная оценка контроллера\"");

            foreach (Controller controller in controllers)
            {
                streamWriter.WriteLine("\"" + controller.ControllerName + "\"" + ";" + controller.AdditiveEstimate);
            }
            streamWriter.Close();
            return true;
        }

        public static bool CreateXLCfileAndWrite(List<Controller> controllers, int expertsCount, string Path)
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Контроллеры и их оценки");

            int row = 1; int column = 1;

            foreach (Controller controller in controllers)
            {
                //название контроллера
                ws.Cell(row, column).Value = controller.ControllerName;
                row++;
                //заголовок таблицы свойств
                ws.Cell(row, column).Value = "Название группы свойств";
                ws.Cell(row, column + 1).Value = "Название свойства";
                WriteXeperts(row, expertsCount, ws);
                ws.Cell(row, column + expertsCount + 2).Value = "сумма оценок";
                ws.Cell(row, column + expertsCount + 3).Value = "ai";
                ws.Cell(row, column + expertsCount + 4).Value = "∑ai";
                ws.Cell(row, column + expertsCount + 5).Value = "Wi";

                row++;
                foreach (PropertyGroup propertyGroup in controller.PropertyGroups)
                {

                    //название группы свойств
                    ws.Cell(row, column).Value = propertyGroup.PropetyGroupName;
                    ws.Cell(row, column + expertsCount + 4).Value = propertyGroup.PropertyesAverageExpertAssessmentsSum;
                    row++;
                    foreach (Property property in propertyGroup.Properties)
                    {
                        column = 2;
                        //название свойсвта

                        if (property.Reversed)
                        {
                            ws.Cell(row, column).Value = property.Name + "*";
                        }
                        else
                        {
                            ws.Cell(row, column).Value = property.Name;
                        }
                        column++;
                        //оценки экспертов
                        foreach (int i in property.ExpertAssessments)
                        {
                            ws.Cell(row, column).Value = i;
                            column++;
                        }
                        //дополнительная информация
                        ws.Cell(row, column).Value = property.SumOfExpertAssessments;
                        ws.Cell(row, column + 1).Value = property.AverageExpertAssessment;
                        ws.Cell(row, column + 3).Value = property.AdditiveEstimate;
                        row++;
                    }
                    column = 1;
                }
                row++;
            }

            ws.Cell(row, column).Value = "Название контроллера";
            ws.Cell(row, column + 1).Value = "Аддитивная оценка контроллера";

            foreach (Controller controller in controllers)
            {
                row++;
                ws.Cell(row, column).Value = controller.ControllerName;
                ws.Cell(row, column + 1).Value = controller.AdditiveEstimate;
            }

            wb.SaveAs(Path);
            return true;
        }

        private static void WriteXeperts(int row, int ExpertsCount, IXLWorksheet ws)
        {
            for (int i = 1; i <= ExpertsCount; i++)
            {
                ws.Cell(row, 2 + i).Value = "Эксперт " + i;
            }
        }
    }

    [Serializable()]
    public class ControllerGroupSaver
    {
        private List<Controller> Controllers;

        public void Save(string directory, string name, List<Controller> controllers)
        {
            Controllers = controllers;

            string path = directory;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += @"\" + name;
            FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, this);
            stream.Close();
        }

        //Функция загрузки контроллера возвращает null если контроллер отсутствует
        static public List<Controller> Load(string directory)
        {
            if (!File.Exists(directory))
            {
                return null;
            }
            FileStream stream = new FileStream(directory, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            ControllerGroupSaver controller = (ControllerGroupSaver)bf.Deserialize(stream);
            stream.Close();
            return controller.Controllers;
        }

    }
}
