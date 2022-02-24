using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ReviewsApp.Models
{
    public class User : IdentityUser
    {
        public IList<Review> Reviews { get; set; }
        public User()
        {
            Reviews = new List<Review>();
        }

    }
}
