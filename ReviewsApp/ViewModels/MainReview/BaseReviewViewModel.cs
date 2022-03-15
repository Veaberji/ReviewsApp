using ReviewsApp.Models.Settings.Constrains;
using ReviewsApp.ViewModels.MainReview.Components;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.ViewModels.MainReview
{
    public class BaseReviewViewModel
    {
        [Required]
        [MaxLength(ReviewConstrains.TitleMaxLength)]
        public string Title { get; set; }

        public ProductViewModel ProductViewModel { get; set; }

        [Required]
        [Display(Name = "Your Review")]
        [MaxLength(ReviewConstrains.BodyMaxLength)]
        public string Body { get; set; }

        [Required]
        [Display(Name = "Your Grade")]
        [Range(ReviewConstrains.AuthorMinGrade, ReviewConstrains.AuthorMaxGrade,
            ErrorMessage = "Add your grade")]
        public int AuthorGrade { get; set; }
    }
}
