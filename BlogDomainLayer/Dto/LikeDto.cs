

namespace BlogDomainLayer.Dto
{
    public class LikeDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
