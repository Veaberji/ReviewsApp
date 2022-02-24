using ReviewsApp.Models.Settings.Constrains;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewsApp.Models
{
    public class Review
    {
        public int Id { get; set; }

        [MaxLength(ReviewConstrains.TitleMaxLength)]
        [Required]
        public string Title { get; set; }



        [ForeignKey("Author")]
        [Required]
        public string AuthorId { get; set; }
        public User Author { get; set; }

        [MaxLength(ReviewConstrains.BodyMaxLength)]
        [Required]
        public string Body { get; set; }

        [Range(ReviewConstrains.AuthorMinGrade, ReviewConstrains.AuthorMaxGrade)]
        [Required]
        public int AuthorGrade { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
