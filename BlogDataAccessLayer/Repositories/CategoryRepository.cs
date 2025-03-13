using BlogDataAccessLayer.Data;
using BlogDataAccessLayer.IRepositories;
using BlogDomainLayer.Models;

namespace BlogDataAccessLayer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Category CreateCategory(Category category)
        {
            _applicationDbContext.categories.Add(category);
            _applicationDbContext.SaveChanges();

            return category;
        }

        public void DeleteCategory(Category category)
        {
            _applicationDbContext.Remove(category);
            _applicationDbContext.SaveChanges();
        }

        public List<Category> GetAllCategories()
        {
            return _applicationDbContext.categories.ToList();
        }

        public Category? GetCategory(int id)
        {
            Category? category = _applicationDbContext.categories.Find(id);
            return category;
        }

        public Category? UpdateCategory(Category category)
        {
            Category? existingCategory = _applicationDbContext.categories.Find(category);

            if (existingCategory == null)
            {
                return null;
            }


            _applicationDbContext.Update(existingCategory);
            _applicationDbContext.SaveChanges();

            return existingCategory;
        }
    }
}
