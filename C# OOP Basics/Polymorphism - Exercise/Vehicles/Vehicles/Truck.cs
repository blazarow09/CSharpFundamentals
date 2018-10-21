using System;

namespace Vehicles.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double consumptionPerKm) : base(fuelQuantity, consumptionPerKm)
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
            var fuelToAdd = amount * 0.95;
            base.FuelQuantity += fuelToAdd;
        }
    }
}