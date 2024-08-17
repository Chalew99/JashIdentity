using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using ClaimBasedPolicyBasedAuthorization.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
//using ClaimBasedPolicyBasedAuthorization.Policy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Hosting;
using ProCodeGuide.Samples.CustomUserManagement.Areas.Identity.Data;



namespace ProCodeGuide.Samples.CustomUserManagement.InitializeTestDB
{     
      public static class Config
{
        public static async Task CreateUserAndClaim(IApplicationBuilder app) //(IServiceProvider serviceProvider)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                if (serviceScope == null)
                {
                    throw new InvalidOperationException("IServiceScopeFactory is not available.");
                }

            var UserManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var RoleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //Added Roles
            var roleResult = await RoleManager.FindByNameAsync("Administrator");
            if (roleResult == null)
            {
                roleResult = new IdentityRole("Administrator");
                await RoleManager.CreateAsync(roleResult);
            }

            var roleClaimList = (await RoleManager.GetClaimsAsync(roleResult)).Select(p => p.Type);
            if (!roleClaimList.Contains("ManagerPermissions"))
            {
                await RoleManager.AddClaimAsync(roleResult, new Claim("ManagerPermissions", "true"));
            }

                ApplicationUser user = await UserManager.FindByEmailAsync("Chalew.mehammed@gmail.com");

            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = "Chalew",
                    Email = "Chalew.mehammed@gmail.com",
                };
                await UserManager.CreateAsync(user, "Jash@1984Gregorian");
            }

            await UserManager.AddToRoleAsync(user, "Administrator");

            var claimList = (await UserManager.GetClaimsAsync(user)).Select(p => p.Type);
            if (!claimList.Contains("DateOfJoining"))
            {
                await UserManager.AddClaimAsync(user, new Claim("DateOfJoining", "09/25/1984"));
            }
            if (!claimList.Contains("IsAdmin"))
            {
                await UserManager.AddClaimAsync(user, new Claim("IsAdmin", "true"));
            }

                ApplicationUser user2 = await UserManager.FindByEmailAsync("opopsopop@gmail.com");

            if (user2 == null)
            {
                user2 = new ApplicationUser()
                {
                    UserName = "FuturePast",
                    Email = "opopsopop@gmail.com",
                };
                await UserManager.CreateAsync(user2, "Love1fuckanother@99");
            }
            var claimList1 = (await UserManager.GetClaimsAsync(user2)).Select(p => p.Type);
            if (!claimList1.Contains("IsAdmin"))
            {
                await UserManager.AddClaimAsync(user2, new Claim("IsAdmin", "false"));
            }
            if (!claimList1.Contains("DateOfJoining"))
            {
                await UserManager.AddClaimAsync(user2, new Claim("DateOfJoining", "09/01/2018"));
            }
            if (!claimList1.Contains("IsHR"))
            {
                await UserManager.AddClaimAsync(user2, new Claim("IsHR", "true"));
            }
        }
    }
}
}