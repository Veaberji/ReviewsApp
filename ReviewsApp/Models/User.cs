using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(255)]
        public string DisplayName { get; set; }
        public IList<Review> Reviews { get; set; }
        public IList<UserGrade> Grades { get; set; }
        public User()
        {
            Reviews = new List<Review>();
            Grades = new List<UserGrade>();
        }

    }
}
