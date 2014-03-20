using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Model
{
    public class FavoritePOCO
    {
        public FavoriteDTO Data { get; set; }
        public FavoritePOCO() { this.Data = new FavoriteDTO(); }
        public FavoritePOCO(FavoriteDTO dto)
        {
            this.Data = dto;
        }
    }
}
