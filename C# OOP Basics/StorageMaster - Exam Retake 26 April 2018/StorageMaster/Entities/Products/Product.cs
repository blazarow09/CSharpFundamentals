using StorageMaster.Entities.Contracts;
using System;

namespace StorageMaster.Entities.Products
{
    public abstract class Product : IProduct
    {
        private double price;

        protected Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException(ExceptionMessages.InvalidPrice);
                }

                this.price = value;
            }
        }

        public double Weight { get; }
    }
}