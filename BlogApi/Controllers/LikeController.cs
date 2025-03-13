using AutoMapper;
using BlogBusinessLogicLayer.IService;
using BlogDomainLayer.Dto;
using BlogDomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        ILikeService _likeService;

        IMapper _mapper;

        public LikeController(ILikeService likeService, IMapper mapper)
        {
            _likeService = likeService;
            _mapper = mapper;
        }

        // Get all likes
        [HttpGet]
        public IActionResult GetAllLikes()
        {
            var likes = _likeService.GetAllLikesNow();
            var resultOfMapping = _mapper.Map<IList<LikeDto>>(likes);
            return Ok(resultOfMapping);
        }

        // Get like by ID
        [HttpGet("{id}")]
        public IActionResult GetLikeById(int id)
        {
            var like = _likeService.GetLikeNow(id);

            if (like == null)
            {
                return NotFound("Like not found.");
            }

            var resultOfMapping = _mapper.Map<LikeDto>(like);
            return Ok(resultOfMapping);
        }

        // Create a new like
        [HttpPost]
        public IActionResult CreateLike([FromBody] CreateLikeDto dto)
        {
            Like mappedLike = _mapper.Map<Like>(dto);

            var createdLike = _likeService.CreateLikeNow(mappedLike, out string message);

            if (createdLike == null)
            {
                return BadRequest(message);
            }

            var likeDto = _mapper.Map<LikeDto>(createdLike);
            return Ok(likeDto);
        }

        // Update a like
        [HttpPut]
        public IActionResult UpdateLike([FromBody] UpdateLikeDto dto)
        {
            Like mappedLike = _mapper.Map<Like>(dto);

            var updatedLike = _likeService.UpdateLikeNow(mappedLike, out string message);

            if (updatedLike == null)
            {
                return BadRequest(message);
            }

            var likeDto = _mapper.Map<LikeDto>(updatedLike);
            return Ok(likeDto);
        }

        // Delete a like by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteLike(int id)
        {
            bool deleted = _likeService.DeleteLikeNow(id);

            if (!deleted)
            {
                return NotFound("Like not found or invalid ID.");
            }

            return Ok("Like deleted successfully.");
        }
    }
}
