using System;
using System.Collections.Generic;

namespace DemoWebAPI_02.Models
{
    public partial class Lessondetail
    {
        public int LessonDetailId { get; set; }
        public string? Title { get; set; }
        public string? Video { get; set; }
        public string? Note { get; set; }
        public TimeOnly? Time { get; set; }
        public int LessonLessonId { get; set; }
        public int DicussDicussId { get; set; }

        public virtual Dicuss DicussDicuss { get; set; } = null!;
        public virtual Lesson LessonLesson { get; set; } = null!;
    }
}
