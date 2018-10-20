namespace P01_RawData
{
    public class Engine
    {
        private int power;
        private int speed;

        public Engine(int power, int engine)
        {
            Power = power;
            Speed = speed;
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
    }
}