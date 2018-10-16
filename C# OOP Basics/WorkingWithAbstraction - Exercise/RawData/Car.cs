using System.Collections.Generic;

namespace P01_RawData
{
    public class Car
    {
        private string model;
        private Cargo cargo;
        private Engine engine;
        private List<Tires> tires;

        public Car(string model, Engine engine, Cargo cargo, List<Tires> tires)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        public List<Tires> Tires
        {
            get { return tires; }
            set { tires = value; }
        }
    }
}
