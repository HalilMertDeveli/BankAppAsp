using Udemy.BankApp.Data.Context;
using Udemy.BankApp.Data.Entities;
using Udemy.BankApp.Data.Interfacesses;

namespace Udemy.BankApp.Data.Repositories
{
    public class ApplicationUserRepository: IApplicationUserRepository
    {
        private readonly BankContext _context;

        public ApplicationUserRepository(BankContext context)
        {
            _context = context;
        }
        public List<ApplicationUser> GetAll()
        {
            return _context.ApplicationUsers.ToList();
        }

        public ApplicationUser GetById(int id)
        {
            return _context.ApplicationUsers.SingleOrDefault(x => x.Id == id);
        }
    }
}
