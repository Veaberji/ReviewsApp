using ReviewsApp.Models.Settings.Constrains;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(TagConstrains.TextMaxLength)]
        public string Text { get; set; }

        [Required]
        public int Count { get; set; }
    }
}
