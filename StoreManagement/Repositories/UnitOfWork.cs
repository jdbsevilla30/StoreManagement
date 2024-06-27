﻿
using StoreManagement.Interface;
using StoreManagement.Data.Model;
using StoreManagement.Data.Model.StoreManagement;
using StoreManagement.Repositories;


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
        public IActivityLogger activityLogger => new ActivityLoggerRepo(_storeManagementContext);
        public IErrorLogger errorLogger => new ErrorLoggerRepo(_storeManagementContext);
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