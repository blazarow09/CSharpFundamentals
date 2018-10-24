using System;
using System.Collections.Generic;
public class StartUp
{
    public static void Main(string[] args)
    {
        var count = int.Parse(Console.ReadLine());
        var values = new List<int>();

        for (int i = 0; i < count; i++)
        {
            var value = int.Parse(Console.ReadLine());
            values.Add(value);
        }
        var indexes = Console.ReadLine()
           .Split(" ");
        var firstIndex = int.Parse(indexes[0]);
        var secondIndex = int.Parse(indexes[1]);
        Box<int> box = new Box<int>(values);
        box.Swap(firstIndex, secondIndex);
        Console.WriteLine(box);
    }
}