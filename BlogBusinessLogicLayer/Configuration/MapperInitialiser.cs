using AutoMapper;
using BlogDomainLayer.Dto;
using BlogDomainLayer.Models;

namespace BlogBusinessLogicLayer.Configuration
{
    class MapperInitialiser : Profile
    {
        public MapperInitialiser()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();

            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Post, CreatePostDto>().ReverseMap();
            CreateMap<Post, UpdatePostDto>().ReverseMap();

            CreateMap<PostCategory, PostCategoryDto>().ReverseMap();
            CreateMap<PostCategory, CreatePostCategoryDto>().ReverseMap();
            CreateMap<PostCategory, UpdatePostCategoryDto>().ReverseMap();

            CreateMap<Like, LikeDto>().ReverseMap();
            CreateMap<Like, CreateLikeDto>().ReverseMap();
            CreateMap<Like, UpdateLikeDto>().ReverseMap();

            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Role, CreateRoleDto>().ReverseMap();
            CreateMap<Role, UpdateRoleDto>().ReverseMap();



        }
    }
}
