using Microsoft.AspNetCore.Identity;

namespace BlogDomainLayer.Models
{
    //public class User : BaseModel // inheritance from the basemodel
    //{
    //    public string UserName { get; set; }
    //    public string Email { get; set; }
    //    public string PasswordHash { get; set; }  // Store hashed password


    //    // Navigation properties
    //    public ICollection<Post> Posts { get; set; }
    //    public ICollection<Comment> Comments { get; set; }
    //    public ICollection<Like> Likes { get; set; }

    //}

    public class User : IdentityUser // IdentityUser with int as primary key
    {
        // Navigation properties
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Like> Likes { get; set; } = new List<Like>();
    }
}

