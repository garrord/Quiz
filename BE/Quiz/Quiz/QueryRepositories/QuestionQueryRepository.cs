using Microsoft.EntityFrameworkCore;
using Quiz.Contracts;
using Quiz.Entities.DbContexts;
using Quiz.Models;

namespace Quiz.QueryRepositories
{
    public class QuestionQueryRepository : IQuestionQueryRepository
    {
        private readonly QuizContext _context;

        public QuestionQueryRepository(QuizContext context)
        {
            _context = context;
        }

        public async Task<List<QuestionModel>> GetQuestionsByCategoryName(string category)
        {
            List<QuestionModel> categories = await (from c in _context.Categories
                                                    join q in _context.Questions on c.CategoryId equals q.CategoryId
                                                    where c.CategoryName == category
                                                    select new QuestionModel()
                                                    {
                                                        QuestionId = q.QuestionId,
                                                        Conundrum = q.Conundrum,
                                                        Answers = (from q2 in _context.Questions
                                                                   join a in _context.Answers on q.QuestionId equals a.QuestionId
                                                                   where q2.Conundrum == q.Conundrum
                                                                   select new AnswerModel()
                                                                   {
                                                                       AnswerText = a.AnswerText,
                                                                       IsCorrect = a.IsCorrect
                                                                   }).ToList()
                                                    }).ToListAsync();
            return categories;
        }
    }
}
