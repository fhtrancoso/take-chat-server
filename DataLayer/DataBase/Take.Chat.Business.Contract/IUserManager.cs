using System.Collections.Generic;
using Take.Chat.Business.Model;

namespace Take.Chat.Business.Contract
{
    public interface IUserManager
    {
        /// <summary>
        /// Method to insert a user if him doesnt exists
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool InsertValidUser(UserModel user);

        /// <summary>
        /// Get a specific user by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        UserModel GetUserByName(string name);

        /// <summary>
        /// Get all users from the fake database
        /// </summary>
        /// <returns></returns>
        ICollection<UserModel> GetAllUsers();
    }
}
