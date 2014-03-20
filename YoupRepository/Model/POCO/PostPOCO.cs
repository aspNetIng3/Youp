using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Model
{
    public class PostPOCO
    {
        public PostDTO Data { get; set; }
        public PostPOCO() { this.Data = new PostDTO(); }
        public PostPOCO(PostDTO dto)
        {
            this.Data = dto;
        }
    }
}
