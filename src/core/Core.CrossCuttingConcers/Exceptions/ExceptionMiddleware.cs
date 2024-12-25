using Core.CrossCuttingConcerns.Exceptions.Handlers;
using Core.CrossCuttingConcerns.Serilog.Loggers;
using Microsoft.AspNetCore.Http;
using Core.CrossCuttingConcerns.Logging;
using System.Text.Json;

namespace Core.CrossCuttingConcerns.Exceptions;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly HttpsExceptionHandler _exceptionHandler;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly LoggerServiceBase _loggerService;

    public ExceptionMiddleware(RequestDelegate next, IHttpContextAccessor httpContextAccessor, LoggerServiceBase loggerService)
    {
        _next = next;
        _exceptionHandler = new HttpsExceptionHandler();
        _httpContextAccessor = httpContextAccessor;
        _loggerService = loggerService;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch(Exception e) 
        {
            await LogException(httpContext, e);
            await HandleExceptionAsync(httpContext.Response, e);
        }
    }

    private Task LogException(HttpContext httpContext, Exception exception)
    {
        List<LogParameter> logParameters = new()
        {
            new LogParameter{Type = httpContext.GetType().Name, Value = exception.ToString() }
        };

        LogDetailWithException logDetailWithException = new LogDetailWithException()
        {
            Parameters = logParameters,
            User = _httpContextAccessor.HttpContext.User.Identity?.Name ?? "?",
            MethodName = _next.Method.Name,
            ExceptionMessage = exception.Message
        };

        _loggerService.Error(JsonSerializer.Serialize(logDetailWithException));
        return Task.CompletedTask;
    }

    private Task HandleExceptionAsync(HttpResponse httpResponse,  Exception exception)
    {
        httpResponse.ContentType = "application/json";
        _exceptionHandler.Response = httpResponse;

        return _exceptionHandler.HandleExceptionAsync(exception);
    }
}