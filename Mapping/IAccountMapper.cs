using Udemy.BankApp.Data.Entities;
using Udemy.BankApp.Models;

namespace Udemy.BankApp.Mapping
{
    public interface IAccountMapper
    {
        Account Map(AccountCreateModel model);
    }
}
