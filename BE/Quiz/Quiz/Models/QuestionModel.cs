namespace Quiz.Models
{
    public class QuestionModel
    {
        public int QuestionId { get; set; }
        public string Conundrum { get; set; }
        public List<AnswerModel> Answers { get; set; }
    }
}
