using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogDomainLayer.Models;

namespace BlogDataAccessLayer.IRepositories
{
    public interface ILikeRepository
    {
        /// <summary>
        /// Get like by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> object </returns>
        Like? GetLike(int id);

        /// <summary>
        /// Get all likes
        /// </summary>
        /// <returns> List of likes </returns>
        List<Like> GetAllLikes();

        /// <summary>
        /// Delete Like
        /// </summary>
        /// <param name="like"></param>
        void DeleteLike(Like like);

        /// <summary>
        /// Create a like
        /// </summary>
        /// <param name="like"></param>
        /// <returns></returns>
        Like CreateLike(Like like);

        /// <summary>
        /// update like
        /// </summary>
        /// <param name="like"></param>
        /// <returns></returns>
        Like? UpdateLike(Like like);
    }
}
