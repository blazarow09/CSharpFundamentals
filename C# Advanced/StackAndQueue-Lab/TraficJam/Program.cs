using System;
using System.Collections.Generic;

namespace TraficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            var carsThatCanPass = int.Parse(Console.ReadLine());

            var input = Console.ReadLine();

            var carsQueue = new Queue<string>();
            var countCarsPassed = 0;

            while (input != "end")
            {
                var carsToPass = Math.Min(carsQueue.Count, carsThatCanPass);
                if (input == "green")
                {
                    for (int i = 0; i < carsToPass; i++)
                    {
                        Console.WriteLine($"{carsQueue.Dequeue()} passed!");
                        countCarsPassed++;
                    }
                }
                else
                {
                    carsQueue.Enqueue(input);
                    
                }
                    input = Console.ReadLine();
            }
            Console.WriteLine($"{countCarsPassed} cars passed the crossroads.");
        }
    }
}
