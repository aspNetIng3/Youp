using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using YoupFO.Models;
using YoupRepository.Models.DAL.Database;
using YoupRepository.Models.DTO;
using YoupRepository.Models.POCO;
using YoupService.Blog;
using YoupService.Post;

namespace YoupFO.Controllers
{
    public class PostController : Controller
    {

        IPostService _cs;

        PostDatabase postDatabase = new PostDatabase();

        public static PostsPOCO postToModify { get; set; }

        public static List<PostsPOCO> listPosts { get; set; }

        public PostController()
        {
            _cs = new PostService(postDatabase);
            listPosts = new List<PostsPOCO>();

        }

        [System.Web.Mvc.HttpPost]
        public ActionResult CreatePost(HttpPostedFileBase file, PostsDTO item)
        {

            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
                ViewData["test"] = "<img src=\""+file.FileName+"\" alt=\"\" />";
            }

            if (item.Title != null)
            {
                item.BlogId = YoupFO.Controllers.BlogController.myBlog.Data.Id;
                item.ThemeId = 5;

                PostsPOCO current = new PostsPOCO(item);
                current = _cs.Create(current);

                listPosts = _cs.GetPostsForBlog(YoupFO.Controllers.BlogController.myBlog.Data.Id);

                return RedirectToAction("GestionBlog", "Blog");
            }
            else
            {
                List<SelectListItem> items = new List<SelectListItem>();

                items.Add(new SelectListItem { Text = "Public", Value = "0", Selected = true });

                items.Add(new SelectListItem { Text = "Privée", Value = "1" });

                items.Add(new SelectListItem { Text = "Amis", Value = "2" });

                ViewBag.Visibility = items;

               
            }

            return View();
        }


        [System.Web.Mvc.HttpPost]

        public ActionResult GestionPost(int id, string submitButton)
        {

            switch (submitButton)
            {
                case "Modifier":
                    postToModify = _cs.GetPost(id);
              
                    return RedirectToAction("EditPost");
                
                case "Supprimer":
                    _cs.Delete(id);
                    break;
                   
             
            }

           // Response.Redirect(Request.RawUrl);
            listPosts = _cs.GetPostsForBlog(YoupFO.Controllers.BlogController.myBlog.Data.Id);

            return RedirectToAction("GestionBlog", "Blog");
        }

        public ActionResult EditPost(PostsDTO item)
        {

            remplirliste();

            var model = new YoupFO.Models.Post();
            if (postToModify.Data != null)
            {
                model.content = postToModify.Data.Content;
                model.visibility = postToModify.Data.Visibility;
            }
             
            return View(model); 
            
           // return View();
        }


         [System.Web.Mvc.HttpPost]
        public ActionResult EditPost(int ? id, PostsDTO post)
        {
            remplirliste();

           PostsPOCO current = postToModify;

            current.Data.Title = post.Title;
             current.Data.Content = post.Content;
             current.Data.Visibility = post.Visibility;

            if (!_cs.Update(current))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return RedirectToAction("Getuser", "Blog", new { id = YoupFO.Controllers.BlogController.myBlog.Data.UserId });
        }


         public ActionResult ListPosts()
        {

            listPosts = _cs.GetPostsForBlog(YoupFO.Controllers.BlogController.myBlog.Data.Id);
            return PartialView();
        }

         public void remplirliste()
         {
             ViewData["Titre"] = postToModify.Data.Title;
             ViewData["Visibility"] = postToModify.Data.Visibility;
             ViewData["Content"] = postToModify.Data.Content;
             List<SelectListItem> items = new List<SelectListItem>();

             bool isPublic = false;
             bool isPrivate = false;
             bool isFriends = false;

             if (postToModify.Data != null)
             {
                 switch (postToModify.Data.Visibility)
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


             items.Add(new SelectListItem { Text = "Public", Value = "0", Selected=isPublic});

             items.Add(new SelectListItem { Text = "Privée", Value = "1", Selected = isPrivate });

             items.Add(new SelectListItem { Text = "Amis", Value = "2", Selected = isFriends });

           //  ViewData["Visibility"] = new SelectList(items);

             ViewBag.Visibility = items;

         }

    
    }
}
