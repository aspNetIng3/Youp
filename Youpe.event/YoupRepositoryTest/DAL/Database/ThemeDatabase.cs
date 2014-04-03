using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public class ThemeDatabase : IThemeDatabase
    {
        public List<Theme> GetThemes()
        {
            YoupEntities context = new YoupEntities();
            return context.Themes.ToList();
        }
        public Theme GetTheme(int themeID)
        {
            YoupEntities context = new YoupEntities();
            return context.Themes.Where(c => c.Id == themeID).SingleOrDefault();
        }
        public Theme Create(Theme theme)
        {
            if (theme == null) return null;
            YoupEntities context = new YoupEntities();
            context.Themes.Add(theme);
            if(context.SaveChanges() == 1)
            {
                return theme;
            }
            return null;
        }
        public Boolean Delete(int themeID)
        {
            YoupEntities context = new YoupEntities();
            Theme themeToRemove = this.GetTheme(themeID);
            context.Themes.Remove(themeToRemove);
            if(context.SaveChanges() ==1)
            {
                return true;
            }

            return false;

        }
        public Boolean Update(Theme themeUpc)
        {
            if (themeUpc == null) return false;
            YoupEntities context = new YoupEntities();
            context.Entry(themeUpc).State = System.Data.Entity.EntityState.Modified;
            if(context.SaveChanges() == 1)
            {
                return true;
            }

            return false;

        }
    }
}
