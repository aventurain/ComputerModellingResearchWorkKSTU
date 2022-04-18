using System;
using System.Collections.Generic;

namespace ComputerModellingLib
{
    [Serializable()]
    public class Property
    {
        private bool Reversed = false;

        private string propetyName;
        //Название свойства контроллера
        public string Name
        {
            get
            {
                return propetyName;
            }
        }

        private double propertyValue;
        //Значение свойства контроллера
        public double Value
        {
            get
            {
                return propertyValue;
            }
        }

        private List<int> expertAssessments = new List<int>();
        //Экспертные оценки
        public List<int> ExpertAssessments
        {
            get
            {
                return expertAssessments;
            }
            set
            {
                //Обнуление суммы оценки экспертов для
                //корректной работы свойства подсчета экспертных оценок
                sumOfExpertAssessments = 0;
                expertAssessments = value;
            }
        }

        private int sumOfExpertAssessments = 0;
        //Сумма экспертных оценок
        public int SumOfExpertAssessments
        {
            get
            {
                if (sumOfExpertAssessments == 0)
                {
                    int sum = 0;
                    foreach (int i in expertAssessments)
                    {
                        sum += i;
                    }
                    sumOfExpertAssessments = sum;
                }
                return sumOfExpertAssessments;
            }
        }

        //Средняя оценка экспертов
        public double AverageExpertAssessment
        {
            get
            {
                return (double)SumOfExpertAssessments / ExpertAssessments.Count;
            }
        }

        //Значение нормированного весового коэффициента
        public double WeightCoefficient(double propertyesAverageExpertAssessmentsSum)
        {
            return ((double)SumOfExpertAssessments / ExpertAssessments.Count) / propertyesAverageExpertAssessmentsSum;
        }

        public Property(string PropertyName, double PropertyValue, List<int> ExpertAssessments, bool IsReversed)
        {
            propetyName = PropertyName;
            propertyValue = PropertyValue;
            this.ExpertAssessments = ExpertAssessments;
            Reversed = IsReversed;
        }

        //Получение Аддитивной оценки
        public double AdditiveEstimate { get; private set; }
        public double SetAdditiveEstimate(List<PropertyInfo> PropertyInfos)
        {
            AdditiveEstimate = 0;

            foreach (PropertyInfo propertyInfo in PropertyInfos)
            {
                if (propertyInfo.Name == Name)
                {
                    if (Reversed)
                    {
                        AdditiveEstimate = (propertyInfo.MaxValue - Value) / (propertyInfo.MaxValue - propertyInfo.MinValue);
                    }
                    else
                    {
                        AdditiveEstimate = (Value - propertyInfo.MinValue) / (propertyInfo.MaxValue - propertyInfo.MinValue);
                    }
                    break;
                }
            }
            return AdditiveEstimate;
        }
    }
}
