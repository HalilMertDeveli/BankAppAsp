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
        private readonly IAccountMapper _accountMapper;

        public AccountRepository(BankContext context, IAccountMapper accountMapper)
        {
            _context = context;
            _accountMapper = accountMapper;
        }


        public void Create(AccountCreateModel model)
        {
            _context.Accounts.Add(_accountMapper.Map(model));
            _context.SaveChanges();
        }
    }
}
