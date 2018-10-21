using System;

namespace VehiclesExtension.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double consumptionPerKm, double tankCapacity) : base(fuelQuantity, consumptionPerKm, tankCapacity)
        {
        }

        public override void DriveVehicle(double distance)
        {
            var fuelConsumed = distance * (base.ConsumptionPerKm + 1.6);

            if (base.FuelQuantity < fuelConsumed)
            {
                Console.WriteLine("Truck needs refueling");
            }
            else
            {
                base.FuelQuantity -= fuelConsumed;
                Console.WriteLine($"Truck travelled {distance} km");
            }
        }

        public override double PrintLeftFuel()
        {
            return base.FuelQuantity;
        }

        public override void RefuelVehicle(double amount)
        {
            if (amount > 0)
            {
                var fuelToAdd = amount * 0.95;
                if (amount > (base.TankCapacity - base.FuelQuantity))
                {
                    Console.WriteLine($"Cannot fit {amount} fuel in the tank");
                }
                else
                {
                    base.FuelQuantity += fuelToAdd;
                }
            }
            else
            {
                Console.WriteLine("Fuel must be a positive number");
            }
        }
    }
}