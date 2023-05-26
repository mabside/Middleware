using Middleware.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

//Register the custom middleware
builder.Services.AddTransient<MyMiddleware>();

var app = builder.Build();

//Middleware1
app.Use( async (HttpContext context, RequestDelegate next) =>
{
  await context.Response.WriteAsync("Middleware 1 called!");
  await next(context);
});

//Middleware2
app.Use( async (HttpContext context, RequestDelegate next) =>
{
  await context.Response.WriteAsync("\n\n");
  await next(context);
});

//Middleware 3 - Using custom middleware class
// app.UseMiddleware<MyMiddleware>();
// app.MyMiddleware(); // uses the extension method
app.UseAnotherCustomMiddleware();

//Middleware 4
app.Run( async (HttpContext context) =>
{
  await context.Response.WriteAsync("Middleware 4 called!\n\n");
});

app.Run();
