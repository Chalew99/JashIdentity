


using Jash.IdentityServer.Models;
using Microsoft.AspNetCore.Authentication;
using System;

namespace Jash.IdentityServer.Hosting.DynamicProviders;

/// <summary>
/// Models a dynamic authentication scheme and it's corresponding IdentityProvider data.
/// </summary>
public class DynamicAuthenticationScheme : AuthenticationScheme
{
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="idp"></param>
    /// <param name="handlerType"></param>
    public DynamicAuthenticationScheme(IdentityProvider idp, Type handlerType)
        : base(idp.Scheme, idp.DisplayName, handlerType)
    {
        IdentityProvider = idp;
    }

    /// <summary>
    /// The corresponding IdentityProvider configuration data.
    /// </summary>
    public IdentityProvider IdentityProvider { get; set; }
}
