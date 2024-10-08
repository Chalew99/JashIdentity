﻿using Microsoft.AspNetCore.Authorization;

namespace ClaimRoleandPolicyBasedAuthorizationDemo.Policy
{
    public class MinimumTimeSpendAuthorize : AuthorizeAttribute
    {
        public MinimumTimeSpendAuthorize(int days)
        {
            NoOfDays = days;
        }

        int days;

        public int NoOfDays
        {
            get
            {
                return days;
            }
            set
            {
                days = value;
                Policy = $"{"MinimumTimeSpend"}.{value.ToString()}";
            }
        }
    }
}
