namespace CountSymbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CountSymbols
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine()
                .ToCharArray();

            var dictionary = new Dictionary<char, int>();

            foreach (var ch in line)
            {
                if (dictionary.ContainsKey(ch) == false)
                {
                    dictionary.Add(ch, 1);
                }
                else if (dictionary.ContainsKey(ch))
                {
                    dictionary[ch]++;
                }
            }

            foreach (var ch in dictionary.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }
        }
    }
}
