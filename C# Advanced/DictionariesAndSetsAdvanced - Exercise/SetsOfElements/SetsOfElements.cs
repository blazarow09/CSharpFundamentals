namespace SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SetsOfElements
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var firstSet = new HashSet<double>();

            var secondSet = new HashSet<double>();

            for (int i = 0; i < sizes[0]; i++)
            {
                var line = double.Parse(Console.ReadLine());

                firstSet.Add(line);
            }

            for (int i = 0; i < sizes[1]; i++)
            {
                var line = double.Parse(Console.ReadLine());

                secondSet.Add(line);
            }

            var print = new List<double>();

            foreach (var num in firstSet)
            {
                if (secondSet.Contains(num))
                {
                    print.Add(num);
                }
            }

            Console.WriteLine(string.Join(" ", print));
        }
    }
}
