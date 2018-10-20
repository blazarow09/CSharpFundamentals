
namespace ValidationData
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static void Main(string[] args)
        {
            var countLines = int.Parse(Console.ReadLine());

            var persons = new List<Person>();

            for (int i = 0; i < countLines; i++)
            {
                var tokens = Console.ReadLine()
                              .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    var person = new Person(
                        tokens[0],
                        tokens[1],
                        int.Parse(tokens[2]),
                        decimal.Parse(tokens[3]));

                    persons.Add(person);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            var bonus = int.Parse(Console.ReadLine());

            persons.ForEach(p => p.IncreaseSalary(bonus));
            persons.ForEach(p => Console.WriteLine(p));
        }
    }
}