using Microsoft.AspNetCore.Mvc;
using TechTweetAPI.Models.Domain;
using TechTweetAPI.Models.DTO.Category;

namespace TechTweetAPI.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);

        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category> CheckByName(string category_name);
    }
}
