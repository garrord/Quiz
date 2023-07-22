using Quiz.Contracts;
using Quiz.Models;

namespace Quiz.Managers
{
    public class QuestionManager : IQuestionManager
    {
        private readonly IQuestionQueryRepository _questionQueryRepository;

        public QuestionManager(IQuestionQueryRepository questionQueryRepository)
        {
            _questionQueryRepository = questionQueryRepository;
        }

        public async Task<List<QuestionModel>> GetQuestionsByCategoryName(string category)
        {
            List<QuestionModel> categories = await _questionQueryRepository.GetQuestionsByCategoryName(category);
            return categories;
        }
    }
}
