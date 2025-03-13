using BlogDataAccessLayer.IRepositories;
using BlogDomainLayer.Models;
using Microsoft.AspNetCore.Identity;

namespace BlogDataAccessLayer.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleRepository(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> CreateRoleAsync(Role role)
        {
            if (role == null || string.IsNullOrWhiteSpace(role.Name))
            {
                throw new ArgumentException("Role cannot be null and must have a valid name.");
            }

            // Ensure the Id is not null
            if (string.IsNullOrEmpty(role.Id))
            {
                role.Id = Guid.NewGuid().ToString();
            }

            IdentityResult result = await _roleManager.CreateAsync(role);

            return result.Succeeded;
        }

        public async Task<bool> DeleteRoleAsync(Role role)
        {
            IdentityResult result = await _roleManager.DeleteAsync(role);

            return result.Succeeded;
        }

        public List<Role> GetAllRolesAsync()
        {
            return _roleManager.Roles.ToList();
        }

        public async Task<Role?> GetRoleByIdAsync(string roleId)
        {
            return await _roleManager.FindByIdAsync(roleId);
        }

        public async Task<Role?> GetRoleByNameAsync(string roleName)
        {
            return await _roleManager.FindByNameAsync(roleName);
        }
        public async Task<bool> UpdateRoleAsync(Role role)
        {
            var existingRole = await _roleManager.FindByIdAsync(role.Id);
            if (existingRole == null)
            {
                return false;
            }

            existingRole.Name = role.Name;

            IdentityResult result = await _roleManager.UpdateAsync(existingRole);

            return result.Succeeded;
        }

    }
}
