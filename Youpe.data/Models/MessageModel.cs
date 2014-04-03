using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youpe.data.POCO;

namespace Youpe.data.Models
{
    public class MessageModel
    {
        
        public Int64? Id { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public int ThreadId { get; set; }
        public int UserId { get; set; }


        //public static Message Mapping()
        //{
        //    Message _msg = new Message();

        //    Mapper

        //}
    }
}
