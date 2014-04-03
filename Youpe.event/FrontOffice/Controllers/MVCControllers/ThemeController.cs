using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoupRepository.Model.POCO;
using YoupRepository.Model.DTO;
using YoupRepository.DAL;
using YoupService;


namespace FrontOffice.Controllers.MVCControllers
{
    public class ThemeController : Controller
    {
        //
        // GET: /Theme/
        ThemeService _themeService;
        ThemeDatabase _ThemeDatabase;

        public ThemeController()
        {
          
            _ThemeDatabase = new ThemeDatabase();
            _themeService = new ThemeService(_ThemeDatabase);
        }


        public ActionResult Index(int id)
        {
            ThemePOCO aTheme= _themeService.getThemeById(id);
            ViewBag.theme = aTheme;

            return View();
        }

    }
}
