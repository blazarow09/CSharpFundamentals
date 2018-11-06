using MilitaryElite.Enums;
using MilitaryElite.Interfaces;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class Engine
    {
        public void Run()
        {
            Dictionary<int, ISoldier> soldiers = new Dictionary<int, ISoldier>();

            string line = Console.ReadLine();

            while (line != "End")
            {
                var tokens = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var type = tokens[0];
                var id = tokens[1];
                var firstName = tokens[2];
                var lastName = tokens[3];
                var salary = 0m;
                Corps corp;

                switch (type)
                {
                    case "Private":
                        salary = decimal.Parse(tokens[4]);

                        var privateSoldier = new Private(id, firstName, lastName, salary);

                        soldiers.Add(int.Parse(id), privateSoldier);
                        break;

                    case "LieutenantGeneral":
                        salary = decimal.Parse(tokens[4]);

                        List<ISoldier> privates = new List<ISoldier>();

                        for (int i = 5; i < tokens.Length; i++)
                        {
                            var privateId = tokens[i];
                            privates.Add(soldiers[int.Parse(privateId)]);
                        }

                        var lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary, privates);

                        soldiers.Add(int.Parse(id), lieutenantGeneral);
                        break;

                    case "Engineer":
                        salary = decimal.Parse(tokens[4]);

                        if (!Enum.TryParse(tokens[5], out corp))
                        {
                            continue;
                        }

                        List<IRepair> repairs = new List<IRepair>();

                        for (int i = 6; i < tokens.Length; i += 2)
                        {
                            var partName = tokens[i];
                            var hoursWorked = int.Parse(tokens[i + 1]);

                            try
                            {
                                var repair = new Repair(partName, hoursWorked);

                                repairs.Add(repair);
                            }
                            catch (ArgumentException)
                            {
                            }
                        }

                        try
                        {
                            var engineer = new Engineer(id, firstName, lastName, salary, corp.ToString(), repairs);

                            soldiers.Add(int.Parse(id), engineer);
                        }
                        catch (ArgumentException)
                        {
                        }
                        break;

                    case "Commando":
                        salary = decimal.Parse(tokens[4]);

                        if (!Enum.TryParse(tokens[5], out corp))
                        {
                            continue;
                        }

                        List<IMission> missions = new List<IMission>();

                        for (int i = 6; i < tokens.Length; i += 2)
                        {
                            var codeName = tokens[i];
                            MissionStatus state;

                            if (!Enum.TryParse(tokens[i + 1], out state))
                            {
                                continue;
                            }

                            try
                            {
                                var mission = new Mission(codeName, state.ToString());
                                missions.Add(mission);
                            }
                            catch (ArgumentException)
                            {
                            }
                        }

                        try
                        {
                            var commando = new Commando(id, firstName, lastName, salary, corp.ToString(), missions);

                            soldiers.Add(int.Parse(id), commando);
                        }
                        catch (ArgumentException)
                        {
                        }
                        break;

                    case "Spy":
                        var codeNumber = int.Parse(tokens[4]);

                        var spy = new Spy(id, firstName, lastName, codeNumber);

                        soldiers.Add(int.Parse(id), spy);
                        break;
                }

                line = Console.ReadLine();
            }

            foreach (var soldier in soldiers.Values)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}