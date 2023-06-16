using RecruitingWeb.Infra;
using Serilog;

namespace RecruitingWeb.Infra
{
    public class RecruitingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RecruitingMiddleware> _logger;
        public RecruitingMiddleware(RequestDelegate next, ILogger<RecruitingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            // var log = new LoggerConfiguration();
            // var requestMethod = context.Request.Method;
            try
            {
                await _next(context);
            }
            catch(Exception generalEx)
            {
                _logger.LogError(generalEx, "There is an Exception caught. Method: {method}. Path: {path}",
                    context.Request.Method, context.Request.Path);
                throw;
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
