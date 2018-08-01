public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private Tire[] tires;

    public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
    {
        this.model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tires = tires;
    }

    public Tire[] Tires
    {
        get { return tires; }
        set { tires = value; }
    }


    public Cargo Cargo
    {
        get { return cargo; }
        set { cargo = value; }
    }


    public Engine Engine
    {
        get { return engine; }
        set { engine = value; }
    }



    public string Model
    {
        get { return model; }
        set { model = value; }
    }

}

