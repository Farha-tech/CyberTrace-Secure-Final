using Microsoft.AspNetCore.Mvc;

namespace CyberTrace.Controllers
{
    public class DictionaryAttackController : Controller
    {
        private const string CorrectUsername = "admin";
        private const string CorrectPassword = "cyber123";

        private static int failedAttempts = 0;
        private static DateTime blockedUntil = DateTime.MinValue;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            if (DateTime.Now < blockedUntil)
            {
                var remainingSeconds =
                    (int)(blockedUntil - DateTime.Now).TotalSeconds + 1;

                ViewBag.Error =
                    $"Too many attempts. Try again in {remainingSeconds} seconds.";

                return View();
            }

            if (username == CorrectUsername &&
                password == CorrectPassword)
            {
                failedAttempts = 0;

                ViewBag.Success =
                    "Login successful.";

                ViewBag.Username = username;

                return View();
            }

            failedAttempts++;

            ViewBag.Error =
                "Invalid username or password.";

            ViewBag.Username = username;

            if (failedAttempts >= 3)
            {
                blockedUntil =
                    DateTime.Now.AddSeconds(30);

                failedAttempts = 0;

                ViewBag.Error =
                    "Dictionary attack blocked. Too many authentication attempts.";
            }

            return View();
        }
    }
}