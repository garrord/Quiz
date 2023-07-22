using System.ComponentModel.DataAnnotations;

namespace Quiz.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Question> Questions { get; set; }
    }
}
