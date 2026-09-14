using CyberTrace.Data;
using Microsoft.AspNetCore.Mvc;

namespace CyberTrace.Controllers
{
    public class SqlInjectionController : Controller
    {
        private readonly CyberTraceDbContext _context;

        public SqlInjectionController(CyberTraceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(string username)
        {
            var users = new List<CyberTrace.Models.SqlUser>();

            if (!string.IsNullOrWhiteSpace(username))
            {
                users = _context.SqlUsers
                    .Where(u => u.Username == username)
                    .ToList();
            }

            return View(users);
        }
    }
}