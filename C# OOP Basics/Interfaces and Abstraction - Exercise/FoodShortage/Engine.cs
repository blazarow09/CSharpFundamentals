using System;
using System.Collections.Generic;

public class Engine
{
    public static int totalFoodBought;

    internal void Start()
    {
        ExecuteProgram();
    }

    private void ExecuteProgram()
    {
        var members = new List<IBuyer>();

        var countLines = int.Parse(Console.ReadLine());

        AddMemebers(members, countLines);

        var buyer = Console.ReadLine();

        while (buyer != "End")
        {
            foreach (var member in members)
            {
                if (member.Name == buyer)
                {
                    totalFoodBought += member.BuyFood();
                }
            }

            buyer = Console.ReadLine();
        }

        Console.WriteLine(totalFoodBought);
    }

    private static void AddMemebers(List<IBuyer> members, int countLines)
    {
        for (int i = 0; i < countLines; i++)
        {
            var memberTokens = Console.ReadLine()
                 .Split(" ");

            if (memberTokens.Length == 4)
            {
                var name = memberTokens[0];
                var age = memberTokens[1];
                var id = memberTokens[2];
                var birthdate = memberTokens[3];

                var citizen = new Citizen(name, age, id, birthdate);

                members.Add(citizen);
            }
            else if (memberTokens.Length == 3)
            {
                var name = memberTokens[0];
                var age = memberTokens[1];
                var group = memberTokens[2];

                var rebel = new Rebel(name, age, group);

                members.Add(rebel);
            }
        }
    }
}