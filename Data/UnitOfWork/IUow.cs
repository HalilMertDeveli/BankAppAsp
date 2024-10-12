using Udemy.BankApp.Data.Interfaceses;

namespace Udemy.BankApp.Data.UnitOfWork
{

    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : class, new();
        void SaveChanges();
    }

}
