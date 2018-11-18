namespace StorageMaster.Entities.Contracts
{
    public interface IStorage
    {
        string Name { get; }

        int Capacity { get; }

        int GarageSlots { get; }

        bool IsFull { get; }
    }
}