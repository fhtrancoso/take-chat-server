using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Take.Chat.Repository.Contract;
using Take.Chat.Repository.Model;

namespace Take.Chat.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ICollection<Message> _messages;
        private int _primaryKey;

        public MessageRepository()
        {
            _primaryKey = 0;
            _messages = new Collection<Message>();
        }

        public ICollection<Message> GetAll()
        {
            return _messages;
        }

        public ICollection<Message> GetByFrom(string name)
        {
            return _messages.Where(x => x.From == name).OrderBy(x => x.From).ToList();
        }

        public void Insert(Message message)
        {
            message.Id = ++_primaryKey;
            _messages.Add(message);
        }
    }
}
