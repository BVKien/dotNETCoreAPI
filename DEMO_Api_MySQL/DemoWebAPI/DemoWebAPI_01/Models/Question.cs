using System;
using System.Collections.Generic;

namespace DemoWebAPI_01.Models
{
    public partial class Question
    {
        public int QuestionId { get; set; }
        public string? CorrectAnswer { get; set; }
        public int? QuizQuizId { get; set; }
        public int QuizQuizId1 { get; set; }
        public int AnswerAnswerId { get; set; }

        public virtual Answer AnswerAnswer { get; set; } = null!;
        public virtual Quiz QuizQuizId1Navigation { get; set; } = null!;
    }
}
