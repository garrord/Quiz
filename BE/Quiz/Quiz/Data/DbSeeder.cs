using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Quiz.Entities.DbContexts;
using Quiz.Entities;

namespace Quiz.Data
{
    public static class DbSeeder
    {
        public static void SeedCategoryData()
        {
            using (QuizContext context = new QuizContext(new DbContextOptionsBuilder<QuizContext>().
                UseSqlServer("Server=localhost\\MSSQLSERVER04;Database=Quiz;Trusted_Connection=True;TrustServerCertificate=True").Options))
            {
                using (var connection = context.Database.GetDbConnection())
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SET IDENTITY_INSERT dbo.Categories ON;";
                        command.ExecuteNonQuery();
                    }

                    string dataFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Categories.json");
                    string json = File.ReadAllText(dataFilePath);
                    List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(json);
                    //List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(json);
                    context.Categories.AddRange(categories);
                    context.SaveChanges();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SET IDENTITY_INSERT dbo.Categories OFF;";
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
        public static void SeedQuestionData()
        {
            using (QuizContext context = new QuizContext(new DbContextOptionsBuilder<QuizContext>().
                UseSqlServer("Server=localhost\\MSSQLSERVER04;Database=Quiz;Trusted_Connection=True;TrustServerCertificate=True").Options))
            {
                using (var connection = context.Database.GetDbConnection())
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SET IDENTITY_INSERT dbo.Questions ON;";
                        command.ExecuteNonQuery();
                    }

                    string dataFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Questions.json");
                    string json = File.ReadAllText(dataFilePath);
                    List<Question> questions = JsonConvert.DeserializeObject<List<Question>>(json);

                    context.Questions.AddRange(questions);
                    context.SaveChanges();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SET IDENTITY_INSERT dbo.Questions OFF;";
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void SeedAnswerData()
        {
            using (QuizContext context = new QuizContext(new DbContextOptionsBuilder<QuizContext>().
                UseSqlServer("Server=localhost\\MSSQLSERVER04;Database=Quiz;Trusted_Connection=True;TrustServerCertificate=True").Options))
            {
                using (var connection = context.Database.GetDbConnection())
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SET IDENTITY_INSERT dbo.Answers ON;";
                        command.ExecuteNonQuery();
                    }

                    string dataFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Answers.json");
                    string json = File.ReadAllText(dataFilePath);
                    List<Answer> answers = JsonConvert.DeserializeObject<List<Answer>>(json);

                    context.Answers.AddRange(answers);
                    context.SaveChanges();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SET IDENTITY_INSERT dbo.Answers OFF;";
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
