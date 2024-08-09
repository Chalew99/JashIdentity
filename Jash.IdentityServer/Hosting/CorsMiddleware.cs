


using Jash.IdentityServer.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

#pragma warning disable 1591

namespace Jash.IdentityServer.Hosting;

public static class CorsMiddlewareExtensions
{
    public static void ConfigureCors(this IApplicationBuilder app)
    {
        var options = app.ApplicationServices.GetRequiredService<IdentityServerOptions>();
        app.UseCors(options.Cors.CorsPolicyName);
    }
}