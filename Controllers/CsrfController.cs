using CyberTrace.Data;
using CyberTrace.Models;
using Microsoft.AspNetCore.Mvc;

namespace CyberTrace.Controllers
{
    public class CsrfController : Controller
    {
        private readonly CyberTraceDbContext _context;

        public CsrfController(CyberTraceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var user = _context.Users.FirstOrDefault(u => u.Id == userId.Value);

            if (user == null)
            {
                return NotFound();
            }

            var model = new EmailChangeModel
            {
                CurrentEmail = user.Email
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(EmailChangeModel model)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var user = _context.Users.FirstOrDefault(u => u.Id == userId.Value);

            if (user == null)
            {
                return NotFound();
            }

            user.Email = model.NewEmail;

            _context.SaveChanges();

            model.CurrentEmail = user.Email;

            ViewBag.Message =
                "Email changed successfully with CSRF protection.";

            return View(model);
        }
    }
}