

namespace BlogDomainLayer.Dto
{
    public class UpdatePostCategoryDto
    {
        public int PostId { get; set; } // The ID of the post
        public int OldCategoryId { get; set; } // The existing category ID (if changing categories)
        public int NewCategoryId { get; set; } // The new category ID to update to
    }
}
