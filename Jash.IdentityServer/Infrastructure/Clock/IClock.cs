


using System;

namespace Jash.IdentityServer;

/// <summary>
/// Abstraction for the date/time.
/// </summary>
public interface IClock
{
    /// <summary>
    /// The current UTC date/time.
    /// </summary>
    DateTimeOffset UtcNow { get; }
}
