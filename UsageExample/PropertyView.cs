using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsageExample
{
    class PropertyView
    {
        public double PropertyValue;
        public List<int> ExpertAssessments = new List<int>();
        public bool IsReversed;
        public string PropertyName;
        public string GroupName;
        public string ControllerName;

        public PropertyView(bool isReverced, string propertyName, string groupName )
        {
            IsReversed = isReverced;
            PropertyName = propertyName;
            GroupName = groupName;
        }
    }
}
