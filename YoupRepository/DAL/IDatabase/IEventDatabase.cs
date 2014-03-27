using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoupRepository.DAL;

namespace YoupRepository.DAL
{
    public interface IEventDatabase
    {
        List<Event> getEvents();

        Event Create(Event tpc);

        bool Delete(string id);

        bool Update(Event tpc);

        Event getEvent(string id);
    }
}
