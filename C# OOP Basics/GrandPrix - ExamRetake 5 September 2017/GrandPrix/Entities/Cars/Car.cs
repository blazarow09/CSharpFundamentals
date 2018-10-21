using System;

public class Car
{
    private const double maxFuelAmount = 160;
    private double fuelAmount;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; }

    public double FuelAmount
    {
        get
        {
            return this.fuelAmount;
        }
        protected set
        {
            if (value <= 0)
            {
                throw new ArgumentException(ErrorMessages.OutOFFuel);
            }

            this.fuelAmount = Math.Min(value, maxFuelAmount);
        }
    }

    public Tyre Tyre { get; private set; }
}