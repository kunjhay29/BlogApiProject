using BlogDomainLayer.Models;

namespace BlogBusinessLogicLayer.IService
{
    public interface IPostService
    {
        /// <summary>
        /// Get a Post by Id
        /// </summary>
        /// <param name="id"> object </param>
        /// <returns> Post </returns>
        Post? GetPostNow(int id);

        /// <summary>
        /// Get all Posts
        /// </summary>
        /// <returns> List of objects </returns>
        List<Post> GetAllPostsNow();

        /// <summary>
        /// Delete a post
        /// </summary>
        /// <param name="post"></param>
        bool DeletePostNow(int id);

        /// <summary>
        /// Create a post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        Post? CreatePostNow(Post post,string userId, out string message);

        /// <summary>
        /// update a post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        Post? UpdatePostNow(Post post, out string message);
    }
}
