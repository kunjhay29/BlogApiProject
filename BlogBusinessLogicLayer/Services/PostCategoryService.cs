using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogBusinessLogicLayer.IService;
using BlogDataAccessLayer.UnitOfWork;
using BlogDomainLayer.Models;

namespace BlogBusinessLogicLayer.Services
{
    public class PostCategoryService : IPostCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PostCategory CreatePostCategoryNow(PostCategory postCategory, out string message)
        {
            if (postCategory == null || postCategory.PostId <= 0 || postCategory.CategoryId <= 0)
            {
                message = "Invalid PostId or CategoryId.";
                return null;
            }

            message = "Post category created successfully";
            return _unitOfWork.postCategoryRepository.CreatePostCategory(postCategory);
        }

        public bool DeletePostCategoryNow(int postId, int categoryId)
        {
            if (postId <= 0 || categoryId <= 0)
            {
                return false; // Invalid composite key
            }

            PostCategory? postCategory = _unitOfWork.postCategoryRepository.GetPostCategory(postId, categoryId);
            if (postCategory == null)
            {
                return false; // Not found
            }

            _unitOfWork.postCategoryRepository.DeletePostCategory(postCategory);
            return true;
        }

        public List<PostCategory> GetAllPostCategoriesNow()
        {
            return _unitOfWork.postCategoryRepository.GetAllPostCategories() ?? new List<PostCategory>();
        }

        public PostCategory? GetPostCategoryNow(int postId, int categoryId)
        {
            if (postId <= 0 || categoryId <= 0)
            {
                return null; // Invalid composite key
            }

            return _unitOfWork.postCategoryRepository.GetPostCategory(postId, categoryId);
        }

        public PostCategory? UpdatePostCategoryNow(PostCategory postCategory)
        {
            throw new NotImplementedException();
        }
    }
}
