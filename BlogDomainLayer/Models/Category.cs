

namespace BlogDomainLayer.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; }

        public string? Description { get; set; } // Nullable description

        // Many-to-Many: A category can be linked to multiple posts
        public ICollection<PostCategory> PostCategories { get; set; } = new List<PostCategory>();
    }

}
