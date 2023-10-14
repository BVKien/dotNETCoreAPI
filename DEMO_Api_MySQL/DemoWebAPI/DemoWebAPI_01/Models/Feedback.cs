using System;
using System.Collections.Generic;

namespace DemoWebAPI_01.Models
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public string? Feedback1 { get; set; }
        public string UserUserId { get; set; } = null!;
        public string LessonLessonId { get; set; } = null!;
        public int LessonLessonId1 { get; set; }

        public virtual Lesson LessonLessonId1Navigation { get; set; } = null!;
    }
}
