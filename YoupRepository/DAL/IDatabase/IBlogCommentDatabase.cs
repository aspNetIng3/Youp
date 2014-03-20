using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.DAL
{
    public interface IBlogCommentDatabase
    {
        List<BlogComment> getBlogComments();

        BlogComment Create(BlogComment tpc);

        bool Delete(int id);

        bool Update(BlogComment tpc);

        BlogComment getBlogComment(int id);
    }
}
