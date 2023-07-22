using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Quiz.Entities.DbContexts
{
    public class QuizContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Category> Categories { get; set; }

        public QuizContext(DbContextOptions<QuizContext> options) : base(options)
        {

        }
    }
}
