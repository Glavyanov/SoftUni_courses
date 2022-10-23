using Microsoft.AspNetCore.Identity;

namespace Library.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<ApplicationUserBook> ApplicationUsersBooks { get; set; } = new HashSet<ApplicationUserBook>();

    }
}
