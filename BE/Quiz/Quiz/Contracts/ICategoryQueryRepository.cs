using Quiz.Models;

namespace Quiz.Contracts
{
    public interface ICategoryQueryRepository
    {
        Task<IList<CategoryModel>> GetAllCategories();
    }
}
