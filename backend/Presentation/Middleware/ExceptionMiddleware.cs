using System.Net;
using System.Text.Json;
using Application.Exceptions;

namespace Presentation.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error no controlado: {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode;
            string message;

            switch (ex)
            {
                case NotFoundException e:
                    statusCode = HttpStatusCode.NotFound;
                    message = e.Message;
                    break;
                case ValidationException e:
                    statusCode = HttpStatusCode.BadRequest;
                    message = e.Message;
                    break;
                case DatabaseException e:
                    statusCode = HttpStatusCode.InternalServerError;
                    message = e.Message;
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    message = "An unexpected error occurred. Please try again.";
                    break;
            }

            var result = JsonSerializer.Serialize(new
            {
                success = false,
                error = message,
                status = (int)statusCode
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(result);
        }
    }
}
