using StoreManagement.Dtos;
using StoreManagement.Interface;

namespace StoreManagement.Helper
{
    public class ActivityLoggerFactory : IActivityLoggerFactory
    {
        public ActivityLoggerDto Create(string? user, DateTime dateTime, string message, string module)
        {
            return new ActivityLoggerDto()
            {
                User = user,
                Date = dateTime,
                Activity = message,
                Module = module
            };
        }
    }
}
