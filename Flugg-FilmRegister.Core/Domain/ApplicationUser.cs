using Microsoft.AspNetCore.Identity;

namespace Flugg_FilmRegister.Core.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }

        public Guid UserProfileID { get; set; } 

        public bool IsAdmin { get; set; }
    }
}
