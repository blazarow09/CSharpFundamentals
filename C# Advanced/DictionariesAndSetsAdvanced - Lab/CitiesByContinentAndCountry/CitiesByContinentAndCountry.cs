namespace CitiesByContinentAndCountry
{
    using System;
    using System.Collections.Generic;

    class CitiesByContinentAndCountry
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());

            var dictionary = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < count; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var continent = tokens[0];
                var country = tokens[1];
                var city = tokens[2];

                if (dictionary.ContainsKey(continent) == false)
                {
                    dictionary[continent] = new Dictionary<string, List<string>>
                    {
                        [country] = new List<string>()
                            { city }
                    };
                }
                else if (dictionary.ContainsKey(continent))
                {
                    if (dictionary[continent].ContainsKey(country) == false)
                    {
                        dictionary[continent].Add(country, new List<string>()
                            { city });
                    }
                    else
                    {
                        dictionary[continent][country].Add(city);
                    }
                }
            }

            foreach (var continent in dictionary)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var item in continent.Value)
                {
                    Console.WriteLine($"    {item.Key} -> {String.Join(", ", item.Value)}");
                }
            }
        }
    }
}
