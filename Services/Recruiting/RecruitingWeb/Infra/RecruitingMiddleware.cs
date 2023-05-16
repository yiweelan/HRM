using RecruitingWeb.Infra;
using Serilog;

namespace RecruitingWeb.Infra
{
    public class RecruitingMiddleware
    {
        private readonly RequestDelegate _next;
        public RecruitingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var log = new LoggerConfiguration();


            var requestMethod = context.Request.Method;
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                
            }
            
        }


    }
}

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseRecruitingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RecruitingMiddleware>();
    }
}
