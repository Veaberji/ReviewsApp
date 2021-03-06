using ReviewsApp.Models.Common;
using ReviewsApp.Models.Settings.Constrains;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewsApp.Models.MainReview
{
    public class UserGrade
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Range(UserGradeConstrains.UserMinGrade, UserGradeConstrains.UserMaxGrade)]
        public int Grade { get; set; }
    }
}
