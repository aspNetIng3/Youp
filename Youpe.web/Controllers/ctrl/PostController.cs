using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Youpe.data.Models;
using Youpe.data.POCO;
using Youpe.data.Sessions;
using Youpe.Models.Repo;
using Youpe.web.Controllers.api;

namespace Youpe.web.Controllers.ctrl
{
    public class PostController : MasterController
    {

        public List<Post> listPosts = null;
        public static Post postToModify { get; set; }
        private PostsController _postApi = new PostsController();
        private List<SelectListItem> _visibility = null;

        public List<SelectListItem> Visibility
        {
            get
            {
                if (_visibility == null)
                {
                    _visibility = new List<SelectListItem>();
                    _visibility.Add(new SelectListItem { Text = "Public", Value = "0", Selected = true });
                    _visibility.Add(new SelectListItem { Text = "Privée", Value = "1" });
                    _visibility.Add(new SelectListItem { Text = "Amis", Value = "2" });
                }

                return _visibility;
            }

            set
            {
                _visibility = value;
            }
        }


        public ActionResult New(long _blogId)
        {
            ViewBag.blogId = _blogId;
            ViewBag.Visibility = Visibility;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult New(HttpPostedFileBase file, PostModel model)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    // extract only the fielname
                    var fileName = Path.GetFileName(file.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                    file.SaveAs(path);
                    ViewData["test"] = "<img src=\"" + file.FileName + "\" alt=\"\" />";
                }

                var _entity = _postApi.Post(model);
                return RedirectToAction("GestionBlog", "Blog", new { id = model.BlogId });
            }



            ViewBag.blogId = model.BlogId;
            ViewBag.Visibility = Visibility;
            return View();
        }


        public ActionResult CreatePost()
        {
            ViewBag.blogId = MySession.Current.GetCurrentUserID;
            ViewBag.Visibility = Visibility;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreatePost(HttpPostedFileBase file, PostModel model)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    // extract only the fielname
                    var fileName = Path.GetFileName(file.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                    file.SaveAs(path);
                    ViewData["test"] = "<img src=\"" + file.FileName + "\" alt=\"\" />";
                }

                model.BlogId = MySession.Current.GetCurrentBlogID;
                var _entity = _postApi.Post(model);
                return RedirectToAction("GestionBlog", "Blog", new { id = model.BlogId });
            }

            ViewBag.blogId = model.BlogId;
            ViewBag.Visibility = Visibility;
            return View();
        }


        

        // Comment Post
        public ActionResult CommentPost(long id)
        {

            return View();
        }

        public ActionResult DeletePost(long id)
        {
           _postApi.Delete(id.ToString());
            
            return RedirectToAction("GestionBlog", "Blog", new { id = MySession.Current.GetCurrentBlogID });
        }

        [Authorize]
        [System.Web.Mvc.HttpPost]
        public ActionResult GestionPost(int id, string submitButton)
        {
            //postToModify = PostRepository.FindById<Post>(id);

            switch (submitButton)
            {
                case "Modifier":
                    return RedirectToAction("EditPost");

                case "Supprimer":
                    PostRepository.Del(postToModify);
                    break;


            }

            // Response.Redirect(Request.RawUrl);
            //listPosts = PostRepository.

            return RedirectToAction("GestionBlog", "Blog");
        }


        public ActionResult EditPost(long id)
        {
           
            Post _post = (Post)_postApi.Get(id.ToString());

            if (_post == null)
            {
                bool isPublic = false;
                bool isPrivate = false;
                bool isFriends = false;

                switch (_post.Visibility)
                {
                    case 0:
                        isPublic = true;
                        break;

                    case 1:
                        isPrivate = true;
                        break;

                    case 2:
                        isFriends = true;
                        break;
                    default:
                        break;
                }

                _visibility.Add(new SelectListItem { Text = "Public", Value = "0", Selected = isPublic });
                _visibility.Add(new SelectListItem { Text = "Privée", Value = "1", Selected = isPrivate });
                _visibility.Add(new SelectListItem { Text = "Amis", Value = "2", Selected = isFriends });
                
            }

            ViewBag.Visibility = Visibility;
            ViewBag.post = _post;

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditPost(string id, PostModel model)
        {
            model.BlogId = MySession.Current.GetCurrentBlogID;
            _postApi.Put(id, model);

            return RedirectToAction("GestionBlog", "Blog", new { id = MySession.Current.GetCurrentUserID });

        }


        public ActionResult ListPosts()
        {
            ViewBag.lstPosts = PostRepository.GetPostsForBlog(MySession.Current.GetCurrentBlogID);
            return PartialView();
        }

         public void remplirliste()
         {
             ViewData["Titre"] = postToModify.Title;
             ViewData["Visibility"] = postToModify.Visibility;
             ViewData["Content"] = postToModify.Content;
             List<SelectListItem> items = new List<SelectListItem>();

             bool isPublic = false;
             bool isPrivate = false;
             bool isFriends = false;

             if (postToModify != null)
             {
                 switch (postToModify.Visibility)
                 {
                     case 0:
                         isPublic = true;
                         break;

                     case 1:
                         isPrivate = true;
                         break;

                     case 2:
                         isFriends = true;
                         break;
                     default:
                         break;
                 }
             }


             items.Add(new SelectListItem { Text = "Public", Value = "0", Selected = isPublic });

             items.Add(new SelectListItem { Text = "Privée", Value = "1", Selected = isPrivate });

             items.Add(new SelectListItem { Text = "Amis", Value = "2", Selected = isFriends });

             //  ViewData["Visibility"] = new SelectList(items);

             ViewBag.Visibility = items;

         }
    
    }
}
