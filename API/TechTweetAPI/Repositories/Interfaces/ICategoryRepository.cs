using TechTweetAPI.Models.Domain;

namespace TechTweetAPI.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);

        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category> CheckByName(string category_name);

        Task<Category?> GetByIdAsync(Guid id);

        Task<Category?> UpdateAsync(Category category);

        Task<Category?> InactiveAsync(Category category);

        Task<Boolean> DeleteAsync(Category category);
    }
}
