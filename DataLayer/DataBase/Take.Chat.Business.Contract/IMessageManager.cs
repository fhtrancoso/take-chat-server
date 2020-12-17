using System.Collections.Generic;
using Take.Chat.Business.Model;

namespace Take.Chat.Business.Contract
{
    public interface IMessageManager
    {
        /// <summary>
        /// Method to create a message in the fake database to check the history
        /// </summary>
        /// <param name="message"></param>
        void InsertMessage(MessageModel message);

        /// <summary>
        /// Method to return all messages of the fake database to check it in the history
        /// </summary>
        /// <returns></returns>
        ICollection<MessageModel> GetAllMessages();
    }
}
