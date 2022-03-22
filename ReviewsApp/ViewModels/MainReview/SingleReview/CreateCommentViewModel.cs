using ReviewsApp.Models.Settings.Constrains;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.ViewModels.MainReview.SingleReview
{
    public class CreateCommentViewModel
    {
        [Required(ErrorMessage = "Comment Required")]
        [Display(Name = "Comment")]
        [MaxLength(CommentConstrains.BodyMaxLength,
            ErrorMessage = "Maximum Comment length")]
        public string Body { get; set; }

        public int ReviewId { get; set; }
    }
}
