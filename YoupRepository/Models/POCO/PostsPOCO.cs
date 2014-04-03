using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.Models.DTO;

namespace YoupRepository.Models.POCO
{
    public class PostsPOCO
    {
        public PostsDTO Data { get; set; }

        public PostsPOCO()
        {
            this.Data = new PostsDTO();
        }

        public PostsPOCO(PostsDTO dto)
        {
            this.Data = dto;
        }
    }
}
