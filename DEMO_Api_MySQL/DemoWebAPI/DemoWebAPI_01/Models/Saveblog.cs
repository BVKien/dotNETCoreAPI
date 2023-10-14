using System;
using System.Collections.Generic;

namespace DemoWebAPI_01.Models
{
    public partial class Saveblog
    {
        public int UserUserId { get; set; }
        public int BlogBlogId { get; set; }
        public DateTime? SaveDay { get; set; }

        public virtual Blog BlogBlog { get; set; } = null!;
        public virtual User UserUser { get; set; } = null!;
    }
}
