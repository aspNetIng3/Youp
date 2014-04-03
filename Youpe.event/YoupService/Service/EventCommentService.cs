using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository;
using YoupRepository.DAL;
using YoupRepository.Model.DTO;
using YoupRepository.Model.POCO;


namespace YoupService
{
    public class EventCommentService : IEventCommentService
    {
        private IEventCommentDatabase eventCommentDatabase;
        private EventCommentDatabase eventCommentDb;

        public EventCommentService(IEventCommentDatabase eventCommentDb)
        {
            eventCommentDatabase = eventCommentDb;
        }

        
        public EventCommentPOCO CreateEventComment(YoupRepository.Model.POCO.EventCommentPOCO eventComment)
        {
            EventCommentDTO ecDTO = eventComment.data;
            EventComment ec=Mapper.Map<EventCommentDTO, EventComment>(ecDTO);
            EventComment ec2=eventCommentDatabase.Create(ec);


            return processToDTO(ec2);
            
        }

        public bool UpdateEventComment(YoupRepository.Model.POCO.EventCommentPOCO eventComment)
        {
            EventComment ec = Mapper.Map<EventCommentDTO, EventComment>(eventComment.data);
            return eventCommentDatabase.Update(ec);
        }

        public bool DeleteEventComment(int id)
        {
            return eventCommentDatabase.Delete(id);
        }

        EventCommentPOCO processToDTO(EventComment evt)
        {

            EventCommentPOCO pocoToReturn = new EventCommentPOCO(Mapper.Map<EventComment, EventCommentDTO>(evt));
            return pocoToReturn;
        }
    }
}
