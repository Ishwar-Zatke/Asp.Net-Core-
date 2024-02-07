using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Middlewares.CustomMiddlewares
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Custom Middleware-Start");
            await next(context);
            await context.Response.WriteAsync("Custom Middleware-End");
        }
    }
}

// Moved outside of CustomMiddleware for clarity and accessibility.
namespace Middlewares.CustomMiddlewares
{
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleware>();
        }
    }
}
