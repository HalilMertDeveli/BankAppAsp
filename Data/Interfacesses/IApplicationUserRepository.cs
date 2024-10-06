using Udemy.BankApp.Data.Entities;

namespace Udemy.BankApp.Data.Interfacesses
{
    public interface IApplicationUserRepository
    {
        List<ApplicationUser> GetAll();
        ApplicationUser GetById(int id);
    }
}
