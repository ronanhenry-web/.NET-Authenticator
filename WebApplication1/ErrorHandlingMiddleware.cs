using Microsoft.Extensions.Localization;
using System.Net;
using System.Text.Json;

namespace WebApplication1
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IStringLocalizer<ErrorHandlingMiddleware> _localizer;

        public ErrorHandlingMiddleware(RequestDelegate next, IStringLocalizer<ErrorHandlingMiddleware> localizer)
        {
            _next = next;
            _localizer = localizer;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var problemDetails = new
                {
                    type = "https://tools.ietf.org/html/rfc7807",
                    title = _localizer["InternalServerError"],
                    status = (int)HttpStatusCode.InternalServerError,
                    detail = _localizer.GetString(ex.Message) ?? ex.Message,
                    instance = context.Request.Path
                };

                context.Response.ContentType = "application/problem+json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var json = JsonSerializer.Serialize(problemDetails);
                await context.Response.WriteAsync(json);
            }
        }

    }
}
