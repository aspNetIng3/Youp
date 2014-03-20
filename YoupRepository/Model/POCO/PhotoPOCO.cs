using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Model
{
    public class PhotoPOCO
    {
        public PhotoDTO Data { get; set; }
        public PhotoPOCO() { this.Data = new PhotoDTO(); }
        public PhotoPOCO(PhotoDTO dto)
        {
            this.Data = dto;
        }
    }
}
