using System;
using Vehicles.Vehicles;

namespace Vehicles
{
    public class StartUp
    {
        private static void Main(string[] args)
        {
            Car car;
            Truck truck;
            AddVehicles(out car, out truck);

            var commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var vehicleType = tokens[1];
                var distanceOrAmount = double.Parse(tokens[2]);

                switch (tokens[0])
                {
                    case "Drive":
                        if (vehicleType.ToLower() == "car")
                        {
                            car.DriveVehicle(distanceOrAmount);
                        }
                        else if (vehicleType.ToLower() == "truck")
                        {
                            truck.DriveVehicle(distanceOrAmount);
                        }
                        break;

                    case "Refuel":
                        if (vehicleType.ToLower() == "car")
                        {
                            car.RefuelVehicle(distanceOrAmount);
                        }
                        else if (vehicleType.ToLower() == "truck")
                        {
                            truck.RefuelVehicle(distanceOrAmount);
                        }
                        break;
                }
            }

            Console.WriteLine($"Car: {car.PrintLeftFuel():f2}");
            Console.WriteLine($"Truck: {truck.PrintLeftFuel():f2}");
        }

        private static void AddVehicles(out Car car, out Truck truck)
        {
            var carTokens = Console.ReadLine()
                            .Split();
            var truckTokens = Console.ReadLine()
                .Split();

            car = new Car(double.Parse(carTokens[1]),
                double.Parse(carTokens[2]));
            truck = new Truck(double.Parse(truckTokens[1]),
double.Parse(truckTokens[2]));
        }
    }
}