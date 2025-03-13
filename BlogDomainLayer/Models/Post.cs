

namespace BlogDomainLayer.Models
{
    public class Post : BaseModel
    {

        public string Title { get; set; }
        public string Content { get; set; }

        public string UserId { get; set; }  // Foreign key (non-nullable if required)
        public User User { get; set; }   // Navigation property

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Many-to-Many: Post can belong to multiple categories
        public ICollection<PostCategory> PostCategories { get; set; } = new List<PostCategory>();

        // Ensure this navigation property exists
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        // Add this navigation property
        public ICollection<Like> Likes { get; set; } = new List<Like>();
    }
}
