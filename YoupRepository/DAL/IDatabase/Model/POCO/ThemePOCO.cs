using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Model
{
    public class ThemePOCO
    {
        public ThemeDTO Data { get; set; }
        public ThemePOCO() { this.Data = new ThemeDTO(); }
        public ThemePOCO(ThemeDTO dto)
        {
            this.Data = dto;
        }
    }
}
