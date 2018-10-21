using System;
using VehiclesExtension.Vehicles;

namespace VehiclesExtension
{
    internal class StartUp
    {
        public static string command;
        public static string vehicleType;

        public static void Main(string[] args)
        {
            var carTokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var car = new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]), double.Parse(carTokens[3]));

            var truckTokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var truck = new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2]), double.Parse(truckTokens[3]));

            var busTokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var bus = new Bus(double.Parse(busTokens[1]), double.Parse(busTokens[2]), double.Parse(busTokens[3]));

            var commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                command = tokens[0];
                vehicleType = tokens[1];
                var distanceOrAmount = double.Parse(tokens[2]);

                switch (command)
                {
                    case "Drive":
                        if (vehicleType == "Car")
                        {
                            car.DriveVehicle(distanceOrAmount);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.DriveVehicle(distanceOrAmount);
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.DriveVehicle(distanceOrAmount);
                        }
                        break;

                    case "Refuel":
                        if (vehicleType == "Car")
                        {
                            car.RefuelVehicle(distanceOrAmount);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.RefuelVehicle(distanceOrAmount);
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.RefuelVehicle(distanceOrAmount);
                        }
                        break;
                    case "DriveEmpty":
                        if (vehicleType == "Bus")
                        {
                            bus.DriveVehicle(distanceOrAmount);
                        }
                        break;
                }
            }

            Console.WriteLine($"Car: {car.PrintLeftFuel():f2}");
            Console.WriteLine($"Truck: {truck.PrintLeftFuel():f2}");
            Console.WriteLine($"Bus: {bus.PrintLeftFuel():f2}");
        }
    }
}