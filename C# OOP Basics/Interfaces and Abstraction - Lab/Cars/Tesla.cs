using System;

public class Tesla : ICar, IElectricCar
{
    public Tesla(string model, string color, int battery)
    {
        this.Model = model;
        this.Color = color;
        this.Battery = battery;
    }

    public int Battery { get; set; }

    public string Model { get; set; }

    public string Color { get; set; }

    public string Start()
    {
        throw new NotImplementedException();
    }

    public string Stop()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"{this.Color} Tesla {this.Model} with {this.Battery} Batteries\n" +
            $"Engine start\n" +
            "Breaaak!";
    }
}