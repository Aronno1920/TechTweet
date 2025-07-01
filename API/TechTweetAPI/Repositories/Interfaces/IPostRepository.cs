using Microsoft.AspNetCore.Mvc;
using TechTweetAPI.Models.Domain;
using TechTweetAPI.Models.DTO;

namespace TechTweetAPI.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task<Post> CreateAsync(Post newPost);

        Task<IEnumerable<Post>> GetAllAsync();

        Task<Post?> GetByIdAsync(Guid id);

        Task<Post?> UpdateAsync(Post post);

        Task DeleteAsync(Guid id);

        Task<IEnumerable<Post>> GetPostsByCategoryAsync(Guid categoryId);
    }
}
