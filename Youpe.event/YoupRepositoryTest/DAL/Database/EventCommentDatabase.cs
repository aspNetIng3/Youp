using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public class EventCommentDatabase : IEventCommentDatabase
    {

        public List<EventComment> GetEventComment(Event evt)
        {
            YoupEntities context = new YoupEntities();

            return context.EventComments.Where(c => c.EventId == evt.Id).ToList();
        }

        public EventComment GetEventComment(int id)
        {
            YoupEntities context = new YoupEntities();

            return context.EventComments.Where(c => c.Id == id).ToList().First();
        }

        public EventComment Create(EventComment evtComment)
        {
            YoupEntities context = new YoupEntities();
            context.EventComments.Add(evtComment);
            if (context.SaveChanges() == 1)
                return evtComment;
            return null;

        }
        public Boolean Delete(int evtCommentID)
        {
            YoupEntities context = new YoupEntities();

           EventComment eventComment = context.EventComments.Where(c => c.Id == evtCommentID).First();
            if (eventComment != null)
            {
                context.EventComments.Remove(eventComment);
                if(context.SaveChanges() == 1)
                    return true;
            }
            return false;
        }
        public Boolean Update(EventComment evtCommentUpc)
        {
            YoupEntities context = new YoupEntities();
            context.Entry(evtCommentUpc).State = System.Data.Entity.EntityState.Modified;
            if(context.SaveChanges() == 1)
            {
                return true;
            }
            return false;
        }
    }
}
