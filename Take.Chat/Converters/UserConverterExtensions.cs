using Take.Chat.Business.Model;
using Take.Chat.Model;

namespace Take.Chat.Converters
{
    /// <summary>
    /// This is is to convert the API model to the domain model and the opposite
    /// </summary>
    public static class UserConverterExtensions
    {
        public static UserModel ToModel(this User user)
        {
            return new UserModel
            {
                Name = user.Name
            };
        }

        public static User ToChatModel(this UserModel user)
        {
            return new User
            {
                Name = user.Name
            };
        }
    }
}
