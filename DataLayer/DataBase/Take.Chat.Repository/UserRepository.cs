using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Take.Chat.Repository.Contract;
using Take.Chat.Repository.Model;

namespace Take.Chat.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ICollection<User> _users;

        public UserRepository()
        {
            _users = new Collection<User>();
        }

        public ICollection<User> GetAll()
        {
            return _users;
        }

        public User GetByName(string name)
        {
            return _users.FirstOrDefault(x => x.Name == name);
        }

        public void Insert(User user)
        {
            _users.Add(user);
        }
    }
}
