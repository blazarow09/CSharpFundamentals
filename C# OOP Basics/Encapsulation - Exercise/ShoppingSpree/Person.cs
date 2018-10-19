namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string name;
        private double money;
        private List<Product> bag;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value == " ")
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public double Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public void AddProductInBag(Product product)
        {
            this.bag.Add(product);
        }

        public void DecreaseMoney(double price)
        {
            this.money -= price;
        }

        public List<Product> SeeBag()
        {
            return this.bag;
        }
    }
}