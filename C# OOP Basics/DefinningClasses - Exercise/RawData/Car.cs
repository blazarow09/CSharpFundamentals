namespace RawData
{
    using System.Collections.Generic;

    public class Car
    {
        public string model;
        public Engine engine;
        public Cargo cargo;
        public List<Tires> tires;

        public Car(string model, Engine engine, Cargo cargo, List<Tires> tires)
        {
            this.model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tires = tires;
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