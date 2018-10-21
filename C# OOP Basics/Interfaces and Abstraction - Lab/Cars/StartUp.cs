using System;

public class StartUp
{
    private static void Main(string[] args)
    {
        ICar seat = new Seat("Lean", "Grey");
        ICar tesla = new Tesla("Model 3", "Red", 2);

        Console.WriteLine(seat.ToString());
        Console.WriteLine(tesla.ToString());
    }
}