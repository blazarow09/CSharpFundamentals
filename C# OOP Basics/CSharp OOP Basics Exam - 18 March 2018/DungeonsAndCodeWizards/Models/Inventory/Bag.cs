using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards.Models.Inventory
{
    public abstract class Bag
    {
        private const int defaultCapacity = 100;

        private readonly List<Item> items;
        private int capacity;

        protected Bag(int capacity = defaultCapacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        protected int Capacity { get; set; }

        private int Load => this.items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items
        {
            get
            {
                return this.items.AsReadOnly();
            }
        }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.FullBag);
            }
        }

        public Item GetItem(string name)
        {
            EnsureItemExists(name);

            var item = this.items.First(i => i.GetType().Name == name);
            this.items.Remove(item);

            return item;
        }

        private void EnsureItemExists(string name)
        {
            if (!this.items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            var itemExists = this.items.Any(i => i.GetType().Name == name);
            if (!itemExists)
            {
                throw new ArgumentException($"No item with name {name} in bag");
            }
        }
    }
}