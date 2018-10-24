namespace StorageMaster.Entities
{
    using StorageMaster.Interfaces;
    using System;

    public abstract class Product : IProductable
    {
        private readonly double price;

        public Product(double price, double weight) 
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price {
            get
            {
                return this.price;
            }
            protected set
            {
                if(value < 0)
                {
                    throw new InvalidOperationException(ExceptionMessages.InvalidPrice);
                }

                value = this.price;
            }
        }

        public double Weight { get; set; }
    }
}