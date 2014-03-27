using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository;
using YoupRepository.DAL;
using YoupRepository.Model;

namespace YoupService.Services
{
    public class MessageService : IMessageServices
    {
        IMessageDatabase _messageDatabase;
        public MessageService()
        {
            _messageDatabase = new MessageDatabase();
        }

        public List<MessagePOCO> getMessages(int threadId, int nbResultsPerThread)
        {
            List<MessagePOCO> listMessages = new List<MessagePOCO>();
            ThreadService thService = new ThreadService();

            return getPaginatedMessages(getAllMessages(), threadId, nbResultsPerThread);
        }

        public MessagePOCO Create(MessagePOCO tpc)
        {
            Mapper.CreateMap<MessageDTO, Message>();
            Message th = _messageDatabase.Create(Mapper.Map<MessageDTO, Message>(tpc.Data));
            Mapper.CreateMap<Message, MessageDTO>();
            return new MessagePOCO(Mapper.Map<Message, MessageDTO>(th));
        }

        public bool Delete(int id)
        {
            return _messageDatabase.Delete(id);
        }

        public bool Update(MessagePOCO tpc)
        {
            Mapper.CreateMap<MessageDTO, Message>();
            return _messageDatabase.Update(Mapper.Map<MessageDTO, Message>(tpc.Data));
        }

        public MessagePOCO getMessage(int id)
        {
            Mapper.CreateMap<Message, MessagePOCO>();
            Message th = _messageDatabase.getMessage(id);
            return new MessagePOCO(Mapper.Map<Message, MessageDTO>(th));
        }
        private List<MessagePOCO> getPaginatedMessages(List<MessagePOCO> messages, int page, int nbResultsPerPage)
        {
            List<MessagePOCO> paginatedList = new List<MessagePOCO>();
            int lastAvailableIndex = messages.Count - 1;
            int firstIndex = (page - 1) * nbResultsPerPage;
            int lastIndex = page * nbResultsPerPage - 1;
            if (firstIndex > lastAvailableIndex || page <= 0 || nbResultsPerPage <= 0)
            {
                return paginatedList;
            }
            else
            {
                int lastValidIndex = lastIndex > lastAvailableIndex ? lastAvailableIndex : lastIndex;
                int count = lastValidIndex - firstIndex;
                return messages.GetRange(firstIndex, count);
            }
        }
        private List<MessagePOCO> getAllMessages()
        {
            // TODO Mock method, uncomplete...
            List<MessagePOCO> messages = new List<MessagePOCO>();
     
            _messageDatabase.getMessages().ForEach(
                me => { messages.Add(ProcessToPoco(me)); }
            );
            return messages;
        }
        public MessagePOCO ProcessToPoco(Message p)
        {
            Mapper.CreateMap<Message, MessageDTO>();
            return new MessagePOCO(Mapper.Map<Message, MessageDTO>(p));
        }
    }
}
