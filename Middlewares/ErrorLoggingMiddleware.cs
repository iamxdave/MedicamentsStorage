using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace cw_8_ko_xDejw.Middlewares
{
    public class ErrorLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string logfile = "log.txt";

        public ErrorLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            } catch (Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Unexpected problem occured");
                
                await File.AppendAllTextAsync(logfile, e.InnerException.ToString() + '\n');
            }
        }
    }
}