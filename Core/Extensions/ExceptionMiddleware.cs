using FluentValidation;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "Internal Server Error";
            var type = e.GetType();
            if (e.GetType() == typeof(ValidationException) || e.GetType() == typeof(FormatException))
            {
                message = e.Message;
            }
            else if (e.GetType() == typeof(UnauthorizedAccessException))
            {
                message = e.Message;
                httpContext.Response.StatusCode = 401;
            }
            else if (e.GetType() == typeof(UserAccountNotFountException))
            {
                message = "UserAccountNotFountException";
                httpContext.Response.StatusCode = 401;
            }
            else if (e.Message.Contains("RabbitMQ"))
            {
                message = "Kuyruk Erişim Problemi!";
                httpContext.Response.StatusCode = 404;
            }


            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                statusCode = httpContext.Response.StatusCode,
                message = message
            }.ToString());
        }
    }
}
