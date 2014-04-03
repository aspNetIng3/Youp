using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Models.DAL.IDatabase
{
    public interface IBlogDatabase
    {
        Blog Create(Blog blog);
        Boolean Delete(string id);
        Boolean Update(Blog blog);
        Blog GetBlog(string userId);
        List<Blog> GetBlogs();
        Blog GetBlogByName(string nameBlog);

    }
}
