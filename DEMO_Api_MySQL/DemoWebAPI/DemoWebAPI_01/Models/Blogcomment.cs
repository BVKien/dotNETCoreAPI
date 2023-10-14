using System;
using System.Collections.Generic;

namespace DemoWebAPI_01.Models
{
    public partial class Blogcomment
    {
        public int BlogCommentId { get; set; }
        public int? BlogId { get; set; }
        public int? UserId { get; set; }
        public int? Level { get; set; }
        public int? OriginCommentId { get; set; }
        public int? ReplyToUser { get; set; }
        public string? Content { get; set; }
        public DateTime? Publish { get; set; }

        public virtual Blog? Blog { get; set; }
        public virtual User? ReplyToUserNavigation { get; set; }
        public virtual User? User { get; set; }
    }
}
