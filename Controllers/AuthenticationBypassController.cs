using Microsoft.AspNetCore.Mvc;

namespace CyberTrace.Controllers
{
    public class AuthenticationBypassController : Controller
    {
        private const string CorrectUsername = "admin";
        private const string CorrectPassword = "admin123";

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            if (username != CorrectUsername ||
                password != CorrectPassword)
            {
                ViewBag.Error =
                    "Authentication failed. Valid credentials are required.";

                return View();
            }

            HttpContext.Session.SetString("Username", username);
            HttpContext.Session.SetString("Role", "Admin");

            ViewBag.Success =
                "Authentication successful. Admin access was granted after valid credential verification.";

            ViewBag.Role = "Admin";

            return View();
        }
    }
}