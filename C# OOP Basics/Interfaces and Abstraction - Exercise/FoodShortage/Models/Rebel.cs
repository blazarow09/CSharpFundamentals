public class Rebel : IRebel, IBuyer
{
    public Rebel(string name, string age, string group)
    {
        this.Name = name;
        this.Age = age;
        this.Group = group;
    }

    public string Name { get; }

    public string Age { get; }

    public string Group { get; }

    public int Food { get; private set; }

    public int BuyFood()
    {
        return 5;
    }
}