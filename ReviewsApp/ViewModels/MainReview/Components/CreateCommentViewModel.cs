using ReviewsApp.Models.Settings.Constrains;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.ViewModels.MainReview.Components
{
    public class CreateCommentViewModel
    {
        [Required]
        [Display(Name = "Comment")]
        [MaxLength(CommentConstrains.BodyMaxLength)]
        public string Body { get; set; }

        [Required]
        public int ReviewId { get; set; }
    }
}
