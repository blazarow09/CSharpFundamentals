using System;

public class Car
{
    private const double fuelMaxTank = 160d;
    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp
    {
        get { return this.hp; }
        private set { this.hp = value; }
    }

    public double FuelAmount
    {
        get
        {
            return this.fuelAmount;
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.OutOfFuel);
            }

            if (value > fuelMaxTank)
            {
                this.fuelAmount = fuelMaxTank;
            }
            else
            {
                this.fuelAmount = value;
            }
        }
    }

    public Tyre Tyre
    {
        get { return this.tyre; }
        private set { this.tyre = value; }
    }

    public void Refuel(double liters)
    {
        this.FuelAmount += liters;
    }

    public void ChangeTyres(Tyre newTyre)
    {
        this.Tyre = newTyre;
    }

    public void ReduceFuel(int lenght, double fuelConsumption)
    {
        this.FuelAmount -= lenght * fuelConsumption;
    }
}