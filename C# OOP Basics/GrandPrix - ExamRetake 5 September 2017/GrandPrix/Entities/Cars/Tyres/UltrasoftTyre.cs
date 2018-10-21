using System;

public class UltrasoftTyre : Tyre
{
    public UltrasoftTyre(double hardness, double grip) : base("Ultrasoft", hardness)
    {
        this.Grip = grip;
    }

    public override double Degradation
    {
        get => base.Degradation;
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException(ErrorMessages.BlownTyre);
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