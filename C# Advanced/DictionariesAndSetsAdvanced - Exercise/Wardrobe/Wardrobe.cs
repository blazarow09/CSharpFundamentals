namespace Wardrobe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Wardrobe
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < count; i++)
            {
                string[] line = Console.ReadLine().Split(new string[] { " -> " },
                    StringSplitOptions.RemoveEmptyEntries).ToArray();
                string color = line[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                string clothes = line[1];
                string[] inputClotes = clothes.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries).ToArray();

                foreach (var item in inputClotes)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color].Add(item, 0);
                    }

                    wardrobe[color][item]++;
                }
            }

            string[] lastLine = Console.ReadLine().Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var colorKvP in wardrobe)
            {
                Console.WriteLine($"{colorKvP.Key} clothes:");

                foreach (var clothesKvP in colorKvP.Value)
                {
                    if (colorKvP.Key == lastLine[0] && clothesKvP.Key == lastLine[1])
                    {
                        Console.WriteLine($"* {clothesKvP.Key} - {clothesKvP.Value} (found!)");
                    }

                    else
                    {
                        Console.WriteLine($"* {clothesKvP.Key} - {clothesKvP.Value}");
                    }
                }
            }
        }
    }
}