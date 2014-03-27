using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public class EventDatabase : IEventDatabase
    {
        public List<Event> getEvents()
        {
            YoupEntities ye = new YoupEntities();

            return ye.Events.ToList();
        }

        public Event Create(Event tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Events.Add(tpc);

            if (ye.SaveChanges() != 0)
                return tpc;

            return null;
        }

        public bool Delete(string id)
        {
            YoupEntities ye = new YoupEntities();

            Event notDisplay = ye.Events.Where(c => c.Id == id).SingleOrDefault();

            if (notDisplay != null)
            {
                notDisplay.DeletedAt = DateTime.Now;
                return Update(notDisplay);
            }

            return false;
        }

        public bool Update(Event tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Entry<Event>(tpc).State = System.Data.EntityState.Modified;

            if (ye.SaveChanges() != 0)
                return true;

            return false;
        }

        public Event getEvent(string id)
        {
            YoupEntities ye = new YoupEntities();

            return ye.Events.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}
