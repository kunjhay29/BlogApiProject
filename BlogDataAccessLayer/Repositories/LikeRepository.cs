using BlogDataAccessLayer.Data;
using BlogDataAccessLayer.IRepositories;
using BlogDomainLayer.Models;

namespace BlogDataAccessLayer.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public LikeRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Like CreateLike(Like like)
        {
            _applicationDbContext.likes.Add(like);
            _applicationDbContext.SaveChanges();

            return like;
        }

        public void DeleteLike(Like like)
        {
            _applicationDbContext.Remove(like);
            _applicationDbContext.SaveChanges();
        }

        public List<Like> GetAllLikes()
        {
            return _applicationDbContext.likes.ToList();
        }

        public Like? GetLike(int id)
        {
            Like? like = _applicationDbContext.likes.Find(id);
            return like;
        }

        public Like? UpdateLike(Like like)
        {
            Like? existingLike = _applicationDbContext.likes.Find(like.Id);

            if (existingLike == null)
            {
                return null;
            }


            _applicationDbContext.Update(existingLike);
            _applicationDbContext.SaveChanges();

            return existingLike;
        }
    }
}
