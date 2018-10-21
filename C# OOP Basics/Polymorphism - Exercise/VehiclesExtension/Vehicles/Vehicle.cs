namespace VehiclesExtension.Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double consumptionPerKm;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double consumptionPerKm, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.ConsumptionPerKm = consumptionPerKm;
            this.FuelQuantity = fuelQuantity;
        }

        protected double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
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

        protected double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }
            set
            {
                this.tankCapacity = value;
            }
        }

        public abstract void DriveVehicle(double distance);

        public abstract void RefuelVehicle(double amount);

        public abstract double PrintLeftFuel();
    }
}