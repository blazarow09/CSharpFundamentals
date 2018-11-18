using StorageMaster.Entities.Contracts;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Entities.Storage
{
    public abstract class Storage : IStorage
    {
        private Vehicle[] garage;
        private List<Product> products;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;

            this.garage = new Vehicle[GarageSlots];
            this.products = new List<Product>();
            this.InitializeGarage(vehicles);
        }

        public string Name { get; }

        public int Capacity { get; }

        public int GarageSlots { get; }

        public bool IsFull => this.products.Sum(w => w.Weight) >= this.Capacity;

        public IReadOnlyCollection<Vehicle> Garage => this.garage;

        public IReadOnlyCollection<Product> Products => this.products;

        public Vehicle GetVehicle(int garageSlot)
        {
            if (this.GarageSlots >= garage.Length)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidSlot);
            }

            var vehicle = this.garage[garageSlot];

            if (vehicle == null)
            {
                throw new InvalidOperationException(ExceptionMessages.NoVehicleInSlot);
            }

            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            var vehicle = GetVehicle(garageSlot);

            if (!this.garage.Contains(null))
            {
                throw new InvalidOperationException(ExceptionMessages.NoFreeRoom);
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

            var vehicle = this.GetVehicle(garageSlot);

            var unloadedProductCount = 0;

            while (!vehicle.IsEmpty && !this.IsFull)
            {
                var crate = vehicle.Unload();
                this.products.Add(crate);

                unloadedProductCount++;
            }
            return unloadedProductCount;
        }

        private void InitializeGarage(IEnumerable<Vehicle> vehicles)
        {
            var garageSlot = 0;

            foreach (var vehicle in vehicles)
            {
                this.garage[garageSlot++] = vehicle;
            }
        }

        private int AddVehicle(Vehicle vehicle)
        {
            var freeGarageSlotIndex = Array.IndexOf(this.garage, null);
            this.garage[freeGarageSlotIndex] = null;

            return freeGarageSlotIndex;
        }
    }
}