using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogDomainLayer.Models;

namespace BlogDataAccessLayer.IRepositories
{
    public interface IPostRepository
    {
        /// <summary>
        /// Get a Post by Id
        /// </summary>
        /// <param name="id"> object </param>
        /// <returns> Post </returns>
        Post? GetPost(int id);

        /// <summary>
        /// Get all Posts
        /// </summary>
        /// <returns> List of objects </returns>
        List<Post> GetAllPosts();

        /// <summary>
        /// Delete a post
        /// </summary>
        /// <param name="post"></param>
        void DeletePost(Post post);

        /// <summary>
        /// Create a post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        Post CreatePost(Post post, string userId);

        /// <summary>
        /// update a post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        Post? UpdatePost(Post post);

    }
}
