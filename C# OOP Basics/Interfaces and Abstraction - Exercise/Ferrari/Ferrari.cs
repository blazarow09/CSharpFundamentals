public class Ferrari : IFerarri
{
    public Ferrari(string name)
    {
        this.Name = name;
    }

    public string Name { get; }

    public string PushBrake()
    {
        return "Brakes!";
    }

    public string PushGas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"488-Spider/{PushBrake()}/{PushGas()}/{this.Name}";
    }
}