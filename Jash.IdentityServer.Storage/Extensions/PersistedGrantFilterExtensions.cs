 
 


using System;
using Jash.IdentityServer.Stores;

namespace Jash.IdentityServer.Extensions;

/// <summary>
/// Extensions for PersistedGrantFilter.
/// </summary>
public static class PersistedGrantFilterExtensions
{
    /// <summary>
    /// Validates the PersistedGrantFilter and throws if invalid.
    /// </summary>
    /// <param name="filter"></param>
    public static void Validate(this PersistedGrantFilter filter)
    {
        if (filter == null) throw new ArgumentNullException(nameof(filter));

        if (String.IsNullOrWhiteSpace(filter.ClientId) && 
            filter.ClientIds == null &&
            String.IsNullOrWhiteSpace(filter.SessionId) &&
            String.IsNullOrWhiteSpace(filter.SubjectId) &&
            String.IsNullOrWhiteSpace(filter.Type) && 
            filter.Types == null)
        {
            throw new ArgumentException("No filter values set.", nameof(filter));
        }
    }
}