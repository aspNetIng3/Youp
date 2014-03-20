using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.DAL
{
    public interface IPostDatabase
    {
        List<Post> getPosts();

        Post Create(Post tpc);

        bool Delete(int id);

        bool Update(Post tpc);

        Post getPost(int id);
    }
}
