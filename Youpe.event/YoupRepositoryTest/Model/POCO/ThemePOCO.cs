using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Model.DTO;

namespace YoupRepository.Model.POCO
{
    public class ThemePOCO
    {
        public ThemeDTO data;
        public ThemePOCO()
        {
            this.data = new ThemeDTO();
        }

        public ThemePOCO(ThemeDTO themeDTO)
        {
            this.data = themeDTO;
        }

    }
}
