using System;

namespace VehiclesExtension.Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double consumptionPerKm, double tankCapacity) : base(fuelQuantity, consumptionPerKm, tankCapacity)
        {
        }

        public override void DriveVehicle(double distance)
        {
            var fuelConsumed = distance * (base.ConsumptionPerKm + 0.9);

            if (fuelConsumed > base.FuelQuantity)
            {
                Console.WriteLine("Car needs refueling");
            }
            else
            {
                base.FuelQuantity -= fuelConsumed;
                Console.WriteLine($"Car travelled {distance} km");
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
                if (amount > (base.TankCapacity - base.FuelQuantity))
                {
                    Console.WriteLine($"Cannot fit {amount} fuel in the tank");
                }
                else
                {
                    base.FuelQuantity += amount;
                }
            }
            else
            {
                Console.WriteLine("Fuel must be a positive number");
            }
        }
    }
}