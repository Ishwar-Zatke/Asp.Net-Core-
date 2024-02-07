using System;
using Routing.CustomConstraint;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(options => { options.ConstraintMap.Add("months", typeof(MonthsCustomConstraint)); });
var app = builder.Build();
app.UseRouting();

//Get Point endpoint
app.UseEndpoints(endpoints =>
{
    _ = endpoints.Map("files/{filename}.{extension}", async (context) =>
    {
        // await context.Response.WriteAsync("In files");
        string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync($"In files - {fileName} - {extension}");
    });

    //Using Default Value 
    _ = endpoints.Map("employee/profile/{EmployeeName=Ishwar}",
        async (context) =>
        {
            string? employeeName = Convert.ToString(context.Request.RouteValues["employeename"]);
            await context.Response.WriteAsync($"In Employee - {employeeName}");
        });

    //Using Optional Parameters - if-else loopings
    _ = endpoints.Map("products/details/{id?}", async (context) =>
    {
        if (context.Request.RouteValues.ContainsKey("id"))
        {
            int id = Convert.ToInt32(context.Request.RouteValues["id"]);
            await context.Response.WriteAsync($"Product details - {id}");
        }
        else
        {
            await context.Response.WriteAsync($"Product details - id is not supplied");
        }
    });

    //Using COnstraint on route - {int,datetime,decimal,long,guid-globalUniqueIdentifier}
    _ = endpoints.Map("products/details/{id:int}", async (context) =>
    {
        if (context.Request.RouteValues.ContainsKey("id"))
        {
            int id = Convert.ToInt32(context.Request.RouteValues["id"]);
            await context.Response.WriteAsync($"Product details - {id}");
        }
        else
        {
            await context.Response.WriteAsync($"Product details - id is not supplied");
        }
    });

    //Using Guid
    _ = endpoints.Map("cities/{cityid:guid}", async context =>
    {
        Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"]));
        await context.Response.WriteAsync($"City Info - {cityId}");
    });

    //Using regex expression
    _ = endpoints.Map("sales-report/{year:int:min(1900)}/{month:months}", async context =>
    {

        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);

        if (month == "apr" || month == "jul" || month == "oct" || month == "jan")
        {
            await context.Response.WriteAsync($"sales report - {year} - {month}");
        }
        else
        {
            await context.Response.WriteAsync($"{month} is not allowed for sales report");
        }
    });
});
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});


app.Run();
