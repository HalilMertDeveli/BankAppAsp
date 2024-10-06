using Udemy.BankApp.Data.Entities;
using Udemy.BankApp.Models;

namespace Udemy.BankApp.Mapping
{
    public class UserMapper:IUserMapper
    {
        public List<UserListModel> MapToListOfUserList(List<ApplicationUser> users)
        {
            return users.Select(x => new UserListModel()
            {
                Id = x.Id,
                Name = x.Name,
                SurName = x.SurName,
            }).ToList();
        }

        public UserListModel MapToUserList(ApplicationUser user)
        {
            return new UserListModel()
            {
                Id = user.Id,
                Name = user.Name,
                SurName = user.SurName,
            };
        }
    }
}
