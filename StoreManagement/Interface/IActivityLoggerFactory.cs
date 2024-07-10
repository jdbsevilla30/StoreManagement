using StoreManagement.Dtos;

namespace StoreManagement.Interface
{
    public interface IActivityLoggerFactory
    {
        ActivityLoggerDto Create(string? user, DateTime dateTime, string errorMessage, string module);
    }
}
