using System;
using System.Collections.Generic;

namespace DemoWebAPI_01.Models
{
    public partial class Blog
    {
        public Blog()
        {
            Blogcomments = new HashSet<Blogcomment>();
        }

        public int BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogImage { get; set; }
        public string? BlogDetail { get; set; }
        public DateTime? PostDate { get; set; }
        public int UserUserId { get; set; }
        public int? BlogStatus { get; set; }
        public int? TimeToRead { get; set; }
        public int BlogTopicBlogTopicId { get; set; }
        public int BlogTagBlogTagId { get; set; }

        public virtual Blogtag BlogTagBlogTag { get; set; } = null!;
        public virtual Blogtopic BlogTopicBlogTopic { get; set; } = null!;
        public virtual User UserUser { get; set; } = null!;
        public virtual ICollection<Blogcomment> Blogcomments { get; set; }
    }
}
