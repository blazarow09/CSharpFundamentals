using System.Collections.Generic;

public abstract class Collection
{
    private const int MaxSize = 100;
    protected List<string> items;

    protected Collection()
    {
        this.items = new List<string>(MaxSize);
    }
}