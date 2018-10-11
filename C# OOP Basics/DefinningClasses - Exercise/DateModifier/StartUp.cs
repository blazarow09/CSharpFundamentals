using System;

class StartUp
{
    static void Main(string[] args)
    {
        var firstDate = Console.ReadLine();
        var secondDate = Console.ReadLine();

        Console.WriteLine(DateModifier.CalculateDifference(firstDate, secondDate));
    }
}
