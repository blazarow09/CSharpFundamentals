public class Soldier : ISoldier
{
    public Soldier(string id, string firstName, string lastName)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string Id { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public override string ToString()
    {
        return string.Format($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");
    }
}