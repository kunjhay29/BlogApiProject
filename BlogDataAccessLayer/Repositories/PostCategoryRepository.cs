using BlogDataAccessLayer.Data;
using BlogDataAccessLayer.IRepositories;
using BlogDomainLayer.Models;

namespace BlogDataAccessLayer.Repositories
{
    public class PostCategoryRepository : IPostCategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PostCategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public PostCategory CreatePostCategory(PostCategory postCategory)
        {
            _applicationDbContext.postCategories.Add(postCategory);
            _applicationDbContext.SaveChanges();

            return postCategory;
        }
        

        public void DeletePostCategory(PostCategory postCategory)
        {
            _applicationDbContext.Remove(postCategory);
            _applicationDbContext.SaveChanges();
        }

        public List<PostCategory> GetAllPostCategories()
        {
            return _applicationDbContext.postCategories.ToList();
        }

        public PostCategory? GetPostCategory(int postId, int categoryId)
        {
            PostCategory? postCategory = _applicationDbContext.postCategories.Find(postId, categoryId);
            return postCategory;
        }

        public PostCategory? UpdatePostCategory(PostCategory postCategory)
        {
            PostCategory? existingPostCategory = _applicationDbContext.postCategories.Find(postCategory.PostId);

            if (existingPostCategory == null)
            {
                return null;
            }


            _applicationDbContext.Update(existingPostCategory);
            _applicationDbContext.SaveChanges();

            return existingPostCategory;
        }
    }
}
