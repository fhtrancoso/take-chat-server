using System;
using System.Collections.Generic;
using System.Text;
using Take.Chat.Repository.Model;

namespace Take.Chat.Repository.Contract
{
    public interface IUserRepository
    {
        void Insert(User user);

        User GetByName(string name);

        ICollection<User> GetAll();
    }
}
