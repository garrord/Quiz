using Microsoft.AspNetCore.Mvc;
using Quiz.Contracts;
using Quiz.Models;

namespace Quick.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllCategories()
        {
            IList<CategoryModel> categories = await _categoryManager.GetAllCategories();
            return new JsonResult(categories);
        }
    }
}