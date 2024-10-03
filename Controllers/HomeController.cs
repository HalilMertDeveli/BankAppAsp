using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Udemy.BankApp.Data.Context;
using Udemy.BankApp.Models;

namespace Udemy.BankApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BankContext _context;

        public HomeController(ILogger<HomeController> logger,BankContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.ApplicationUsers.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
