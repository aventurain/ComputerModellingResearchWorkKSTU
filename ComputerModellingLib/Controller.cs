using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ComputerModellingLib
{
    [Serializable()]
    public class Controller
    {
        public Controller(string ControlerName, List<PropertyGroup> PropertyGroups)
        {
            controllerName = ControlerName;
            propertyGroups = PropertyGroups;
        }
        public Controller(string ControlerName)
        {
            controllerName = ControlerName;
            propertyGroups = new List<PropertyGroup>();
        }

        public void AddPropertyGroup(PropertyGroup propertyGroup)
        {
            AdditiveEstimate = 0;
            propertyGroups.Add(propertyGroup);
        }

        private List<PropertyGroup> propertyGroups = new List<PropertyGroup>();
        //Группы свойств
        public List<PropertyGroup> PropertyGroups
        {
            get
            {
                return propertyGroups;
            }
            set
            {
                AdditiveEstimate = 0;
                propertyGroups = new List<PropertyGroup>(value);
            }
        }

        private string controllerName;
        //Название контроллера
        public string ControllerName
        {
            get
            {
                return controllerName;
            }
        }

        //Получение Аддитивной оценки
        public double AdditiveEstimate { get; private set; }
        public double SetAdditiveEstimate(List<PropertyInfo> propertyInfos)
        {
            AdditiveEstimate = 0;
            foreach (PropertyGroup propertyGroup in propertyGroups)
            {
                AdditiveEstimate += propertyGroup.SetAdditiveEstimate(propertyInfos);
            }
            return AdditiveEstimate;
        }

        //Обновление экспертных оценок true если были обновлены, false если не найдена группа
        public bool UpdateProperyExpertAssessments(string propertyName, List<int> ExpertAssessments)
        {
            AdditiveEstimate = 0;
            for(int i = 0; i < propertyGroups.Count; i++)
            {
                for(int j = 0; j < propertyGroups[i].Properties.Count; j++)
                {
                    if(propertyName == propertyGroups[i].Properties[j].Name)
                    {
                        propertyGroups[i].Properties[j].ExpertAssessments = new List<int>(ExpertAssessments);
                        propertyGroups[i].Reload();
                        return true;
                    }
                }
            }
            return false;
        }

        //серриализация контроллера
        public void Save()
        {
            string path = Environment.CurrentDirectory + @"\Controllers";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += @"\" + controllerName;
            FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, this);
            stream.Close();
        }

        //Функция загрузки контроллера возвращает null если контроллер отсутствует
        static public Controller Load(string controllerName)
        {
            string path = Environment.CurrentDirectory + @"\Controllers" + @"\" + controllerName;
            if (!File.Exists(path))
            {
                return null;
            }
            FileStream stream = new FileStream(path, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            Controller controller = (Controller)bf.Deserialize(stream);
            stream.Close();
            return controller;
        }
    }
}
