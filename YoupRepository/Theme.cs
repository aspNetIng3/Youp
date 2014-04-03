//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YoupRepository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Theme
    {
        public Theme()
        {
            this.Events = new HashSet<Event>();
            this.Posts = new HashSet<Post>();
            this.Themes1 = new HashSet<Theme>();
            this.Threads = new HashSet<Thread>();
            this.UserYoups = new HashSet<UserYoup>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> ThemeId { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public System.DateTime UpdatedAt { get; set; }
        public Nullable<System.DateTime> DeletedAt { get; set; }
    
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Theme> Themes1 { get; set; }
        public virtual Theme Theme1 { get; set; }
        public virtual ICollection<Thread> Threads { get; set; }
        public virtual ICollection<UserYoup> UserYoups { get; set; }
    }
}
