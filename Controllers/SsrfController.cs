using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CyberTrace.Controllers
{
    public class SsrfController : Controller
    {
        private readonly HttpClient _httpClient;

        public SsrfController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(5);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult InternalResource()
        {
            return Content(
                "CYBERTRACE INTERNAL RESOURCE\n" +
                "Secret Data: INTERNAL-SECRET-2026\n" +
                "This resource should not be accessible through SSRF."
            );
        }

        [HttpPost]
        public async Task<IActionResult> Index(string targetUrl)
        {
            if (string.IsNullOrWhiteSpace(targetUrl))
            {
                ViewBag.Error = "Please enter a URL.";
                return View();
            }

            if (!Uri.TryCreate(
                    targetUrl,
                    UriKind.Absolute,
                    out Uri? uri))
            {
                ViewBag.Error = "Invalid URL.";
                return View();
            }

            if (uri.Scheme != Uri.UriSchemeHttps)
            {
                ViewBag.Error = "Only HTTPS URLs are allowed.";
                return View();
            }

            if (IsPrivateOrLocalAddress(uri.Host))
            {
                ViewBag.Error =
                    "Access to private or local addresses is blocked.";

                return View();
            }

            try
            {
                var response = await _httpClient.GetAsync(uri);

                var content =
                    await response.Content.ReadAsStringAsync();

                ViewBag.TargetUrl = targetUrl;
                ViewBag.StatusCode = (int)response.StatusCode;
                ViewBag.Response = content;

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.TargetUrl = targetUrl;
                ViewBag.Error = ex.Message;

                return View();
            }
        }

        private bool IsPrivateOrLocalAddress(string host)
        {
            if (host.Equals(
                    "localhost",
                    StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (host.Equals(
                    "127.0.0.1",
                    StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (host.Equals(
                    "::1",
                    StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (IPAddress.TryParse(
                    host,
                    out IPAddress? ipAddress))
            {
                if (IPAddress.IsLoopback(ipAddress))
                {
                    return true;
                }

                if (ipAddress.AddressFamily ==
                    System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    byte[] bytes =
                        ipAddress.GetAddressBytes();

                    if (bytes[0] == 10)
                    {
                        return true;
                    }

                    if (bytes[0] == 172 &&
                        bytes[1] >= 16 &&
                        bytes[1] <= 31)
                    {
                        return true;
                    }

                    if (bytes[0] == 192 &&
                        bytes[1] == 168)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}