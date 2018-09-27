namespace AverageStudentGrades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AverageStudentGrades
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());

            var dictionary = new Dictionary<string, List<double>>();

            for (int i = 0; i < count; i++)
            {
                var line = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = line[0];
                var grade = double.Parse(line[1]);

                if (dictionary.ContainsKey(name) == false)
                {
                    dictionary[name] = new List<double>() { grade };
                }
                else
                {
                    dictionary[name].Add(grade);
                }
            }

            foreach (var item in dictionary)
            {
                Console.Write($"{item.Key} -> ");

                foreach (var grades in item.Value)
                {
                    Console.Write($"{ grades:f2} ");
                }
                Console.WriteLine($"(avg: {item.Value.Average():F2})");
            }
        }
    }
}