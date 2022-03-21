using ReviewsApp.Models.Common;
using ReviewsApp.Models.Settings.Constrains;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewsApp.Models.MainReview
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(CommentConstrains.BodyMaxLength)]
        public string Body { get; set; }

        [Required]
        public DateTime PublishingDate { get; set; }

        [Required]
        [ForeignKey("Author")]
        public string AuthorId { get; set; }
        public User Author { get; set; }

        [ForeignKey("Review")]
        public int? ReviewId { get; set; }
        public Review Review { get; set; }

        public int RowVersion { get; set; }
    }
}
