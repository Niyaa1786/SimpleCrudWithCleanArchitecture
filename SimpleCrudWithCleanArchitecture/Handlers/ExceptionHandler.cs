using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using SimpleCrud.Api.Responses;
using SimpleCrud.Application.Exceptions;
using System.Net;

namespace SimpleCrud.Api.Handlers
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(ILogger<ExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            //Default Values
            int statusCode = (int)HttpStatusCode.InternalServerError;
            string message = "An unexpected error occurred.";
            object? errors = null;

            if (exception is NotFoundException nf)
            {
                statusCode = (int)HttpStatusCode.NotFound;
                message = nf.Message;

            }
            else if (exception is ValidationException ve)
            {
                statusCode = (int)HttpStatusCode.BadRequest;
                message = "Validation Failed";
                errors = ve.Errors
                    .GroupBy(e => e.PropertyName)
                    .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());
            }
            else if(exception is ArgumentException ae)
            {
                statusCode = (int)HttpStatusCode.BadRequest;
                message = "Invalid argument";
            }

            var response = ApiResponse<object>.Error(message, errors);

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }
}
