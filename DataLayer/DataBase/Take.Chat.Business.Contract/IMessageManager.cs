using System.Collections.Generic;
using Take.Chat.Business.Model;

namespace Take.Chat.Business.Contract
{
    public interface IMessageManager
    {
        void SendMessage(MessageModel message);

        ICollection<MessageModel> GetAllMessages();
    }
}
