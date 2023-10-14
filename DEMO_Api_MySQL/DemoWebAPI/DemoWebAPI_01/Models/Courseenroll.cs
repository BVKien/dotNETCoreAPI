using System;
using System.Collections.Generic;

namespace DemoWebAPI_01.Models
{
    public partial class Courseenroll
    {
        public int CourseEnrollId { get; set; }
        public int? Status { get; set; }
        public string? LessonCurrent { get; set; }
        public DateOnly? EnrollDate { get; set; }
        public int CourseCourseId { get; set; }
        public int UserUserId { get; set; }

        public virtual Course CourseCourse { get; set; } = null!;
        public virtual User UserUser { get; set; } = null!;
    }
}
