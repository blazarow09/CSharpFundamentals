namespace PeriodicTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PeriodicTable
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            var periodicTable = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                var line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var element in line)
                {
                    periodicTable.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", periodicTable.OrderBy(e => e)));
        }
    }
}
