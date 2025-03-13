using AutoMapper;
using BlogBusinessLogicLayer.IService;
using BlogDomainLayer.Dto;
using BlogDomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostCategoryController : ControllerBase
    {
        IPostCategoryService _postCategoryService;

        IMapper _mapper;

        public PostCategoryController(IPostCategoryService postCategoryService, IMapper mapper)
        {
            _postCategoryService = postCategoryService;
            _mapper = mapper;
        }

        // Get all post categories
        [HttpGet]
        public IActionResult GetAllPostCategories()
        {
            var postCategories = _postCategoryService.GetAllPostCategoriesNow();
            var resultOfMapping = _mapper.Map<IList<PostCategoryDto>>(postCategories);
            return Ok(resultOfMapping);
        }

        // Get post category by composite key (postId, categoryId)
        [HttpGet("{postId}/{categoryId}")]
        public IActionResult GetPostCategoryById(int postId, int categoryId)
        {
            var postCategory = _postCategoryService.GetPostCategoryNow(postId, categoryId);

            if (postCategory == null)
            {
                return NotFound("PostCategory not found.");
            }

            var resultOfMapping = _mapper.Map<PostCategoryDto>(postCategory);
            return Ok(resultOfMapping);
        }

        // Create a new post category
        [HttpPost]
        public IActionResult CreatePostCategory([FromBody] CreatePostCategoryDto dto)
        {
            PostCategory mappedPostCategory = _mapper.Map<PostCategory>(dto);

            var createdPostCategory = _postCategoryService.CreatePostCategoryNow(mappedPostCategory, out string message);

            if (createdPostCategory == null)
            {
                return BadRequest(message);
            }

            var postCategoryDto = _mapper.Map<PostCategoryDto>(createdPostCategory);
            return Ok(postCategoryDto);
        }

        // Delete a post category by composite key (postId, categoryId)
        [HttpDelete("{postId}/{categoryId}")]
        public IActionResult DeletePostCategory(int postId, int categoryId)
        {
            bool deleted = _postCategoryService.DeletePostCategoryNow(postId, categoryId);

            if (!deleted)
            {
                return NotFound("PostCategory not found or invalid keys.");
            }

            return Ok("PostCategory deleted successfully.");
        }
    }
}
