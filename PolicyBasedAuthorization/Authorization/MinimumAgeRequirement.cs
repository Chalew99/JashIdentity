using Microsoft.AspNetCore.Authorization;

namespace PolicyBasedAuthorization.Security
{
class MinimumAgeRequirement : IAuthorizationRequirement
{
    public int Age { get; private set; }

    public MinimumAgeRequirement(int age) { Age = age; }
}
}