using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.DAL
{
    public interface IUserThemeDatabase
    {
        List<Theme> getUserThemes(int id);
    }
}
