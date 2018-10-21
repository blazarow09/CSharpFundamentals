using System;

public class Engine
{
    public void StartProgram()
    {
        var listOfNumbers = Console.ReadLine()
            .Split();
        var listOfSites = Console.ReadLine()
            .Split();

        var smartphone = new Smartphone();

        foreach (var number in listOfNumbers)
        {
            Console.WriteLine(smartphone.Call(number));
        }

        foreach (var site in listOfSites)
        {
            Console.WriteLine(smartphone.Browse(site));
        }
    }
}