using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YoupRepository.Models.DTO;
using YoupRepository.Models.POCO;
using YoupService.Blog;

namespace YoupFO.Controllers
{
    public class BlogApiController : ApiController
    {
        IBlogService _cs;

        public BlogApiController(IBlogService blogService)
        {
            _cs = blogService;
        }


        /// <summary>
        /// Get all blog
        /// </summary>
        /// <returns></returns>
        public List<BlogsDTO> GetAllBlog()
        {
            List<BlogsDTO> listBlog = new List<BlogsDTO>();
            _cs.GetBlogs().ForEach(c => listBlog.Add(c.Data));
            return listBlog;
        }


        /// <summary>
        /// get blog with userID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public BlogsDTO GetBlog(string userID)
        {
            BlogsPOCO current = _cs.GetBlog(userID);
            if (current.Data == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return current.Data;           

        }

        /// <summary>
        /// Post blog
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public HttpResponseMessage PostBlog(BlogsDTO item)
        {
            BlogsPOCO current = new BlogsPOCO(item);
            current = _cs.Create(current);
            var response = Request.CreateResponse<BlogsDTO>(HttpStatusCode.Created, current.Data);
            string uri = Url.Link("DefaultApi", new { id = current.Data.Id });
            response.Headers.Location = new Uri(uri);
            return response;

        }

        /// <summary>
        /// Put blog
        /// </summary>
        /// <param name="id"></param>
        /// <param name="blog"></param>
        public void PutBlog(int id, BlogsDTO blog)
        {
            BlogsPOCO current = new BlogsPOCO(blog);
            current.Data.Id = id;
            if (!_cs.Update(current))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }            

        }

        /// <summary>
        /// delete blog
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBlog(string id)
        {
            if (!_cs.Delete(id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }                     

        }
    }
}
