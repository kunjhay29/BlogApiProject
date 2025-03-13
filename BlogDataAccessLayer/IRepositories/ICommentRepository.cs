using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogDomainLayer.Models;

namespace BlogDataAccessLayer.IRepositories
{
    public interface ICommentRepository
    {
        /// <summary>
        /// Get comment by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns> object </returns>
        Comment? GetComment(int id);

        /// <summary>
        /// Get all comments
        /// </summary>
        /// <returns> List of objects </returns>
        List<Comment> GetAllComments();

        /// <summary>
        /// Delete a comment
        /// </summary>
        /// <param name="comment"></param>
        void DeleteComment(int id);

        /// <summary>
        /// Create comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Comment CreateComment(Comment comment);

        /// <summary>
        /// Update a comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Comment? UpdateComment(Comment comment);
    }
}
