using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.Add(new ServiceDescriptor(
    typeof(ICitiesService),
    typeof(CitiesService),
    ServiceLifetime.Scoped
));

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.MapControllers();

app.Run();
