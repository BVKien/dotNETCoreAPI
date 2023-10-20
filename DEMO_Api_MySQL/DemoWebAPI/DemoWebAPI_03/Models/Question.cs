using System;
using System.Collections.Generic;

namespace DemoWebAPI_03.Models
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        public int QuestionId { get; set; }
        public string? CorrectAnswer { get; set; }
        public int QuizQuizId { get; set; }

        public virtual Quiz QuizQuiz { get; set; } = null!;
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
