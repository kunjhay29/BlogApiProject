

namespace BlogDomainLayer.Dto
{
    public class CreatePostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorId { get; set; }
    }
}
