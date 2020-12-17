using NUnit.Framework;
using System.Collections.Generic;
using Take.Chat.Business;
using Take.Chat.Business.Contract;
using Take.Chat.Business.Model;
using Take.Chat.Repository.Contract;
using Take.Chat.Repository.Model;
using Telerik.JustMock;

namespace Tests
{
    public class UserBusinessTest
    {
        private IUserManager _manager;
        private IUserRepository _repository;

        [SetUp]
        public void Setup()
        {
            _repository = Mock.Create<IUserRepository>();
            _manager = new UserManager(_repository);
        }

        [Test]
        public void WhenCreatingNewValidUser_ItShouldReturnSuccess()
        {
            User existsUserRepo = null;

            UserModel existsModel = null;

            var model = new UserModel
            {
                Name = "User2"
            };

            Mock.Arrange(() => _repository.GetByName(Arg.IsAny<string>())).Returns(existsUserRepo);
            var response = _manager.InsertValidUser(model);
            
            Assert.True(response);
        }

        [Test]
        public void WhenCreatingNewInvalidUser_ItShouldReturnSuccess()
        {
            var existsRepoModel = new User
            {
                Name = "User1"
            };

            var existsModel = new UserModel
            {
                Name = "User1"
            };

            var model = new UserModel
            {
                Name = "User1"
            };

            Mock.Arrange(() => _repository.GetByName(Arg.IsAny<string>())).Returns(existsRepoModel);
            var response = _manager.InsertValidUser(model);

            Assert.False(response);
        }
    }
}