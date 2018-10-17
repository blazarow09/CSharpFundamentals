using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    public class StartUp
    {
        public static void Main()
        {
            var doctors = new Dictionary<string, List<string>>();
            var departments = new Dictionary<string, List<List<string>>>();

            var command = Console.ReadLine();

            FillDictionaries(doctors, departments, command);

            command = Console.ReadLine();

            PrintResult(doctors, departments, command);
        }

        private static string FillDictionaries(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string command)
        {
            while (command != "Output")
            {
                var tokens = command
                    .Split();

                var departament = tokens[0];
                var patient = tokens[3];
                var fullname = tokens[1] + tokens[2];

                if (!doctors.ContainsKey(fullname))
                {
                    doctors[fullname] = new List<string>();
                }
                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<List<string>>();
                    for (int rooms = 0; rooms < 20; rooms++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                var isTherePlace = departments[departament]
                    .SelectMany(x => x)
                    .Count() < 60;

                CheckWhetherThereIsPlace(doctors, departments, departament, patient, fullname, isTherePlace);

                command = Console.ReadLine();
            }

            return command;
        }

        private static void CheckWhetherThereIsPlace(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string departament, string patient, string fullname, bool isTherePlace)
        {
            if (isTherePlace)
            {
                var room = 0;

                doctors[fullname].Add(patient);

                for (int i = 0; i < departments[departament].Count; i++)
                {
                    if (departments[departament][i].Count < 3)
                    {
                        i = room;
                        break;
                    }
                }

                departments[departament][room].Add(patient);
            }
        }

        private static string PrintResult(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string command)
        {
            while (command != "End")
            {
                string[] args = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, departments[args[0]]
                        .Where(x => x.Count > 0)
                        .SelectMany(x => x)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int room))
                {
                    Console.WriteLine(string.Join(Environment.NewLine, departments[args[0]][room - 1]
                        .OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join(Environment.NewLine, doctors[args[0] + args[1]]
                        .OrderBy(x => x)));
                }
                command = Console.ReadLine();
            }

            return command;
        }
    }
}
