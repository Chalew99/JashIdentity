using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;


namespace PolicyBasedAuthorization.Security

{
class MinimumAgeAuthorizeAttribute : AuthorizeAttribute, IAuthorizationRequirement,
                                     IAuthorizationRequirementData
{
    public MinimumAgeAuthorizeAttribute(int age) => Age = age;
    public int Age { get; }

    public IEnumerable<IAuthorizationRequirement> GetRequirements()
    {
        yield return this;
    }
}

}
