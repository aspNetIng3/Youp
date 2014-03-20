using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public class MessageDatabase : IMessageDatabase
    {
        public List<Message> getMessages()
        {
            YoupEntities ye = new YoupEntities();

            return ye.Messages.ToList();
        }

        public Message Create(Message tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Messages.Add(tpc);

            if (ye.SaveChanges() != 0)
                return tpc;

            return null;
        }

        public bool Delete(int id)
        {
            YoupEntities ye = new YoupEntities();

            Message notDisplay = ye.Messages.Where(c => c.Id == id).SingleOrDefault();

            if (notDisplay != null)
            {
                notDisplay.DeletedAt = DateTime.Now;
                return Update(notDisplay);
            }

            return false;
        }

        public bool Update(Message tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Entry<Message>(tpc).State = System.Data.EntityState.Modified;

            if (ye.SaveChanges() != 0)
                return true;

            return false;
        }

        public Message getMessage(int id)
        {
            YoupEntities ye = new YoupEntities();

            return ye.Messages.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}
