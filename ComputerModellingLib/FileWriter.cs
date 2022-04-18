using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            for(int i = 1; i <= expertsCount; i++)
            {
                expertsStr += "\"Эксперт " + i + "\"" + ";";
                propertygroupTab += ";";
            }

            foreach (Controller controller in controllers)
            {
                //название контроллера
                streamWriter.WriteLine("\"" + controller.ControllerName + "\"" + ";");
                
                //заголовок таблицы свойств
                streamWriter.WriteLine("\"Название группы свойств\"" + ";" + "\"Название свойства\"" + ";" + expertsStr + "\"сумма оценок\"" +  ";" + "\"ai \"" + ";" + "\" ∑ai \"" + ";" + "\" Wi \"");;
                foreach (PropertyGroup propertyGroup in controller.PropertyGroups)
                {
                    //название группы свойств
                    streamWriter.WriteLine("\"" + propertyGroup.PropetyGroupName + "\"" + ";" + ";" + propertygroupTab + ";" + propertyGroup.PropertyesAverageExpertAssessmentsSum);
                    foreach(Property property in propertyGroup.Properties)
                    {
                        //название свойсвта
                        string propertyInfo = ";" + "\"" + property.Name ;
                        if(property.Reversed)
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
                streamWriter.WriteLine("\""+ controller.ControllerName + "\"" + ";" + controller.AdditiveEstimate);
            }
            streamWriter.Close();
            return true;
        }
    }
}
