using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    internal void StartProgram()
    {
        ExecuteCommands();
    }

    private void ExecuteCommands()
    {
        var members = new List<IMember>();

        var tokens = Console.ReadLine().Split();

        while (tokens[0] != "End")
        {
            if (tokens.Count() == 3)
            {
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var id = tokens[2];

                IMember citizen = new Citizen(name, age, id);
                members.Add(citizen);
            }
            else if (tokens.Count() == 2)
            {
                var model = tokens[0];
                var id = tokens[1];

                IMember robot = new Robot(model, id);
                members.Add(robot);
            }

            tokens = Console.ReadLine().Split();
        }

        var idToFInd = Console.ReadLine();

        foreach (var member in members)
        {
            if (member.Id.EndsWith(idToFInd))
            {
                Console.WriteLine(member.Id);
            }
        }
    }
}