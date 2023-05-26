namespace Middleware.CustomMiddleware;

class MyMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("Custom Middleware started!!\n\n");
        await next(context);
        await context.Response.WriteAsync("Custom Middleware finished!!\n\n");
        //After logic
    }
}

public static class CustomMiddlewareExtension 
{
    public static IApplicationBuilder MyMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<MyMiddleware>();
    }
}
