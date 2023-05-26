var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Middleware1
app.Use( async (HttpContext context, RequestDelegate next) =>
{
  await context.Response.WriteAsync("Welcome from ASP.NET Core App!");
  await next(context);
});

//Middleware2
app.Use( async (HttpContext context, RequestDelegate next) =>
{
  await context.Response.WriteAsync("\n\n");
  await next(context);
});

//Middleware3
app.Run( async (HttpContext context) =>
{
  await context.Response.WriteAsync("This is my first ASP.NET Core App!");
});

app.Run();
