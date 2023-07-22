using Microsoft.AspNetCore.Mvc;
using Quiz.Contracts;
using Quiz.Models;

namespace Quiz.Controllers
{
    [ApiController]
    [Route("api/question")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionManager _questionManager;

        public QuestionController(IQuestionManager questionManager)
        {
            _questionManager = questionManager;
        }

        [HttpGet("{category}")]
        public async Task<ActionResult> GetQuestionsByCategoryName(string category)
        {
            List<QuestionModel> categories = await _questionManager.GetQuestionsByCategoryName(category);
            return new JsonResult(categories);
        }
    }

}
