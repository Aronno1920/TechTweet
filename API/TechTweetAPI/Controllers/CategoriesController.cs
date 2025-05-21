using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechTweetAPI.Data;
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
            var _category = _mapper.Map<Category>(createDto);

            var saveCategory = await _categoryRepository.CreateAsync(_category);

            var newCategory = _mapper.Map<CategoryDto>(saveCategory);

            return Ok(newCategory);
        }
    }
}
