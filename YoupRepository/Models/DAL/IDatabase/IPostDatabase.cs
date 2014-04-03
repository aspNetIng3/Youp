using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Models.DAL.IDatabase
{

    public interface IPostDatabase
    {
        List<Post> GetPosts();
        Post Create(Post post);
        Boolean Delete(int id);
        Boolean Update(Post blog);
        List<Post> GetPostsForBlog(int blogId);
        Post GetPost( int id);

    }
}
