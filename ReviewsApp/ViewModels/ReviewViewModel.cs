using ReviewsApp.Models.Settings.Constrains;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.ViewModels
{
    public class ReviewViewModel
    {
        [Required]
        [MaxLength(ReviewConstrains.TitleMaxLength)]
        public string Title { get; set; }

        public string AuthorId { get; set; }

        [Required]
        [Display(Name = "Title of the described product")]
        [MaxLength(ProductConstrains.NameMaxLength)]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Your Review")]
        [MaxLength(ReviewConstrains.BodyMaxLength)]
        public string Body { get; set; }

        [Required]
        [Display(Name = "Your Grade")]
        [Range(ReviewConstrains.AuthorMinGrade, ReviewConstrains.AuthorMaxGrade)]
        public int AuthorGrade { get; set; }

    }
}
