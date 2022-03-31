using System.Collections.Generic;

namespace ComputerModellingLib
{
    public class Controller
    {
        public Controller(string ControlerName, List<PropertyGroup> PropertyGroups)
        {
            controllerName = ControlerName;
            propertyGroups = PropertyGroups;
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
                propertyGroups = value;
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
    }
}
