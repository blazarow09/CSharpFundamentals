namespace PizzaCalories
{
    using System;

    public class Topping
    {
        private string toppingType;
        private int weight;
        private const int baseCalories = 2;

        public Topping(string toppingType, int weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        private string ToppingType
        {
            get
            {
                return this.toppingType;
            }
            set
            {
                if (value.ToLower() != "meat" &&
                   value.ToLower() != "veggies" &&
                   value.ToLower() != "cheese" &&
                   value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.toppingType = value;
            }
        }

        private int Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.toppingType} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public double Calories()
        {
            double modifier = baseCalories;

            switch (this.ToppingType.ToLower())
            {
                case "meat": modifier *= 1.2; break;
                case "veggies": modifier *= 0.8; break;
                case "cheese": modifier *= 1.1; break;
                case "sauce": modifier *= 0.9; break;
            }

            return modifier * this.Weight;
        }
    }
}