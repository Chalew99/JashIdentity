//Reference https://github.com/jignesht24/Aspnetcore/tree/master


using Microsoft.AspNetCore.Authorization;


namespace ClaimRoleandPolicyBasedAuthorizationDemo.Policy
{
    public static class AuthorizationPolicies
    {
        public static void AddCustomAuthorizationPolicies(this AuthorizationOptions options)
        {
            options.AddPolicy("IsAdminClaimAccess", policy => policy.RequireClaim("DateOfJoing"));
            //You can implement the below one by directly adding the attribut[Authorize(Roles = "Administration")] to the action/controller
            options.AddPolicy("IsAdminClaimAccess", policy => policy.RequireClaim("IsAdmin", "true"));
            options.AddPolicy("NonAdminAccess", policy => policy.RequireClaim("IsAdmin", "false"));
            options.AddPolicy("RoleBasedClaim", policy => policy.RequireClaim("ManagerPermissions", "true"));
            options.AddPolicy("Morethan365DaysClaim", policy => policy.Requirements.Add(new MinimumTimeSpendRequirement(365)));
            options.AddPolicy("AccessPageTestMethod5", policy => policy.Requirements.Add(new PageAccessRequirement()));
            options.AddPolicy("AccessPageTestMethod6", policy => policy.RequireAssertion(context =>
            {
                var isHRClaim = context.User.FindFirst(c => c.Type == "IsHR");
                var dateOfJoiningClaim = context.User.FindFirst(c => c.Type == "DateOfJoining");

                bool isHR = isHRClaim != null && Convert.ToBoolean(isHRClaim.Value);
                bool hasJoinedFor365Days = dateOfJoiningClaim != null &&
                                           (DateTime.Now.Date - Convert.ToDateTime(dateOfJoiningClaim.Value).Date).TotalDays >= 365;

                return isHR || hasJoinedFor365Days;
            }));
        }
    }
}
