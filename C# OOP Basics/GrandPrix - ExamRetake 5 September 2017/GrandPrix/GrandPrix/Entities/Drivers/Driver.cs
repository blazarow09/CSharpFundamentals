public class Driver : IDriver
{
    public Driver(string name, Car car, double fuelConsumption)
    {
        this.Name = name;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumption;
        this.TotalTime = 0.0;
    }

    public string Name { get; }

    public double TotalTime { get; protected set; }

    public Car Car { get; }

    public double FuelConsumptionPerKm { get; protected set; }

    public virtual double Speed => (this.Car.Hp + Car.Tyre.Degradation) / Car.FuelAmount;
}