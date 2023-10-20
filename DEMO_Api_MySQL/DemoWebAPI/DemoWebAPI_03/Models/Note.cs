using System;
using System.Collections.Generic;

namespace DemoWebAPI_03.Models
{
    public partial class Note
    {
        public int NoteId { get; set; }
        public string? Content { get; set; }
        public int ChapterChapterId { get; set; }
        public int UserUserId { get; set; }

        public virtual Chapter ChapterChapter { get; set; } = null!;
        public virtual User UserUser { get; set; } = null!;
    }
}
