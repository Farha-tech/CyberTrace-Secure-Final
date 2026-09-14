using Microsoft.AspNetCore.Mvc;

namespace CyberTrace.Controllers
{
    public class FuzzingController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                ViewBag.Error = "Input cannot be empty.";
                return View();
            }

            const int maxLength = 50;

            if (input.Length > maxLength)
            {
                ViewBag.Error =
                    $"Input blocked. Maximum allowed length is {maxLength} characters.";

                return View();
            }

            if (input.Any(char.IsControl))
            {
                ViewBag.Error =
                    "Input blocked because it contains invalid control characters.";

                return View();
            }

            if (input.Contains(
                    "<script>",
                    StringComparison.OrdinalIgnoreCase))
            {
                ViewBag.Error =
                    "Input blocked because potentially dangerous script content was detected.";

                return View();
            }

            ViewBag.Input = input;
            ViewBag.Length = input.Length;

            ViewBag.Success =
                "Input accepted after security validation.";

            return View();
        }
    }
}