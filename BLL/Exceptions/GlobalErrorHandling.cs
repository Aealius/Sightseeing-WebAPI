using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class GlobalErrorHandling
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandling(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            var stackTrace = String.Empty;
            string message;
            var exceptionType = exception.GetType();
            switch (exceptionType.GetType().ToString())
            {
                case "InvalidRequestException":
                    message = exception.Message;
                    status = HttpStatusCode.BadRequest;
                    stackTrace = exception.StackTrace;
                    break;
                case "NotFoundException":
                    message = exception.Message;
                    status = HttpStatusCode.NotFound;
                    stackTrace = exception.StackTrace;
                    break;
                case "NotImplementedException":
                    status = HttpStatusCode.NotImplemented;
                    message = exception.Message;
                    stackTrace = exception.StackTrace;
                    break;
                case "UnauthorizedAccessException":
                    status = HttpStatusCode.Unauthorized;
                    message = exception.Message;
                    stackTrace = exception.StackTrace;
                    break;
                case "KeyNotFoundException":
                    status = HttpStatusCode.Unauthorized;
                    message = exception.Message;
                    stackTrace = exception.StackTrace;
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    message = exception.Message;
                    stackTrace = exception.StackTrace;
                    break;
            }
            var exceptionResult = JsonSerializer.Serialize(new
            {
                error = message, stackTrace
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(exceptionResult);
        }
    }
}
