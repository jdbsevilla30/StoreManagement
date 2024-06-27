using StoreManagement.Data.Model.StoreManagement;

namespace StoreManagement.Interface
{
    public interface IActivityLogger
    {
        public void LogActivity(ActivityLog activity);
    }
}
