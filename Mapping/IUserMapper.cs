using Udemy.BankApp.Data.Entities;
using Udemy.BankApp.Models;

namespace Udemy.BankApp.Mapping
{
    public interface IUserMapper
    {
        List<UserListModel> MapToListOfUserList(List<ApplicationUser> users);
        UserListModel MapToUserList(ApplicationUser user);
    }
}
