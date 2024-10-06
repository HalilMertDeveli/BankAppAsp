using Microsoft.AspNetCore.Mvc;
using Udemy.BankApp.Data.Context;
using Udemy.BankApp.Data.Entities;
using Udemy.BankApp.Data.Interfacesses;
using Udemy.BankApp.Data.Repositories;
using Udemy.BankApp.Mapping;
using Udemy.BankApp.Models;

namespace Udemy.BankApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IUserMapper _userMapper;
        private readonly BankContext _context;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountMapper _accountMapper;
        public AccountController( IApplicationUserRepository applicationUserRepository, IUserMapper userMapper, IAccountRepository accountRepository, IAccountMapper accountMapper)
        {

            _applicationUserRepository = applicationUserRepository;
            _userMapper = userMapper;
            _accountRepository = accountRepository;
            _accountMapper = accountMapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int id)
        {
            var userInfo = _userMapper.MapToUserList(_applicationUserRepository.GetById(id));
            return View(userInfo);
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel model)
        {
            _accountRepository.Create(_accountMapper.Map(model));
            
            return RedirectToAction("Index", "Home");
        }
    }
}
