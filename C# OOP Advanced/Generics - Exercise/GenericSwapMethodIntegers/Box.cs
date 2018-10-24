using System.Collections.Generic;
using System.Text;

public class Box<T>
{
    private List<T> values = new List<T>();

    public Box(List<T> values)
    {
        this.values = values;
    }

    public void Swap(int firstIndex, int secondIndex)
    {
        var firstElement = values[firstIndex];
        var secondElement = values[secondIndex];

        this.values.RemoveAt(firstIndex);
        this.values.Insert(firstIndex, secondElement);
        this.values.RemoveAt(secondIndex);
        this.values.Insert(secondIndex, firstElement);
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