using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        var name = Console.ReadLine();
        IFerarri car = new Ferrari(name);

        Console.WriteLine(car);
    }
}