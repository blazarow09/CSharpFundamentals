using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        Console.WriteLine(new Box<int>(123123));
        Console.WriteLine(new Box<string>("life in a box"));
    }
}