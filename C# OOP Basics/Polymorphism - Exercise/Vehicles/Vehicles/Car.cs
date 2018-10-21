using System;

namespace Vehicles.Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double consumptionPerKm) : base(fuelQuantity, consumptionPerKm)
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
            base.FuelQuantity += amount;
        }
    }
}