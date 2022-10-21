using Microsoft.AspNetCore.Identity;

namespace Watchlist.Data.Entities
{
    public class User : IdentityUser
    {
        public ICollection<UserMovie> UsersMovies { get; set; } = new HashSet<UserMovie>();

    }
}
