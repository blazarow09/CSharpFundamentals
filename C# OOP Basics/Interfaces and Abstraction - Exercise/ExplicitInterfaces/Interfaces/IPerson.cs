namespace PersonInfo
{
    public interface IPerson
    {
        string Name { get; }

        string Age { get; }

        string GetName();
    }
}