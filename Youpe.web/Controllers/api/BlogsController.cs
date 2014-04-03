using AutoMapper;
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
using Youpe.web.Controllers;


namespace Youpe.web.Controllers.api
{
    public class BlogsController : MasterApiController
    {
        // GET api/<controller>
        public IEnumerable<Blog> Get()
        {
            var lstBlogs = BlogRepository.Context.Blogs.ToList();

            return lstBlogs;
        }

        public Blog Get(long id)
        {
            var _entity = BlogRepository.findById<Blog>(id);

            if (_entity == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return _entity;
        }

        public HttpResponseMessage Post(BlogModel form)
        {
            // Mapper

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            Blog _entity = new Blog();

            _entity = BlogRepository.Add<Blog, BlogModel>(_entity, form,true);

            var response = Request.CreateResponse<Blog>(HttpStatusCode.Created, _entity);
            string uri = Url.Link("DefaultApi", new { id = _entity.Id });
            response.Headers.Location = new Uri(uri);
            return response;

        }

        public HttpResponseMessage Put(string id, BlogModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            Blog _entity = BlogRepository.findById<Blog>(long.Parse(id));

            if (_entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                _entity = BlogRepository.Upd(_entity, model, false);
            }
            catch(DbUpdateConcurrencyException  ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
            
        }

        public HttpResponseMessage Delete(string id)
        {
            Blog _entity = BlogRepository.findById<Blog>(long.Parse(id));

            if (_entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                BlogRepository.Del(_entity);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, _entity);
        }
        

    }
}