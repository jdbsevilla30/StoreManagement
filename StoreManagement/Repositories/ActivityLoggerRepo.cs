using StoreManagement.Data.Model.StoreManagement;
using StoreManagement.Dtos;
using StoreManagement.Interface;

namespace StoreManagement.Repositories
{
    public class ActivityLoggerRepo : IActivityLogger
    {
        private readonly StoreManagementContext _context;

        public ActivityLoggerRepo(StoreManagementContext context)
        {
            _context = context;
        }

        public void LogActivity(ActivityLog activity)
        {
            _context.Add(activity);
        }


    }
}
