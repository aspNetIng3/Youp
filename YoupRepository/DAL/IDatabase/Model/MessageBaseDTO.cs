using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoupRepository.DAL;

namespace YoupRepository.Model
{
    public abstract class MessageBaseDTO
    {
        public abstract int Id { get; set; }
        public abstract string Title { get; set; }
        public abstract string Content { get; set; }
        public abstract int ThreadId { get; set; }
        public abstract string UserId { get; set; }
        public abstract System.DateTime CreatedAt { get; set; }
        public abstract System.DateTime UpdatedAt { get; set; }
        public abstract Nullable<System.DateTime> DeletedAt { get; set; }

        public virtual Thread Thread { get; set; }
        public virtual User User { get; set; }

        static readonly NullMsgObj nullObj = new NullMsgObj();
        public static NullMsgObj Null
        {
            get { return nullObj; }
        }
    }

    public class NullMsgObj : MessageBaseDTO
    {
        public override int Id { get { return 0; } set { Id = value; } }
        public override string Title { get { return String.Empty; } set { Title = value; } }
        public override string Content { get { return String.Empty; } set { Content = value; } }
        public override string UserId { get { return String.Empty; } set { UserId = value; } }
        public override int ThreadId { get { return 0; } set { ThreadId = value; } }
        public override System.DateTime CreatedAt { get { return new DateTime(); } set { CreatedAt = value; } }
        public override System.DateTime UpdatedAt { get { return new DateTime(); } set { UpdatedAt = value; } }
        public override Nullable<System.DateTime> DeletedAt { get { return new DateTime(); } set { DeletedAt = value; } }

        public override Thread Thread { get { return new Thread(); } set { Thread = value; } }
        public override User User { get { return new User(); } set { User = value; } }
    }

}
