using System;
using System.Collections.Generic;

namespace DemoWebAPI_02.Models
{
    public partial class Likecomment
    {
        public int UserUserId { get; set; }
        public int BlogCommentBlogCommentId { get; set; }

        public virtual Blogcomment BlogCommentBlogComment { get; set; } = null!;
        public virtual User UserUser { get; set; } = null!;
    }
}
