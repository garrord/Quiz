using Quiz.Contracts;
using Quiz.Models;

namespace Quiz.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryQueryRepository _categoryQueryRepo;

        public CategoryManager(ICategoryQueryRepository categoryQueryRepo)
        {
            _categoryQueryRepo = categoryQueryRepo;
        }

        public async Task<IList<CategoryModel>> GetAllCategories()
        {
            IList<CategoryModel> categories = await _categoryQueryRepo.GetAllCategories();
            return categories;
        }
    }
}
