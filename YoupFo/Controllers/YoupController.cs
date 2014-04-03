using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using YoupFo.Models;
using YoupService.Services;
using YoupRepository.Model;

namespace YoupFo.Controllers
{
    public class YoupController : Controller
    {
        private IThemeService _themeService = new ThemeService();

        public List<ThemePOCO> ListForum;
        
        public YoupController()
        {
            ViewBag.ListForum = getThemes();
        }
        public ActionResult Nav()
        {
            ViewBag.ListForum = getThemes();  
            return this.PartialView();
        }

        public List<ThemeModel> getThemes()
        {
            List<ThemePOCO> firstLevelThemesPOCO = _themeService.GetFirstLevelThemes();
            List<ThemeModel> firstLevelThemes = new List<ThemeModel>();
            foreach (ThemePOCO tp in firstLevelThemesPOCO)
            {
                ThemeModel tm = convertPocoToModel(tp);
                tm.SousForums = convertThemesPoco(_themeService.GetThemes(tm.Id));
                firstLevelThemes.Add(tm);
            }
            return firstLevelThemes;
        }

        public List<ThemeModel> convertThemesPoco(List<ThemePOCO> themesPOCO) {
            List<ThemeModel> themes = new List<ThemeModel>();
            
            foreach (ThemePOCO tp in themesPOCO)
            {
                themes.Add(convertPocoToModel(tp));
            }
            return themes;
        }

        public ThemeModel convertPocoToModel(ThemePOCO themePoco) { 
            ThemeDTO td = themePoco.Data;
            return new ThemeModel(td.Id, td.ThemeId, td.Name, td.Description);
        }
    }
}
