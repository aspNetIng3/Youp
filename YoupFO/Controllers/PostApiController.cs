using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YoupRepository.Models.DTO;
using YoupRepository.Models.POCO;
using YoupService.Post;

namespace YoupFO.Controllers
{
    public class PostApiController : ApiController
    {
         IPostService _cs;

         public PostApiController(IPostService postService)
        {
            _cs = postService;
        }


       /// <summary>
       /// Get all post
       /// </summary>
       /// <returns></returns>
        public List<PostsDTO> GetAllPost()
        {
            List<PostsDTO> listPost = new List<PostsDTO>();
            _cs.GetPosts().ForEach(c => listPost.Add(c.Data));
            return listPost;
        }


       /// <summary>
       /// Get post
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public PostsDTO GetPost(int id)
        {
            PostsPOCO current = _cs.GetPost(id);
            if (current.Data == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return current.Data;           

        }

        /// <summary>
        /// Post an article
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public HttpResponseMessage PostPost(PostsDTO item)
        {
            PostsPOCO current = new PostsPOCO(item);
            current = _cs.Create(current);
            var response = Request.CreateResponse<PostsDTO>(HttpStatusCode.Created, current.Data);
            string uri = Url.Link("DefaultApi", new { id = current.Data.Id });
            response.Headers.Location = new Uri(uri);
            return response;

        }

       /// <summary>
       /// put an article
       /// </summary>
       /// <param name="id"></param>
       /// <param name="post"></param>
        public void PutPost(int id, PostsDTO post)
        {
            PostsPOCO current = new PostsPOCO(post);
            current.Data.Id = id;
            if (!_cs.Update(current))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }            

        }

       /// <summary>
       /// delete an article
       /// </summary>
       /// <param name="id"></param>
        public void DeletePost(int id)
        {
            if (!_cs.Delete(id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }                     

        }
    }
}
