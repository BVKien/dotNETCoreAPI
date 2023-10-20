using System;
using System.Collections.Generic;

namespace DemoWebAPI_03.Models
{
    public partial class Course
    {
        public Course()
        {
            Chapters = new HashSet<Chapter>();
            Courseenrolls = new HashSet<Courseenroll>();
            Feedbacks = new HashSet<Feedback>();
        }

        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public string? CourseInfo { get; set; }
        public string? Image { get; set; }
        public string? VideoIntro { get; set; }
        public int? Fee { get; set; }
        public int? Status { get; set; }
        public int CategoryCategoryId { get; set; }
        public int UserUserId { get; set; }

        public virtual Category CategoryCategory { get; set; } = null!;
        public virtual User UserUser { get; set; } = null!;
        public virtual ICollection<Chapter> Chapters { get; set; }
        public virtual ICollection<Courseenroll> Courseenrolls { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
