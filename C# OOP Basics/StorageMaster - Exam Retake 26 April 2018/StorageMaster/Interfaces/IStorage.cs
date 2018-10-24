namespace StorageMaster.Interfaces
{
    using StorageMaster.Entities;
    using System.Collections.Generic;

    public interface IStorage
    {
        string Name { get; }

        int Capacity { get; }

        IReadOnlyCollection<Vehicle> Garage { get; }

        IReadOnlyCollection<Product> Products { get; }
    }
}