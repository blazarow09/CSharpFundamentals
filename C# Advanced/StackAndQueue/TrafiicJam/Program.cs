using System;
using System.Collections.Generic;

namespace TrafiicJam
{
    class Program
    {
        static void Main(string[] args)
        {
            var carsPerGreen = int.Parse(Console.ReadLine());

            var input = Console.ReadLine();

            var cars = new Queue<string>();

            var countCarsPassed = 0;

            while (input != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < carsPerGreen; i++)
                    {
                        if (cars.Count < carsPerGreen)
                        {
                            for (int j = 0; j < cars.Count; j++)
                            {
                                Console.WriteLine($"{cars.Dequeue()} passed!");
                                countCarsPassed++;
                            }
                        }
                        else
                        {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        countCarsPassed++;
                        }
                    }
                }
                else
                {
                        cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{countCarsPassed} cars passed the crossroads.");
        }
    }
}
