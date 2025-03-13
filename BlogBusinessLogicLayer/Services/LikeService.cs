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
    public class LikeService : ILikeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LikeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Like CreateLikeNow(Like like, out string message)
        {
            if (like == null || like.PostId <= 0 || like.UserId == null)
            {
                message = "Invalid PostId or UserId.";
                return null;
            }

            message = "Like added successfully";
            return _unitOfWork.likeRepository.CreateLike(like);
        }

        public bool DeleteLikeNow(int id)
        {
            if (id <= 0)
            {
                return false; // Invalid likeId
            }

            Like? like = _unitOfWork.likeRepository.GetLike(id);
            if (like == null)
            {
                return false; // Not found
            }

            _unitOfWork.likeRepository.DeleteLike(like);
            return true;
        }

        public List<Like> GetAllLikesNow()
        {
            return _unitOfWork.likeRepository.GetAllLikes() ?? new List<Like>();
        }

        public Like? GetLikeNow(int id)
        {
            if (id <= 0)
            {
                return null; // Invalid id
            }

            return _unitOfWork.likeRepository.GetLike(id);
        }

        public Like? UpdateLikeNow(Like like, out string message)
        {
            if (like == null || like.PostId <= 0 || like.UserId == null)
            {
                message = "Invalid PostId or UserId.";
                return null;
            }

            Like? existingLike = _unitOfWork.likeRepository.GetLike(like.Id);
            if (existingLike == null)
            {
                message = "Like not found";
                return null;
            }

            message = "Like updated successfully";
            return _unitOfWork.likeRepository.UpdateLike(like);
        }
    }
}
