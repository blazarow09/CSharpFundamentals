namespace StorageMaster.Entities
{
    using StorageMaster.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Storage : IStorage
    {
        protected Vehicle[] garage;
        private List<Product> products = new List<Product>();
        private int garageSlots;

        public Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.garage = new Vehicle[garageSlots];
            this.garageSlots = garageSlots;
        }

        public string Name { get; }

        public int GarageSlots { get; protected set; }

        public int Capacity { get; }

        public IReadOnlyCollection<Vehicle> Garage => this.garage;

        public IReadOnlyCollection<Product> Products => this.products;

        public bool IsFull => this.Products.Sum(p => p.Weight) >= this.Capacity;

        public Vehicle GetVehicle(int garageSlots)
        {
            if (garageSlots >= this.garageSlots)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGarageSlot);
            }

            var vehicle = this.garage[garageSlots];

            if (vehicle == null)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyGarageSlot);
            }

            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            var vehicle = GetVehicle(garageSlot);
            var hasFreeSlot = deliveryLocation.Garage.Any(g => g == null);

            if (!hasFreeSlot)
            {
                throw new InvalidOperationException(ExceptionMessages.NoFreeRoamInGarage);
            }

            this.garage[garageSlot] = null;

            var addedSlot = deliveryLocation.AddVehicle(vehicle);
            return addedSlot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException(ExceptionMessages.FullStorage);
            }

            var vehicle = GetVehicle(garageSlot);
            var unloadedProductCount = 0;

            while (this.IsFull)
            {
                var crate = vehicle.Unload();
                this.products.Add(crate);

                unloadedProductCount++;
            }

            return unloadedProductCount;
        }

        public int AddVehicle(Vehicle vehicle)
        {
            var freeGarageSlotIndex = Array.IndexOf(this.garage, null);
            this.garage[freeGarageSlotIndex] = vehicle;

            return freeGarageSlotIndex;
        }

        public void InitializeGarage(IEnumerable<Vehicle> vehicles)
        {
            var garageSlot = 0;

            foreach (var vehicle in vehicles)
            {
                this.garage[garageSlot++] = vehicle;
            }
        }
    }
}