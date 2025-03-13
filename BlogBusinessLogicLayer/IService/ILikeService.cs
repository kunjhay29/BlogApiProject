using BlogDomainLayer.Models;

namespace BlogBusinessLogicLayer.IService
{
    public interface ILikeService
    {
        /// <summary>
        /// Get like by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> object </returns>
        Like? GetLikeNow(int id);

        /// <summary>
        /// Get all likes
        /// </summary>
        /// <returns> List of likes </returns>
        List<Like> GetAllLikesNow();

        /// <summary>
        /// Delete Like
        /// </summary>
        /// <param name="like"></param>
        bool DeleteLikeNow(int id);

        /// <summary>
        /// Create a like
        /// </summary>
        /// <param name="like"></param>
        /// <returns></returns>
        Like CreateLikeNow(Like like, out string message);

        /// <summary>
        /// update like
        /// </summary>
        /// <param name="like"></param>
        /// <returns></returns>
        Like? UpdateLikeNow(Like like, out string message);
    }
}
