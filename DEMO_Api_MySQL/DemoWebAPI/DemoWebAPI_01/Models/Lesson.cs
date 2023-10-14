using System;
using System.Collections.Generic;

namespace DemoWebAPI_01.Models
{
    public partial class Lesson
    {
        public Lesson()
        {
            Feedbacks = new HashSet<Feedback>();
            Lessondetails = new HashSet<Lessondetail>();
            Quizzes = new HashSet<Quiz>();
        }

        public int LessonId { get; set; }
        public string? Name { get; set; }
        public int CourseCourseId { get; set; }

        public virtual Course CourseCourse { get; set; } = null!;
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Lessondetail> Lessondetails { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
