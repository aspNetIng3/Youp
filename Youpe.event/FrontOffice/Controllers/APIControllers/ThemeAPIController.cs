using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YoupService;
using YoupRepository.DAL;
using YoupRepository.Model.POCO;
using YoupRepository.Model.DTO;

namespace FrontOffice.Controllers.APIControllers
{
    public class ThemeAPIController : ApiController
    {

        IThemeService _iThemeService;
        ThemeDatabase _themeDatabase;
        ThemeService _themeService;

        public ThemeAPIController()
        {
            _themeDatabase = new ThemeDatabase();
            _themeService = new ThemeService(_themeDatabase);
        }

        [HttpGet]
        public IEnumerable<ThemePOCO> allThemes()
        {
            List<ThemePOCO> list = _themeService.getAllThemes();
            if (list == null)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return list;

        }



    }
}
