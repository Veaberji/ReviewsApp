using ReviewsApp.Models.Settings.Constrains;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.ViewModels
{
    public class ReviewViewModel
    {
        [MaxLength(ReviewConstrains.TitleMaxLength)]
        [Required]
        public string Title { get; set; }

        public string AuthorId { get; set; }

        [MaxLength(ReviewConstrains.BodyMaxLength)]
        [Required]
        [Display(Name = "Your Review")]
        public string Body { get; set; }

        [Range(ReviewConstrains.AuthorMinGrade, ReviewConstrains.AuthorMaxGrade)]
        [Required]
        [Display(Name = "Your Grade")]
        public int AuthorGrade { get; set; }

    }
}
