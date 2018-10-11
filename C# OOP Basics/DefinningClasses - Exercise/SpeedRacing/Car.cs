public class Car
{
    private string model;
    private double fuelAmount;
    private double Conspumption;

    public string Model { get; set; }

    public double FuelAmount { get; set; }

    public double Consumption { get; set; }

    public double Distance { get; set; }

    public Car(string model, double fuelAmount, double fuelConsumption)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.Consumption = fuelConsumption;
        this.Distance = 0;
    }

    public bool Drive(double distance)
    {
        var fuelNeeded = distance * this.Consumption;

        if (this.FuelAmount < fuelNeeded)
        {
            return false;
        }

        this.FuelAmount -= fuelNeeded;
        this.Distance += distance;
        return true;
    }
}
