using AutoMapper;
using BlogBusinessLogicLayer.IService;
using BlogDomainLayer.Dto;
using BlogDomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsersNow();
            return Ok(users); // No need for mapping, already in DTO format
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return BadRequest("Email cannot be empty.");
            }

            var userWithRoles = await _userService.GetUserByEmailAsyncNow(email);

            if (userWithRoles == null)
            {
                return NotFound("User not found.");
            }

            return Ok(userWithRoles);
        }

        // Create a new user
        [HttpPost]

        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest(new { message = "Invalid request data." });
                }

                // AutoMapper conversion from DTO to Model
                User mappedUser = _mapper.Map<User>(dto);

                // Attempt to create user
                User? createdUser = await _userService.CreateUserNow(mappedUser, dto.Password);

                if (createdUser == null)
                {
                    return BadRequest(new { message = "User creation failed. Please try again." });
                }

                // Convert to DTO for response
                UserDto userDto = _mapper.Map<UserDto>(createdUser);
                return Ok(userDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message }); // 409 Conflict for existing user
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", error = ex.Message });
            }
        }
        //public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        //{
        //    // AutoMapper conversion from DTO to Model
        //    User mappedUser = _mapper.Map<User>(dto);

        //    User? createdUser = await _userService.CreateUserNow(mappedUser, dto.Password);

        //    if (createdUser == null)
        //    {
        //        return BadRequest("User creation failed");
        //    }

        //    UserDto userDto = _mapper.Map<UserDto>(createdUser);

        //    return Ok(userDto);
        //}

        // Update user
        [Authorize] // 🔒 Requires JWT token
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto dto)
        {
            // AutoMapper conversion
            User mappedUser = _mapper.Map<User>(dto);

            User? updatedUser = await _userService.UpdateUserNow(mappedUser);

            if (updatedUser == null)
            {
                return BadRequest("User update failed");
            }

            UserDto userDto = _mapper.Map<UserDto>(updatedUser);

            return Ok(userDto);
        }

        [Authorize] // 🔒 Requires JWT token
        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteUser(string email)
        {
            // ✅ Fetch user entity, not DTO
            User? user = await _userService.GetUserEntityByEmailAsync(email);

            if (user == null)
            {
                return NotFound("User not found");
            }

            bool deleted = await _userService.DeleteUserNow(user);

            if (!deleted)
            {
                return BadRequest("User deletion failed");
            }

            return Ok("User deleted successfully");
        }

        //// Add user to a role
        //[HttpPost("{id}/roles")]
        //public async Task<IActionResult> AddUserToRole(string id, [FromBody] AddUserToRoleDto dto)
        //{
        //    User? user = await _userService.GetUserByIdAsyncNow(id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    bool result = await _userService.AddUserToRoleNow(user, dto.RoleName);

        //    if (!result)
        //    {
        //        return BadRequest("Failed to add user to role");
        //    }

        //    return Ok("User added to role successfully");
    }
    }
