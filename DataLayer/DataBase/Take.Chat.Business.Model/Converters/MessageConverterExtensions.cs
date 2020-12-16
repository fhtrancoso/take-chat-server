using System.Collections.Generic;
using Take.Chat.Repository.Model;

namespace Take.Chat.Business.Model.Converters
{
    public static class MessageConverterExtensions
    {
        // MESSAGE CONVERTERS
        public static MessageModel ToModel(this Message message)
        {
            return new MessageModel
            {
                FromName = message.From,
                Text = message.Text,
                ToName = message.To
            };
        }

        public static Message ToModelRepository(this MessageModel message)
        {
            return new Message
            {
                From = message.FromName,
                Text = message.Text,
                To = message.ToName
            };
        }

        public static List<MessageModel> ToModelList(this List<Message> message)
        {
            var list = new List<MessageModel>();

            foreach (var m in message)
            {
                list.Add(m.ToModel());
            }

            return list;
        }
    }
}
