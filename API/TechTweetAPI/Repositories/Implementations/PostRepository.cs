using TechTweetAPI.Data;
using TechTweetAPI.Models.Domain;
using TechTweetAPI.Models.DTO;
using TechTweetAPI.Repositories.Interfaces;

namespace TechTweetAPI.Repositories.Implementations
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PostRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Post> CreateAsync(Post newPost)
        {
            await _dbContext.Posts.AddAsync(newPost);
            await _dbContext.SaveChangesAsync();
            return newPost;
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Posts.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the category.", ex);
            }
        }

        public async Task<Post?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _dbContext.Posts.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the category.", ex);
            }
        }

        public async Task<Post?> UpdateAsync(Post post)
        {
            try
            {
                var existingPost = await _dbContext.Posts.FindAsync(post.Id);
                if (existingPost == null)
                {
                    return null;
                }
                existingPost.Title = post.Title;
                existingPost.Content = post.Content;
                existingPost.CategoryId = post.CategoryId;
                _dbContext.Posts.Update(existingPost);
                await _dbContext.SaveChangesAsync();
                return existingPost;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the category.", ex);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var post = await _dbContext.Posts.FindAsync(id);
                if (post != null)
                {
                    _dbContext.Posts.Remove(post);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the category.", ex);
            }
        }

        public async Task<IEnumerable<Post>> GetPostsByCategoryAsync(Guid categoryId)
        {
            try
            {
                return await _dbContext.Posts
                    .Where(p => p.CategoryId == categoryId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the category.", ex);
            }
        }
    }
}
