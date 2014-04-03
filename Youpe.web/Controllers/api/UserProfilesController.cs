using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Youpe.data.Models;
using Youpe.data.POCO;
using Youpe.web.Models.Repo;

namespace Youpe.web.Controllers.api
{
    public class UserProfilesController : MasterApiController
    {
        // GET api/<controller>
        public IEnumerable<object> Get()
        {
            var _lst = UserProfileRepository.Context.UserProfiles.ToList();

            return _lst;
        }

        // GET api/<controller>/5
        public object Get(string id)
        {
            var _entity = UserProfileRepository.findById<UserProfile>(long.Parse(id));

            if (_entity == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return _entity;
        }

        // POST api/<controller>
        public HttpResponseMessage Post(UserRegisterModel model)
        {
            // Mapper

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.NotModified);
            }

            UserProfile _entity = new UserProfile();

            // mapper
            //Mapper.CreateMap<BlogModel, Blog>();
            //_blog = Mapper.Map<Blog>(form);
            //_blog = Mapper.Map<BlogModel, Blog>(form);

            _entity = UserProfileRepository.Add<UserProfile, UserRegisterModel>(_entity, model);

            var response = Request.CreateResponse<UserProfile>(HttpStatusCode.Created, _entity);
            string uri = Url.Link("DefaultApi", new { id = _entity.Id });
            response.Headers.Location = new Uri(uri);
            return response;

        }

        // PUT api/<controller>/5
        public void Put(string id, UserRegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            UserProfile _myBlog = UserProfileRepository.findById<UserProfile>(long.Parse(id));

            if (_myBlog == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _myBlog = UserProfileRepository.Upd(_myBlog, model);
        }

        // DELETE api/<controller>/5
        public void Delete(string id)
        {
            UserProfile _entity = UserProfileRepository.findById<UserProfile>(long.Parse(id));

            if (_entity == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            UserProfileRepository.Del(_entity);
        }
    }
}