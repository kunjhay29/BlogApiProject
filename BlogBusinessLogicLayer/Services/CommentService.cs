using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogBusinessLogicLayer.IService;
using BlogDataAccessLayer.UnitOfWork;
using BlogDomainLayer.Models;

namespace BlogBusinessLogicLayer.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Comment CreateCommentNow(Comment comment, out string message)
        {
            if (comment == null || comment.PostId <= 0 || string.IsNullOrWhiteSpace(comment.Content))
            {
                message = "Invalid PostId or Comment content cannot be empty.";
                return null;
            }

            message = "Comment added successfully";
            return _unitOfWork.commentRepository.CreateComment(comment);
        }

        public bool DeleteCommentNow(int id)
        {
            if (id <= 0)
            {
                return false; // Invalid commentId
            }

            Comment? comment = _unitOfWork.commentRepository.GetComment(id);
            if (comment == null)
            {
                return false; // Not found
            }

            _unitOfWork.commentRepository.GetComment(id);
            return true;
        }

        public List<Comment> GetAllCommentsNow()
        {
            return _unitOfWork.commentRepository.GetAllComments() ?? new List<Comment>();
        }

        //public Comment? GetCommentNow(int id)
        //{
        //    if (id <= 0)
        //    {
        //        return null; // Invalid id
        //    }

        //    return _unitOfWork.commentRepository.GetComment(id);
        //}

        public Comment? GetCommentNow(int id)
        {
            if (id <= 0)
            {
                Console.WriteLine("Invalid comment ID: " + id);
                return null; // Invalid id
            }

            var comment = _unitOfWork.commentRepository.GetComment(id);

            if (comment == null)
            {
                Console.WriteLine("Comment not found for ID: " + id);
            }
            else
            {
                Console.WriteLine($"Comment found: {comment.Content}");
            }

            return comment;
        }


        public Comment? UpdateCommentNow(Comment comment, out string message)
        {
            if(comment == null || string.IsNullOrWhiteSpace(comment.Content))
            {
                message = "Comment content cannot be empty.";
                return null;
            }

            Comment? existingComment = _unitOfWork.commentRepository.GetComment(comment.Id);
            if (existingComment == null)
            {
                message = "Comment not found";
                return null;
            }

            message = "Comment updated successfully";
            return _unitOfWork.commentRepository.UpdateComment(comment);
        }
    }
}
