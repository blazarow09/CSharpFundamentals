using System;
using System.Collections.Generic;

internal class Engine
{
    internal void Run()
    {
        ExecuteCommands();
    }

    private void ExecuteCommands()
    {
        var soldiersById = new Dictionary<int, ISoldier>();

        var line = Console.ReadLine();

        while (line != "End")
        {
            var tokens = line.Split();
            var soldierType = tokens[0];
            var id = tokens[1];
            var firstName = tokens[2];
            var lastnName = tokens[3];

            switch (soldierType)
            {
                case "Private":
                    var salary = double.Parse(tokens[4]);
                    soldiersById.Add(int.Parse(id), new Private(id, firstName, lastnName, salary));
                    break;

                case "LeutenantGeneral":
                    salary = double.Parse(tokens[4]);
                    var privates = new List<ISoldier>();

                    for (int i = 5; i < tokens.Length; i++)
                    {
                        var privateId = int.Parse(tokens[i]);
                        privates.Add(soldiersById[privateId]);
                    }

                    soldiersById.Add(int.Parse(id), new LeutenantGeneral(id, firstName, lastnName, salary, privates));
                    break;

                case "Engineer":
                    salary = double.Parse(tokens[4]);
                    var corps = tokens[5];

                    var repairs = new List<IRepairs>();

                    for (int i = 6; i < tokens.Length; i += 2)
                    {
                        var partName = tokens[i];
                        var hoursWorked = int.Parse(tokens[i + 1]);

                        var repair = new Repairs(partName, hoursWorked);

                        repairs.Add(repair);

                        try
                        {
                            soldiersById.Add(int.Parse(id), new Engineer(id, firstName, lastnName, salary, corps, repairs));
                        }
                        catch (ArgumentException)
                        {
                        }
                    }
                    break;

                case "Commando":
                    salary = double.Parse(tokens[4]);
                    corps = tokens[5];

                    var missions = new List<IMissions>();

                    for (int i = 6; i < tokens.Length; i += 2)
                    {
                        var codeName = tokens[i];
                        var state = tokens[i + 1];

                        try
                        {
                            var mission = new Missions(codeName, state);

                            missions.Add(mission);
                        }
                        catch (ArgumentException)
                        {
                        }
                    }

                    try
                    {
                        soldiersById.Add(int.Parse(id), new Commando(id, firstName, lastnName, salary, corps, missions));
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "Spy":
                    var codeNumber = int.Parse(tokens[4]);

                    soldiersById.Add(int.Parse(id), new Spy(id, firstName, lastnName, codeNumber));
                    break;
            }

            line = Console.ReadLine();
        }

        foreach (var soldier in soldiersById)
        {
            Console.WriteLine(soldier.Value);
        }
    }
}