﻿//using System;
//using System.Threading.Tasks;
//using ClaimRoleandPolicyBasedAuthorizationDemo.Policy;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.Extensions.Options;

//namespace ClaimRoleandPolicyBasedAuthorizationDemo.Policy
//{
//    public class MinimumTimeSpendPolicy : IAuthorizationPolicyProvider
//    {
//        public DefaultAuthorizationPolicyProvider defaultPolicyProvider { get; }
//        public MinimumTimeSpendPolicy(IOptions<AuthorizationOptions> options)
//        {
//            defaultPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
//        }
//        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
//        {
//            return defaultPolicyProvider.GetDefaultPolicyAsync();
//        }

//        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
//        {
//            string[] subStringPolicy = policyName.Split(new char[] { '.' });
//            if (subStringPolicy.Length > 1 && subStringPolicy[0].Equals("MinimumTimeSpend", StringComparison.OrdinalIgnoreCase) && int.TryParse(subStringPolicy[1], out var days))
//            {
//                var policy = new AuthorizationPolicyBuilder();
//                policy.AddRequirements(new MinimumTimeSpendRequirement(days));
//                return Task.FromResult(policy.Build());
//            }
//            return defaultPolicyProvider.GetPolicyAsync(policyName);
//        }
//    }
//}


using System;
using System.Threading.Tasks;
using ClaimRoleandPolicyBasedAuthorizationDemo.Policy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace ClaimRoleandPolicyBasedAuthorizationDemo.Policy
{
    public class MinimumTimeSpendPolicy : IAuthorizationPolicyProvider
    {
        public DefaultAuthorizationPolicyProvider defaultPolicyProvider { get; }
        public MinimumTimeSpendPolicy(IOptions<AuthorizationOptions> options)
        {
            defaultPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return defaultPolicyProvider.GetDefaultPolicyAsync();
        }

        public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            string[] subStringPolicy = policyName.Split(new char[] { '.' });
            if (subStringPolicy.Length > 1 && subStringPolicy[0].Equals("MinimumTimeSpend", StringComparison.OrdinalIgnoreCase) && int.TryParse(subStringPolicy[1], out var days))
            {
                var policy = new AuthorizationPolicyBuilder();
                policy.AddRequirements(new MinimumTimeSpendRequirement(days));
                return Task.FromResult<AuthorizationPolicy?>(policy.Build());
            }
            return defaultPolicyProvider.GetPolicyAsync(policyName);
        }

        public Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
        {
            return defaultPolicyProvider.GetFallbackPolicyAsync();
        }
    }
}

