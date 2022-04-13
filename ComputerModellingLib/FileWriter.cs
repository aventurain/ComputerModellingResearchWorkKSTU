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
        public static void CreateCSVfileAndWrite(List<Controller> controllers, string Path)
        {
            StreamWriter streamWriter = new StreamWriter(Path);
            foreach(Controller controller in controllers)
            {
                streamWriter.WriteLine("\""+ controller.ControllerName + "\"" + ";" + controller.AdditiveEstimate);
            }
            streamWriter.Close();
        }
    }
}
