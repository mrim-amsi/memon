using Microsoft.AspNetCore.Identity;

namespace Web_Application_with_Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string PhoneNumber { get; set; } = null!;
    }
}