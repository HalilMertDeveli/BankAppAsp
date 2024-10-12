using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Udemy.BankApp.Data.Context;
using Udemy.BankApp.Data.Entities;
using Udemy.BankApp.Data.Interfaceses;
using Udemy.BankApp.Data.Interfacesses;
using Udemy.BankApp.Data.Repositories;
using Udemy.BankApp.Mapping;
using Udemy.BankApp.Models;

namespace Udemy.BankApp.Controllers
{
    public class AccountController : Controller
    {
        //private readonly IApplicationUserRepository _applicationUserRepository;
        //private readonly IUserMapper _userMapper;
        //private readonly IAccountRepository _accountRepository;
        //private readonly IAccountMapper _accountMapper;
        //public AccountController( IApplicationUserRepository applicationUserRepository, IUserMapper userMapper, IAccountRepository accountRepository, IAccountMapper accountMapper)
        //{

        //    _applicationUserRepository = applicationUserRepository;
        //    _userMapper = userMapper;
        //    _accountRepository = accountRepository;
        //    _accountMapper = accountMapper;
        //}

        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<ApplicationUser> _userRepository;

       public AccountController(IRepository<Account> accountRepository, IRepository<ApplicationUser> userRepository)
       {
           _accountRepository = accountRepository;
           _userRepository = userRepository;
       }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int id)
        {
            var userInfo = _userRepository.GetById(id);
            return View(userInfo);
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel model)
        {
            _accountRepository.Create(new Account()
            {
                AccountNumber =  model.AccountNumber,
                Balance = model.Balance,
                ApplicationUserId = model.ApplicationUserId
            });
            
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult GetByUserId(int userId)
        {
            var query = _accountRepository.GetQueryable();
            var accounts = query.Where(x => x.ApplicationUserId == userId).ToList();

            var user = _userRepository.GetById(userId);

            var list = new List<AccountListModel>();

            ViewBag.FullName = user.Name + " " + user.SurName;

            foreach (var account in accounts)
            {
                list.Add(new()
                {
                    AccountNumber = account.AccountNumber,
                    ApplicationUserId = account.ApplicationUserId,
                    Balance = account.Balance,
                    Id = account.Id,
                });
            }

            return View(list);
        }
        [HttpGet]
        public IActionResult SendMoney(int accountId)
        {
            var query = _accountRepository.GetQueryable();

            var accounts = query.Where(x => x.Id != accountId).ToList();

            var list = new List<AccountListModel>();

            

            ViewBag.SenderId = accountId;

            foreach (var account in accounts)
            {
                list.Add(new AccountListModel()
                {
                    AccountNumber = account.AccountNumber,
                    ApplicationUserId = account.ApplicationUserId,
                    Balance = account.Balance,
                    Id = account.Id
                });
            }

            //var list2 = new SelectList(list);

            //var item = list2.Items;


            return View(new SelectList(list,"Id","AccountNumber"));
        }

        [HttpPost]
        public IActionResult SendMoney(SendMoneyModel model)
        {
            var senderAccount = _accountRepository.GetById(model.SenderId);

            senderAccount.Balance -= model.Amount;

            _accountRepository.Update(senderAccount);

            var account = _accountRepository.GetById(model.AccountId);

            account.Balance += model.Amount;
            _accountRepository.Update(account);


            return RedirectToAction(actionName: "Index",controllerName:"Home");
        }

    }
}
