﻿using Udemy.BankApp.Data.Context;
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

        public void Create(ApplicationUser user)
        {
            _context.ApplicationUsers.Add(user);
            _context.SaveChanges();

            _context.Set<ApplicationUser>().Add(user);
            _context.SaveChanges();
        }

        public void Remove(ApplicationUser user)
        {
            _context.ApplicationUsers.Remove(user);
            _context.SaveChanges();

            _context.Set<ApplicationUser>().Remove(user);
            _context.SaveChanges();
        }
    }
}
