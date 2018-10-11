using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        var cars = new List<Car>();

        var carsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < carsCount; i++)
        {
            var carTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var carModel = carTokens[0];
            
            if (cars.Any(c => c.Model == carModel) == false)
            {
                Car car = new Car(carModel,
                    double.Parse(carTokens[1]),
                    double.Parse(carTokens[2]));
                cars.Add(car);
            }
        }

        var line = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        while (line[0] != "End")
        {
            var carModel = line[1];
            var km = int.Parse(line[2]);

            var carToDrive = cars.Find(c => c.Model == carModel);

            bool isMoved = carToDrive.Drive(km);

            if (isMoved == false)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }

            line = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount} {car.Distance}");
        }
    }
}
