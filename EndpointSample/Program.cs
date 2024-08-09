using ConfigurationDebugViewEndpoint.Extensions;

#pragma warning disable ASP0014
#pragma warning disable CS8604 // Possible null reference argument.


var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapConfigurationDebugView();
});

app.Run();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGet("/config", async context =>
//    {
//        var config = (Configuration as IConfigurationRoot).GetDebugView();
//        await context.Response.WriteAsync(config);
//    });
//});




