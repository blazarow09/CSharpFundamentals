using System.Collections.Generic;
using System.Linq;

public class Box<T>
{
    private List<T> data = new List<T>();

    public void Add(T element)
    {
        this.data.Add(element);
    }

    public T Remove()
    {
        var deleted = data.LastOrDefault();

        data.RemoveAt(data.Count - 1);

        return deleted;
    }

    public int Count => this.data.Count;
}