using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youpe.data.POCO
{
    class APoco1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }


        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Int64? CreatedUserID { get; set; }
        public Int64? UpdatedUserID { get; set; }
        public string CreatedIP { get; set; }
        public string UpdatedIP { get; set; }
        public bool? IsDesactiver { get; set; }
    }
}
