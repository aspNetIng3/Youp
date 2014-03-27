using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Model
{
    public class ThreadPOCO
    {
        public ThreadDTO Data { get; set; }
        public ThreadPOCO() { this.Data = new ThreadDTO(); }
        public ThreadPOCO(ThreadDTO dto) {
            this.Data = dto;
        }
    }
}
