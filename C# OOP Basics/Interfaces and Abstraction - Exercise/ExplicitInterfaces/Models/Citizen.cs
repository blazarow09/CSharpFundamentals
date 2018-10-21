public class Citizen : IPerson, IResident
{
    public Citizen(string name)
    {
        this.Name = name;
    }

    public string Name { get; }

    public string Age { get; }

    string IResident.Name { get; }

    string IResident.Country { get; }

    public string GetName()
    {
        return $"{this.Name}";
    }

    string IResident.GetName()
    {
        return $"Mr/Ms/Mrs {this.Name}";
    }
}