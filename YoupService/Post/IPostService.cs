using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Models;
using YoupRepository.Models.POCO;

namespace YoupService.Post
{
    public interface IPostService
    {
        PostsPOCO Create(PostsPOCO upc);
        bool Delete(int id);
        bool Update(PostsPOCO upc);
        PostsPOCO GetPost(int id);
        List<PostsPOCO> GetPostsForBlog(int blogId);
        List<PostsPOCO> GetPosts();
    }
}
