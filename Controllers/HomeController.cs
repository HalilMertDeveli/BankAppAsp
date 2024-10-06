using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Udemy.BankApp.Data.Context;
using Udemy.BankApp.Data.Interfacesses;
using Udemy.BankApp.Data.Repositories;
using Udemy.BankApp.Mapping;
using Udemy.BankApp.Models;

namespace Udemy.BankApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IUserMapper _userMapper;

        public HomeController(ILogger<HomeController> logger, IApplicationUserRepository applicationUserRepository,IUserMapper userMapper)
        {
            _logger = logger;
            _applicationUserRepository = applicationUserRepository;
            _userMapper = userMapper;
        }

        public IActionResult Index()
        {
            return View(_userMapper.MapToListOfUserList(_applicationUserRepository.GetAll()));
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
