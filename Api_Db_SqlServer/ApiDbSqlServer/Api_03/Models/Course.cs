using System;
using System.Collections.Generic;

namespace Api_03.Models
{
    public partial class Course
    {
        public Course()
        {
            Lessons = new HashSet<Lesson>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Category { get; set; }

        public virtual Category? CategoryNavigation { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
