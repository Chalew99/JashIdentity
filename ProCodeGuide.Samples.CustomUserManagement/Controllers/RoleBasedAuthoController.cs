using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ClaimRoleandPolicyBasedAuthorizationDemo.Policy;


namespace ClaimRoleandPolicyBasedAuthorizationDemo.Controllers
{
    namespace RolebaseAuthorization.Controllers
    {
        public class RoleAuthorizationController : Controller
        {
            [Authorize(Roles = "Admin")]
            public IActionResult OnlyAdminAccess()
            {
                ViewData["role"] = "Admin";
                return View("AuthorizationSuccessPage");
            }
            [Authorize(Roles = "User")]
            public IActionResult OnlyUserAccess()
            {
                ViewData["role"] = "User";
                return View("AuthorizationSuccessPage");
            }
            [Authorize(Roles = "HR")]
            public IActionResult OnlyHRAccess()
            {
                ViewData["role"] = "HR";
                return View("AuthorizationSuccessPage");
            }
        }
    }
}
