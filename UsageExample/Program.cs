using System;
using ComputerModellingLib;
using System.Collections.Generic;

namespace UsageExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Проперти для контроллера 1
            Property property = new Property("property1", 10, new List<int> { 10, 5, 6, 3, 2 }, false);
            Property property1 = new Property("property2", 7, new List<int> { 10, 6, 6, 6, 7 }, false);
            Property property2 = new Property("property3", 8, new List<int> { 1, 5, 1, 3, 4 }, false);
            //группы свойств контроллера 1
            PropertyGroup propertyGroup1 = new PropertyGroup("PropertyGroup1");
            PropertyGroup propertyGroup2 = new PropertyGroup("PropertyGroup2");
            propertyGroup1.AddProperty(property);
            propertyGroup1.AddProperty(property1);
            propertyGroup2.AddProperty(property2);

            Controller controller = new Controller("Controller1", new List<PropertyGroup> { propertyGroup1, propertyGroup2 });

            //проперти для контроллера 2 Отличаются значением и оценками
            Property property3 = new Property("property1", 6, new List<int> { 3, 9, 6, 8, 2 }, false);
            Property property4 = new Property("property2", 10, new List<int> { 10, 7, 6, 3, 2 }, false);
            Property property5 = new Property("property3", 9, new List<int> { 1, 5, 6, 3, 2 }, false);
            //группы свойств контроллера 2
            PropertyGroup propertyGroup3 = new PropertyGroup("PropertyGroup1");
            PropertyGroup propertyGroup4 = new PropertyGroup("PropertyGroup2");
            propertyGroup3.AddProperty(property3);
            propertyGroup3.AddProperty(property4);
            propertyGroup4.AddProperty(property5);

            Controller controller2 = new Controller("Controller1", new List<PropertyGroup> { propertyGroup3, propertyGroup4 });

            Comparer comparer = new Comparer(new List<Controller> { controller, controller2 });

            controller.SetAdditiveEstimate(comparer.PropertyInfos);

            Console.WriteLine(controller.AdditiveEstimate);

            Console.ReadLine();
        }
    }
}
