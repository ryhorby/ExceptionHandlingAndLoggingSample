using ExceptionHandlingAndLogging.Api.Models;
using System.Net;
using System.Text.Json;

namespace ExceptionHandlingAndLogging.Api.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private RequestDelegate _next;
        private ILogger _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ErrorHandlerMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = exception switch
                {
                    UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                    MethodAccessException => (int)HttpStatusCode.Forbidden,
                    NullReferenceException => (int)HttpStatusCode.NotFound,
                    ArgumentException => (int)HttpStatusCode.BadRequest,
                    _ => (int)HttpStatusCode.InternalServerError,
                };

                var result = JsonSerializer.Serialize(
                    new Dto()
                    {
                        ErrorMessage = exception.Message
                    });

                _logger.LogError(result);
                
                await response.WriteAsync(result);
            }
        }
    }

    public static class ErrorHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandler(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
