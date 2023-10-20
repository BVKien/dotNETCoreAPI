using System;
using System.Collections.Generic;

namespace DemoWebAPI_03.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            Questions = new HashSet<Question>();
        }

        public int QuizId { get; set; }
        public int ChapterChapterId { get; set; }

        public virtual Chapter ChapterChapter { get; set; } = null!;
        public virtual ICollection<Question> Questions { get; set; }
    }
}
