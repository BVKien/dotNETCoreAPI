using System;
using System.Collections.Generic;

namespace DemoWebAPI_01.Models
{
    public partial class Course
    {
        public Course()
        {
            Courseenrolls = new HashSet<Courseenroll>();
            Lessons = new HashSet<Lesson>();
        }

        public int CourseId { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? CourseInfo { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
        public int UserUserId { get; set; }
        public int CategoryCategoryId { get; set; }
        public int? FeeStatus { get; set; }
        public string? VideoIntro { get; set; }

        public virtual Category CategoryCategory { get; set; } = null!;
        public virtual User UserUser { get; set; } = null!;
        public virtual ICollection<Courseenroll> Courseenrolls { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
