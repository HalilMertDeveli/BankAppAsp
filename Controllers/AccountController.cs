using Microsoft.AspNetCore.Mvc;
using Udemy.BankApp.Data.Context;

namespace Udemy.BankApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly BankContext _context;

        public AccountController(BankContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int id)
        {
            var userInfo = _context.ApplicationUsers.SingleOrDefault(x => x.Id == id);
            return View(userInfo);
        }
    }
}
