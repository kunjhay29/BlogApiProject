using BlogDataAccessLayer.IRepositories;
using BlogDomainLayer.Models;
using Microsoft.AspNetCore.Identity;

namespace BlogDataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        //to get all users

        public List<User> GetAllUsers()
        {
            return _userManager.Users.ToList();
        }

        //To return a single user by id
        //async method name ends with async
        //async must always use the await keyword

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email); //i cahneged here
        }

        public async Task<User> CreateUser(User user, string password)
        {
            //IdentityResult result = await _userManager.CreateAsync(user, password);

            //if (!result.Succeeded)
            //{
            //    return null;
            //}

            //return user;

            try
            {
                if (user == null || string.IsNullOrWhiteSpace(password))
                {
                    throw new ArgumentException("User object or password cannot be null/empty.");
                }

                // Attempt to create user with Identity
                IdentityResult result = await _userManager.CreateAsync(user, password);

                if (!result.Succeeded)
                {
                    string errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    throw new Exception($"User creation failed: {errors}");
                }

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in CreateUser method: {ex.Message}");
            }
        }

        public async Task<bool> DeleteUser(User user)
        {
            IdentityResult result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                return true;
            }

            return false;
        }

        public async Task<User> UpdateUser(User user)

        {

            IdentityResult result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return null;
            }

            return user;
        }

        public async Task<bool> AddUserToRole(User user, string roleName)
        {
            IdentityResult result = await _userManager.AddToRoleAsync(user, roleName);

            if (result.Succeeded)
            {
                return true;
            }

            return false;

        }

        public async Task<IList<string>> GetUserRoles(User user)
        {
            return await _userManager.GetRolesAsync(user);
        }

    }
}
