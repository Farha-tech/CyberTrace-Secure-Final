using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;

namespace CyberTrace.Controllers
{
    public class HttpSecurityController : Controller
    {
        private const string CorrectUsername = "admin";
        private const string CorrectPassword = "admin123";

        [HttpGet]
        public IActionResult Index()
        {
            AddSecurityHeaders();

            return View();
        }

        private void AddSecurityHeaders()
        {
            Response.Headers.Remove("X-Powered-By");
            Response.Headers.Remove("X-Debug-Mode");
            Response.Headers.Remove("X-Application-Environment");

            Response.Headers["X-Content-Type-Options"] =
                "nosniff";

            Response.Headers["X-Frame-Options"] =
                "DENY";

            Response.Headers["Referrer-Policy"] =
                "strict-origin-when-cross-origin";

            Response.Headers["Permissions-Policy"] =
                "geolocation=(), microphone=(), camera=()";

            Response.Headers["Content-Security-Policy"] =
                "default-src 'self'; object-src 'none'; frame-ancestors 'none'; base-uri 'self'";
        }
    }
}