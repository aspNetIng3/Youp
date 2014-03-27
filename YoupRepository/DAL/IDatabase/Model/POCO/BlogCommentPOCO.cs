using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Model
{
    public class BlogCommentPOCO
    {
        public BlogCommentDTO Data { get; set; }
        public BlogCommentPOCO() { this.Data = new BlogCommentDTO(); }
        public BlogCommentPOCO(BlogCommentDTO dto)
        {
            this.Data = dto;
        }
    }
}
