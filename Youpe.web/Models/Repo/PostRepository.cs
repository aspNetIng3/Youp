using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youpe.data.POCO;
using Youpe.web.Models;

namespace Youpe.Models.Repo
{
    public class PostRepository : YoupeRepository
    {

        /// <summary>
        /// Get article with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Post GetPost(int id)
        {
            Post _myPost = findById<Post>(id);

            if (_myPost == null)
            {
                throw new Exception();
            }

            return _myPost;
        }


        /// <summary>
        /// Get article from blog
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        public static List<Post> GetPostsForBlog(long blogId)
        {
            List<Post> listPost = new List<Post>();

            listPost = GetPosts();
            listPost = listPost.Where(prop=>prop.BlogId == blogId).ToList();


            return listPost;

        }

        /// <summary>
        /// Get all articles
        /// </summary>
        /// <returns></returns>
        public static List<Post> GetPosts()
        {
            List<Post> listPost = Context.Posts.ToList();
            return listPost;
        }
    }
}
