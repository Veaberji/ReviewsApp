using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewsApp.Models
{
    public class Image
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        [ForeignKey("Review")]
        public int ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
