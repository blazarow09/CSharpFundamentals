namespace ShoppingSpree
{
    using System;

    public class Product
    {
        private string productName;
        private double price;

        public Product(string productName, double price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.productName = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.price = value;
            }
        }
    }
}