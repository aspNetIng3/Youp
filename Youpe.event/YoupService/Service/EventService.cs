using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Model.POCO;
using YoupRepository.Model.DTO;
using YoupRepository.DAL;
using YoupRepository;
using AutoMapper;

namespace YoupService
{
    public class EventService : IEventService
    {
        IEventDatabase _eventDatabase;
        public EventService(IEventDatabase eventDatabase)
        {
            _eventDatabase = eventDatabase;
        }

        public List<EventPOCO> getEvents()
        {
            List<EventPOCO> listEvent = new List<EventPOCO>();
            _eventDatabase.GetEvents().ForEach(
                c =>
                {
                    try
                    {
                        var t = c.User;
                        listEvent.Add(processToDTO(c));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                });

            return listEvent;
        }
        public EventPOCO getEvent(string eventID)
        {
            Event evt = _eventDatabase.GetEvent(eventID);
            return new EventPOCO(Mapper.Map < Event, EventDTO > (evt));
        }

        public EventPOCO createEvent(EventPOCO evt)
        {
           // Mapper.CreateMap<EventDTO, Event>();
            Event createdEvt = _eventDatabase.Create(Mapper.Map<EventDTO,Event>(evt.data));
            //Mapper.CreateMap<Event, EventDTO>();
            return new EventPOCO(Mapper.Map<Event, EventDTO>(createdEvt));
        }
        public bool deleteEvent(string eventID)
        {
            return _eventDatabase.Delete(eventID);
        }

        public bool updateEvent(EventPOCO eventUPC)
        {
            //Mapper.CreateMap<EventDTO, Event>();
            return _eventDatabase.Update(Mapper.Map<EventDTO, Event>(eventUPC.data));
        }

        EventPOCO processToDTO(Event evt)
        {

            EventPOCO pocoToReturn = new EventPOCO(Mapper.Map<Event, EventDTO>(evt));
            return pocoToReturn; 
        }
    }
}
