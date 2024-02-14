var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

//Setup necessary files for controllers and ROuting
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
