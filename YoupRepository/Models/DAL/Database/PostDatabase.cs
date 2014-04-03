using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Models.DAL.IDatabase;

namespace YoupRepository.Models.DAL.Database
{
    public class PostDatabase : IPostDatabase
    {

        public Post Create(Post post)
        {
            YoupEntities youp = new YoupEntities();
            youp.Posts.Add(post);
            if (youp.SaveChanges() == 1)
                return post;

            return null;
        }

        public bool Delete(int id)
        {
            YoupEntities youp = new YoupEntities();
            Post post = youp.Posts.Where(c => c.Id == id).SingleOrDefault();

            if (post != null)
            {
                youp.Posts.Remove(post);
                youp.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(Post post)
        {
            YoupEntities youp = new YoupEntities();
            youp.Entry(post).State = System.Data.EntityState.Modified;
            if (youp.SaveChanges() == 1)
                return true;

            return false;
        }

        public List<Post> GetPostsForBlog(int blogId)
        {
            YoupEntities youp = new YoupEntities();
            return youp.Posts.Where(c => c.BlogId == blogId).ToList();
        }

        public Post GetPost( int id)
        {
            YoupEntities youp = new YoupEntities();
            return youp.Posts.Where(c => c.Id == id).SingleOrDefault();
        }

        public List<Post> GetPosts()
        {
            YoupEntities youp = new YoupEntities();
            return youp.Posts.ToList();
        }
    }
}
