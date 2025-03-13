using BlogDomainLayer.Dto;
using BlogDomainLayer.Models;

namespace BlogBusinessLogicLayer.IService
{
    public interface IUserService
    {
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns> list of users </returns>
        List<UserWithRolesDto> GetAllUsersNow();

        /// <summary>
        /// Get user
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Object </returns>
        Task<UserWithRolesDto> GetUserByEmailAsyncNow(string email);

        /// <summary>
        /// Create a user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<User> CreateUserNow(User user, string password);

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns> new object </returns>
        Task<bool> DeleteUserNow(User user);

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns> updated object </returns>
        Task<User> UpdateUserNow(User user);

        /// <summary>
        /// Add a particular user to a role
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        Task<bool> AddUserToRoleNow(User user, string roleName);

        Task<User?> GetUserEntityByEmailAsync(string email);
    }
}
