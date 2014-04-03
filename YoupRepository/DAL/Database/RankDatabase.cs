using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public class RankDatabase : IRankDatabase
    {
        public List<Rank> getRanks()
        {
            YoupEntities ye = new YoupEntities();

            return ye.Ranks.ToList();
        }

        public Rank Create(Rank tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Ranks.Add(tpc);

            if (ye.SaveChanges() != 0)
                return tpc;

            return null;
        }

        public bool Delete(int id)
        {
            YoupEntities ye = new YoupEntities();

            Rank notDisplay = ye.Ranks.Where(c => c.Id == id).SingleOrDefault();

            return false;
        }

        public bool Update(Rank tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Entry<Rank>(tpc).State = System.Data.EntityState.Modified;

            if (ye.SaveChanges() != 0)
                return true;

            return false;
        }

        public Rank getRank(int id)
        {
            YoupEntities ye = new YoupEntities();

            return ye.Ranks.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}
