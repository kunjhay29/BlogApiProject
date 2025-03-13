using BlogDataAccessLayer.Repositories;

namespace BlogDataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        UserRepository userRepository { get; }

        PostRepository postRepository { get; }

        PostCategoryRepository postCategoryRepository { get; }

        LikeRepository likeRepository { get; }

        CommentRepository commentRepository { get; }    

        CategoryRepository categoryRepository { get; }

        RoleRepository roleRepository { get; }

    }
}
