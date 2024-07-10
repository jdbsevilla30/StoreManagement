using StoreManagement.Dtos;

namespace StoreManagement.Interface
{
    public interface IErrorLoggerFactory
    {
         ErrorLoggerDto Create(string? user, DateTime dateTime, string errorMessage, string module);
    }
}
