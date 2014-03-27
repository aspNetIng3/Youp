using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL.Database
{
    public class UserThemeDatabase : IUserThemeDatabase
    {
        public List<Theme> getUserThemes(int userId)
        {
            YoupEntities ye = new YoupEntities();

            //return ye.UserThemes.ToList();
            return new List<Theme>();
        }

        public UserTheme Create(UserTheme tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.UserThemes.Add(tpc);

            if (ye.SaveChanges() != 0)
                return tpc;

            return null;
        }

        public bool Delete(string id)
        {
            YoupEntities ye = new YoupEntities();

            //UserTheme notDisplay = ye.UserThemes.Where(c => c.ThemeId == id).SingleOrDefault();

            //return Update(notDisplay);
            return false;
        }

        public bool Update(UserTheme tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Entry<UserTheme>(tpc).State = System.Data.EntityState.Modified;

            if (ye.SaveChanges() != 0)
                return true;

            return false;
        }

        public UserTheme getUserTheme(string userId, string themeId)
        {
            YoupEntities ye = new YoupEntities();

            return ye.UserThemes.Where(c => c.UserId == userId).SingleOrDefault();
        }

    }
}
