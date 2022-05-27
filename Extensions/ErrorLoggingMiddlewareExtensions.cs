using cw_8_ko_xDejw.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace cw_8_ko_xDejw.Extensions
{
    public static class ErrorLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorLoggingMiddleware>();
        }
    }
}