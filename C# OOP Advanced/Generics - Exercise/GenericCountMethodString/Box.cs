using System;
using System.Collections.Generic;

public class Box<T>
    where T : IComparable
{
    private List<T> values = new List<T>();

    public Box(List<T> values)
    {
        this.values = values;
    }

    public int Count(string constraint)
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