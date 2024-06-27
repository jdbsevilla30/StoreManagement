namespace StoreManagement.Interface
{
    public interface IUnitOfWork
    {
        IStoreInventory storeInventory { get; }
        IActivityLogger activityLogger { get; }
        IErrorLogger errorLogger { get; }
        Task<bool> Complete();
    }
}