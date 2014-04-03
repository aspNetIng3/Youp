using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youpe.data.Sessions;

namespace Youpe.data.POCO
{
    public class APoco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string CreatedIp { get; set; }
        public string UpdatedIp { get; set; }

        public APoco()
        {
            this.Update();
        }


        private void Update()
        {
            if (this.Id == 0)
            {
                this.CreatedAt = DateTime.Now;
                this.CreatedIp = MySession.Current.GetCurrentIP;
            }

            this.UpdatedAt = DateTime.Now;
            this.UpdatedIp = MySession.Current.GetCurrentIP;
        }

        
    }
}
