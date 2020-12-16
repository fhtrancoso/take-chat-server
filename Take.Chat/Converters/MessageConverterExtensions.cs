using Take.Chat.Business.Model;
using Take.Chat.Model;

namespace Take.Chat.Converters
{
    public static class MessageConverterExtensions
    {
        public const string MESSAGE_SEPARATOR_SOCKET = "|";

        public static MessageModel ToModel(this Message message)
        {
            return new MessageModel
            {
                FromName = message.FromName,
                Text = message.Text,
                ToName = message.ToName
            };
        }

        public static Message ToChatObject(this MessageModel message)
        {
            return new Message
            {
                FromName = message.FromName,
                Text = message.Text,
                ToName = message.ToName
            };
        }

        public static string ToClientMessage(this string message)
        {
            var messageReturn = string.Empty;

            var userFrom = "SYSTEM";
            var userTo = string.Empty;
            var arrays = message.Split(MESSAGE_SEPARATOR_SOCKET);

            // It indicates we have the USER TO
            if (arrays.Length > 2)
            {
                userFrom = arrays[0];
                userTo = arrays[1];
                message = arrays[2];
                messageReturn = $"[{userFrom}] says to {userTo}: {message}";
            }
            else if (arrays.Length == 2)
            {
                userFrom = arrays[0];
                message = arrays[1];
                messageReturn = $"[{userFrom}] says: {message}";
            }
            else
            {
                messageReturn = $"[{userFrom}] says: {message}";
            }

            return messageReturn;
        }

    }
}
