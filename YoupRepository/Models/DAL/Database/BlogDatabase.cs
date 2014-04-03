using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Models.DAL.IDatabase;

namespace YoupRepository.Models.DAL.Database
{
    public class BlogDatabase : IBlogDatabase
    {
        public Blog Create(Blog blog)
        {
           
            YoupEntities youp = new YoupEntities();
            youp.Blogs.Add(blog);
            if (youp.SaveChanges() == 1)
                return blog;

            return null;
        }

        public bool Delete(string id)
        {
            YoupEntities youp = new YoupEntities();
            Blog blog = youp.Blogs.Where(c => c.UserId == id).SingleOrDefault();

            if (blog != null)
            {
                youp.Blogs.Remove(blog);
                youp.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(Blog blog)
        {
            YoupEntities youp = new YoupEntities();
            youp.Entry(blog).State = System.Data.EntityState.Modified;
            if (youp.SaveChanges() == 1)
                return true;

            return false;
        }

        public Blog GetBlog(string userId)
        {
            YoupEntities youp = new YoupEntities();
            return youp.Blogs.Where(c => c.UserId == userId).SingleOrDefault();
        }


        public Blog GetBlogByName(string nameBlog)
        {
            YoupEntities youp = new YoupEntities();
            return youp.Blogs.Where(c => c.Name == nameBlog).SingleOrDefault();
        }


        public List<Blog> GetBlogs()
        {
            YoupEntities youp = new YoupEntities();
            return youp.Blogs.ToList();
        }


    }
}
