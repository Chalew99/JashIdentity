


using Jash.IdentityServer.Models;
using System.Diagnostics;

namespace Jash.IdentityServer.Extensions;

/// <summary>
/// Extensions for ServerSideSession
/// </summary>
internal static class ServerSideSessionExtensions
{
    /// <summary>
    /// Clones the instance
    /// </summary>
    [DebuggerStepThrough]
    internal static ServerSideSession Clone(this ServerSideSession other)
    {
        var item = new ServerSideSession()
        {
            Key = other.Key,
            Scheme = other.Scheme,
            SubjectId = other.SubjectId,
            SessionId = other.SessionId,
            DisplayName = other.DisplayName,
            Created = other.Created,
            Renewed = other.Renewed,
            Expires = other.Expires,
            Ticket = other.Ticket,
        };
        return item;
    }
}