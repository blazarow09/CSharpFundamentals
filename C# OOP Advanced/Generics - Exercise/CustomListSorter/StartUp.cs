using System;

namespace CustomListSorter
{
    public class StartUp
    {
        private static void Main(string[] args)
        {
            var line = Console.ReadLine();

            CustomList<string> customList = new CustomList<string>();

            while (line != "END")
            {
                var tokens = line.Split();
                var command = tokens[0];

                switch (command)
                {
                    case "Add":
                        customList.Add(tokens[1]);
                        break;

                    case "Remove":
                        customList.Remove(int.Parse(tokens[1]));
                        break;

                    case "Contains":
                        var count = customList.Contains(tokens[1]);
                        Console.WriteLine(count);
                        break;

                    case "Swap":
                        var firstIndex = int.Parse(tokens[1]);
                        var secondIndex = int.Parse(tokens[2]);

                        customList.Swap(firstIndex, secondIndex);
                        break;

                    case "Greater":
                        var counter = customList.CountGreaterThan(tokens[1]);
                        Console.WriteLine(counter);
                        break;

                    case "Max":
                        var max = customList.Max();
                        Console.WriteLine(max);
                        break;

                    case "Min":
                        var min = customList.Min();
                        Console.WriteLine(min);
                        break;

                    case "Sort":
                        customList.Sort();
                        break;

                    case "Print":
                        foreach (var element in customList.Elements)
                        {
                            Console.WriteLine(element);
                        }
                        break;
                }

                line = Console.ReadLine();
            }
        }
    }
}