using BlogBusinessLogicLayer.IService;
using BlogDomainLayer.Models;
using BlogDataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using BlogDomainLayer.Dto;

namespace BlogBusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly UserManager<User> _userManager;

        public UserService(IUnitOfWork unitOfWork, IPasswordHasher<User> passwordHasher, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _userManager = userManager;
        }

        public async Task<bool> AddUserToRoleNow(User user, string roleName)
        {
            if (user == null || string.IsNullOrWhiteSpace(roleName))
            {
                return false; // Invalid input
            }

            return await _unitOfWork.userRepository.AddUserToRole(user, roleName);
        }

        public async Task<User> CreateUserNow(User user, string password)
        {
            if (user == null || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("User or password cannot be empty.");
            }

            var existingUser = await _unitOfWork.userRepository.GetUserByEmailAsync(user.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("User with this email already exists.");
            }

            // Hash password
            user.PasswordHash = _passwordHasher.HashPassword(user, password);

            // Save user
            User? createdUser = await _unitOfWork.userRepository.CreateUser(user, password);

            if (createdUser == null)
            {
                throw new Exception("User creation failed at repository level.");
            }

            return createdUser;
        }

        public async Task<bool> DeleteUserNow(User user)
        {
            if (user == null)
            {
                return false;
            }

            return await _unitOfWork.userRepository.DeleteUser(user);
        }

        public List<UserWithRolesDto> GetAllUsersNow()
        {
            var users = _unitOfWork.userRepository.GetAllUsers();

            var usersWithRoles = users.Select(user => new UserWithRolesDto
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Roles = _unitOfWork.userRepository.GetUserRoles(user).Result.ToList() // Fetch roles
            }).ToList();

            return usersWithRoles;
        }

        public async Task<UserWithRolesDto> GetUserByEmailAsyncNow(string email)
        {
            var user = await _unitOfWork.userRepository.GetUserByEmailAsync(email);

            if (user == null)
            {
                return null; // Return null if user is not found
            }

            var roles = await _unitOfWork.userRepository.GetUserRoles(user);

            return new UserWithRolesDto
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Roles = roles.ToList()
            };
        }


        public async Task<User> UpdateUserNow(User user)
        {
            if (user == null)
            {
                return null;
            }

            var existingUser = await _unitOfWork.userRepository.GetUserByEmailAsync(user.Email);
            if (existingUser == null)
            {
                return null;
            }

            User? updatedUser = await _unitOfWork.userRepository.UpdateUser(user);

            if (updatedUser == null)
            {
                return null;
            }

            return updatedUser;
        }


        public async Task<User?> GetUserEntityByEmailAsync(string email)
        {
            return await _unitOfWork.userRepository.GetUserByEmailAsync(email);
        }
    }
}