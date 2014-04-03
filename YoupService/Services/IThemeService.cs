using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Model;

namespace YoupService.Services
{
    public interface IThemeService
    {
        ThemePOCO GetTheme(int id);
        List<ThemePOCO> GetThemes();

        List<ThemePOCO> GetThemes(int parentTheme);

        List<ThemePOCO> GetFirstLevelThemes();

        ThemePOCO Create(ThemePOCO theme);
        bool Delete(int id);

        bool Update(ThemePOCO theme);

        ThemePOCO getTheme(int id);
    }
}
