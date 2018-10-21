public class AddCollection : Collection, IAddCollection
{
    public int Add(string item)
    {
        this.items.Add(item);
        return this.items.Count - 1;
    }
}