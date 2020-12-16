using System.Collections.Generic;
using Take.Chat.Repository.Model;

namespace Take.Chat.Repository.Contract
{
    public interface IMessageRepository
    {
        void Insert(Message message);

        ICollection<Message> GetByFrom(string name);

        ICollection<Message> GetAll();
    }
}
