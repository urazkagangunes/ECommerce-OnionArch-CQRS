using Core.CrossCuttingConcers.Exceptions.ExceptionTypes;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcers.Exceptions.Handlers;

public class HttpsExceptionHandler : ExceptionHandler
{
    private HttpResponse response;

    public HttpResponse Response
    {
        get => response ?? throw new ArgumentNullException(nameof(response));
        set => response = value;
    }
    protected override Task HandleException(AuthorizationException authorizationException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        string details = new AuthorizationProblemDetails(authorizationException.Message).AsJson;
    }

    protected override Task HandleException(ValidationException validationException)
    {
        throw new NotImplementedException();
    }

    protected override Task HandleException(BusinessException businessException)
    {
        throw new NotImplementedException();
    }

    protected override Task HandleException(Exception exception)
    {
        throw new NotImplementedException();
    }
}
