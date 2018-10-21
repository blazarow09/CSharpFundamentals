namespace Vehicles.Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double consumptionPerKm;

        public Vehicle(double fuelQuantity, double consumptionPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.ConsumptionPerKm = consumptionPerKm;
        }

        protected double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            set
            {
                this.fuelQuantity = value;
            }
        }

        protected double ConsumptionPerKm
        {
            get
            {
                return this.consumptionPerKm;
            }
            set
            {
                this.consumptionPerKm = value;
            }
        }

       

        public abstract void DriveVehicle(double distance);

        public abstract void RefuelVehicle(double amount);

        public abstract double PrintLeftFuel();
    }
}