using StorageMaster.Entities.Products;
using System;

namespace StorageMaster.Factories
{
    public class ProductFactory
    {
        public Product CreateProduc(string type, double price)
        {
            switch (type)
            {
                case "Gpu":
                    return new Gpu(price);

                case "HardDrive":
                    return new HardDrive(price);

                case "Ram":
                    return new Ram(price);

                case "SolidStateDrive":
                    return new SolidStateDrive(price);

                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidProduct);
            }
        }
    }
}