using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Models.DAL.IDatabase;

namespace YoupRepository.Models.DAL.Database
{
    public class ThemeDatabase : IThemeDatabase
    {
        public List<Themes> GetThemes()
        {
            var sle = new YoupEntities();
            return sle.Themes.ToList();
        } 
    }
}
