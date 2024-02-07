using WebappforController.Controllers;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddTransient<HomeController>();
builder.Services.AddControllers();
var app = builder.Build();

//ENable the routing
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
