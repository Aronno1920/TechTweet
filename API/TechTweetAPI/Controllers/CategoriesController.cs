using AutoMapper;
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
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createDto)
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

        private async Task<Boolean> IsExistCategory(string category_name)
        {
            var category = await _categoryRepository.CheckByName(category_name);
            return category != null;
        }
    }
}
