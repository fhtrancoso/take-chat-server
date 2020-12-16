using System.Collections.Generic;
using Take.Chat.Business.Model;

namespace Take.Chat.Business.Contract
{
    public interface IMessageManager
    {
        void InsertMessage(MessageModel message);

        ICollection<MessageModel> GetAllMessages();
    }
}
