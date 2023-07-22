using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Entities
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public Question Question { get; set; }
        [ForeignKey("QuestionId")]
        public int QuestionId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
