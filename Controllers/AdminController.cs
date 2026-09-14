using Microsoft.AspNetCore.Mvc;

namespace CyberTrace.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            var username =
                HttpContext.Session.GetString("Username");

            var role =
                HttpContext.Session.GetString("Role");

            if (string.IsNullOrWhiteSpace(username))
            {
                return RedirectToAction("Login", "Account");
            }

            if (!string.Equals(
                    role,
                    "Admin",
                    StringComparison.OrdinalIgnoreCase))
            {
                return View("AccessDenied");
            }

            return View();
        }
    }
}