
using StoreManagement.Interface;
using StoreManagement.Data.Model;
using StoreManagement.Data.Model.StoreManagement;


namespace File_Backup_Service.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreManagementContext _storeManagementContext;

        public UnitOfWork(StoreManagementContext storeManagementContext)
        {
            _storeManagementContext = storeManagementContext;
        }

        public IStoreInventory storeInventory => new StoreInventoryRepo(_storeManagementContext);

        public async Task<bool> Complete()
        {
            return await _storeManagementContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _storeManagementContext.Dispose();
        }
    }
}