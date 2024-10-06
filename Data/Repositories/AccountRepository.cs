using Udemy.BankApp.Data.Context;
using Udemy.BankApp.Data.Entities;
using Udemy.BankApp.Data.Interfacesses;
using Udemy.BankApp.Mapping;
using Udemy.BankApp.Models;

namespace Udemy.BankApp.Data.Repositories
{
    public class AccountRepository: IAccountRepository
    {
        private readonly BankContext _context;

        public AccountRepository(BankContext context )
        {
            _context = context;
            
        }


        public void Create(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();

            _context.Set<Account>().Add(account);
            _context.SaveChanges();
        }


        public void Remove(Account account)
        {
            _context.Accounts.Remove(account);
            _context.SaveChanges();

            _context.Set<Account>().Remove(account);
            _context.SaveChanges();
        }
    }
}
