using BlogBusinessLogicLayer.IService;
using BlogDataAccessLayer.UnitOfWork;
using BlogDomainLayer.Models;

namespace BlogBusinessLogicLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public Category CreateCategoryNow(Category category, out string message)
        {
            if (category == null || string.IsNullOrWhiteSpace(category.Name))
            {
                message = "Category name cannot be empty.";
                return null;
            }

            message = "Category created successfully.";
            return _unitOfWork.categoryRepository.CreateCategory(category);
        }

        public bool DeleteCategoryNow(int id)
        {
            if (id <= 0)
            {
                return false; // Invalid ID
            }

            Category? category = _unitOfWork.categoryRepository.GetCategory(id);
            if (category == null)
            {
                return false; // Not found
            }

            _unitOfWork.categoryRepository.DeleteCategory(category);
            return true;
        }

        public List<Category> GetAllCategoriesNow()
        {
            return _unitOfWork.categoryRepository.GetAllCategories() ?? new List<Category>();
        }

        public Category? GetCategoryNow(int id)
        {
            if (id <= 0)
            {
                return null; // Invalid ID
            }

            return _unitOfWork.categoryRepository.GetCategory(id);

        }

        public Category? UpdateCategoryNow(Category category, out string message)
        {
            if (category == null || string.IsNullOrWhiteSpace(category.Name))
            {
                message = "Category name cannot be empty.";
                return null;
            }

            Category? existingCategory = _unitOfWork.categoryRepository.GetCategory(category.Id);
            if (existingCategory == null)
            {
                message = "Category not found.";
                return null;
            }

            message = "Category updated successfully.";
            return _unitOfWork.categoryRepository.UpdateCategory(category);
        }
    }
}
