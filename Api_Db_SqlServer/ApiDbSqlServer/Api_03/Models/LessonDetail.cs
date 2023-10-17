using System;
using System.Collections.Generic;

namespace Api_03.Models
{
    public partial class LessonDetail
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Lesson { get; set; }

        public virtual Lesson LessonNavigation { get; set; } = null!;
    }
}
