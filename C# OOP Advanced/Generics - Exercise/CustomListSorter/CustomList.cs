using System;
using System.Collections.Generic;
using System.Linq;

public class CustomList<T>
where T : IComparable<T>
{
    private IList<T> elements;

    public CustomList(IEnumerable<T> elements)
    {
        this.elements = new List<T>(elements);
    }

    public CustomList()
        : this(Enumerable.Empty<T>())
    {
    }

    public IEnumerable<T> Elements
    {
        get
        {
            return this.elements;
        }
    }

    public void Sort()
    {
        var sorted = this.elements.ToList();
        sorted.Sort();

        this.elements =  sorted;
    }

    public void Add(T element)
    {
        this.elements.Add(element);
    }

    public T Remove(int index)
    {
        this.ValidateIndex(index);

        T elementToRemove = this.elements[index];

        this.elements.Remove(elementToRemove);

        return elementToRemove;
    }

    public bool Contains(T element)
    {
        var contains = this.elements.Contains(element);

        return contains;
    }

    public void Swap(int firstIndex, int secondIndex)
    {
        ValidateIndex(firstIndex);
        ValidateIndex(secondIndex);

        var temp = this.elements[firstIndex];

        this.elements[firstIndex] = this.elements[secondIndex];
        this.elements[secondIndex] = temp;
    }

    public int CountGreaterThan(T element)
    {
        var count = this.elements.Count(e => e.CompareTo(element) > 0);

        return count;
    }

    public T Max()
    {
        return this.elements.Max();
    }

    public T Min()
    {
        return this.elements.Min();
    }

    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= this.elements.Count)
        {
            throw new ArgumentException("Invalid index");
        }
    }
}

