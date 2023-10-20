using System;
using System.Collections.Generic;

namespace DemoWebAPI_03.Models
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public string? Feedback1 { get; set; }
        public int UserUserId { get; set; }
        public int CourseCourseId { get; set; }

        public virtual Course CourseCourse { get; set; } = null!;
        public virtual User UserUser { get; set; } = null!;
    }
}
