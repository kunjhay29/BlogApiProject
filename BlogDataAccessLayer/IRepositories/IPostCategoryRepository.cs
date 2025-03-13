using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogDomainLayer.Models;

namespace BlogDataAccessLayer.IRepositories
{
    public interface IPostCategoryRepository
    {
        /// <summary>
        /// Get a PostCategory byu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns> post </returns>
        PostCategory? GetPostCategory(int postId, int categoryId);

        /// <summary>
        /// Get all PostCategories
        /// </summary>
        /// <returns> return a list of object </returns>
        List<PostCategory> GetAllPostCategories();

        /// <summary>
        /// Delete a postcategory
        /// </summary>
        /// <param name="post"></param>
        void DeletePostCategory(PostCategory postCategory);

        /// <summary>
        /// Create Postcategory
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        PostCategory CreatePostCategory(PostCategory postCategory);

        /// <summary>
        /// Update a postcategory
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        PostCategory? UpdatePostCategory(PostCategory postCategory);
    }
}
