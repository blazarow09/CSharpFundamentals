using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class Potato
    {
        static void Main(string[] args)
        {
            long input = long.Parse(Console.ReadLine());

            string[] vault = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();

            long gold = 0;
            long rocks = 0;
            long cash = 0;

            for (int i = 0; i < vault.Length; i += 2)
            {
                string name = vault[i];

                long count = long.Parse(vault[i + 1]);

                string value = string.Empty;

                if (name.Length == 3)
                {
                    value = "Cash";
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    value = "Gem";
                }
                else if (name.ToLower() == "gold")
                {
                    value = "Gold";
                }

                if (value == "")
                {
                    continue;
                }
                else if (input < bag.Values.Select(x => x.Values.Sum()).Sum() + count)
                {
                    continue;
                }

                switch (value)
                {
                    case "Gem":
                        if (!bag.ContainsKey(value))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (count > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[value].Values.Sum() + count > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(value))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (count > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[value].Values.Sum() + count > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(value))
                {
                    bag[value] = new Dictionary<string, long>();
                }

                if (!bag[value].ContainsKey(name))
                {
                    bag[value][name] = 0;
                }

                bag[value][name] += count;
                if (value == "Gold")
                {
                    gold += count;
                }
                else if (value == "Gem")
                {
                    rocks += count;
                }
                else if (value == "Cash")
                {
                    cash += count;
                }
            }

            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}