using System;
using System.Collections.Generic;

namespace DemoWebAPI_03.Models
{
    public partial class Answer
    {
        public int AnswerId { get; set; }
        public string? Answer1 { get; set; }
        public int QuestionQuestionId { get; set; }

        public virtual Question QuestionQuestion { get; set; } = null!;
    }
}
