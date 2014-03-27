using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public class ThemeDatabase : IThemeDatabase
    {

        public List<Theme> getThemes()
        {
            YoupEntities ye = new YoupEntities();

            return ye.Themes.ToList();
        }

        public Theme Create(Theme tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Themes.Add(tpc);

            if (ye.SaveChanges() != 0)
                return tpc;

            return null;
        }

        public bool Delete(int id)
        {
            YoupEntities ye = new YoupEntities();

            Theme notDisplay = ye.Themes.Where(c => c.Id == id).SingleOrDefault();

            if (notDisplay != null)
            {
                notDisplay.DeletedAt = DateTime.Now;
                return Update(notDisplay);
            }

            return false;
        }

        public bool Update(Theme tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Entry<Theme>(tpc).State = System.Data.EntityState.Modified;

            if (ye.SaveChanges() != 0)
                return true;

            return false;
        }

        public Theme getTheme(int id)
        {
            YoupEntities ye = new YoupEntities();

            return ye.Themes.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}
