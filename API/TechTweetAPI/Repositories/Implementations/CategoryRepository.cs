using TechTweetAPI.Data;
using TechTweetAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
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

        #region Validation Related
        public async Task<Category> CreateAsync(Category category)
        {
            try
            {
                await _dbContext.Categories.AddAsync(category);
                await _dbContext.SaveChangesAsync();

                return category;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the category.", ex);
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Categories
                .OrderByDescending(o => o.IsActive)
                .ThenBy(o => o.Name)
                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving categories.", ex);
            }
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while validating the category ID.", ex);
            }
        }

        public async Task<Category?> UpdateAsync(Category category)
        {
            try
            {
                var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
                if (existingCategory != null)
                {
                    _dbContext.Entry(existingCategory).CurrentValues.SetValues(category);
                    await _dbContext.SaveChangesAsync();

                    return existingCategory;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the category.", ex);
            }
            return null;
        }

        public async Task<Category?> InactiveAsync(Category category)
        {
            try
            {
                var inactive_category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
                if (inactive_category != null)
                {
                    inactive_category.IsActive = false; // Soft delete
                    _dbContext.Entry(inactive_category).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                    return inactive_category;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the category.", ex);
            }
            return null;
        }

        public async Task<Boolean> DeleteAsync(Category category)
        {
            try
            {
                var deletedCategory = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
                if (deletedCategory != null)
                {
                    _dbContext.Categories.Remove(deletedCategory);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the category.", ex);
            }
            return false;
        }

        #endregion

        #region Check Validation Related
        public async Task<Category> CheckByName(string category_name)
        {
            try
            {
                return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Name == category_name);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while checking the category by name.", ex);
            }
        }
        #endregion
    }
}