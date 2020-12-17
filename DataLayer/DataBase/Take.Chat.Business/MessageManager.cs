using System.Collections.Generic;
using Take.Chat.Business.Contract;
using Take.Chat.Business.Model;
using Take.Chat.Business.Model.Converters;
using Take.Chat.Repository.Contract;

namespace Take.Chat.Business
{
    public class MessageManager : IMessageManager
    {
        private readonly IMessageRepository _repository;

        public MessageManager(IMessageRepository repository)
        {
            _repository = repository;
        }

        ///<inheritdoc/>
        public ICollection<MessageModel> GetAllMessages()
        {
            // here we could use the AutoMapper package
            var list = new List<MessageModel>();

            foreach (var m in _repository.GetAll())
            {
                list.Add(m.ToModel());
            }

            return list;
        }

        ///<inheritdoc/>
        public void InsertMessage(MessageModel message)
        {
            _repository.Insert(message.ToModelRepository());
        }
    }
}
