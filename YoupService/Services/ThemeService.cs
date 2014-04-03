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
        public ThemePOCO GetTheme(int id)
        {
            return ProcessToPoco(_themeDatabase.getTheme(id));
        }

        public List<ThemePOCO> GetThemes() {
            List<ThemePOCO> themes = new List<ThemePOCO>();
            _themeDatabase.getThemes()
                .ForEach(th => { themes.Add(ProcessToPoco(th)); });
            return themes;
        }
        public List<ThemePOCO> GetFirstLevelThemes()
        {
            List<ThemePOCO> themes = new List<ThemePOCO>();
            _themeDatabase.getThemes().ForEach(
                th => { if (th.ThemeId == null) { themes.Add(ProcessToPoco(th)); } }
            );
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
            return new ThemePOCO(Mapper.Map<Theme, ThemeDTO>(th));
        }

        public ThemePOCO getTheme(int id)
        {
            Theme th = _themeDatabase.getTheme(id);
            return new ThemePOCO(Mapper.Map<Theme, ThemeDTO>(th));
        }
        public ThemePOCO Create(ThemePOCO tpc)
        {
            Theme th = _themeDatabase.Create(Mapper.Map<ThemeDTO, Theme>(tpc.Data));
            return new ThemePOCO(Mapper.Map<Theme, ThemeDTO>(th));
        }

        public bool Delete(int id)
        {
            return _themeDatabase.Delete(id);
        }

        public bool Update(ThemePOCO tpc)
        {
            return _themeDatabase.Update(Mapper.Map<ThemeDTO, Theme>(tpc.Data));
        }
    }
}
