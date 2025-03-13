using BlogDataAccessLayer.Data;
using BlogDataAccessLayer.IRepositories;
using BlogDomainLayer.Models;

namespace BlogDataAccessLayer.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CommentRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public Comment CreateComment(Comment comment)
        {
            _applicationDbContext.comments.Add(comment);
            _applicationDbContext.SaveChanges();

            return comment;
        }

        public void DeleteComment(int id)
        {
            _applicationDbContext.Remove(id);
            _applicationDbContext.SaveChanges();
        }
        

        public List<Comment> GetAllComments()
        {
            return _applicationDbContext.comments.ToList();
        }

        public Comment? GetComment(int id)
        {
            Comment? comment = _applicationDbContext.comments.Find(id);
            return comment;
        }

        public Comment? UpdateComment(Comment comment)
        {
            Comment? existingComment = _applicationDbContext.comments.Find(comment);

            if (existingComment == null)
            {
                return null;
            }


            _applicationDbContext.Update(existingComment);
            _applicationDbContext.SaveChanges();

            return existingComment;
        }
    }
}
