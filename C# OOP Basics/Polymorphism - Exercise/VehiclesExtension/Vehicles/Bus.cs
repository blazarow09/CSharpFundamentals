using System;

namespace VehiclesExtension.Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double consumptionPerKm, double tankCapacity) : base(fuelQuantity, consumptionPerKm, tankCapacity)
        {
        }

        public override void DriveVehicle(double distance)
        {
            double fuelConsumed;

            if (StartUp.vehicleType == "Bus" && StartUp.command != "DriveEmpty")
            {
                fuelConsumed = distance * (base.ConsumptionPerKm + 1.4);
            }
            else
            {
                fuelConsumed = distance * (base.ConsumptionPerKm);
            }

            if (base.FuelQuantity < fuelConsumed)
            {
                Console.WriteLine("Bus needs refueling");
            }
            else
            {
                base.FuelQuantity -= fuelConsumed;
                Console.WriteLine($"Bus travelled {distance} km");
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