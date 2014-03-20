using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoupRepository.DAL
{
    public interface IBlogDatabase
    {
        List<Blog> getBlogs();

        Blog Create(Blog tpc);

        bool Delete(int id);

        bool Update(Blog tpc);

        Blog getBlog(int id);
    }
}
