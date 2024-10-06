using Udemy.BankApp.Models;

namespace Udemy.BankApp.Data.Interfacesses
{
    public interface IAccountRepository
    {
        void Create(AccountCreateModel user);
    }
}
