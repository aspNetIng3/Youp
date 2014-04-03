using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Model.DTO;
using YoupRepository.Model.POCO;
using YoupRepository;
using YoupRepository.DAL;
using AutoMapper;

namespace YoupService
{
    public class ThemeService : IThemeService
    {
         IThemeDatabase _iThemeDatabase;

        public ThemeService (IThemeDatabase iThemeDatabase)
        {
            _iThemeDatabase = iThemeDatabase;
        }

        public List<ThemePOCO> getAllThemes()
        {
            List<ThemePOCO> themes = new List<ThemePOCO>();
            _iThemeDatabase.GetThemes().ForEach(
                c =>
                {
                    try
                    {
                        themes.Add(processToDTO(c));

                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                });

            return themes;
        }

        public ThemePOCO getThemeById(int id)
        {

          Theme theme = _iThemeDatabase.GetTheme(id);
          if (theme == null)
              return null;
          return processToDTO(theme);
        }


        ThemePOCO processToDTO(Theme theme)
        {
            /*
            ThemeDTO themeDTO = new ThemeDTO();
            themeDTO.Name = theme.Name;
            themeDTO.Description = theme.Description;
            themeDTO.CreatedAt = theme.CreatedAt;
            themeDTO.DeletedAt = theme.DeletedAt;
            themeDTO.UpdatedAt = theme.UpdatedAt;
            themeDTO.Events = theme.Events;

            return new ThemePOCO(themeDTO);
             * */

            
            ThemePOCO pocoToReturn = new ThemePOCO(Mapper.Map<Theme, ThemeDTO>(theme));
            return pocoToReturn;
            
        }

    }
}
