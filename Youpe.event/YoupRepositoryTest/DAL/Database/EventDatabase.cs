using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; 

namespace YoupRepository.DAL
{
    public class EventDatabase : IEventDatabase
    {
        public EventDatabase(){}
        public List<Event> GetEvents()
        {
            YoupEntities context = new YoupEntities();
           // return context.Events.Include(u => u.User).ToList();
            
            return context.Events.ToList();
        }
        public Event GetEvent(String evtID)
        {
            YoupEntities context = new YoupEntities();
            return context.Events.Where(c => c.Id == evtID).SingleOrDefault();
        }

        public Event Create(Event evt)
        {
            YoupEntities context = new YoupEntities();
            context.Events.Add(evt);
            if (context.SaveChanges() == 1)
                return evt;
            return null;
        }
        public Boolean Delete(String evtID)
        {
            YoupEntities context = new YoupEntities();
            Event eventToRemove = this.GetEvent(evtID);
            if(eventToRemove != null)
            {
                context.Events.Remove(eventToRemove);
                if(context.SaveChanges() == 1)
                    return true;
            }
            return false;
        }
        public Boolean Update(Event evtUpc)
        {
            YoupEntities context = new YoupEntities();
            context.Entry(evtUpc).State = EntityState.Modified;
            if (context.SaveChanges() == 1)
                return true;
            return false;
        }


    }
}
