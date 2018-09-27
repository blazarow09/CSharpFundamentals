namespace CountSameValuesInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CountSameValuesInArray
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var dictionary = new Dictionary<double, int>();

            for (int index = 0; index < numbers.Length; index++)
            {
                if (dictionary.ContainsKey(numbers[index]) == false)
                {
                    dictionary[numbers[index]] = 1;
                }
                else
                {
                    dictionary[numbers[index]]++;
                }
            }

            foreach (var number in dictionary)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
