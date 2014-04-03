using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
//using System.Web.Http;
using System.Web.Mvc;
using Youpe.data.Models;
using Youpe.data.POCO;
using Youpe.data.Sessions;
using Youpe.Models.Repo;
using Youpe.web.Controllers.api;


namespace Youpe.web.Controllers.ctrl
{
    
    public class BlogController : MasterController
    {
        public Blog myBlog { get; set; }
        public string nameBlog { get; set; }
        public List<Post> lstPosts = new List<Post>();
        private BlogsController _blogApi = new BlogsController();


        public ActionResult ListBlog()
        {
            var _lst = _blogApi.Get();

            ViewBag.lstBlog = _lst;
            return View();
        }


        public ActionResult Getuser(string id)
        {
            var _myBlog = BlogRepository.findById<Blog>(long.Parse(id));

            if (_myBlog != null)
            {
                lstPosts = PostRepository.Context.Posts.Where(p => p.BlogId == _myBlog.Id).ToList();
            }

            ViewBag.lstPosts = lstPosts;
            return RedirectToAction("GestionBlog");
        }

        public ActionResult CreationBlog()
        {
            return View();
        }

        [Authorize]
        [System.Web.Mvc.HttpPost]
        public ActionResult CreationBlog(BlogModel model)
        {

            if (!ModelState.IsValid)
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
            }

            var _blog = _blogApi.Post(model);

            return RedirectToAction("GestionBlog");

        }

        public ActionResult GestionBlog(long id = 0)
        {
            Blog _blog = (Blog)_blogApi.Get(id);
            var lstPosts = new List<object>();

            if (_blog != null)
            {
                ViewData["nomBlog"] = _blog.Name;
                ViewData["IsActive"] = _blog.IsActive;

                MySession.Current.GetCurrentBlogID = id;

                // Get Post

                ViewBag.blog = _blog;
                ViewBag.lstPosts = PostRepository.Context.Posts.Where(p => p.BlogId == _blog.Id).ToList();
            }
            else
            {
                ViewBag.blog = _blog;
                ViewBag.lstPosts = lstPosts;
            }

            return View();
        }

        [Authorize]
        public ActionResult ReactiverBlog(long id)
        {
            Blog _blog = BlogRepository.findById<Blog>(id);
            if (_blog != null)
            {
                _blog.IsActive = true;
                BlogRepository.upd<Blog, object>(_blog);
            }

            return RedirectToAction("GestionBlog", new { id = id });
        }

        [Authorize]
        public ActionResult DesactiverBlog(long id)
        {
            Blog _blog = BlogRepository.findById<Blog>(id);
            if (_blog != null)
            {
                _blog.IsActive = false;
                BlogRepository.upd<Blog, object>(_blog);
            }

            return RedirectToAction("GestionBlog", new { id = id });
        }

        [Authorize]
        public ActionResult DeleteBlog(long id)
        {
            // Delete All Depends
            _blogApi.Delete(id.ToString());

            return RedirectToAction("ListBlog");
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult GestionBlog(int? id)
        {

            switch (id)
            {
                case 2:

                    List<Post> postsBlog = BlogRepository.Context.Posts.Where(p => p.BlogId == myBlog.Id).ToList();

                    if (postsBlog != null)
                    {
                        PostsController _postApi = new PostsController();
                        foreach (Post p in postsBlog)
                        {
                            _postApi.Delete((p.Id).ToString());
                        }
                    }

                    _blogApi.Delete((myBlog.Id).ToString());

                    return Redirect("/");


                case null:

                    if (myBlog.IsActive == false)
                    {
                        myBlog.IsActive = true;

                    }
                    else
                    {
                        myBlog.IsActive = false;

                    }


                    //_blogApi.Put(myBlog.Id, myBlog);

                    break;

                default:
                    break;
            }

            Response.Redirect(Request.RawUrl);
            return View();
        }





        //IBlogService _cs;

        //BlogDatabase blogDatabase = new BlogDatabase();
        //BlogService blog;
        //public static BlogsPOCO myBlog { get; set; }
        //public string nameBlog { get; set; }



        //public BlogController()
        //{
        //    _cs = new BlogService(blogDatabase);
        //   //myBlog = _cs.GetBlog("1");

        //}

        //public ActionResult Getuser(string id)
        //{
        //    //blogDatabase = new BlogDatabase();
        //    //_cs = new BlogService(blogDatabase);
        //    myBlog = _cs.GetBlog(id);

        //    IPostService _csP;

        //    PostDatabase postDatabase = new PostDatabase();

        //    _csP = new PostService(postDatabase);

        //    if(myBlog.Data !=null)
        //    YoupFO.Controllers.PostController.listPosts = _csP.GetPostsForBlog(YoupFO.Controllers.BlogController.myBlog.Data.Id);

        //    return RedirectToAction("GestionBlog");
        //}

        //public ActionResult CreationBlog()
        //{

        //    return View();
        //}

        //[System.Web.Mvc.HttpPost]
        //public ActionResult CreationBlog(BlogsDTO item)
        //{

        //    nameBlog = item.Name;
        //    item.UserId = "3";
        //    item.IsActive = 1;
        //     BlogsPOCO current = new BlogsPOCO(item);
        //    current = _cs.Create(current);
        //    //return View();
        //    myBlog = _cs.GetBlog("3");
        //   return RedirectToAction("GestionBlog");
        //}

        //public ActionResult GestionBlog()
        //{
        //    if (myBlog.Data != null)
        //    {
        //        ViewData["nomBlog"] = myBlog.Data.Name;
        //        ViewData["IsActive"] = myBlog.Data.IsActive;

        //        //YoupFO.Controllers.PostController.listPosts = _cs.GetPostsForBlog(106);
        //    }
               

        //    return View();
        //}

        //[System.Web.Mvc.HttpPost]
        //public ActionResult GestionBlog(int? id)
        //{
     
        //    switch (id)
        //    {
        //        case 2:

        //            PostDatabase postDatabase = new PostDatabase();
        //            IPostService postService = new PostService(postDatabase);
        //            List<PostsPOCO> postsBlog = postService.GetPostsForBlog(myBlog.Data.Id);

        //            if(postsBlog != null)
        //            {
        //                foreach (PostsPOCO p in postsBlog)
        //                {
        //                    postService.Delete(p.Data.Id);
        //                }
        //            }

        //            if (!_cs.Delete(myBlog.Data.UserId))
        //            {
        //                throw new HttpResponseException(HttpStatusCode.NotFound);
        //            }
        //            else
        //            {
        //                return Redirect("/");
        //            }
        //            break;

        //        case null:

        //            if (myBlog.Data.IsActive == 0)
        //            {
        //                myBlog.Data.IsActive = 1;
                       
        //            }
        //            else
        //            {
        //                myBlog.Data.IsActive = 0;
                       
        //            }

        //            myBlog.Data.UpdateAt = DateTime.Now;
        //            if (!_cs.Update(myBlog))
        //            {
        //                throw new HttpResponseException(HttpStatusCode.NotFound);
        //            }
        //            break;

        //        default:
        //            break;
        //    }
         
        //     Response.Redirect(Request.RawUrl);
        //    return View();
        //}

        //public ActionResult ReactiveBlog()
        //{
        //    BlogsPOCO blogUpdate = _cs.GetBlog("1");
          
        //    blogUpdate.Data.IsActive = 1;
        //    if (!_cs.Update(blogUpdate))
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }


        //    return View("GestionBlog");
        //}


    }
}
