using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Model.POCO;


namespace YoupService
{
    public interface IEventService
    {
        List<EventPOCO> getEvents();
        EventPOCO getEvent(string eventID);
        EventPOCO createEvent(EventPOCO evt);
        bool deleteEvent(string eventID);
        bool updateEvent(EventPOCO eventUPC);
    }
}
