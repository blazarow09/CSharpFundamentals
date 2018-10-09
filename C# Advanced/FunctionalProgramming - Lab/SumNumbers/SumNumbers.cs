namespace SumNumbers
{
    using System;
    using System.Linq;

    class SumNumbers
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Console.WriteLine($"{numbers.Count}");
            Console.WriteLine($"{numbers.Sum()}");
        }
    }
}
