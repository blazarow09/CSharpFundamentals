    public class Car
    {
    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double Consumption { get; set; }
    public double Distance { get; set; }

    public Car(string model, double fuelAmount, double conspumtion)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.Consumption = conspumtion;
        this.Distance = 0;
    }

    public bool Drive(double distance)
    {
        double fuelNeeded = distance * this.Consumption;

        if (this.FuelAmount < fuelNeeded)
        {
            return false;
        }

        this.FuelAmount -= fuelNeeded;
        this.Distance += distance;
        return true;
    }
}

