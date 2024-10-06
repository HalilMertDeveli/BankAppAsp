using Udemy.BankApp.Data.Entities;
using Udemy.BankApp.Models;

namespace Udemy.BankApp.Mapping
{
    public class AccountMapper:IAccountMapper
    {
        public Account Map(AccountCreateModel model)
        {
            return new Account { 
                AccountNumber=model.AccountNumber,
                ApplicationUserId=model.ApplicationUserId,
                Balance = model.Balance
                
            };
        }
    }
}
