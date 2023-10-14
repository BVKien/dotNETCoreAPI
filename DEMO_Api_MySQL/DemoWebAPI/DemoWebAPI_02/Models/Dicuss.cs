using System;
using System.Collections.Generic;

namespace DemoWebAPI_02.Models
{
    public partial class Dicuss
    {
        public Dicuss()
        {
            Asks = new HashSet<Ask>();
            Lessondetails = new HashSet<Lessondetail>();
        }

        public int DicussId { get; set; }
        public int LessonDetailLessonDetailId { get; set; }

        public virtual ICollection<Ask> Asks { get; set; }
        public virtual ICollection<Lessondetail> Lessondetails { get; set; }
    }
}
