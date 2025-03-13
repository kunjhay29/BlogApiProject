

namespace BlogDomainLayer.Dto
{
    public class UpdateLikeDto
    {
        public int Id { get; set; } // Assuming Likes have a unique ID
        public int PostId { get; set; } // The post being liked
        public string UserId { get; set; } // The user who liked the post
        public bool IsLiked { get; set; } // True if liked, False if unliked
    }
}
