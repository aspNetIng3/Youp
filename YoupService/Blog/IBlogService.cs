    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Models;
using YoupRepository.Models.POCO;
namespace YoupService.Blog
{
    public interface IBlogService
    {
        BlogsPOCO Create(BlogsPOCO upc);
        bool Delete(string id);
        bool Update(BlogsPOCO upc);
        BlogsPOCO GetBlog(string userId);
        BlogsPOCO GetBlogByName(string nameBlog);

        List<BlogsPOCO> GetBlogs();
    }
}
