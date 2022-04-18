using ComputerModellingLib;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class ControllerTest
    {
        [Test]
        public void ProperyGroupsTest()
        {

            List<PropertyGroup> propertyGroups = new List<PropertyGroup>();
            //Проперти для контроллера 1
            Property property = new Property("Время выполнения операции", 6, new List<int> { 6, 6, 6, 6, 5, 6, 5, 5, 5, 5 }, true);
            Property property1 = new Property("Функциональность", 6, new List<int> { 5, 5, 5, 5, 5, 5, 5, 4, 4, 4 }, false);
            Property property2 = new Property("Наработак на отказ", 100000, new List<int> { 6, 6, 6, 5, 6, 6, 6, 6, 6, 6 }, false);
            Property property3 = new Property("ср. вр. восстановления", 2, new List<int> { 6, 6, 4, 5, 4, 4, 4, 4, 4, 4 }, true);
            Property property4 = new Property("Стоимость оборудования", 3183.95, new List<int> { 6, 6, 6, 6, 5, 8, 6, 5, 6, 6 }, true);
            Property property5 = new Property("Стоимость монтажа", 500, new List<int> { 6, 6, 6, 6, 6, 6, 5, 6, 5, 5 }, true);
            Property property6 = new Property("Потребляемая мощность", 4, new List<int> { 9, 9, 8, 9, 9, 9, 9, 9, 9, 7 }, true);
            Property property7 = new Property("Гарантийный срок", 1, new List<int> { 8, 8, 8, 8, 7, 6, 5, 8, 7, 7 }, false);
            Property property8 = new Property("Масса", 0.3, new List<int> { 5, 6, 5, 8, 7, 8, 6, 8, 8, 8 }, true);
            //группы свойств контроллера 1

            PropertyGroup propertyGroup1 = new PropertyGroup("Производительность");
            PropertyGroup propertyGroup2 = new PropertyGroup("Надёжность");
            PropertyGroup propertyGroup3 = new PropertyGroup("Затраты");

            propertyGroup1.AddProperty(property);
            propertyGroup1.AddProperty(property1);
            propertyGroup2.AddProperty(property2);
            propertyGroup2.AddProperty(property3);
            propertyGroup3.AddProperty(property4);
            propertyGroup3.AddProperty(property5);
            propertyGroup3.AddProperty(property6);
            propertyGroup3.AddProperty(property7);
            propertyGroup3.AddProperty(property8);

            propertyGroups.Add(propertyGroup1);
            propertyGroups.Add(propertyGroup2);
            propertyGroups.Add(propertyGroup3);

            Controller controller = new Controller("Controller1", propertyGroups);
            Comparer comparer = new Comparer(new List<Controller> { controller });

            controller.SetAdditiveEstimate(comparer.PropertyInfos);

            Assert.AreEqual(10.2, controller.PropertyGroups[0].PropertyesAverageExpertAssessmentsSum);
            Assert.AreEqual(10.4, controller.PropertyGroups[1].PropertyesAverageExpertAssessmentsSum);
            Assert.AreEqual(34.5, controller.PropertyGroups[2].PropertyesAverageExpertAssessmentsSum);

            Assert.AreEqual(0.539215686, Math.Round(controller.PropertyGroups[0].Properties[0].WeightCoefficient(controller.PropertyGroups[0].PropertyesAverageExpertAssessmentsSum), 9));
            Assert.AreEqual(0.460784314, Math.Round(controller.PropertyGroups[0].Properties[1].WeightCoefficient(controller.PropertyGroups[0].PropertyesAverageExpertAssessmentsSum), 9));
            Assert.AreEqual(0.567307692, Math.Round(controller.PropertyGroups[1].Properties[0].WeightCoefficient(controller.PropertyGroups[1].PropertyesAverageExpertAssessmentsSum), 9));
            Assert.AreEqual(0.432692308, Math.Round(controller.PropertyGroups[1].Properties[1].WeightCoefficient(controller.PropertyGroups[1].PropertyesAverageExpertAssessmentsSum), 9));
            Assert.AreEqual(0.173913043, Math.Round(controller.PropertyGroups[2].Properties[0].WeightCoefficient(controller.PropertyGroups[2].PropertyesAverageExpertAssessmentsSum), 9));
            Assert.AreEqual(0.165217391, Math.Round(controller.PropertyGroups[2].Properties[1].WeightCoefficient(controller.PropertyGroups[2].PropertyesAverageExpertAssessmentsSum), 9));
            Assert.AreEqual(0.252173913, Math.Round(controller.PropertyGroups[2].Properties[2].WeightCoefficient(controller.PropertyGroups[2].PropertyesAverageExpertAssessmentsSum), 9));
            Assert.AreEqual(0.208695652, Math.Round(controller.PropertyGroups[2].Properties[3].WeightCoefficient(controller.PropertyGroups[2].PropertyesAverageExpertAssessmentsSum), 9));
            Assert.AreEqual(0.2, Math.Round(controller.PropertyGroups[2].Properties[4].WeightCoefficient(controller.PropertyGroups[2].PropertyesAverageExpertAssessmentsSum), 9));
        }

        [Test]
        public void AllControllersTest()
        {
            List<PropertyGroup> propertyGroups = new List<PropertyGroup>();
            //Проперти для контроллера 1
            Property property = new Property("Время выполнения операции", 6, new List<int> { 2, 2, 2, 2, 3, 3, 3, 3, 3, 3 }, true);
            Property property1 = new Property("Функциональность", 2, new List<int> { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 }, false);
            Property property2 = new Property("Наработак на отказ", 100000, new List<int> { 4, 5, 5, 5, 5, 5, 5, 4, 5, 6 }, false);
            Property property3 = new Property("ср. вр. восстановления", 2, new List<int> { 7, 5, 6, 5, 6, 5, 7, 7, 7, 7 }, true);
            Property property4 = new Property("Стоимость оборудования", 3183.95, new List<int> { 3, 3, 3, 3, 3, 3, 4, 3, 3, 3 }, true);
            Property property5 = new Property("Стоимость монтажа", 500, new List<int> { 4, 4, 4, 4, 5, 6, 4, 5, 6, 4 }, true);
            Property property6 = new Property("Потребляемая мощность", 4, new List<int> { 5, 5, 5, 8, 7, 5, 8, 7, 5, 7 }, true);
            Property property7 = new Property("Гарантийный срок", 1, new List<int> { 3, 3, 3, 3, 3, 4, 3, 3, 4, 4 }, false);
            Property property8 = new Property("Масса", 0.3, new List<int> { 2, 2, 2, 2, 2, 2, 3, 2, 3, 2 }, true);
            //группы свойств контроллера 1

            PropertyGroup propertyGroup1 = new PropertyGroup("Производительность");
            PropertyGroup propertyGroup2 = new PropertyGroup("Надёжность");
            PropertyGroup propertyGroup3 = new PropertyGroup("Затраты");

            propertyGroup1.AddProperty(property);
            propertyGroup1.AddProperty(property1);
            propertyGroup2.AddProperty(property2);
            propertyGroup2.AddProperty(property3);
            propertyGroup3.AddProperty(property4);
            propertyGroup3.AddProperty(property5);
            propertyGroup3.AddProperty(property6);
            propertyGroup3.AddProperty(property7);
            propertyGroup3.AddProperty(property8);

            propertyGroups.Add(propertyGroup1);
            propertyGroups.Add(propertyGroup2);
            propertyGroups.Add(propertyGroup3);

            Controller controller1 = new Controller("Controller1", propertyGroups);

            List<PropertyGroup> propertyGroups2 = new List<PropertyGroup>();
            //Проперти для контроллера 2
            Property property02 = new Property("Время выполнения операции", 7, new List<int> { 6, 6, 5, 6, 5, 6, 4, 4, 3, 4 }, true);
            Property property12 = new Property("Функциональность", 7, new List<int> { 8, 8, 8, 8, 8, 8, 9, 9, 9, 9 }, false);
            Property property22 = new Property("Наработак на отказ", 80000, new List<int> { 8, 8, 8, 8, 8, 8, 8, 8, 8, 8 }, false);
            Property property32 = new Property("ср. вр. восстановления", 3, new List<int> { 8, 8, 9, 8, 9, 9, 9, 9, 9, 9 }, true);
            Property property42 = new Property("Стоимость оборудования", 3210, new List<int> { 5, 5, 5, 6, 5, 6, 4, 4, 3, 4 }, true);
            Property property52 = new Property("Стоимость монтажа", 400, new List<int> { 8, 8, 8, 8, 8, 8, 8, 9, 9, 9 }, true);
            Property property62 = new Property("Потребляемая мощность", 4, new List<int> { 10, 9, 9, 9, 10, 10, 10, 10, 10, 10 }, true);
            Property property72 = new Property("Гарантийный срок", 2, new List<int> { 9, 9, 8, 9, 9, 8, 9, 9, 9, 9 }, false);
            Property property82 = new Property("Масса", 0.4, new List<int> { 4, 4, 4, 4, 5, 5, 5, 5, 5, 5 }, true);
            //группы свойств контроллера 2

            PropertyGroup propertyGroup12 = new PropertyGroup("Производительность");
            PropertyGroup propertyGroup22 = new PropertyGroup("Надёжность");
            PropertyGroup propertyGroup32 = new PropertyGroup("Затраты");

            propertyGroup12.AddProperty(property02);
            propertyGroup12.AddProperty(property12);
            propertyGroup22.AddProperty(property22);
            propertyGroup22.AddProperty(property32);
            propertyGroup32.AddProperty(property42);
            propertyGroup32.AddProperty(property52);
            propertyGroup32.AddProperty(property62);
            propertyGroup32.AddProperty(property72);
            propertyGroup32.AddProperty(property82);

            propertyGroups2.Add(propertyGroup12);
            propertyGroups2.Add(propertyGroup22);
            propertyGroups2.Add(propertyGroup32);

            Controller controller2 = new Controller("Controller2", propertyGroups2);

            List<PropertyGroup> propertyGroups3 = new List<PropertyGroup>();
            //Проперти для контроллера 3
            Property property03 = new Property("Время выполнения операции", 7, new List<int> { 4, 4, 4, 4, 4, 5, 5, 6, 6, 6 }, true);
            Property property13 = new Property("Функциональность", 6, new List<int> { 9, 9, 9, 9, 9, 8, 8, 7, 7, 7 }, false);
            Property property23 = new Property("Наработак на отказ", 100000, new List<int> { 8, 8, 8, 8, 8, 8, 9, 9, 9, 9 }, false);
            Property property33 = new Property("ср. вр. восстановления", 3, new List<int> { 7, 7, 7, 7, 7, 7, 7, 5, 6, 6 }, true);
            Property property43 = new Property("Стоимость оборудования", 4767, new List<int> { 4, 4, 4, 4, 4, 5, 5, 6, 6, 6 }, true);
            Property property53 = new Property("Стоимость монтажа", 500, new List<int> { 6, 6, 6, 6, 5, 6, 6, 6, 6, 6 }, true);
            Property property63 = new Property("Потребляемая мощность", 5, new List<int> { 8, 8, 8, 9, 10, 10, 9, 9, 9, 9 }, true);
            Property property73 = new Property("Гарантийный срок", 3, new List<int> { 4, 2, 4, 2, 4, 2, 2, 2, 2, 2 }, false);
            Property property83 = new Property("Масса", 0.3, new List<int> { 6, 6, 6, 6, 6, 6, 5, 6, 6, 6 }, true);
            //группы свойств контроллера 3

            PropertyGroup propertyGroup13 = new PropertyGroup("Производительность");
            PropertyGroup propertyGroup23 = new PropertyGroup("Надёжность");
            PropertyGroup propertyGroup33 = new PropertyGroup("Затраты");

            propertyGroup13.AddProperty(property03);
            propertyGroup13.AddProperty(property13);
            propertyGroup23.AddProperty(property23);
            propertyGroup23.AddProperty(property33);
            propertyGroup33.AddProperty(property43);
            propertyGroup33.AddProperty(property53);
            propertyGroup33.AddProperty(property63);
            propertyGroup33.AddProperty(property73);
            propertyGroup33.AddProperty(property83);

            propertyGroups3.Add(propertyGroup13);
            propertyGroups3.Add(propertyGroup23);
            propertyGroups3.Add(propertyGroup33);

            Controller controller3 = new Controller("Controller3", propertyGroups3);

            List<PropertyGroup> propertyGroups4 = new List<PropertyGroup>();
            //Проперти для контроллера 4
            Property property04 = new Property("Время выполнения операции", 4, new List<int> { 9, 8, 9, 7, 8, 9, 7, 7, 7, 7 }, true);
            Property property14 = new Property("Функциональность", 9, new List<int> { 10, 10, 10, 10, 10, 10, 9, 9, 10, 10 }, false);
            Property property24 = new Property("Наработак на отказ", 80000, new List<int> { 10, 10, 10, 10, 10, 10, 9, 9, 10, 10 }, false);
            Property property34 = new Property("ср. вр. восстановления", 4, new List<int> { 4, 4, 4, 4, 5, 6, 8, 4, 4, 8 }, true);
            Property property44 = new Property("Стоимость оборудования", 4394, new List<int> { 4, 4, 4, 4, 4, 5, 6, 6, 6, 6 }, true);
            Property property54 = new Property("Стоимость монтажа", 600, new List<int> { 4, 2, 4, 2, 4, 2, 2, 2, 2, 3 }, true);
            Property property64 = new Property("Потребляемая мощность", 20, new List<int> { 2, 2, 2, 3, 3, 3, 3, 3, 3, 3 }, true);
            Property property74 = new Property("Гарантийный срок", 1, new List<int> { 2, 2, 2, 2, 2, 3, 3, 3, 3, 3 }, false);
            Property property84 = new Property("Масса", 5, new List<int> { 4, 4, 4, 4, 5, 5, 5, 5, 5, 5 }, true);
            //группы свойств контроллера 4

            PropertyGroup propertyGroup14 = new PropertyGroup("Производительность");
            PropertyGroup propertyGroup24 = new PropertyGroup("Надёжность");
            PropertyGroup propertyGroup34 = new PropertyGroup("Затраты");

            propertyGroup14.AddProperty(property04);
            propertyGroup14.AddProperty(property14);
            propertyGroup24.AddProperty(property24);
            propertyGroup24.AddProperty(property34);
            propertyGroup34.AddProperty(property44);
            propertyGroup34.AddProperty(property54);
            propertyGroup34.AddProperty(property64);
            propertyGroup34.AddProperty(property74);
            propertyGroup34.AddProperty(property84);

            propertyGroups4.Add(propertyGroup14);
            propertyGroups4.Add(propertyGroup24);
            propertyGroups4.Add(propertyGroup34);

            Controller controller4 = new Controller("Controller4", propertyGroups4);

            List<PropertyGroup> propertyGroups5 = new List<PropertyGroup>();
            //Проперти для контроллера 5
            Property property05 = new Property("Время выполнения операции", 4, new List<int> { 2, 2, 2, 2, 2, 3, 3, 3, 3, 3 }, true);
            Property property15 = new Property("Функциональность", 4, new List<int> { 3, 3, 3, 3, 3, 3, 3, 2, 2, 2 }, false);
            Property property25 = new Property("Наработак на отказ", 80000, new List<int> { 8, 8, 8, 8, 8, 9, 9, 8, 9, 9 }, false);
            Property property35 = new Property("ср. вр. восстановления", 4, new List<int> { 1, 2, 3, 2, 1, 2, 3, 1, 2, 3 }, true);
            Property property45 = new Property("Стоимость оборудования", 5488, new List<int> { 4, 4, 5, 5, 2, 3, 3, 3, 3, 3 }, true);
            Property property55 = new Property("Стоимость монтажа", 600, new List<int> { 2, 2, 2, 2, 2, 3, 3, 3, 3, 3 }, true);
            Property property65 = new Property("Потребляемая мощность", 20, new List<int> { 3, 3, 3, 3, 2, 3, 2, 4, 4, 2 }, true);
            Property property75 = new Property("Гарантийный срок", 1, new List<int> { 2, 2, 2, 3, 3, 2, 2, 2, 3, 3 }, false);
            Property property85 = new Property("Масса", 5, new List<int> { 1, 2, 2, 2, 2, 2, 1, 1, 1, 1 }, true);
            //группы свойств контроллера 5

            PropertyGroup propertyGroup15 = new PropertyGroup("Производительность");
            PropertyGroup propertyGroup25 = new PropertyGroup("Надёжность");
            PropertyGroup propertyGroup35 = new PropertyGroup("Затраты");

            propertyGroup15.AddProperty(property05);
            propertyGroup15.AddProperty(property15);
            propertyGroup25.AddProperty(property25);
            propertyGroup25.AddProperty(property35);
            propertyGroup35.AddProperty(property45);
            propertyGroup35.AddProperty(property55);
            propertyGroup35.AddProperty(property65);
            propertyGroup35.AddProperty(property75);
            propertyGroup35.AddProperty(property85);

            propertyGroups5.Add(propertyGroup15);
            propertyGroups5.Add(propertyGroup25);
            propertyGroups5.Add(propertyGroup35);

            Controller controller5 = new Controller("Controller5", propertyGroups5);

            List<PropertyGroup> propertyGroups6 = new List<PropertyGroup>();
            //Проперти для контроллера 6
            Property property06 = new Property("Время выполнения операции", 6, new List<int> { 9, 9, 9, 9, 9, 9, 8, 8, 8, 8 }, true);
            Property property16 = new Property("Функциональность", 8, new List<int> { 9, 9, 9, 9, 9, 7, 8, 7, 8, 7 }, false);
            Property property26 = new Property("Наработак на отказ", 100000, new List<int> { 10, 10, 9, 9, 9, 9, 10, 9, 9, 9 }, false);
            Property property36 = new Property("ср. вр. восстановления", 3, new List<int> { 10, 10, 10, 10, 8, 8, 10, 10, 10, 9 }, true);
            Property property46 = new Property("Стоимость оборудования", 6477, new List<int> { 10, 10, 10, 7, 8, 9, 7, 7, 7, 7 }, true);
            Property property56 = new Property("Стоимость монтажа", 400, new List<int> { 8, 8, 9, 9, 9, 9, 8, 9, 8, 9 }, true);
            Property property66 = new Property("Потребляемая мощность", 5, new List<int> { 10, 9, 10, 10, 10, 10, 10, 10, 10, 10 }, true);
            Property property76 = new Property("Гарантийный срок", 2, new List<int> { 10, 10, 9, 9, 9, 10, 10, 10, 10, 10 }, false);
            Property property86 = new Property("Масса", 0.3, new List<int> { 10, 10, 8, 7, 8, 7, 10, 10, 8, 9 }, true);
            //группы свойств контроллера 6

            PropertyGroup propertyGroup16 = new PropertyGroup("Производительность");
            PropertyGroup propertyGroup26 = new PropertyGroup("Надёжность");
            PropertyGroup propertyGroup36 = new PropertyGroup("Затраты");

            propertyGroup16.AddProperty(property06);
            propertyGroup16.AddProperty(property16);
            propertyGroup26.AddProperty(property26);
            propertyGroup26.AddProperty(property36);
            propertyGroup36.AddProperty(property46);
            propertyGroup36.AddProperty(property56);
            propertyGroup36.AddProperty(property66);
            propertyGroup36.AddProperty(property76);
            propertyGroup36.AddProperty(property86);

            propertyGroups6.Add(propertyGroup16);
            propertyGroups6.Add(propertyGroup26);
            propertyGroups6.Add(propertyGroup36);

            Controller controller6 = new Controller("Controller6", propertyGroups6);

            List<PropertyGroup> propertyGroups7 = new List<PropertyGroup>();
            //Проперти для контроллера 7
            Property property07 = new Property("Время выполнения операции", 6, new List<int> { 7, 7, 7, 7, 7, 7, 8, 8, 8, 8 }, true);
            Property property17 = new Property("Функциональность", 6, new List<int> { 8, 8, 8, 8, 8, 8, 7, 7, 8, 8 }, false);
            Property property27 = new Property("Наработак на отказ", 100000, new List<int> { 10, 10, 10, 10, 10, 9, 9, 10, 10, 10 }, false);
            Property property37 = new Property("ср. вр. восстановления", 3, new List<int> { 5, 6, 7, 5, 4, 3, 4, 6, 5, 3 }, true);
            Property property47 = new Property("Стоимость оборудования", 5523, new List<int> { 8, 8, 9, 6, 9, 8, 8, 8, 8, 8 }, true);
            Property property57 = new Property("Стоимость монтажа", 400, new List<int> { 9, 9, 8, 9, 9, 9, 8, 9, 9, 9 }, true);
            Property property67 = new Property("Потребляемая мощность", 5, new List<int> { 10, 10, 10, 9, 9, 9, 10, 10, 10, 10 }, true);
            Property property77 = new Property("Гарантийный срок", 3, new List<int> { 8, 8, 8, 10, 10, 10, 9, 9, 10, 10 }, false);
            Property property87 = new Property("Масса", 0.3, new List<int> { 9, 9, 9, 8, 8, 7, 5, 8, 5, 6 }, true);
            //группы свойств контроллера 7

            PropertyGroup propertyGroup17 = new PropertyGroup("Производительность");
            PropertyGroup propertyGroup27 = new PropertyGroup("Надёжность");
            PropertyGroup propertyGroup37 = new PropertyGroup("Затраты");

            propertyGroup17.AddProperty(property07);
            propertyGroup17.AddProperty(property17);
            propertyGroup27.AddProperty(property27);
            propertyGroup27.AddProperty(property37);
            propertyGroup37.AddProperty(property47);
            propertyGroup37.AddProperty(property57);
            propertyGroup37.AddProperty(property67);
            propertyGroup37.AddProperty(property77);
            propertyGroup37.AddProperty(property87);

            propertyGroups7.Add(propertyGroup17);
            propertyGroups7.Add(propertyGroup27);
            propertyGroups7.Add(propertyGroup37);

            Controller controller7 = new Controller("Controller7", propertyGroups7);
            Comparer comparer = new Comparer(new List<Controller> { controller1, controller2, controller3, controller4, controller5, controller6, controller7});

            controller1.SetAdditiveEstimate(comparer.PropertyInfos);
            controller2.SetAdditiveEstimate(comparer.PropertyInfos);
            controller3.SetAdditiveEstimate(comparer.PropertyInfos);
            controller4.SetAdditiveEstimate(comparer.PropertyInfos);
            controller5.SetAdditiveEstimate(comparer.PropertyInfos);
            controller6.SetAdditiveEstimate(comparer.PropertyInfos);
            controller7.SetAdditiveEstimate(comparer.PropertyInfos);

            Assert.AreEqual(1.78605285, Math.Round(controller1.AdditiveEstimate, 9));
            Assert.AreEqual(1.585982148, Math.Round(controller2.AdditiveEstimate, 9));
            Assert.AreEqual(1.93354533, Math.Round(controller3.AdditiveEstimate, 9));
            Assert.AreEqual(1.178130291, Math.Round(controller4.AdditiveEstimate, 9));
            Assert.AreEqual(0.711242222, Math.Round(controller5.AdditiveEstimate, 9));
            Assert.AreEqual(2.033266196, Math.Round(controller6.AdditiveEstimate, 9));
            Assert.AreEqual(2.145222063, Math.Round(controller7.AdditiveEstimate, 9));
        }
        
        [Test]
        public void SaveTest()
        {

        }
    }
}
