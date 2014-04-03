using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Models.DTO
{
    public abstract class BlogsBaseDTO
    {

        public abstract int Id { get; set; }
        public abstract string Name { get; set; }
        public abstract int IsActive { get; set; }
        public abstract string UserId { get; set; }
        public abstract DateTime CreateAt { get; set; }
        public abstract DateTime UpdateAt { get; set; }
        public abstract DateTime DeleteAt { get; set; }

        // Singleton
        static readonly NullCatObj nullObj = new NullCatObj();
        public static NullCatObj Null
        {
            get { return nullObj; }
        }

       
    }

    // Embedded Null Object class
    public class NullCatObj : BlogsBaseDTO
    {
        public override int Id { get { return -1; } set { Id = value; } }
        public override string Name
        {
            get { return String.Empty; }
            set { Name = value; }
        }

        //public override bool IsActive
        //{
        //    get
        //    {
        //        return false;
        //    }
        //    set
        //    {
        //        IsActive = value;
        //    }
        //}

        public override int IsActive { get { return -1; } set { Id = value; } }

        public override string UserId
        {
            get { return String.Empty; }
            set { UserId = value; }
        }

        public override DateTime CreateAt
        {
            get
            {
                return DateTime.Now;
            }
            set
            {
                CreateAt = value;
            }
        }

        public override DateTime UpdateAt
        {
            get
            {
                return DateTime.Now;
            }
            set
            {
                UpdateAt = value;
            }
        }

        public override DateTime DeleteAt
        {
            get
            {
                return DateTime.Now;
            }
            set
            {
                DeleteAt = value;
            }
        }
    }
}
