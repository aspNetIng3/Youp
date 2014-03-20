using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public class ParticipateDatabase : IParticipateDatabase
    {
        public List<Participate> getParticipates()
        {
            YoupEntities ye = new YoupEntities();
            
            return ye.Participates.ToList();
        }

        public Participate Create(Participate tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Participates.Add(tpc);

            if (ye.SaveChanges() != 0)
                return tpc;

            return null;
        }

        public bool Delete(string id)
        {
            YoupEntities ye = new YoupEntities();

            Participate notDisplay = ye.Participates.Where(c => c.UserId == id).SingleOrDefault();

            /*
            if (notDisplay != null)
            {
                //notDisplay.DeletedAt = DateTime.Now;
                return Update(notDisplay);
            }
             * */

            return false;
        }

        public bool Update(Participate tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Entry<Participate>(tpc).State = System.Data.EntityState.Modified;

            if (ye.SaveChanges() != 0)
                return true;

            return false;
        }

        public Participate getParticipate(string id)
        {
            YoupEntities ye = new YoupEntities();

            return ye.Participates.Where(c => c.UserId == id).SingleOrDefault();
        }
    }
}
