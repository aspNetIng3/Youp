using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public class UserThemeDatabase : IUserThemeDatabase
    {
        public List<Theme> getUserThemes(int id)
        {
            YoupEntities ye = new YoupEntities();

            return ye.Themes.Where(c => c.Id == id).ToList<Theme>();
        }
    }
}
