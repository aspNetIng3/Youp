using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public class FavoriteDatabase : IFavoriteDatabase
    {

        public List<Favorite> getFavorites()
        {
            YoupEntities ye = new YoupEntities();

            return ye.Favorites.ToList();
        }

        public Favorite Create(Favorite tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Favorites.Add(tpc);

            if (ye.SaveChanges() != 0)
                return tpc;

            return null;
        }

        public bool Delete(int id)
        {
            YoupEntities ye = new YoupEntities();

            Favorite notDisplay = ye.Favorites.Where(c => c.Id == id).SingleOrDefault();

            if (notDisplay != null)
            {
                notDisplay.DeletedAt = DateTime.Now;
                return Update(notDisplay);
            }

            return false;
        }

        public bool Update(Favorite tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Entry<Favorite>(tpc).State = System.Data.EntityState.Modified;

            if (ye.SaveChanges() != 0)
                return true;

            return false;
        }

        public Favorite getFavorite(int id)
        {
            YoupEntities ye = new YoupEntities();

            return ye.Favorites.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}
