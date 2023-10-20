using System;
using System.Collections.Generic;

namespace DemoWebAPI_03.Models
{
    public partial class Category
    {
        public Category()
        {
            Courses = new HashSet<Course>();
        }

        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
