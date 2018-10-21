using System;

public class Seat : ICar
{
    public Seat(string model, string color)
    {
        this.Model = model;
        this.Color = color;
    }

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
        return $"{this.Color} Seat {this.Model}\n" +
            $"Engine start\n" +
            "Breaaak!";
    }
}