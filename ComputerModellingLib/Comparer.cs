using System.Collections.Generic;

namespace ComputerModellingLib
{
    public class Comparer
    {
        public Comparer() { }

        public Comparer(List<Controller> Controllers)
        {
            this.Controllers = Controllers;
        }

        private List<Controller> controllers = new List<Controller>();
        //Контроллеры
        public List<Controller> Controllers
        {
            get
            {
                return controllers;
            }
            set
            {
                propertyInfos = null;
                controllers = value;
            }
        }

        private List<PropertyInfo> propertyInfos;
        //Информация о свойствах
        public List<PropertyInfo> PropertyInfos
        {
            get
            {
                if (propertyInfos == null)
                {
                    propertyInfos = new List<PropertyInfo>();

                    bool exist;
                    for (int controller = 0; controller < Controllers.Count; controller++)
                    {
                        for (int propertyGroop = 0; propertyGroop < Controllers[controller].PropertyGroups.Count; propertyGroop++)
                        {
                            for (int property = 0; property < Controllers[controller].PropertyGroups[propertyGroop].Properties.Count; property++)
                            {
                                exist = false;
                                for (int propertyInfo = 0; propertyInfo < propertyInfos.Count; propertyInfo++)
                                {
                                    if (propertyInfos[propertyInfo].Name == Controllers[controller].PropertyGroups[propertyGroop].Properties[property].Name)
                                    {
                                        propertyInfos[propertyInfo].SetValue(Controllers[controller].PropertyGroups[propertyGroop].Properties[property].Value);
                                        exist = true;
                                        break;
                                    }
                                }
                                if (!exist)
                                {
                                    propertyInfos.Add(new PropertyInfo(Controllers[controller].PropertyGroups[propertyGroop].Properties[property].Name));
                                    propertyInfos[propertyInfos.Count - 1].SetValue(Controllers[controller].PropertyGroups[propertyGroop].Properties[property].Value);
                                }
                            }
                        }
                    }
                }
                return propertyInfos;
            }
        }
    }
}
