public class AddRemoveCollection : Collection, IAddRemoveCollection
{
    public int Add(string item)
    {
        this.items.Insert(0, item);
        return 0;
    }

    public string Remove()
    {
        var itemToRemove = this.items[this.items.Count - 1];
        this.items.RemoveAt(this.items.Count - 1);
        return itemToRemove;
    }
}