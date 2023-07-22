using Microsoft.EntityFrameworkCore;
using Quiz.Contracts;
using Quiz.Entities.DbContexts;
using Quiz.Managers;
using Quiz.QueryRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<QuizContext>(dbContextOptions => dbContextOptions
    .UseSqlServer("Server=localhost\\MSSQLSERVER04;Database=Quiz;Trusted_Connection=True;TrustServerCertificate=True"));
builder.Services.AddTransient<ICategoryQueryRepository, CategoryQueryRepository>();
builder.Services.AddTransient<ICategoryManager, CategoryManager>();
builder.Services.AddTransient<IQuestionQueryRepository, QuestionQueryRepository>();
builder.Services.AddTransient<IQuestionManager, QuestionManager>();
builder.Services.AddCors(options => options.AddPolicy("AllowSpecificOrigin",
    builder => builder.WithOrigins("*")
    .AllowAnyMethod()
    .AllowAnyHeader()
));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("AllowSpecificOrigin");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//DbSeeder.SeedCategoryData();
//DbSeeder.SeedQuestionData();
//DbSeeder.SeedAnswerData();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
