using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YoupRepository.Model;
using YoupService.Services;

namespace YoupFo.Controllers
{
    public class ThemeApiController : ApiController
    {
        IThemeService _cs;

        public ThemeApiController() 
        {
            _cs = new ThemeService();
        }
        public ThemeApiController(IThemeService themeService)
        {
            _cs = themeService;
        }
        /// <summary>
        /// Retourne les thèmes 
        /// </summary>
        /// <returns></returns>
        public List<ThemeDTO> GetAll()
        {
            List<ThemeDTO> listThemesDto = new List<ThemeDTO>();
            _cs.GetThemes(1).ForEach(c => listThemesDto.Add(c.Data));
            return listThemesDto;
        }
        /// <summary>
        /// Création d'un thème
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(ThemeDTO item)
        {
            ThemePOCO current = new ThemePOCO(item);
            current = _cs.Create(current);
            var response = Request.CreateResponse<ThemeDTO>(HttpStatusCode.Created, current.Data);
            string uri = Url.Link("DefaultApi", new { id = current.Data.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }
        /// <summary>
        /// Récupération d'un theme par son identifiant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ThemeDTO Get(int id)
        {
            ThemePOCO current = _cs.getTheme(id);
            if (current.Data == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return current.Data;
        }
        /// <summary>
        /// Modification d'un thème
        /// </summary>
        /// <param name="id"></param>
        /// <param name="theme"></param>
        public void Put(int id, ThemeDTO theme)
        {
            ThemePOCO current = new ThemePOCO(theme);
            current.Data.Id = id;
            if (!_cs.Update(current))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        /// <summary>
        /// Suppression d'un thème
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            if (!_cs.Delete(id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

    }
}
