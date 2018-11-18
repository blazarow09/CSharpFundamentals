using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storage;
using StorageMaster.Entities.Vehicles;
using StorageMaster.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        private readonly Dictionary<string, Storage> storageRegistry;
        private readonly Dictionary<string, Stack<Product>> productPool;

        private readonly ProductFactory productFactory;
        private readonly StorageFactory storageFactory;

        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.storageRegistry = new Dictionary<string, Storage>();
            this.productPool = new Dictionary<string, Stack<Product>>();

            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();

        }

        public string AddProduct(string type, double price)
        {
            if (!this.productPool.ContainsKey(type))
            {
                this.productPool[type] = new Stack<Product>();
            }

            var product = this.productFactory.CreateProduc(type, price);

            this.productPool[type].Push(product);

            return $"Added {type} to pool.";
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = this.storageFactory.CreateStorage(type, name);

            this.storageRegistry[storage.Name] = storage;

            return $"Registered {storage.Name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegistry[storageName];
            var vehicle = storage.GetVehicle(garageSlot);

            this.currentVehicle = vehicle;

            return $"Selected {vehicle.GetType().Name}";

        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            var loadedProductCount = 0;

            foreach (var name in productNames)
            {
                if (this.currentVehicle.IsFull)
                {
                    break;
                }

                if (!this.productPool.ContainsKey(name) || !this.productPool[name].Any())
                {
                    throw new InvalidOperationException($"{name} is out of stock!");
                }

                var product = this.productPool[name].Pop();

                this.currentVehicle.LoadProduct(product);

                loadedProductCount++;
            }

            var totalProductsCount = productNames.Count();

            return $"Loaded {loadedProductCount}/{totalProductsCount} products into {this.currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!this.storageRegistry.ContainsKey(sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            if (!this.storageRegistry.ContainsKey(destinationName))
            {
                throw new InvalidOperationException("Invalid destionation storage");
            }

            var sourceStorage = this.storageRegistry[sourceName];
            var destinationStorage = this.storageRegistry[destinationName];

            var vehicle = sourceStorage.GetVehicle(sourceGarageSlot);

            var destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {vehicle.GetType().Name} to {destinationStorage.Name} (slot {destinationGarageSlot})";

        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegistry[storageName];
            var vehicle = storage.GetVehicle(garageSlot);

            var productsInVehicle = vehicle.Trunk.Count;
            var unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storage.Name}";
        }

        public string GetStorageStatus(string storageName)
        {
           var storage = this.storageRegistry[storageName];

            var stockInfo = storage.Products
                .GroupBy(p=>p.GetType().Name)
                .Select(g => new 
                {
                    Name = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(p => p.Count)
                .ThenBy(p => p.Name)
                .Select(p => $"{p.Name} ({p.Count})")
                .ToArray();

            var productsCapacity = storage.Products.Sum(p => p.Weight);

            var stockFormat = $"Stock ({productsCapacity}/{storage.Capacity}): [{string.Join(", ", stockInfo)}]";

            var garage = storage.Garage.ToArray();
            var vehicleNames = garage.Select(v => v?.GetType().Name ?? "empty").ToArray();

            var garageFormat = $"Garage: [{string.Join("|", vehicleNames)}]";

            return stockFormat + Environment.NewLine + garageFormat;
        }

        public string GetSummary()
        {
            StringBuilder sb = new StringBuilder();

            var sortedStorage = this.storageRegistry.Values
            .OrderByDescending(s => s.Products.Sum(p => p.Price))
            .ToArray();

            foreach (var storage in sortedStorage)
            {
                sb.AppendLine($"{storage.Name}");
                var totalMoney = storage.Products.Sum(p => p.Price);
                sb.AppendLine($"Storage worth: {totalMoney:f2}");
            }

            return sb.ToString().TrimEnd('\r', '\n');
        }


    }
}
