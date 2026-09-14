using Microsoft.AspNetCore.Mvc;

namespace CyberTrace.Controllers
{
    public class InformationDisclosureController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var safeInformation = new
            {
                Application = "CyberTrace",
                Status = "Operational",
                Message = "Sensitive system information is protected."
            };

            return Json(safeInformation);
        }
    }
}