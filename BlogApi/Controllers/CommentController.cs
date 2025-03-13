using AutoMapper;
using BlogBusinessLogicLayer.IService;
using BlogDomainLayer.Dto;
using BlogDomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        ICommentService _commentService;

        IMapper _mapper;

        private readonly UserManager<User> _userManager; // 🔹 Add this


        public CommentController(ICommentService commentService, IMapper mapper, UserManager<User> userManager)
        {
            _commentService = commentService;
            _mapper = mapper;
            _userManager = userManager; // 🔹 Assign it
        }

        // Get all comments
        [HttpGet]
        public IActionResult GetAllComments()
        {
            var comments = _commentService.GetAllCommentsNow();
            var resultOfMapping = _mapper.Map<IList<CommentDto>>(comments);
            return Ok(resultOfMapping);
        }

        // Get comment by ID
        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            var comment = _commentService.GetCommentNow(id);

            if (comment == null)
            {
                return NotFound("Comment not found.");
            }

            var resultOfMapping = _mapper.Map<CommentDto>(comment);
            return Ok(resultOfMapping);
        }

        // Create a new comment
        //[HttpPost]
        //public IActionResult CreateComment([FromBody] CreateCommentDto dto)
        //{
        //    Comment mappedComment = _mapper.Map<Comment>(dto);

        //    var createdComment = _commentService.CreateCommentNow(mappedComment, out string message);

        //    if (createdComment == null)
        //    {
        //        return BadRequest(message);
        //    }

        //    var commentDto = _mapper.Map<CommentDto>(createdComment);
        //    return Ok(commentDto);
        //}

        [HttpPost]
        [Authorize] // 🔹 Ensure only logged-in users can comment
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto dto)
        {
            var user = await _userManager.GetUserAsync(User); // 🔹 Get the authenticated user
            if (user == null) return Unauthorized("User not found");

            Comment mappedComment = _mapper.Map<Comment>(dto);
            mappedComment.UserId = user.Id; // 🔹 Assign authenticated user's ID
            mappedComment.CreatedAt = DateTime.UtcNow;

            var createdComment = _commentService.CreateCommentNow(mappedComment, out string message);

            if (createdComment == null)
            {
                return BadRequest(message);
            }

            var commentDto = _mapper.Map<CommentDto>(createdComment);
            return Ok(commentDto);
        }

        // Update a comment
        [HttpPut]
        public IActionResult UpdateComment([FromBody] UpdateCommentDto dto)
        {
            Comment mappedComment = _mapper.Map<Comment>(dto);

            var updatedComment = _commentService.UpdateCommentNow(mappedComment, out string message);

            if (updatedComment == null)
            {
                return BadRequest(message);
            }

            var commentDto = _mapper.Map<CommentDto>(updatedComment);
            return Ok(commentDto);
        }

        // Delete a comment by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            bool deleted = _commentService.DeleteCommentNow(id);

            if (!deleted)
            {
                return NotFound("Comment not found or invalid ID.");
            }

            return Ok("Comment deleted successfully.");
        }
    }
}
