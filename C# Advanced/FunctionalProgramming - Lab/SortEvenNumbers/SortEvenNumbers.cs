namespace SortEvenNumbers
{
    using System;
    using System.Linq;

    class SortEvenNumbers
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .ToList()
                .ForEach(n => Console.WriteLine(n));
        }
    }
}
