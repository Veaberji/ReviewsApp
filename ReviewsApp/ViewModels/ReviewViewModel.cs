using Microsoft.AspNetCore.Http;
using ReviewsApp.Models.Settings.Constrains;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.ViewModels
{
    public class ReviewViewModel
    {
        [Required]
        [MaxLength(ReviewConstrains.TitleMaxLength)]
        public string Title { get; set; }

        public string AuthorId { get; set; }

        public ProductViewModel ProductViewModel { get; set; }

        [Required]
        [Display(Name = "Your Review")]
        [MaxLength(ReviewConstrains.BodyMaxLength)]
        public string Body { get; set; }

        [Required]
        [Display(Name = "Your Grade")]
        [Range(ReviewConstrains.AuthorMinGrade, ReviewConstrains.AuthorMaxGrade)]
        public int AuthorGrade { get; set; }

        public TagViewModel TagViewModel { get; set; }

        public IEnumerable<IFormFile> ImagesFiles { get; set; }
    }
}
