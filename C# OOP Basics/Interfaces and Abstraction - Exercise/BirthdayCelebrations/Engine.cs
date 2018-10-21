using System;
using System.Collections.Generic;

public class Engine
{
    internal void StartProgram()
    {
        ExecuteCommands();
    }

    private void ExecuteCommands()
    {
        var members = new List<IBirthdayable>();

        var tokens = Console.ReadLine().Split();

        while (tokens[0] != "End")
        {
            if (tokens[0] == "Citizen")
            {
                var name = tokens[1];
                var age = int.Parse(tokens[2]);
                var id = tokens[3];
                var birthdate = tokens[4];

                IBirthdayable citizen = new Citizen(name, age, id, birthdate);
                members.Add(citizen);
            }
            else if (tokens[0] == "Pet")
            {
                var name = tokens[1];
                var birthdate = tokens[2];

                IBirthdayable pet = new Pet(name, birthdate);
                members.Add(pet);
            }

            tokens = Console.ReadLine().Split();
        }

        var yearToFInd = Console.ReadLine();

        foreach (var member in members)
        {
            if (member.Birthdate.EndsWith(yearToFInd))
            {
                Console.WriteLine(member.Birthdate);
            }
        }
    }
}