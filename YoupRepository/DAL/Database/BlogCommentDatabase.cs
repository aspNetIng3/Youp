using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public class BlogCommentDatabase : IBlogCommentDatabase
    {
        public List<BlogComment> getBlogComments()
        {
            YoupEntities ye = new YoupEntities();

            return ye.BlogComments.ToList();
        }

        public BlogComment Create(BlogComment tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.BlogComments.Add(tpc);

            if (ye.SaveChanges() != 0)
                return tpc;

            return null;
        }

        public bool Delete(int id)
        {
            YoupEntities ye = new YoupEntities();

            BlogComment notDisplay = ye.BlogComments.Where(c => c.Id == id).SingleOrDefault();

            if (notDisplay != null)
            {
                notDisplay.DeletedAt = DateTime.Now;
                return Update(notDisplay);
            }

            return false;
        }

        public bool Update(BlogComment tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Entry<BlogComment>(tpc).State = System.Data.EntityState.Modified;

            if (ye.SaveChanges() != 0)
                return true;

            return false;
        }

        public BlogComment getBlogComment(int id)
        {
            YoupEntities ye = new YoupEntities();

            return ye.BlogComments.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}
