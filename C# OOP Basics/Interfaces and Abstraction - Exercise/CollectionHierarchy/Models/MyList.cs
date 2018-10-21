public class MyList : Collection, IMylist
{
    public int Used
    {
        get
        {
            return this.items.Count;
        }
    }

    public int Add(string item)
    {
        this.items.Insert(0, item);
        return 0;
    }

    public string Remove()
    {
        string itemToRemove = this.items[0];
        this.items.RemoveAt(0);
        return itemToRemove;
    }
}