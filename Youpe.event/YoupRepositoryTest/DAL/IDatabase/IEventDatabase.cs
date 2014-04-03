using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public interface IEventDatabase
    {
        List<Event> GetEvents();
        Event GetEvent(String evtID);
        Event Create(Event evt);
        Boolean Delete(String evtID);
        Boolean Update(Event evtUpc);
    }
}
