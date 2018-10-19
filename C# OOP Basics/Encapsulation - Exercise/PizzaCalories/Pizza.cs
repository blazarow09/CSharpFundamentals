namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Pizza
    {
        private string name;
        private List<Topping> toppings = new List<Topping>();
        private Dough dough;

        public Pizza()
        {
        }

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
        }

        private string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        private Dough Dough
        {
            get
            {
                return this.dough;
            }
            set
            {
                this.dough = value;
            }
        }

        public int GetNumberOfToppings()
        {
            return this.toppings.Count;
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(topping);
        }
    }
}