using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogDomainLayer.Models;

namespace BlogDataAccessLayer.IRepositories
{
    public interface IUserRepository 
    {
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns> list of users </returns>
        List<User> GetAllUsers();

        /// <summary>
        /// Get user
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Object </returns>
        Task<User> GetUserByEmailAsync(string email); // i changed here

        /// <summary>
        /// Create a user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<User> CreateUser(User user, string password);

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns> new object </returns>
        Task<bool> DeleteUser(User user);

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns> updated object </returns>
        Task<User> UpdateUser(User user);

        /// <summary>
        /// Add a particular user to a role
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        Task<bool> AddUserToRole(User user, string roleName);

        Task<IList<string>> GetUserRoles(User user);



    }
}
