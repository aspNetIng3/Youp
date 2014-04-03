using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Models.DTO;

namespace YoupRepository.Models.POCO
{
    public class BlogsPOCO
    {
        public BlogsDTO Data { get; set; }

        public BlogsPOCO()
        {
            this.Data = new BlogsDTO();
        }

        public BlogsPOCO(BlogsDTO dto)
        {
            this.Data = dto;
        }
    }
}
