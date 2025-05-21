using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechTweetAPI.Data;
using TechTweetAPI.Models.Domain;
using TechTweetAPI.Models.DTO.Category;

namespace TechTweetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoriesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto category)
        {
            var _category = new Category
            {
                Name = category.Name,
                UrlHandle = category.UrlHandle,
                IsActive = true,
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow,
            };

            await _dbContext.Categories.AddAsync(_category);
            await _dbContext.SaveChangesAsync();

            var newCategory = new CategoryDto
            {
                Id = _category.Id,
                Name = _category.Name,
                UrlHandle = _category.UrlHandle,
                IsActive = _category.IsActive,
            };

            return Ok(newCategory);
        }

    }
}
