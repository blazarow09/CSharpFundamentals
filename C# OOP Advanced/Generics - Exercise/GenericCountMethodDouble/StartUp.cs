using System;
using System.Collections.Generic;
public class StartUp
{
    private static void Main(string[] args)
    {
        var count = int.Parse(Console.ReadLine());
        var values = new List<double>();
        for (int i = 0; i < count; i++)
        {
            var value = double.Parse(Console.ReadLine());
            values.Add(value);
        }
        var constraint = double.Parse(Console.ReadLine());
        Box<double> box = new Box<double>(values);
        Console.WriteLine(box.Count(constraint));
    }
}