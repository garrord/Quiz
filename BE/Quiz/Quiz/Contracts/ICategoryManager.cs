using Quiz.Models;

namespace Quiz.Contracts
{
    public interface ICategoryManager
    {
        Task<IList<CategoryModel>> GetAllCategories();
    }
}
