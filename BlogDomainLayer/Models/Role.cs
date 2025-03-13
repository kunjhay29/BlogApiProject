using Microsoft.AspNetCore.Identity;

namespace BlogDomainLayer.Models
{
    public class Role : IdentityRole<string>
    {
        public Role() : base()
        {
            Id = Guid.NewGuid().ToString(); // Ensure Id is set
        }

        public Role(string roleName) : base(roleName)
        {
            Id = Guid.NewGuid().ToString(); // Ensure Id is set
        }

    }
}
