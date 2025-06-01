using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TechTweetAPI.Models.Domain;
using TechTweetAPI.Models.DTO.Category;
using TechTweetAPI.Repositories.Interfaces;

namespace TechTweetAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto createDto)
        {
            if (IsExistCategory(createDto.Name).Result)
            {
                return BadRequest("Category with this name already exists.");
            }
            else
            {
                createDto.UrlHandle = createDto.UrlHandle.Replace(' ', '-').ToLower();
                var _category = _mapper.Map<Category>(createDto);

                var saveCategory = await _categoryRepository.CreateAsync(_category);
                
                var newCategory = _mapper.Map<CategoryDto>(saveCategory);
                return Ok(newCategory);
            }
        }

        [HttpGet]
        [ActionName("GetAll")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();

            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories);


            return Ok(categoryDtos);
        }

        [HttpGet("{id:Guid}")]
        [ActionName("GetById")]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return Ok(categoryDto);
        }

        [HttpPut("{id:Guid}")]
        [ActionName("Update")]
        public async Task<IActionResult> EditCategory([FromRoute] Guid id, UpdateCategoryDto request)
        {
            var _category = new Category
            {
                Id = id,
                Name = request.Name,
                UrlHandle = request.UrlHandle.Replace(' ', '-').ToLower(),
                IsActive = request.IsActive
            };

            var updatedCategory = await _categoryRepository.UpdateAsync(_category);

            if (updatedCategory == null)
            {
                return NotFound();
            }
            var categoryDto = _mapper.Map<CategoryDto>(updatedCategory);

            return Ok(updatedCategory);
        }

        [HttpDelete("{id:Guid}")]
        [ActionName("Inactive")]
        public async Task<IActionResult> InactiveCategory([FromRoute] Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            category.IsActive = false; // Soft delete
            var updatedCategory = await _categoryRepository.InactiveAsync(category);
            if (updatedCategory == null)
            {
                return NotFound();
            }
            return Ok("Category inactivated successfully.");
        }

        [HttpDelete("{id:Guid}")]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteCatetory([FromRoute] Guid id)
        {
            var deletedCategory = await _categoryRepository.GetByIdAsync(id);
            if (deletedCategory == null)
            {
                return NotFound();
            }

            var isDelete = await _categoryRepository.DeleteAsync(deletedCategory);
            if (isDelete == null)
            {
                return NotFound();
            }


            return Ok("Category deleted successfully.");
        }




        #region Check Validation Related
        private async Task<Boolean> IsExistCategory(string category_name)
        {
            var category = await _categoryRepository.CheckByName(category_name);
            return category != null;
        }
        #endregion
    }
}
