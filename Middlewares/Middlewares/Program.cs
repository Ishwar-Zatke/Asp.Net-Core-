//namespace to acess the custom middleware files 
using Middlewares.CustomMiddlewares;
var builder = WebApplication.CreateBuilder(args);
//Added as service
builder.Services.AddTransient<CustomMiddleware>();
var app = builder.Build();

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hey");
    await next(context);
});

//Added the custom middleware class
//app.UseMiddleware<CustomMiddleware>();
app.UseCustomMiddleware();

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Done");
    await next(context);
});

app.UseRouting();

app.UseEndpoints(endpoints => {
    endpoints.Map("map", async (context) =>
    {
        await context.Response.WriteAsync("Inside Map");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync($"Received at {context.Request.Path}");
});
app.Run();
