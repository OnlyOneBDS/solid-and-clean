using System.Net;
using HR.LeaveManagement.Api.Models;
using HR.LeaveManagement.Application.Exceptions;
using Newtonsoft.Json;

namespace HR.LeaveManagement.Api.Middleware;

public class ExceptionMiddleware
{
  private readonly RequestDelegate _next;
  private readonly ILogger<ExceptionMiddleware> _logger;

  public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
  {
    _next = next;
    _logger = logger;
  }

  public async Task InvokeAsync(HttpContext httpContext)
  {
    try
    {
      await _next(httpContext);
    }
    catch (Exception ex)
    {
      await HandleExceptionAsync(httpContext, ex);
    }
  }

  private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
  {
    HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
    CustomProblemDetails problem = new();

    switch (ex)
    {
      case BadRequestException badRequest:
        statusCode = HttpStatusCode.BadRequest;
        problem = new CustomProblemDetails
        {
          Title = badRequest.Message,
          Status = (int)statusCode,
          Detail = badRequest.InnerException?.Message,
          Type = nameof(BadRequestException),
          Errors = badRequest.ValidationErrors,
        };
        break;
      case NotFoundException notFound:
        statusCode = HttpStatusCode.NotFound;
        problem = new CustomProblemDetails
        {
          Title = notFound.Message,
          Status = (int)statusCode,
          Detail = notFound.InnerException?.Message,
          Type = nameof(NotFoundException),
        };
        break;
      default:
        problem = new CustomProblemDetails
        {
          Title = ex.Message,
          Status = (int)statusCode,
          Detail = ex.StackTrace,
          Type = nameof(HttpStatusCode.InternalServerError),
        };
        break;
    }

    httpContext.Response.StatusCode = (int)statusCode;
    var logMessage = JsonConvert.SerializeObject(problem);

    _logger.LogError(logMessage);
    await httpContext.Response.WriteAsJsonAsync(problem);
  }
}
