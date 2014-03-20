using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.DAL
{
    public interface IThemeDatabase
    {
        List<Theme> getThemes();

        Theme Create(Theme tpc);

        bool Delete(int id);

        bool Update(Theme tpc);

        Theme getTheme(int id);
    }
}
