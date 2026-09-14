using Microsoft.AspNetCore.Mvc;
using CyberTrace.Models;

namespace CyberTrace.Controllers
{
    public class ScanController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string targetUrl)
        {
            var result = new ScanResult
            {
                Id = 1,
                TargetUrl = targetUrl,
                ScanDate = DateTime.Now,
                IsSafe = false,
                Vulnerabilities = new List<Vulnerability>
                {
                    new Vulnerability
                    {
                        Id = 1,
                        Name = "SQL Injection",
                        Category = "Injection",
                        Severity = "High",
                        Description = "SQL Injection occurs when untrusted user input is directly included in a database query.",
                        AttackScenario = "An attacker may manipulate input parameters to modify the intended SQL query and access unauthorized data.",
                        Recommendation = "Use parameterized queries, prepared statements, and proper input validation.",
                        IsFixed = false
                    },

                    new Vulnerability
                    {
                        Id = 2,
                        Name = "Cross-Site Scripting (XSS)",
                        Category = "Injection",
                        Severity = "Medium",
                        Description = "XSS occurs when untrusted input is rendered in a web page without proper encoding.",
                        AttackScenario = "An attacker may inject malicious JavaScript into a vulnerable page and execute it in another user's browser.",
                        Recommendation = "Validate input and properly encode output before rendering user-controlled data.",
                        IsFixed = false
                    },

                    new Vulnerability
                    {
                        Id = 3,
                        Name = "Cross-Site Request Forgery (CSRF)",
                        Category = "Broken Access Control",
                        Severity = "High",
                        Description = "CSRF allows an attacker to force an authenticated user to perform an unwanted action.",
                        AttackScenario = "An attacker may create a malicious page that sends a forged request to a vulnerable application.",
                        Recommendation = "Use anti-forgery tokens and validate requests on the server side.",
                        IsFixed = true
                    },

                    new Vulnerability
                    {
                        Id = 4,
                        Name = "IDOR",
                        Category = "Broken Access Control",
                        Severity = "High",
                        Description = "IDOR occurs when an application allows users to access objects belonging to other users without proper authorization checks.",
                        AttackScenario = "An attacker may change an object identifier in the URL and attempt to access another user's profile.",
                        Recommendation = "Verify that the requested object belongs to the currently authenticated user before returning it.",
                        IsFixed = true
                    },

                    new Vulnerability
                    {
                        Id = 5,
                        Name = "Broken Admin Access Control",
                        Category = "Broken Access Control",
                        Severity = "High",
                        Description = "Broken access control occurs when users can access administrative functionality without the required privileges.",
                        AttackScenario = "A normal user may attempt to directly access an administrative URL.",
                        Recommendation = "Verify the user's role and authorization before allowing access to administrative resources.",
                        IsFixed = true
                    }
                }
            };

            return View("Result", result);
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}