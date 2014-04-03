using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public interface IThemeDatabase
    {
        List<Theme> GetThemes();
        Theme GetTheme(int themeID);
        Theme Create(Theme theme);
        Boolean Delete(int themeID);
        Boolean Update(Theme themeUpc);
    }
}
