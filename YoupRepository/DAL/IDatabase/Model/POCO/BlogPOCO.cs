using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Model
{
    public class BlogPOCO
    {
        public BlogDTO Data { get; set; }
        public BlogPOCO() { this.Data = new BlogDTO(); }
        public BlogPOCO(BlogDTO dto)
        {
            this.Data = dto;
        }
    }
}
