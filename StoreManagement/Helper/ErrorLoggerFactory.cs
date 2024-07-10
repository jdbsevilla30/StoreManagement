using StoreManagement.Dtos;
using StoreManagement.Interface;

namespace StoreManagement.Helper
{
    public class ErrorLoggerFactory : IErrorLoggerFactory
    {
        public ErrorLoggerDto Create(string? user, DateTime dateTime, string errorMessage, string module)
        {
            return new ErrorLoggerDto()
            {
                User = user,
                Date = dateTime,
                ErrorMessage = errorMessage,
                Module = module
            };
        }
    }
}
