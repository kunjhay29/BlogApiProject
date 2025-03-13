using BlogDataAccessLayer.Data;
using BlogDataAccessLayer.IRepositories;
using BlogDataAccessLayer.Repositories;
using BlogDomainLayer.Models;
using Microsoft.AspNetCore.Identity;

namespace BlogDataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UnitOfWork(ApplicationDbContext applicationDbContext, IUserStore<User> userStore , IRoleStore<Role> roleStore)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = new UserManager<User>(userStore, null, null, null, null, null, null, null, null);
            _roleManager = new RoleManager<Role>(roleStore, null, null, null, null);
        }

        private UserRepository _userRepository;
        private PostRepository _postRepository;
        private PostCategoryRepository _postCategoryRepository;
        private LikeRepository _likeRepository;
        private CommentRepository _commentRepository;
        private CategoryRepository _categoryRepository;
        private RoleRepository _roleRepository;

        public UserRepository userRepository => _userRepository ??= new UserRepository(_userManager);

        public PostRepository postRepository => _postRepository ??= new PostRepository(_applicationDbContext);

        public PostCategoryRepository postCategoryRepository => _postCategoryRepository ??= new PostCategoryRepository(_applicationDbContext);

        public LikeRepository likeRepository => _likeRepository ??= new LikeRepository(_applicationDbContext);

        public CommentRepository commentRepository => _commentRepository ??= new CommentRepository(_applicationDbContext);

        public CategoryRepository categoryRepository => _categoryRepository ??= new CategoryRepository(_applicationDbContext);

        public RoleRepository roleRepository => _roleRepository ??= new RoleRepository(_roleManager);

    }
}
