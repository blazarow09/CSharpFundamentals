using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
    where T : IComparable<T>
{
    private List<T> values = new List<T>();

    public Box(List<T> values)
    {
        this.values = values;
    }

    public int Count(double constraint)
    {
        var counter = 0;

        foreach (var value in values)
        {
            if (constraint.CompareTo(value) < 0)
            {
                counter++;
            }
        }

        return counter;
    }
}
