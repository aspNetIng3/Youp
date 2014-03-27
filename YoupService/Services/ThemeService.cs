using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository;
using YoupRepository.DAL;
using YoupRepository.Model;

namespace YoupService.Services
{
    public class ThemeService : IThemeService
    {
        IThemeDatabase _themeDatabase;
        
        public ThemeService()
        {
            _themeDatabase = new ThemeDatabase();
        }

        public List<ThemePOCO> GetThemes() {
            List<ThemePOCO> themes = new List<ThemePOCO>();
            _themeDatabase.getThemes()
                .ForEach(th => { themes.Add(ProcessToPoco(th)); });
            return themes;
        }

        public List<ThemePOCO> GetThemes(int parentTheme) {
            List<ThemePOCO> themes = new List<ThemePOCO>();
            _themeDatabase.getThemes()
                .Where(th => th.ThemeId == parentTheme)
                .ToList()
                .ForEach(th => { themes.Add(ProcessToPoco(th)); });
            return themes;
        }

        public ThemePOCO ProcessToPoco(Theme th)
        {
            Mapper.CreateMap<Theme, ThemeDTO>();
            return new ThemePOCO(Mapper.Map<Theme, ThemeDTO>(th));
        }
    }
}
