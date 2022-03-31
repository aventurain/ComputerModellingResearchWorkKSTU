using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerModellingLib
{
    public class PropertyGroup
    {
        private List<Property> properties = new List<Property>();
        //Свойства
        public List<Property> Properties
        {
            get
            {
                return properties;
            }
            set
            {
                propertyesAverageExpertAssessmentsSum = 0;
                properties = value;
            }
        }
        
        private string propetyGroupName;
        //Название группы свойств
        public string PropetyGroupName
        {
            get
            {
                return propetyGroupName;
            }
        }

        public PropertyGroup(string PropertyGroupName, List<Property> Properties)
        {
            propetyGroupName = PropertyGroupName;
            this.Properties = Properties;
        }
        public PropertyGroup(string PropertyGroupName)
        {
            propetyGroupName = PropertyGroupName;
        }

        private double propertyesAverageExpertAssessmentsSum = 0;
        
        // Сумма средних всех свойств
        public double PropertyesAverageExpertAssessmentsSum
        {
            get
            {
                if (propertyesAverageExpertAssessmentsSum == 0)
                {
                    double sum = 0;
                    foreach (Property property in properties)
                    {
                        sum += property.AverageExpertAssessment;
                    }
                    propertyesAverageExpertAssessmentsSum = sum;
                }
                return propertyesAverageExpertAssessmentsSum;
            }
        }

        //Добавить свойство
        public void AddProperty(Property property)
        {
            if(property != null)
                Properties.Add(property);
        }
        
        //Удалить свойство
        public void DeleteProperty(string PropertyName)
        {
            for (int i = 0; i < properties.Count; i++)
            {
                if (properties[i].Name == PropertyName)
                {
                    Properties.RemoveAt(i);
                    return;
                }
            }
        }

        //Обновить оценки экспертов
        public void UpdateExpertAssessments(string name, List<int> ExpertAssessments)
        {
            propertyesAverageExpertAssessmentsSum = 0;
            foreach (Property property in properties)
            {
                if (property.Name == name)
                {
                    property.ExpertAssessments = ExpertAssessments;
                    return;
                }
            }
        }

        public double AdditiveEstimate { get; private set; }
        //Получение Аддитивной оценки
        public double SetAdditiveEstimate(List<PropertyInfo> propertyInfos)
        {
            AdditiveEstimate = 0;
            foreach(Property property in properties)
            {
                AdditiveEstimate += property.SetAdditiveEstimate(propertyInfos) * property.WeightCoefficient(PropertyesAverageExpertAssessmentsSum);
            }
            return AdditiveEstimate;
        }
    }
}
