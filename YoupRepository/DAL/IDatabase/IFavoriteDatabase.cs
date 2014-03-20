using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.DAL
{
    public interface IFavoriteDatabase
    {
        List<Favorite> getFavorites();

        Favorite Create(Favorite tpc);

        bool Delete(int id);

        bool Update(Favorite tpc);

        Favorite getFavorite(int id);
    }
}
