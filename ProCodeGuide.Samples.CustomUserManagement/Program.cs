
//https://procodeguide.com/asp-net-core/user-management-in-aspnet-core/
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ClaimRoleandPolicyBasedAuthorizationDemo.Areas.Identity.Data;
using ClaimRoleandPolicyBasedAuthorizationDemo.Data;
using ClaimRoleandPolicyBasedAuthorizationDemo.InitializeTestDB;
using ClaimRoleandPolicyBasedAuthorizationDemo.Policy;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationContextConnection' not found.");

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();
builder.Services.AddTransient<IAuthorizationPolicyProvider, MinimumTimeSpendPolicy>();
builder.Services.AddSingleton<IAuthorizationHandler, MinimumTimeSpendHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, RoleCheckerHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, TimeSpendHandler>();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization(options =>
{
    AuthorizationPolicies.AddCustomAuthorizationPolicies(options);
});

builder.Services.AddRazorPages();

var app = builder.Build();

Config.CreateUserAndClaim(app).Wait();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
