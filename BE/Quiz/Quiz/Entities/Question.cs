using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Entities
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string Conundrum { get; set; }
        public List<Answer> Answers { get; set; }
        public Category Category { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
    }
}
