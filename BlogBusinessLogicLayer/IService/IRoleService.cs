using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogDomainLayer.Models;
using Microsoft.AspNetCore.Identity;

namespace BlogBusinessLogicLayer.IService
{
    public interface IRoleService
    {
        /// <summary>
        /// Get all roles
        /// </summary>
        /// <returns> A list of roles </returns>
        List<Role> GetAllRolesAsyncNow();

        /// <summary>
        /// Get a role
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns> obect </returns>
        Task<Role> GetRoleByIdAsyncNow(string roleId);

        /// <summary>
        /// Get role by name
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns> object </returns>
        Task<Role> GetRoleByNameAsyncNow(string roleName);

        /// <summary>
        /// Create a role
        /// </summary>
        /// <param name="role"></param>
        /// <returns>new object<returns>
        Task<bool> CreateRoleAsyncNow(Role role);

        /// <summary>
        /// Delete a role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        Task<bool> DeleteRoleAsyncNow(Role role);

        /// <summary>
        /// Update a role
        /// </summary>
        /// <param name="role"></param>
        /// <returns>Updated role</returns>
        Task<bool> UpdateRoleAsyncNow(Role role);

        Task<User?> GetUserByEmailAsync(string email);
        Task<bool> RoleExistsAsync(string roleName);

        /// <summary>
        ///  assign role to users
        /// </summary>
        /// <param name="email"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        Task<IdentityResult> AssignRoleToUserAsync(string email, string roleName);

        /// <summary>
        /// Get user roles
        /// </summary>
        /// <param name="email"></param>
        /// <returns> a list of objects </returns>
        Task<IList<string>> GetUserRolesAsync(string email);
        

    }
}
