using System.Collections.Generic;
using System.Text;
public class Box<T>
{
    private List<T> values = new List<T>();
    public Box(List<T> values)
    {
        this.values = values;
    }
    public void Swap(int first, int second)
    {
        var firstElement = values[first];
        var secondElement = values[second];
        this.values.RemoveAt(first);
        this.values.Insert(first, secondElement);
        this.values.RemoveAt(second);
        this.values.Insert(second, firstElement);
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var value in values)
        {
            sb.AppendLine($"{value.GetType().FullName}: {value}");
        }
        return sb.ToString().Trim();
    }
}