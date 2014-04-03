using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoupRepository.Models.DTO
{
     public abstract class PostsBaseDTO
    {
        public abstract int Id { get; set; }
        public abstract string Title { get; set; }
        public abstract string Content { get; set; }
        public abstract int Visibility { get; set; }
        public abstract int ThemeId { get; set; }
        public abstract int BlogId { get; set; }
        public abstract DateTime CreateAt { get; set; }
        public abstract DateTime UpdateAt { get; set; }
        public abstract DateTime DeleteAt { get; set; }

        static readonly MyNullCatObj nullObj = new MyNullCatObj();
        public static MyNullCatObj Null
        {
            get { return nullObj; }
        }

    }

     // Embedded Null Object class
     public class MyNullCatObj : PostsBaseDTO
     {
         public override int Id { get { return -1; } set { Id = value; } }
         public override string Title
         {
             get { return String.Empty; }
             set { Title = value; }
         }

         public override string Content
         {
             get { return String.Empty; }
             set { Content = value; }
         }


         public override int Visibility { get { return -1; } set { Id = value; } }

         public override int ThemeId { get { return -1; } set { Id = value; } }

         public override int BlogId { get { return -1; } set { Id = value; } }


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
