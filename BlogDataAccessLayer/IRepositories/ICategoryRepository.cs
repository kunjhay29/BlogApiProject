using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogDomainLayer.Models;

namespace BlogDataAccessLayer.IRepositories
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Get category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Object </returns>
        Category? GetCategory(int id);

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns> list of object </returns>
        List<Category> GetAllCategories();

        /// <summary>
        /// Delete a category
        /// </summary>
        /// <param name="category"></param>
        void DeleteCategory(Category category);

        /// <summary>
        /// Create a category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Category CreateCategory(Category category);

        /// <summary>
        /// Update a category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Category? UpdateCategory(Category category);
    }
}
