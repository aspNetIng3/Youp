using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.DAL
{
    public class PostDatabase : IPostDatabase
    {

        public List<Post> getPosts()
        {
            YoupEntities ye = new YoupEntities();

            return ye.Posts.ToList();
        }

        public Post Create(Post tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Posts.Add(tpc);

            if (ye.SaveChanges() != 0)
                return tpc;

            return null;
        }

        public bool Delete(int id)
        {
            YoupEntities ye = new YoupEntities();

            Post notDisplay = ye.Posts.Where(c => c.Id == id).SingleOrDefault();

            if (notDisplay != null)
            {
                notDisplay.DeletedAt = DateTime.Now;
                return Update(notDisplay);
            }

            return false;
        }

        public bool Update(Post tpc)
        {
            YoupEntities ye = new YoupEntities();

            ye.Entry<Post>(tpc).State = System.Data.EntityState.Modified;

            if (ye.SaveChanges() != 0)
                return true;

            return false;
        }

        public Post getPost(int id)
        {
            YoupEntities ye = new YoupEntities();

            return ye.Posts.Where(c => c.Id == id).SingleOrDefault();
        }
    }
}
