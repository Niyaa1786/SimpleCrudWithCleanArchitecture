using SimpleCrud.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace SimpleCrud.Api.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
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
                _logger.LogError(ex, "Unhandled exception occurred.");

                var statusCode = HttpStatusCode.InternalServerError;
                var message = "An unexpected error occurred.";

                if (ex is NotFoundException)
                {
                    statusCode = HttpStatusCode.NotFound;
                    message = ex.Message;
                }

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)statusCode;

                var response = new
                {
                    status = context.Response.StatusCode,
                    message = message
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
