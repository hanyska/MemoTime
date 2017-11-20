using System;
using System.Net;
using System.Threading.Tasks;
using MemoTime.Core.Domain;
using MemoTime.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MemoTime.Api.Framework
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(e, context);
            }
        }

        private static Task HandleExceptionAsync(Exception exception, HttpContext context)
        {
            var errorCode = "error";
            var exceptionType = exception.GetType();
            var statusCode = HttpStatusCode.BadRequest;

            switch (exception)
            {
                case Exception e when exceptionType == typeof(UnauthorizedAccessException):
                    statusCode = HttpStatusCode.Unauthorized;
                    break;
                    
                case ServiceException e :
                    errorCode = e.Code;
                    break;
                    
                case DomainException e:
                    break;
            }

            var response = new { code = errorCode, message = exception.Message, stack = exception.StackTrace};
            var payload = JsonConvert.SerializeObject(response);
            
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) statusCode;
            
            return context.Response.WriteAsync(payload);

        }
        
    }
}