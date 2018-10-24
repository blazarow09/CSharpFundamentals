namespace StorageMaster.Entities
{
    using StorageMaster.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public abstract class Vehicle : IVehicle
    {
        private Stack<Product> trunk = new Stack<Product>();

        public Vehicle()
        {
        }

        public int Capacity { get; protected set; }

        public IReadOnlyCollection<Product> Trunk => trunk;

        public bool IsEmpty => this.trunk.Any();


        public bool IsFull => this.trunk.Sum(p => p.Weight) >= this.Capacity;

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException(ExceptionMessages.FullVehicle);
            }

            this.trunk.Push(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyProduct);
            }

            return this.trunk.Pop();
        }
    }
}
