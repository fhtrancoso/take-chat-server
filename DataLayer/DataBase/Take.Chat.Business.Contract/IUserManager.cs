using System.Collections.Generic;
using Take.Chat.Business.Model;

namespace Take.Chat.Business.Contract
{
    public interface IUserManager
    {
        bool InsertValidUser(UserModel user);

        UserModel GetUserByName(string name);

        ICollection<UserModel> GetAllUsers();
    }
}
