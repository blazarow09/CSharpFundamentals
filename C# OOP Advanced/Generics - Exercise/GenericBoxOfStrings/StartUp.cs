using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        var count = int.Parse(Console.ReadLine());
        for (int i = 0; i < count; i++)
        {
            var value = Console.ReadLine();
            Console.WriteLine(new Box<string>(value));
        }
    }
}