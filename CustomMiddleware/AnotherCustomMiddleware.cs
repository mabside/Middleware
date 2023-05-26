namespace  Middleware.CustomMiddleware
{
    public class AnotherCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public AnotherCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("AnotherCustomMiddleware called!\n\n");
            await _next.Invoke(httpContext);
            await httpContext.Response.WriteAsync("AnotherCustomMiddleware finished!\n\n");
        }
    }

    public static class AnotherCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseAnotherCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AnotherCustomMiddleware>();
        }
    }
}