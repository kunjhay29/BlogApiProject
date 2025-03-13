using BlogBusinessLogicLayer.IService;
using BlogDataAccessLayer.UnitOfWork;
using BlogDomainLayer.Models;
using Microsoft.AspNetCore.Identity;

namespace BlogBusinessLogicLayer.Services
{ 
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public RoleService(IUnitOfWork unitOfWork, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> CreateRoleAsyncNow(Role role)
        {
            if (role == null || string.IsNullOrWhiteSpace(role.Name))
            {
                return false; // Invalid input
            }

            return await _unitOfWork.roleRepository.CreateRoleAsync(role);
        }

        public async Task<bool> DeleteRoleAsyncNow(Role role)
        {
            if (role == null)
            {
                return false; // Invalid input
            }

            return await _unitOfWork.roleRepository.DeleteRoleAsync(role);
        }

        public List<Role> GetAllRolesAsyncNow()
        {
            return _unitOfWork.roleRepository.GetAllRolesAsync();
        }

        public async Task<Role> GetRoleByIdAsyncNow(string roleId)
        {
            if (string.IsNullOrWhiteSpace(roleId))
            {
                return null; // Invalid input
            }

            return await _unitOfWork.roleRepository.GetRoleByIdAsync(roleId);
        }

        public async Task<Role> GetRoleByNameAsyncNow(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return null; // Invalid input
            }

            return await _unitOfWork.roleRepository.GetRoleByNameAsync(roleName);
        }

        public async Task<bool> UpdateRoleAsyncNow(Role role)
        {
            if (role == null || string.IsNullOrWhiteSpace(role.Id) || string.IsNullOrWhiteSpace(role.Name))
            {
                return false; // Invalid input
            }

            return await _unitOfWork.roleRepository.UpdateRoleAsync(role);
        }

        // 🔹 Get User by Email
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        // 🔹 Check if a Role Exists
        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }

        // 🔹 Assign a Role to a User
        public async Task<IdentityResult> AssignRoleToUserAsync(string email, string roleName)
        {
            var user = await GetUserByEmailAsync(email);
            if (user == null)
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });

            if (!await RoleExistsAsync(roleName))
                return IdentityResult.Failed(new IdentityError { Description = "Role does not exist." });

            return await _userManager.AddToRoleAsync(user, roleName);
        }

        // 🔹 Get User Roles
        public async Task<IList<string>> GetUserRolesAsync(string email)
        {
            var user = await GetUserByEmailAsync(email);
            if (user == null)
                return new List<string>();

            return await _userManager.GetRolesAsync(user);
        }

    }
}
