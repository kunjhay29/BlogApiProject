using BlogDomainLayer.Models;

namespace BlogBusinessLogicLayer.IService
{
    public interface ICommentService
    {
        /// <summary>
        /// Get comment by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns> object </returns>
        Comment? GetCommentNow(int id);

        /// <summary>
        /// Get all comments
        /// </summary>
        /// <returns> List of objects </returns>
        List<Comment> GetAllCommentsNow();

        /// <summary>
        /// Delete a comment
        /// </summary>
        /// <param name="comment"></param>
        bool DeleteCommentNow(int id);

        /// <summary>
        /// Create comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Comment CreateCommentNow(Comment comment, out string message);

        /// <summary>
        /// Update a comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Comment? UpdateCommentNow(Comment comment, out string message);
    }
}
