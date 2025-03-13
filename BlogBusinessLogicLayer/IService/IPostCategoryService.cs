using BlogDomainLayer.Models;

namespace BlogBusinessLogicLayer.IService
{
    public interface IPostCategoryService
    {
        /// <summary>
        /// Get a PostCategory byu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns> post </returns>
        PostCategory? GetPostCategoryNow(int postId, int categoryId);

        /// <summary>
        /// Get all PostCategories
        /// </summary>
        /// <returns> return a list of object </returns>
        List<PostCategory> GetAllPostCategoriesNow();

        /// <summary>
        /// Delete a postcategory
        /// </summary>
        /// <param name="post"></param>
        bool DeletePostCategoryNow(int postId, int categoryId);

        /// <summary>
        /// Create Postcategory
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        PostCategory CreatePostCategoryNow(PostCategory postCategory, out string message);

        /// <summary>
        /// Update a postcategory
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        PostCategory? UpdatePostCategoryNow(PostCategory postCategory);
    }
}
