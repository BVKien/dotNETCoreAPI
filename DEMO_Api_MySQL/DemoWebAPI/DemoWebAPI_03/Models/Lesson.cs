using System;
using System.Collections.Generic;

namespace DemoWebAPI_03.Models
{
    public partial class Lesson
    {
        public Lesson()
        {
            Dicusses = new HashSet<Dicuss>();
        }

        public int LessonId { get; set; }
        public string? Title { get; set; }
        public string? Video { get; set; }
        public TimeOnly? Time { get; set; }
        public int ChapterChapterId { get; set; }

        public virtual Chapter ChapterChapter { get; set; } = null!;
        public virtual ICollection<Dicuss> Dicusses { get; set; }
    }
}
