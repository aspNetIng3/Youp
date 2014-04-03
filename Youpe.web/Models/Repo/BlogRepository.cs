using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youpe.data.POCO;
using Youpe.web.Models;

namespace Youpe.Models.Repo
{
    public class BlogRepository : YoupeRepository
    {
        public IEnumerable<Blog> GetAll()
        {
            var lstBlog = Context.Blogs.ToList();

            return lstBlog;
        }
    }
}
