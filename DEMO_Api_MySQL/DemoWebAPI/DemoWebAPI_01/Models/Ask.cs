using System;
using System.Collections.Generic;

namespace DemoWebAPI_01.Models
{
    public partial class Ask
    {
        public Ask()
        {
            Replies = new HashSet<Reply>();
        }

        public int AskId { get; set; }
        public string? AskDetail { get; set; }
        public int DicussDicussId { get; set; }

        public virtual Dicuss DicussDicuss { get; set; } = null!;
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
