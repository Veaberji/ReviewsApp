using ReviewsApp.Models.Settings.Constrains;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.ViewModels.Review.Components
{
    public class CommentViewModel
    {
        [Required]
        [Display(Name = "Comment")]
        [MaxLength(CommentConstrains.BodyMaxLength)]
        public string Body { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [Required]
        public int ReviewId { get; set; }
    }
}
