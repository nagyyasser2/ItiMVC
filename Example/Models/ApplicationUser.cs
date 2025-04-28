using Microsoft.AspNetCore.Identity;

namespace Example.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Address { get; set; }
    }
}
