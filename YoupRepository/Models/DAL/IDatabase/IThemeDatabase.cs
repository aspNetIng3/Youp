using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Models.DAL.IDatabase
{
    public interface IThemeDatabase
    {
        List<Themes> GetThemes();
    }
}
