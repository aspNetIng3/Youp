using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public class ThreadDatabase : IThreadDatabase
    {
        public List<Thread> getThreads()
        {
            YoupEntities ye = new YoupEntities();

            return ye.Threads.ToList();
        }

        public Thread Create(Thread tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Threads.Add(tpc);

            if (ye.SaveChanges() != 0)
                return tpc;

            return null;
        }

        public bool Delete(int id)
        {
            YoupEntities ye = new YoupEntities();

            Thread notDisplay = ye.Threads.Where(c => c.Id == id).SingleOrDefault();

            if(notDisplay != null)
            {
                notDisplay.DeletedAt = DateTime.Now;
                return Update(notDisplay);                
            }

            return false;
        }

        public bool Update(Thread tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Entry<Thread>(tpc).State = System.Data.EntityState.Modified;

            if (ye.SaveChanges() != 0)
                return true;

            return false;
        }

        public Thread getThread(int id)
        {
            YoupEntities ye = new YoupEntities();

            return ye.Threads.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}
