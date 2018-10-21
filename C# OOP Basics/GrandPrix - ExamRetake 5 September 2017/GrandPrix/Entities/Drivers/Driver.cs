public abstract class Driver
{
    public Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.TotalTime = 0d;
    }

    public string Name { get; }

    public double TotalTime { get; protected set; }

    public Car Car { get; }

    public double FuelConsumptionPerKm { get; protected set; }

    public virtual double Speed => (this.Car.Hp + Car.Tyre.Degradation) / Car.FuelAmount;
}
