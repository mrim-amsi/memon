using Microsoft.AspNetCore.Identity;

namespace Web_Application_with_Identity.Models
{
    public class statusUser
    {
        public int numStatus { get; set; }
        public bool boolStatus { get; set; }
        public string message { get; set; }
        public IdentityUser applicationUser { get; set; }=null;
    }
}
