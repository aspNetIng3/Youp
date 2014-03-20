using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public class EventCommentDatabase : IEventCommentDatabase
    {
        public List<EventComment> getEventComments()
        {
            YoupEntities ye = new YoupEntities();

            return ye.EventComments.ToList();
        }

        public EventComment Create(EventComment tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.EventComments.Add(tpc);

            if (ye.SaveChanges() != 0)
                return tpc;

            return null;
        }

        public bool Delete(int id)
        {
            YoupEntities ye = new YoupEntities();

            EventComment notDisplay = ye.EventComments.Where(c => c.Id == id).SingleOrDefault();

            if (notDisplay != null)
            {
                notDisplay.DeletedAt = DateTime.Now;
                return Update(notDisplay);
            }

            return false;
        }

        public bool Update(EventComment tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Entry<EventComment>(tpc).State = System.Data.EntityState.Modified;

            if (ye.SaveChanges() != 0)
                return true;

            return false;
        }

        public EventComment getEventComment(int id)
        {
            YoupEntities ye = new YoupEntities();

            return ye.EventComments.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}
