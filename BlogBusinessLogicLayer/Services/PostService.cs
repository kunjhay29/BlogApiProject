
using BlogBusinessLogicLayer.IService;
using BlogDataAccessLayer.UnitOfWork;
using BlogDomainLayer.Models;

namespace BlogBusinessLogicLayer.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Post? CreatePostNow(Post post,string userId, out string message)
        {
            // ✅ Validate input data
            if (post == null)
            {
                message = "Invalid post data.";
                return null;
            }

            if (string.IsNullOrWhiteSpace(post.Title))
            {
                message = "Post title cannot be empty";
                return null;
            }

            if (string.IsNullOrWhiteSpace(post.Content))
            {
                message = "Post content cannot be empty";
                return null;
            }

            if (string.IsNullOrWhiteSpace(userId))
            {
                message = "User ID is required.";
                return null;
            }

            // ✅ Set the UserId before saving
            post.UserId = userId;
            post.CreatedAt = DateTime.UtcNow; // Set timestamp

            // ✅ Save post to DB
            Post? createdPost = _unitOfWork.postRepository.CreatePost(post, userId);

            if (createdPost == null)
            {
                message = "Failed to create post";
                return null;
            }

            message = "Post created successfully";
            return createdPost;
        }

        public bool DeletePostNow(int id)
        {
            if (id < 0)
            {
                return false;
            }

            Post? post = _unitOfWork.postRepository.GetPost(id);

            if (post == null)
            {
                return false;
            }

            return true;
        }

        public List<Post> GetAllPostsNow()
        {
            return _unitOfWork.postRepository.GetAllPosts();
        }

        public Post? GetPostNow(int id)
        {
            if (id < 0)
            {
                return null;
            }

            return _unitOfWork.postRepository.GetPost(id);
        }

        public Post? UpdatePostNow(Post post, out string message)
        {
            //if (string.IsNullOrWhiteSpace(post.Title))
            //{
            //    message = "Title is required";
            //    return null;
            //}

            //if (string.IsNullOrWhiteSpace(post.Content))
            //{
            //    message = "Content is required";
            //    return null;
            //}

            //Post? existingPost = _unitOfWork.postRepository.GetPost(post.Id);
            //if (existingPost == null)
            //{
            //    message = "Post not found";
            //    return null;
            //}

            //post.UpdatedAt = DateTime.UtcNow; // Track updates
            //Post? updatedPost = _unitOfWork.postRepository.UpdatePost(post);

            //if (updatedPost == null)
            //{
            //    message = "Failed to update post";
            //    return null;
            //}

            //message = "Post updated successfully";
            //return updatedPost;

            if (string.IsNullOrWhiteSpace(post.Title))
            {
                message = "Title is required";
                return null;
            }

            if (string.IsNullOrWhiteSpace(post.Content))
            {
                message = "Content is required";
                return null;
            }

            // Retrieve the existing post from the database
            Post? existingPost = _unitOfWork.postRepository.GetPost(post.Id);
            if (existingPost == null)
            {
                message = "Post not found";
                return null;
            }

            // ✅ Update existing post instead of replacing it
            existingPost.Title = post.Title;
            existingPost.Content = post.Content;
            existingPost.UpdatedAt = DateTime.UtcNow;

            // Save changes
            Post? updatedPost = _unitOfWork.postRepository.UpdatePost(existingPost);

            if (updatedPost == null)
            {
                message = "Failed to update post";
                return null;
            }

            message = "Post updated successfully";
            return updatedPost;
        }




    }

      
}
