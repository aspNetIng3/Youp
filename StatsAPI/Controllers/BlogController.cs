using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YoupRepository;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace StatsAPI.Controllers.v1
{
    public class BlogController : ApiController
    {
        YoupEntities db = new YoupEntities();

        // GET api/v1/blog/getCountArticle/{blog_id}
        // Retourne le nombre d'article pour un blog
        public HttpResponseMessage GetCountArticle(int id)
        {
            Blog blog = db.Blogs.Find(id);

            if (blog == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Blog not found");
            }
            
            return Request.CreateResponse(blog.Posts.Count().ToString());
        }

        // GET api/v1/blog/GetCountVisit/{blog_id}
        // Retourne le nombre de visite pour un blog
        public HttpResponseMessage GetCountVisit(int id)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }

        // GET api/v1/blog/GetCountLike/{blog_id}
        // Retourne le nombre de like pour un blog
        public HttpResponseMessage GetCountLike(int id)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }

        // GET api/v1/blog/GetCountComment/{blog_id}
        // Retourne le nombre de commentaire pour un blog
        public HttpResponseMessage GetCountComment(int id)
        {
            Blog blog = db.Blogs.Find(id);

            if (blog == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Blog not found");
            }
            
            IEnumerable<Post> posts = db.Posts.Where(c => c.BlogId.Equals(id));

            int value = 0;

            foreach (Post post in posts)
            {
                IEnumerable<BlogComment> temp = post.BlogComments.ToList();
                value += temp.Count();
            }

            return Request.CreateResponse(value);
        }

        // GET api/v1/blog/GetCountCommentByArticle/{post_id}
        // Retourne le nombre de commentaire pour un article
        public HttpResponseMessage GetCountCommentByArticle(int id)
        {
            IEnumerable<Post> posts = db.Posts.Where(c => c.Id == id);
            // replace where by find to manage not found

            int value = 0;

            foreach (Post post in posts)
            {
                IEnumerable<BlogComment> temp = post.BlogComments.ToList();
                value += temp.Count();
            }

            return Request.CreateResponse(value);
        }

        // GET api/v1/blog/GetTopByVisit
        // Retourne le blog_id du blog le plus visité
        public HttpResponseMessage GetTopByVisit()
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "Not Implemented");
        }

    }
}
