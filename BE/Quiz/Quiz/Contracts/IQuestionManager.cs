using Quiz.Models;

namespace Quiz.Contracts
{
    public interface IQuestionManager
    {
        Task<List<QuestionModel>> GetQuestionsByCategoryName(string category);
    }
}
