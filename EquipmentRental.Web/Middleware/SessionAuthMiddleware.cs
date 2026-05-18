using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace EquipmentRental.Web.Middleware
{
    public class SessionAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path;

            // Skip authentication for the following paths
            bool isPublicPath = path.StartsWithSegments("/Account/Login") ||
                                path.StartsWithSegments("/Account/Register") ||
                                path.StartsWithSegments("/Home/Index") ||
                                path.StartsWithSegments("/Home/Privacy") ||
                                path.Value?.StartsWith("/css/") == true ||
                                path.Value?.StartsWith("/js/") == true ||
                                path.Value?.StartsWith("/lib/") == true ||
                                path.Value?.StartsWith("/img/") == true;

            if (!isPublicPath && context.Session.GetInt32("UserId") == null)
            {
                context.Response.Redirect("/Account/Login");
                return;
            }

            await _next(context);
        }
    }

    // Extension method to make it easier to add the middleware to the pipeline
    public static class SessionAuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseSessionAuth(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SessionAuthMiddleware>();
        }
    }
}