using ReviewsApp.Models.MainReview;
using ReviewsApp.Models.Settings.Constrains;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.ViewModels.MainReview
{
    public class CreateReviewViewModel : BaseReviewViewModel
    {
        [Required(ErrorMessage = "Product Title Required")]
        [Display(Name = "Review Title")]
        [MaxLength(ReviewConstrains.TitleMaxLength,
            ErrorMessage = "Maximum Title length")]
        public override string Title { get; set; }

        [Required(ErrorMessage = "Review Required")]
        [Display(Name = "Your Review")]
        [MaxLength(ReviewConstrains.BodyMaxLength,
            ErrorMessage = "Maximum Review length")]
        public override string Body { get; set; }

        [Required(ErrorMessage = "Grade Required")]
        [Display(Name = "Your Grade")]
        [Range(ReviewConstrains.AuthorMinGrade, ReviewConstrains.AuthorMaxGrade,
            ErrorMessage = "Grade range")]
        public override int AuthorGrade { get; set; }
        public string Tags { get; set; }
        public string ImagesUrls { get; set; }
        public string UserName { get; set; }
        public IEnumerable<ProductType> ProductTypes { get; set; }
    }
}
