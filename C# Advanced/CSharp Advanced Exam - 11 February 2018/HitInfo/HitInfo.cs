namespace HitInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class HitInfo
    {
        static void Main(string[] args)
        {
            var targetIndex = int.Parse(Console.ReadLine());

            var hitList = new Dictionary<string, Dictionary<string, string>>();

            string command;

            while ((command = Console.ReadLine()) != "end transmissions")
            {
                var commandArgs = command.Split("=", StringSplitOptions.RemoveEmptyEntries);

                var name = commandArgs[0];

                if (hitList.ContainsKey(name) == false)
                {
                    hitList[name] = new Dictionary<string, string>();
                }

                var line = commandArgs[1].Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (var pair in line)
                {
                    var tokens = pair.Split(":", StringSplitOptions.RemoveEmptyEntries);

                    hitList[name][tokens[0]] = tokens[1];
                }
            }

            var target = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Last();

            Console.WriteLine($"Info on {target}:");

            var man = hitList[target];

            foreach (var key in man.Keys.OrderBy(k => k))
            {
                Console.WriteLine($"---{key}: {man[key]}");
            }

            int infoIndex = hitList[target]
                .Select(kvp => kvp.Key.Length + kvp.Value.Length)
                .Sum();

            Console.WriteLine($"Info index: {infoIndex}");


            if (infoIndex >= targetIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetIndex - infoIndex} more info.");
            }
        }
    }
}
