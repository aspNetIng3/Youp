using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public class BlogDatabase : IBlogDatabase
    {
        public List<Blog> getBlogs()
        {
            YoupEntities ye = new YoupEntities();

            return ye.Blogs.ToList();
        }

        public Blog Create(Blog tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Blogs.Add(tpc);

            if (ye.SaveChanges() != 0)
                return tpc;

            return null;
        }

        public bool Delete(int id)
        {
            YoupEntities ye = new YoupEntities();

            Blog notDisplay = ye.Blogs.Where(c => c.Id == id).SingleOrDefault();

            if (notDisplay != null)
            {
                notDisplay.DeletedAt = DateTime.Now;
                return Update(notDisplay);
            }

            return false;
        }

        public bool Update(Blog tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Entry<Blog>(tpc).State = System.Data.EntityState.Modified;

            if (ye.SaveChanges() != 0)
                return true;

            return false;
        }

        public Blog getBlog(int id)
        {
            YoupEntities ye = new YoupEntities();

            return ye.Blogs.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}
