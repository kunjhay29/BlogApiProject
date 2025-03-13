using AutoMapper;
using BlogBusinessLogicLayer.IService;
using BlogDomainLayer.Dto;
using BlogDomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;

        IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // Get all categories
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetAllCategoriesNow();
            var resultOfMapping = _mapper.Map<IList<CategoryDto>>(categories);
            return Ok(resultOfMapping);
        }

        // Get category by ID
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryService.GetCategoryNow(id);

            if (category == null)
            {
                return NotFound("Category not found.");
            }

            var resultOfMapping = _mapper.Map<CategoryDto>(category);
            return Ok(resultOfMapping);
        }

        // Create a new category
        [HttpPost]
        public IActionResult CreateCategory([FromBody] CreateCategoryDto dto)
        {
            Category mappedCategory = _mapper.Map<Category>(dto);

            var createdCategory = _categoryService.CreateCategoryNow(mappedCategory, out string message);

            if (createdCategory == null)
            {
                return BadRequest(message);
            }

            var categoryDto = _mapper.Map<CategoryDto>(createdCategory);
            return Ok(categoryDto);
        }

        // Update a category
        [HttpPut]
        public IActionResult UpdateCategory([FromBody] UpdateCategoryDto dto)
        {
            Category mappedCategory = _mapper.Map<Category>(dto);

            var updatedCategory = _categoryService.UpdateCategoryNow(mappedCategory, out string message);

            if (updatedCategory == null)
            {
                return BadRequest(message);
            }

            var categoryDto = _mapper.Map<CategoryDto>(updatedCategory);
            return Ok(categoryDto);
        }

        // Delete a category by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            bool deleted = _categoryService.DeleteCategoryNow(id);

            if (!deleted)
            {
                return NotFound("Category not found or invalid ID.");
            }

            return Ok("Category deleted successfully.");
        }
    }
}
