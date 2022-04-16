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
    }
}
