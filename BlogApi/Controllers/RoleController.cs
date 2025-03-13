using AutoMapper;
using BlogBusinessLogicLayer.IService;
using BlogDomainLayer.Dto;
using BlogDomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRoleService _roleService;

        IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }


        // Get all roles
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var roles = _roleService.GetAllRolesAsyncNow();

            if (roles == null || roles.Count == 0)
            {
                return NotFound("No roles found.");
            }

            var resultOfMapping = _mapper.Map<IList<RoleDto>>(roles);
            return Ok(resultOfMapping);
        }

        // Get role by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Role ID cannot be empty.");
            }

            Role? role = await _roleService.GetRoleByIdAsyncNow(id);

            if (role == null)
            {
                return NotFound("Role not found.");
            }

            RoleDto resultOfMapping = _mapper.Map<RoleDto>(role);
            return Ok(resultOfMapping);
        }

        // Get role by name
        [HttpGet("name/{roleName}")]
        public async Task<IActionResult> GetRoleByName(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return BadRequest("Role name cannot be empty.");
            }

            Role? role = await _roleService.GetRoleByNameAsyncNow(roleName);

            if (role == null)
            {
                return NotFound("Role not found.");
            }

            RoleDto resultOfMapping = _mapper.Map<RoleDto>(role);
            return Ok(resultOfMapping);
        }

        // Create a new role
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Name))
            {
                return BadRequest("Role name is required.");
            }

            Role mappedRole = _mapper.Map<Role>(dto);
            bool success = await _roleService.CreateRoleAsyncNow(mappedRole);

            if (!success)
            {
                return BadRequest("Role creation failed.");
            }

            RoleDto roleDto = _mapper.Map<RoleDto>(mappedRole);
            return Ok(roleDto);
        }

        // Delete role
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Role ID cannot be empty.");
            }

            Role? role = await _roleService.GetRoleByIdAsyncNow(id);

            if (role == null)
            {
                return NotFound("Role not found.");
            }

            bool deleted = await _roleService.DeleteRoleAsyncNow(role);

            if (!deleted)
            {
                return BadRequest("Role deletion failed.");
            }

            return Ok("Role deleted successfully.");
        }

        // Update role
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(string id, [FromBody] UpdateRoleDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Name) || string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Role ID and name are required.");
            }

            Role? existingRole = await _roleService.GetRoleByIdAsyncNow(id);
            if (existingRole == null)
            {
                return NotFound("Role not found.");
            }

            // Update role properties
            existingRole.Name = dto.Name;

            bool updated = await _roleService.UpdateRoleAsyncNow(existingRole);

            if (!updated)
            {
                return BadRequest("Role update failed.");
            }

            RoleDto updatedRoleDto = _mapper.Map<RoleDto>(existingRole);
            return Ok(updatedRoleDto);
        }

        // Assign a role to a user
        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Role))
            {
                return BadRequest("Both Email and Role are required.");
            }

            var user = await _roleService.GetUserByEmailAsync(dto.Email);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var roleExists = await _roleService.RoleExistsAsync(dto.Role);
            if (!roleExists)
            {
                return BadRequest("Role does not exist.");
            }

            var result = await _roleService.AssignRoleToUserAsync(user.Email, dto.Role);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok($"Role '{dto.Role}' assigned to {user.Email}");
        }


    }
}
