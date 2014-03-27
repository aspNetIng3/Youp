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
        List<ThemePOCO> GetThemes();

        List<ThemePOCO> GetThemes(int parentTheme);
    }
}
