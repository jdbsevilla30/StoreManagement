using StoreManagement.Data.Model.StoreManagement;

namespace StoreManagement.Interface
{
    public interface IErrorLogger
    {
        public void LogError(ErrorLog error);
    }
}
