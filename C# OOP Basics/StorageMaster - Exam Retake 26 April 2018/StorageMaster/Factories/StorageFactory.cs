using StorageMaster.Entities.Storage;
using System;

namespace StorageMaster.Factories
{
    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            switch (type)
            {
                case "AutomatedWarehouse":
                    return new AutomatedWarehouse(name);

                case "Warehouse":
                    return new Warehouse(name);

                case "DistributionCenter":
                    return new DistributionCenter(name);

                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidStorage);
            }
        }
    }
}