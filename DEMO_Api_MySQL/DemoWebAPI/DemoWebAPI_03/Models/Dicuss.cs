using System;
using System.Collections.Generic;

namespace DemoWebAPI_03.Models
{
    public partial class Dicuss
    {
        public Dicuss()
        {
            Asks = new HashSet<Ask>();
        }

        public int DicussId { get; set; }
        public int LessonLessonId { get; set; }

        public virtual Lesson LessonLesson { get; set; } = null!;
        public virtual ICollection<Ask> Asks { get; set; }
    }
}
