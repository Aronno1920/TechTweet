using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechTweetAPI.Models.Domain;
using TechTweetAPI.Models.DTO;
using TechTweetAPI.Repositories.Interfaces;

namespace TechTweetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class PostsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostCreateDto createDto)
        {
            var _post = _mapper.Map<Post>(createDto);
            var savePost = await _postRepository.CreateAsync(_post);
            var newPost = _mapper.Map<PostDto>(savePost);

            return Ok(newPost);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postRepository.GetAllAsync();
            var postDtos = _mapper.Map<List<PostDto>>(posts);
            return Ok(postDtos);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            var postDto = _mapper.Map<PostDto>(post);
            return Ok(postDto);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] PostUpdateDto updateDto)
        {
            var existingPost = await _postRepository.GetByIdAsync(id);
            if (existingPost == null)
            {
                return NotFound();
            }
            var updatedPost = _mapper.Map(updateDto, existingPost);
            var result = await _postRepository.UpdateAsync(updatedPost);
            if (result == null)
            {
                return BadRequest("Failed to update the post.");
            }
            var postDto = _mapper.Map<PostDto>(result);
            return Ok(postDto);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var existingPost = await _postRepository.GetByIdAsync(id);
            if (existingPost == null)
            {
                return NotFound();
            }
            var result = await _postRepository.DeleteAsync(existingPost);
            if (!result)
            {
                return BadRequest("Failed to delete the post.");
            }
            return NoContent();
        }
    }
