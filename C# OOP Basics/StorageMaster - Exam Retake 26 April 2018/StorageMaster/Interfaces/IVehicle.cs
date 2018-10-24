namespace StorageMaster.Interfaces
{
    using StorageMaster.Entities;
    using System.Collections.Generic;

    public interface IVehicle
    {
        int Capacity { get; }

        IReadOnlyCollection<Product> Trunk { get; }
    }
}