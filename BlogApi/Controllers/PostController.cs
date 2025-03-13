using System.Security.Claims;
using AutoMapper;
using BlogBusinessLogicLayer.IService;
using BlogDomainLayer.Dto;
using BlogDomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostService _postService;

        IMapper _mapper;

        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        // Get all posts
        [HttpGet]
        public IActionResult GetAllPosts()
        {
            var posts = _postService.GetAllPostsNow();
            var resultOfMapping = _mapper.Map<IList<PostDto>>(posts);
            return Ok(resultOfMapping);
        }

        // Get post by ID
        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
            Post? post = _postService.GetPostNow(id);

            if (post == null)
            {
                return NotFound();
            }

            PostDto resultOfMapping = _mapper.Map<PostDto>(post);
            return Ok(resultOfMapping);
        }

        // Create a new post
        [HttpPost]
        public IActionResult CreatePost([FromBody] CreatePostDto dto)
        {
            //Post mappedPost = _mapper.Map<Post>(dto);

            //Post? createdPost = _postService.CreatePostNow(mappedPost, out string message);

            //if (createdPost == null)
            //{
            //    return BadRequest("Post creation failed");
            //}

            //PostDto postDto = _mapper.Map<PostDto>(createdPost);

            //return Ok(postDto);


            // recent

            //if (dto == null)
            //{
            //    return BadRequest("Invalid post data.");
            //}

            //// ✅ Get the logged-in UserId
            //string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            //if (string.IsNullOrEmpty(userId))
            //{
            //    return Unauthorized("User is not authenticated.");
            //}

            //Post mappedPost = _mapper.Map<Post>(dto);

            //// ✅ Pass UserId to the service
            //Post? createdPost = _postService.CreatePostNow(mappedPost, userId, out string message);

            //if (createdPost == null)
            //{
            //    return BadRequest($"Post creation failed: {message}");
            //}

            //PostDto postDto = _mapper.Map<PostDto>(createdPost);

            //return Ok(postDto);

            // recent2
            //if (dto == null)
            //{
            //    return BadRequest("Invalid post data.");
            //}

            //// ✅ Ensure the user is authenticated before proceeding
            //if (User.Identity == null || !User.Identity.IsAuthenticated)
            //{
            //    return Unauthorized("User is not authenticated.");
            //}

            //// ✅ Get the logged-in UserId securely
            //string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            //if (string.IsNullOrEmpty(userId))
            //{
            //    return Unauthorized("User ID is missing from the authentication session.");
            //}

            //// ✅ Map the DTO to the Post entity
            //Post mappedPost = _mapper.Map<Post>(dto);

            //// ✅ Pass UserId to the service
            //Post? createdPost = _postService.CreatePostNow(mappedPost, userId, out string message);

            //if (createdPost == null)
            //{
            //    return BadRequest($"Post creation failed: {message}");
            //}

            //// ✅ Convert to DTO and return
            //PostDto postDto = _mapper.Map<PostDto>(createdPost);

            //return Ok(postDto);

            if (dto == null)
            {
                return BadRequest("Invalid post data.");
            }

            // ✅ Get User ID from JWT
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not authenticated.");
            }

            Post mappedPost = _mapper.Map<Post>(dto);

            // ✅ Pass UserId to the service
            Post? createdPost = _postService.CreatePostNow(mappedPost, userId, out string message);

            if (createdPost == null)
            {
                return BadRequest($"Post creation failed: {message}");
            }

            PostDto postDto = _mapper.Map<PostDto>(createdPost);

            return Ok(postDto);
        }

        // Update a post
        [HttpPut]
        public IActionResult UpdatePost([FromBody] UpdatePostDto dto)
        {
            //Post mappedPost = _mapper.Map<Post>(dto);

            //Post? updatedPost = _postService.UpdatePostNow(mappedPost, out string message);

            //if (updatedPost == null)
            //{
            //    return BadRequest("Post update failed");
            //}

            //PostDto postDto = _mapper.Map<PostDto>(updatedPost);

            //return Ok(postDto);

            if (dto.Id <= 0)
            {
                return BadRequest("Invalid post ID");
            }

            Console.WriteLine($"Updating Post ID: {dto.Id}"); // Debugging log

            Post mappedPost = _mapper.Map<Post>(dto);

            Post? updatedPost = _postService.UpdatePostNow(mappedPost, out string message);

            if (updatedPost == null)
            {
                return BadRequest(message);  // ✅ Return error message from service
            }

            PostDto postDto = _mapper.Map<PostDto>(updatedPost);

            return Ok(postDto);
        }

        // Delete a post
        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            Post? post = _postService.GetPostNow(id);

            if (post == null)
            {
                return NotFound();
            }

            bool deleted = _postService.DeletePostNow(id);

            if (!deleted)
            {
                return BadRequest("Post deletion failed");
            }

            return Ok("Post deleted successfully");
        }
    }
}
