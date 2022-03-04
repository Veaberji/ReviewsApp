using ReviewsApp.Models.Settings.Constrains;
using System;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(CommentConstrains.BodyMaxLength)]
        public string Body { get; set; }

        [Required]
        public DateTime PublishingDate { get; set; }
    }
}
