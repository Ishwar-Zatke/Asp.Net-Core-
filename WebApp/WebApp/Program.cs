using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    WebRootPath = "myroot"
});
var app = builder.Build();

app.UseStaticFiles();//works with the webRootPath assigned
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "mywebroot")
    )
});

//Dictionary of countries to print the names
Dictionary<int,string> countries = new Dictionary<int, string>()
{
    {1,"United States" },
    {2,"Canada" },
    {3,"United Kingdom" },
    {4,"India" },
    {5,"Japan" },
};

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/countries", async context =>
    {
        foreach (KeyValuePair<int, string> cnt in countries)
        {
            await context.Response.WriteAsync($"{cnt.Key},{cnt.Value}");
        }
    });

    endpoints.MapGet("/countries/{countryID:int:range(1,100)", async context =>
    {
        if (context.Request.RouteValues.ContainsKey("countryID") == false)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("The CountryID should be between 1 and 100");
        }
        int countryID = Convert.ToInt32(context.Request.RouteValues["countryID"]);
        if (countries.ContainsKey(countryID))
        {
            string countryName = countries[countryID];
            await context.Response.WriteAsync($"{countryName}");
        }
        else
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync($"[No country]");
        }
    });

    endpoints.MapGet("/countries/{countryID:min(101)}", async context =>
    {
    context.Response.StatusCode = 400;
    await context.Response.WriteAsync("The CountryID should be between 1 and 100 - min");
    });
});
app.Run();
