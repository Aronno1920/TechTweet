using AutoMapper;
using TechTweetAPI.Data;
using TechTweetAPI.Models.Domain;
using TechTweetAPI.Models.DTO.Category;
using TechTweetAPI.Repositories.Interfaces;

namespace TechTweetAPI.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return category;
        }
    }
}