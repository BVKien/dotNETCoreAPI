using System;
using System.Collections.Generic;

namespace DemoWebAPI_02.Models
{
    public partial class Answer
    {
        public Answer()
        {
            Questions = new HashSet<Question>();
        }

        public int AnswerId { get; set; }
        public string? Answer1 { get; set; }
        public int QuestionQuestionId { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
