using BlogDomainLayer.Models;

namespace BlogBusinessLogicLayer.IService
{
    public interface ICategoryService
    {
        /// <summary>
        /// Get category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Object </returns>
        Category? GetCategoryNow(int id);

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns> list of object </returns>
        List<Category> GetAllCategoriesNow();

        /// <summary>
        /// Delete a category
        /// </summary>
        /// <param name="category"></param>
        bool DeleteCategoryNow(int id);

        /// <summary>
        /// Create a category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Category CreateCategoryNow(Category category, out string message);

        /// <summary>
        /// Update a category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Category? UpdateCategoryNow(Category category, out string message);
    }
}
