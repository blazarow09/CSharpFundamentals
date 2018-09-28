namespace EvenTimes
{
    using System;
    using System.Collections.Generic;

    class EvenTimes
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());

            var dictionary = new Dictionary<int, int>();

            for (int i = 0; i < count; i++)
            {
                var number = int.Parse(Console.ReadLine());

                if (dictionary.ContainsKey(number) == false)
                {
                    dictionary.Add(number, 1);
                }
                else if (dictionary.ContainsKey(number))
                {
                    dictionary[number]++;
                }
            }

            foreach (var num in dictionary)
            {
                if (num.Value % 2 == 0)
                {
                    Console.WriteLine(string.Join(" ", num.Key));
                }
            }
        }
    }
}
