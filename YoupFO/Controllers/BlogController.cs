using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using YoupRepository.Models.DAL.Database;
using YoupRepository.Models.DTO;
using YoupRepository.Models.POCO;
using YoupService.Blog;
using YoupService.Post;

namespace YoupFO.Controllers
{

 
    public class BlogController : Controller
    {

        IBlogService _cs;

        BlogDatabase blogDatabase = new BlogDatabase();
        BlogService blog;
        public static BlogsPOCO myBlog { get; set; }
        public string nameBlog { get; set; }



        public BlogController()
        {
            _cs = new BlogService(blogDatabase);
           //myBlog = _cs.GetBlog("1");

        }

        public ActionResult Getuser(string id)
        {
            //blogDatabase = new BlogDatabase();
            //_cs = new BlogService(blogDatabase);
            myBlog = _cs.GetBlog(id);

            IPostService _csP;

            PostDatabase postDatabase = new PostDatabase();

            _csP = new PostService(postDatabase);

            if(myBlog.Data !=null)
            YoupFO.Controllers.PostController.listPosts = _csP.GetPostsForBlog(YoupFO.Controllers.BlogController.myBlog.Data.Id);

            return RedirectToAction("GestionBlog");
        }

        public ActionResult CreationBlog()
        {

            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult CreationBlog(BlogsDTO item)
        {

            nameBlog = item.Name;
            item.UserId = "3";
            item.IsActive = 1;
             BlogsPOCO current = new BlogsPOCO(item);
            current = _cs.Create(current);
            //return View();
            myBlog = _cs.GetBlog("3");
           return RedirectToAction("GestionBlog");
        }


        public ActionResult GestionBlog()
        {
            if (myBlog.Data != null)
            {
                ViewData["nomBlog"] = myBlog.Data.Name;
                ViewData["IsActive"] = myBlog.Data.IsActive;

                //YoupFO.Controllers.PostController.listPosts = _cs.GetPostsForBlog(106);
            }
               

            return View();
        }

        [System.Web.Mvc.HttpPost]
     
        public ActionResult GestionBlog(int? id)
        {
     
            switch (id)
            {
                case 2:

                    PostDatabase postDatabase = new PostDatabase();
                    IPostService postService = new PostService(postDatabase);
                    List<PostsPOCO> postsBlog = postService.GetPostsForBlog(myBlog.Data.Id);

                    if(postsBlog != null)
                    {
                        foreach (PostsPOCO p in postsBlog)
                        {
                            postService.Delete(p.Data.Id);
                        }
                    }

                    if (!_cs.Delete(myBlog.Data.UserId))
                    {
                        throw new HttpResponseException(HttpStatusCode.NotFound);
                    }
                    else
                    {
                        return Redirect("/");
                    }
                    break;

                case null:

                    if (myBlog.Data.IsActive == 0)
                    {
                        myBlog.Data.IsActive = 1;
                       
                    }
                    else
                    {
                        myBlog.Data.IsActive = 0;
                       
                    }

                    myBlog.Data.UpdateAt = DateTime.Now;
                    if (!_cs.Update(myBlog))
                    {
                        throw new HttpResponseException(HttpStatusCode.NotFound);
                    }
                    break;

                default:
                    break;
            }
         
             Response.Redirect(Request.RawUrl);
            return View();
        }

        public ActionResult ReactiveBlog()
        {
            BlogsPOCO blogUpdate = _cs.GetBlog("1");
          
                    blogUpdate.Data.IsActive = 1;
                    if (!_cs.Update(blogUpdate))
                    {
                        throw new HttpResponseException(HttpStatusCode.NotFound);
                    }


            return View("GestionBlog");
        }


    }
}
