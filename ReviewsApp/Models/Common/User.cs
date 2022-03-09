using Microsoft.AspNetCore.Identity;
using ReviewsApp.Models.MainReview;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.Models.Common
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(255)]
        public string DisplayName { get; set; }
        public IList<Review> Reviews { get; set; }
        public IList<UserGrade> Grades { get; set; }
        public IList<Comment> Comments { get; set; }
        public IList<Like> Likes { get; set; }
        public User()
        {
            Reviews = new List<Review>();
            Grades = new List<UserGrade>();
            Comments = new List<Comment>();
            Likes = new List<Like>();
        }

    }
}
