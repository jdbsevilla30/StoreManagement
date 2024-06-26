namespace StoreManagement.Interface
{
    public interface IUnitOfWork
    {
        IStoreInventory storeInventory { get; }
    }
}