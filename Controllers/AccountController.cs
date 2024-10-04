using Microsoft.AspNetCore.Mvc;
using Udemy.BankApp.Data.Context;
using Udemy.BankApp.Data.Entities;
using Udemy.BankApp.Models;

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
            var userInfo = _context.ApplicationUsers.Select(x=>new UserListModel()
            {
                Id = x.Id,
                Name = x.Name,
                SurName = x.SurName
            }).SingleOrDefault(x => x.Id == id);
            return View(userInfo);
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel model)
        {
            _context.Accounts.Add(new Account()
            {
                AccountNumber = model.AccountNumber,
                ApplicationUserId = model.ApplicationUserId,
                Balance = model.Balance,
            });
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
