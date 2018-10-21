public class Citizen : ICitizen, IBuyer
{
    public Citizen(string name, string age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
    }

    public string Name { get; }

    public string Age { get; }

    public string Id { get; }

    public string Birthdate { get; }

    public int Food { get; private set; }

    public int BuyFood()
    {
        return 10;
    }
}