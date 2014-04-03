using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Youpe.data.Models;
using Youpe.data.POCO;
using Youpe.Models.Repo;

namespace Youpe.web.Controllers.api
{
    public class ThemesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Theme> Get()
        {
            var lstBlogs = ThemeRepository.Context.Themes.ToList();

            return lstBlogs;
        }

        public Theme Get(long id)
        {
            var _entity = ThemeRepository.findById<Theme>(id);

            if (_entity == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return _entity;
        }

        public HttpResponseMessage Post(ThemeModel form)
        {
            // Mapper

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            Theme _entity = new Theme();

            _entity = ThemeRepository.Add<Theme, ThemeModel>(_entity, form, true);

            var response = Request.CreateResponse<Theme>(HttpStatusCode.Created, _entity);
            string uri = Url.Link("DefaultApi", new { id = _entity.Id });
            response.Headers.Location = new Uri(uri);
            return response;

        }

        public HttpResponseMessage Put(string id, ThemeModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            Theme _entity = ThemeRepository.findById<Theme>(long.Parse(id));

            if (_entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                _entity = ThemeRepository.Upd(_entity, model, false);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);

        }

        public HttpResponseMessage Delete(string id)
        {
            Theme _entity = ThemeRepository.findById<Theme>(long.Parse(id));

            if (_entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                ThemeRepository.Del(_entity);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, _entity);
        }



        public List<Theme> GetFirstLevelThemes()
        {
            List<Theme> themes = new List<Theme>();
            Get().ToList().ForEach(
                th => { if (th.ThemeId == null) { themes.Add(th); } }
            );
            return themes;
        }

        public List<Theme> GetChields(int parentTheme)
        {
            List<Theme> themes = new List<Theme>();
            Get()
                .Where(th => th.ThemeId == parentTheme)
                .ToList()
                .ForEach(th => { themes.Add(th); });
            return themes;
        }

        
    }
}