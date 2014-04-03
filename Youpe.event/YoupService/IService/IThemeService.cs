using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Model.DTO;
using YoupRepository.Model.POCO;

namespace YoupService
{
    public interface IThemeService
    {
        List<ThemePOCO> getAllThemes();

        ThemePOCO getThemeById(int id);
    }
}
