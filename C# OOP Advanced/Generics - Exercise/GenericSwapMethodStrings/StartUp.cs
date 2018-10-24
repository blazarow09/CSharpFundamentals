using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        var count = int.Parse(Console.ReadLine());
        var values = new List<string>();

        for (int i = 0; i < count; i++)
        {
            var value = Console.ReadLine();

            values.Add(value);
        }

        var indexes = Console.ReadLine()
            .Split(" ")
            .ToList();

        Box<string> box = new Box<string>(values);

        var firstIndex = int.Parse(indexes[0]);
        var secondIndex = int.Parse(indexes[1]);

        box.Swap(firstIndex, secondIndex);

        Console.WriteLine(box);
    }
}