using Microsoft.AspNetCore.Identity;

namespace Watchlist.Data.Entities
{
    public class User : IdentityUser
    {
        public ICollection<UserMovie> UsersMovie { get; set; } = new HashSet<UserMovie>();

    }
}
