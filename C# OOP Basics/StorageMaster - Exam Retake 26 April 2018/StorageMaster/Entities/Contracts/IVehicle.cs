namespace StorageMaster.Entities.Contracts
{
    public interface IVehicle
    {
        int Capacity { get; }

        bool IsFull { get; }

        bool IsEmpty { get; }
    }
}