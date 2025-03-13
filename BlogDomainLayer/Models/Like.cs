

namespace BlogDomainLayer.Models
{
    public class Like : BaseModel
    {
        
        public Post Post { get; set; }
        public int PostId { get; set; } // Foreign Key (Non-nullable)

        public User User { get; set; }
        public string UserId { get; set; } // Foreign Key (Non-nullable)
        

    }
}
