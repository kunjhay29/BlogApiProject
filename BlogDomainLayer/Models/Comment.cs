

namespace BlogDomainLayer.Models
{
    public class Comment : BaseModel
    {
        //Ensure A user is attached to a commnet, no anonymouse comment
        public Post Post { get; set; }
        public int PostId { get; set; } // Foreign Key (Non-nullable)

        public User User { get; set; }
        public string UserId { get; set; } // Foreign Key (Non-nullable)

        public string Content { get; set; }
    }

}
