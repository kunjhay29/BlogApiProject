using BlogDataAccessLayer.Data;
using BlogDataAccessLayer.IRepositories;
using BlogDomainLayer.Models;

namespace BlogDataAccessLayer.Repositories
{
    public class PostRepository : IPostRepository
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public PostRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Post CreatePost(Post post, string userId)
        {
            if (post == null || string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentException("Post data or UserId cannot be null.");
            }

            post.UserId = userId;  // ✅ Ensure UserId is assigned

            _applicationDbContext.posts.Add(post);
            _applicationDbContext.SaveChanges();

            return post;
        }

        public void DeletePost(Post post)
        {
            _applicationDbContext.Remove(post);
            _applicationDbContext.SaveChanges();
        }

        public List<Post> GetAllPosts()
        {
            return _applicationDbContext.posts.ToList();
        }

        public Post? GetPost(int id)
        {
            Post? post = _applicationDbContext.posts.Find(id);
            return post;
        }

        public Post? UpdatePost(Post post)
        {
            // Retrieve existing post from DB
            Post? existingPost = _applicationDbContext.posts.Find(post.Id);

            if (existingPost == null)
            {
                return null; // Post not found
            }

            // ✅ Update the existing post's values
            existingPost.Title = post.Title;
            existingPost.Content = post.Content;
            existingPost.UpdatedAt = DateTime.UtcNow;

            // ✅ Now update in DB
            _applicationDbContext.posts.Update(existingPost);
            _applicationDbContext.SaveChanges();

            return existingPost; // ✅ Return the updated post
        }
    }
}
