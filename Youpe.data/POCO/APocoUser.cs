using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youpe.data.Sessions;

namespace Youpe.data.POCO
{
    public class APocoUser : APoco
    {
        public APocoUser()
            : base()
        {
            //this.UserId = MySession.Current.GetCurrentUserID;
        }

        public Int64? UserId { get; set; }

        [ForeignKey("UserId")]
        public UserProfile User { get; set; }
    }
}
