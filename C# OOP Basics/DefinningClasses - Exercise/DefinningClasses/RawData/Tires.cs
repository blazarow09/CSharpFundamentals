namespace RawData
{
    public class Tires
    {
        public double pressure;
        public int age;

        public Tires (double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }

        public double Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
}
