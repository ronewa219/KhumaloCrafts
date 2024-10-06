using KhumaloCrafts.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace KhumaloCrafts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Constructor with dependency injection for the ILogger
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Action method to return the Index view
        public IActionResult Index()
        {
            return View();
        }

        // Action method to return the Privacy view
        public IActionResult Privacy()
        {
            return View();
        }

        // Action method to return an error view with a specific error message
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Log the error
            _logger.LogError("An error occurred.");

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
