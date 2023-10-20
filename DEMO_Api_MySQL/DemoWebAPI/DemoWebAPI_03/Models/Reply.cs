using System;
using System.Collections.Generic;

namespace DemoWebAPI_03.Models
{
    public partial class Reply
    {
        public int ReplyId { get; set; }
        public string? Content { get; set; }
        public int? AskAskId { get; set; }

        public virtual Ask? AskAsk { get; set; }
    }
}
