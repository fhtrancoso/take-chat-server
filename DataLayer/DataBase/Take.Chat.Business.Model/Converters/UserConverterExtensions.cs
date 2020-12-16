using System.Collections.Generic;
using Take.Chat.Repository.Model;

namespace Take.Chat.Business.Model.Converters
{
    public static class UserConverterExtensions
    {
        // USER CONVERTERS
        public static UserModel ToModel(this User user)
        {
            return new UserModel
            {
                Name = user.Name
            };
        }

        public static User ToModelRepository(this UserModel user)
        {
            return new User
            {
                Name = user.Name
            };
        }

        public static List<UserModel> ToModelList(this List<User> user)
        {
            var list = new List<UserModel>();

            foreach (var m in user)
            {
                list.Add(m.ToModel());
            }

            return list;
        }
    }
}
