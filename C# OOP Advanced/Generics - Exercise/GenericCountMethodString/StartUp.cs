using System;
using System.Collections.Generic;

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

        var constraint = Console.ReadLine();

        Box<string> box = new Box<string>(values);

        Console.WriteLine(box.Count(constraint));
    }
}