using System;
using System.Collections.Generic;

namespace DemoWebAPI_03.Models
{
    public partial class Chapter
    {
        public Chapter()
        {
            Lessons = new HashSet<Lesson>();
            Notes = new HashSet<Note>();
            Quizzes = new HashSet<Quiz>();
        }

        public int ChapterId { get; set; }
        public string? Name { get; set; }
        public int CourseCourseId { get; set; }

        public virtual Course CourseCourse { get; set; } = null!;
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
