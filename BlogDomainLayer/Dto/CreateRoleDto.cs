
using System.ComponentModel.DataAnnotations;


namespace BlogDomainLayer.Dto
{
    public class CreateRoleDto
    {
        [Required(ErrorMessage = "Role name is required.")]
        public string Name { get; set; }
    }
}
