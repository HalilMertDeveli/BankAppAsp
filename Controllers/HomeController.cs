using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Udemy.BankApp.Data.Context;
using Udemy.BankApp.Data.Entities;
using Udemy.BankApp.Data.Interfacesses;
using Udemy.BankApp.Data.Repositories;
using Udemy.BankApp.Data.UnitOfWork;
using Udemy.BankApp.Mapping;
using Udemy.BankApp.Models;

namespace Udemy.BankApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserMapper _userMapper;
        private readonly IUow _uow;


        public HomeController(ILogger<HomeController> logger, IUserMapper userMapper, IUow uow)
        {
            _logger = logger;
            _userMapper = userMapper;
            _uow = uow;
        }

        public IActionResult Index()
        {
            return View(_userMapper.MapToListOfUserList(_uow.GetRepository<ApplicationUser>().GetAll()));
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
