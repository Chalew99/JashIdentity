


using Microsoft.AspNetCore.Authentication;
using System;

namespace Jash.IdentityServer;

class LegacyClock : IClock
{
#pragma warning disable CS0618 // Type or member is obsolete
    private readonly ISystemClock _clock;
#pragma warning restore CS0618 // Type or member is obsolete

#pragma warning disable CS0618 // Type or member is obsolete
    public LegacyClock(ISystemClock clock)
#pragma warning restore CS0618 // Type or member is obsolete
    {
        _clock = clock;
    }

    public DateTimeOffset UtcNow
    {
        get => _clock.UtcNow;
    }
}
