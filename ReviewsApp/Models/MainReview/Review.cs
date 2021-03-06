using ReviewsApp.Models.Common;
using ReviewsApp.Models.Settings.Constrains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewsApp.Models.MainReview
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ReviewConstrains.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        [ForeignKey("Author")]
        public string AuthorId { get; set; }
        public User Author { get; set; }

        [Required]
        [MaxLength(ReviewConstrains.BodyMaxLength)]
        public string Body { get; set; }

        [Required]
        [Range(ReviewConstrains.AuthorMinGrade, ReviewConstrains.AuthorMaxGrade)]
        public int AuthorGrade { get; set; }
        public DateTime DateAdded { get; set; }

        public List<Tag> Tags { get; set; }
        public List<Image> Images { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }

        public int RowVersion { get; set; }

        public Review()
        {
            Tags = new List<Tag>();
            Images = new List<Image>();
            Comments = new List<Comment>();
            Likes = new List<Like>();
        }
    }
}
