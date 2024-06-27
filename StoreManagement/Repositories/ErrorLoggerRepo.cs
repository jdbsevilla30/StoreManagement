using StoreManagement.Data.Model.StoreManagement;
using StoreManagement.Interface;

namespace StoreManagement.Repositories
{
    public class ErrorLoggerRepo : IErrorLogger
    {
        private readonly StoreManagementContext _context;

        public ErrorLoggerRepo(StoreManagementContext context)
        {
           _context = context;
        }

        public void LogError(ErrorLog error)
        {
           _context.ErrorLogs.Add(error);
        }
    }
}
