using StorageMaster.Entities.Contracts;
using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Entities.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private List<Product> trunk;

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new List<Product>();
        }

        public int Capacity { get; }

        public IReadOnlyCollection<Product> Trunk => this.trunk;

        public bool IsFull => this.Trunk.Sum(w => w.Weight) >= this.Capacity;

        public bool IsEmpty => !this.Trunk.Any();

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException(ExceptionMessages.FullVehicle);
            }

            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException(ExceptionMessages.NoProductsLeft);
            }

            var product = this.trunk.Last();
            this.trunk.RemoveAt(trunk.Count - 1);

            return product;
        }
    }
}