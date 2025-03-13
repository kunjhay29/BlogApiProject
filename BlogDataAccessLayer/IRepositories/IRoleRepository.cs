using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogDomainLayer.Models;

namespace BlogDataAccessLayer.IRepositories
{
    public interface IRoleRepository
    {
        /// <summary>
        /// Get all roles
        /// </summary>
        /// <returns> list of objects </returns>
        List<Role> GetAllRolesAsync();

        /// <summary>
        /// Get a role
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns> Object </returns>
        Task<Role?> GetRoleByIdAsync(string roleId);
        /// <summary>
        /// Get a role nanme
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns> role </returns>
        Task<Role?> GetRoleByNameAsync(string roleName);

        /// <summary>
        /// Create Role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        Task<bool> CreateRoleAsync(Role role);

        /// <summary>
        /// Delete role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        Task<bool> DeleteRoleAsync(Role role);

        /// <summary>
        /// Update an existing role
        /// </summary>
        /// <param name="role"></param>
        /// <returns> updated object </returns>
        Task<bool> UpdateRoleAsync(Role role);
    }
}
