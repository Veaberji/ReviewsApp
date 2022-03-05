using ReviewsApp.Models.Settings.Constrains;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.Models.MainReview
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(TagConstrains.TextMaxLength)]
        public string Text { get; set; }

        [Required]
        public int Count { get; set; }

        public IList<Review> Reviews { get; set; }

        public Tag()
        {
            Reviews = new List<Review>();
        }
    }
}
