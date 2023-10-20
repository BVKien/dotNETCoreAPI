using System;
using System.Collections.Generic;

namespace DemoWebAPI_03.Models
{
    public partial class Blogtag
    {
        public Blogtag()
        {
            Blogs = new HashSet<Blog>();
        }

        public int BlogTagId { get; set; }
        public string? BlogTagName { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
