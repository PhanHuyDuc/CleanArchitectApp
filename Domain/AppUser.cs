using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public required string DisplayName { get; set; }
        public required string Bio { get; set; }
        public ICollection<Photo>? Photos { get; set; }
    }
}