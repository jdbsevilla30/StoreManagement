using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StoreManagement.Data.Model.StoreManagement;
using System;
using System.Threading.Tasks;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string Message { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IServiceScopeFactory serviceScopeFactory)
    {
        _next = next;
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong: {ex}");
            LogExceptionToDatabase(ex);
            await HandleExceptionAsync(context, ex);
        }
    }

    private async void LogExceptionToDatabase(Exception exception)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var dbContext = scopedServices.GetRequiredService<StoreManagementContext>();

            var errorLog = new ErrorLog
            {
                User = "user",
                Date = DateTime.Now,
                ErrorMessage = $"Error: {exception.Message}",
                Module = "module"
            };

           dbContext.ErrorLogs.Add(errorLog);
           await dbContext.SaveChangesAsync();
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await context.Response.WriteAsync(new ErrorDetails
        {
            StatusCode = context.Response.StatusCode,
            Message = "Internal Server Error."
        }.ToString());
    }
}
