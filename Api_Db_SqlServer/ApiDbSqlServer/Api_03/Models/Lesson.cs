using System;
using System.Collections.Generic;

namespace Api_03.Models
{
    public partial class Lesson
    {
        public Lesson()
        {
            LessonDetails = new HashSet<LessonDetail>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Course { get; set; }

        public virtual Course? CourseNavigation { get; set; }
        public virtual ICollection<LessonDetail> LessonDetails { get; set; }
    }
}
