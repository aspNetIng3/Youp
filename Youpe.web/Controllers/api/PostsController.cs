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
    public class PostsController : MasterApiController
    {
        // GET api/<controller>
        public IEnumerable<object> Get()
        {
            var _lst = PostRepository.Context.Posts.ToList();

            return _lst;
        }

        public object Get(string id)
        {
            var _entity = PostRepository.findById<Post>(long.Parse(id));

            if (_entity == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return _entity;
        }

        public HttpResponseMessage Post(PostModel form)
        {
            // Mapper

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            Post _entity = new Post();

            _entity = PostRepository.Add<Post, PostModel>(_entity, form, true);

            

            try
            {
                var response = Request.CreateResponse<Post>(HttpStatusCode.Created, _entity);
                string uri = Url.Link("DefaultApi", new { id = _entity.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch
            {
                return null;
            }

        }

        public HttpResponseMessage Put(string id, PostModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            Post _entity = PostRepository.findById<Post>(long.Parse(id));

            if (_entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                _entity = PostRepository.Upd(_entity, model, false);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);

        }

        public HttpResponseMessage Delete(string id)
        {
            Post _entity = PostRepository.findById<Post>(long.Parse(id));

            if (_entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                PostRepository.Del(_entity);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, _entity);
        }
        
    }
}