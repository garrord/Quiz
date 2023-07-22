using Quiz.Models;

namespace Quiz.Contracts
{
    public interface IQuestionQueryRepository
    {
        Task<List<QuestionModel>> GetQuestionsByCategoryName(string category);
    }
}
