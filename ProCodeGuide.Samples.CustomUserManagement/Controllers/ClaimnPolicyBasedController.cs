using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ClaimRoleandPolicyBasedAuthorizationDemo.Policy;

namespace ClaimRoleandPolicyBasedAuthorizationDemo.Controllers
{
    public class ClaimnPolicyBasedController : Controller
    {
        [Authorize(Policy = "IsAdminClaimAccess")]
        public IActionResult TestMethod1()
        {
            ViewData["role"] = ", you have met IsAdminClaimAccess authorization policy";
            return View("AuthorizationSuccessPage");
        }
        
        [Authorize(Policy = "IsAdminClaimAccess")]
        [Authorize(Policy = "NonAdminAccess")]
        public IActionResult TestMethod2()
        {
            ViewData["role"] = ", you have met 'IsAdminClaimAccess' and 'NonAdminAccess' authorization policies";
            return View("AuthorizationSuccessPage");
        }

        [Authorize(Policy = "RoleBasedClaim")]
        public IActionResult TestMethod3()
        {
            ViewData["role"] = ", you have met 'RoleBasedClaims' authorization policy implemented via policy";
            return View("AuthorizationSuccessPage");
        }
        
        [Authorize(Policy = "Morethan365DaysClaim")]
        public IActionResult TestMethod4()
        {
            ViewData["role"] = ", you have met 'Morethan365DaysClaim' authorization policy";
            return View("AuthorizationSuccessPage");
        }

        [Authorize(Policy = "AccessPageTestMethod5")]
        public IActionResult TestMethod5()
        {
            ViewData["role"] = ", you have met 'AccessPageTestMethod5' authorization policy, ";
            return View("AuthorizationSuccessPage");
        }

        [Authorize(Policy = "AccessPageTestMethod6")]
        public IActionResult TestMethod6()
        {
             ViewData["role"] = ", you have met 'AccessPageTestMethod6' authorization policy, ";
             return View("AuthorizationSuccessPage");
        }

        [MinimumTimeSpendAuthorize(180)]
        public IActionResult TestMethod7()
        {
             ViewData["role"] = ", you have met 'MinimumTimeSpendAuthorize(180)' authorization policy, which is implemented by runtime configuration policy ";
             return View("AuthorizationSuccessPage");
        }

        [MinimumTimeSpendAuthorize(365)]
        public IActionResult TestMethod8()
        {
             ViewData["role"] = ", you have met 'MinimumTimeSpendAuthorize(365)' authorization policy, which is implemented by runtime configuration policy ";
             return View("AuthorizationSuccessPage");
        }

        [MinimumTimeSpendAuthorize(10)]
        public IActionResult TestMethod9()
        {
             ViewData["role"] = ", you have met 'MinimumTimeSpendAuthorize(10)' authorization policy, which is implemented by runtime configuration policy ";
             return View("AuthorizationSuccessPage");
        }
    }
}