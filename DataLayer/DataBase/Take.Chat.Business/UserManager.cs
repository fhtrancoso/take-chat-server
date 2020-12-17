using System;
using System.Collections.Generic;
using System.Text;
using Take.Chat.Business.Contract;
using Take.Chat.Business.Model;
using Take.Chat.Repository.Contract;
using Take.Chat.Business.Model.Converters;

namespace Take.Chat.Business
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _repository;
        public UserManager(IUserRepository repository)
        {
            _repository = repository;
        }

        ///<inheritdoc/>
        public ICollection<UserModel> GetAllUsers()
        {
            // here we could use the AutoMapper package
            var list = new List<UserModel>();

            foreach (var m in _repository.GetAll())
            {
                list.Add(m.ToModel());
            }

            return list;
        }

        ///<inheritdoc/>
        public bool InsertValidUser(UserModel user)
        {
            var isValidUser = GetUserByName(user.Name) == null;

            if (isValidUser)
            {
                _repository.Insert(user.ToModelRepository());
            }

            return isValidUser;
        }

        ///<inheritdoc/>
        public UserModel GetUserByName(string name)
        {
            return _repository.GetByName(name)?.ToModel();
        }
    }
}
