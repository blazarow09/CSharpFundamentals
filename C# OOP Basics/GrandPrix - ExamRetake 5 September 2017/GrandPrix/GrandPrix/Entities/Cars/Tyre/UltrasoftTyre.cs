using System;

public class UltrasoftTyre : Tyre
{
    public UltrasoftTyre(double hardness) : base("Ultrasoft", hardness)
    {
    }

    public override double Degradation
    {
        get => base.Degradation;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Blown Tyre");
            }

            base.Degradation = value;
        }
    }

    public double Grip { get; }

    public override void CompleteLap()
    {
        base.CompleteLap();

        this.Degradation -= this.Grip;
    }
}