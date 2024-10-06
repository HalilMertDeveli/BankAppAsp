using Udemy.BankApp.Data.Context;
using Udemy.BankApp.Data.Entities;
using Udemy.BankApp.Data.Interfacesses;
using Udemy.BankApp.Models;

namespace Udemy.BankApp.Data.Repositories
{
    public class AccountRepository: IAccountRepository
    {
        private readonly BankContext _context;

        public AccountRepository(BankContext context)
        {
            _context = context;
        }


        public void Create(AccountCreateModel model)
        {
            _context.Accounts.Add(new Account()
            {
                AccountNumber = model.AccountNumber,
                ApplicationUserId = model.ApplicationUserId,
                Balance = model.Balance,
            });
            _context.SaveChanges();
        }
    }
}
