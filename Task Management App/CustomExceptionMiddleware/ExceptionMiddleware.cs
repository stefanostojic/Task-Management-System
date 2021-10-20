using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Task_Management_System.Exceptions;

namespace Task_Management_System.CustomExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

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
            catch (CustomException ex)
            {
                _logger.LogError($"{ex.ErrorMessage}: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await HandleExceptionAsync(httpContext, new CustomException());
            }
        }

        private Task HandleExceptionAsync(HttpContext context, CustomException ex)
        {
            context.Response.ContentType = "aplication/json";
            context.Response.StatusCode = ex.StatusCode;

            return context.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.ErrorMessage
            }.ToString());
        }
    }
}
