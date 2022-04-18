using System;
using System.Collections.Generic;

namespace ComputerModellingLib
{
    [Serializable()]
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
                properties = new List<Property>(value);
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
            if (property != null)
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

        public double AdditiveEstimate { get; private set; }
        //Получение Аддитивной оценки
        public double SetAdditiveEstimate(List<PropertyInfo> propertyInfos)
        {
            AdditiveEstimate = 0;
            foreach (Property property in properties)
            {
                AdditiveEstimate += property.SetAdditiveEstimate(propertyInfos) * property.WeightCoefficient(PropertyesAverageExpertAssessmentsSum);
            }
            return AdditiveEstimate;
        }

        public void Reload()
        {
            AdditiveEstimate = 0;
            propertyesAverageExpertAssessmentsSum = 0;

        }
    }
}
