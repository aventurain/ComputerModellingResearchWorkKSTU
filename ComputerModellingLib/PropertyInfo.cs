namespace ComputerModellingLib
{
    public class PropertyInfo
    {
        public double MinValue { get; private set; }
        public double MaxValue { get; private set; }
        public string Name { get; private set; }
        public PropertyInfo(string Name)
        {
            this.Name = Name;
            MinValue = float.MaxValue;
            MaxValue = float.MinValue;
        }

        public void SetValue(double value)
        {
            if (value > MaxValue) MaxValue = value;
            if (value < MinValue) MinValue = value;
        }
    }
}
