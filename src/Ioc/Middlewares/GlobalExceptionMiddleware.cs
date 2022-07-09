#region

using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Model.Exceptions;
using Newtonsoft.Json;

#endregion

namespace Ioc.Middlewares
{
    public class GlobalExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (CustomValidationException validationException)
            {
                await HandleCustomValidationException(context, validationException);
            }
            catch (Exception exception)
            {
                await HandleGenericException(context, exception);
            }
        }

        private static Task HandleCustomValidationException(HttpContext context,
            CustomValidationException validationException)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = HttpStatusCode.BadRequest.GetHashCode();

            validationException.TraceId = Activity.Current?.Id ?? context.TraceIdentifier;
            validationException.Status = context.Response.StatusCode;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(validationException.ToProblemDetails()));
        }

        private static Task HandleGenericException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = HttpStatusCode.InternalServerError.GetHashCode();

            var validationException = new CustomValidationException(exception.GetBaseException().Message,
                context.Response.StatusCode, Activity.Current?.Id ?? context.TraceIdentifier);

            return context.Response.WriteAsync(JsonConvert.SerializeObject(validationException.ToProblemDetails()));
        }
    }
}