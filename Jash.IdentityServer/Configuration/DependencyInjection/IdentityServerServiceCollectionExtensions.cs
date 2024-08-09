#nullable enable
using Jash.IdentityServer.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IdentityServerServiceCollectionExtensions
    {
        public static IIdentityServerBuilder AddIdentityServerBuilder(this IServiceCollection services)
        {
            return new IdentityServerBuilder(services);
        }

        public static IIdentityServerBuilder AddIdentityServer(this IServiceCollection services)
        {
            var builder = services.AddIdentityServerBuilder();

            builder.AddRequiredPlatformServices()
                    .AddCookieAuthentication()
                    .AddCoreServices()
                    .AddDefaultEndpoints()
                    .AddPluggableServices()
                    .AddKeyManagement()
                    .AddDynamicProvidersCore()
                    .AddOidcDynamicProvider()
                    .AddValidators()
                    .AddResponseGenerators()
                    .AddDefaultSecretParsers()
                    .AddDefaultSecretValidators()
                    ;

            // provide default in-memory implementations, not suitable for most production scenarios
            builder.AddInMemoryPersistedGrants();
            builder.AddInMemoryPushedAuthorizationRequests();
            return builder;
        }
    }

}
