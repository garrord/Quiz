﻿using Microsoft.EntityFrameworkCore;
using Quiz.Contracts;
using Quiz.Entities.DbContexts;
using Quiz.Models;

namespace Quiz.QueryRepositories
{
    public class CategoryQueryRepository : ICategoryQueryRepository
    {
        private readonly QuizContext _context;

        public CategoryQueryRepository(QuizContext context)
        {
            _context = context;
        }

        public async Task<IList<CategoryModel>> GetAllCategories()
        {
            IList<CategoryModel> categories = await (from c in _context.Categories
                                                     select new CategoryModel()
                                                     {
                                                         CategoryId = c.CategoryId,
                                                         CategoryName = c.CategoryName
                                                     }).ToListAsync();
            return categories;
        }
    }
}
