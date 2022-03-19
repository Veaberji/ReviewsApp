using ReviewsApp.Models.MainReview;
using ReviewsApp.Models.Settings.Constrains;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.ViewModels.MainReview.Components
{
    public class ProductViewModel
    {
        [Required]
        [Display(Name = "Name of the described product")]
        [MaxLength(ProductConstrains.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Product type")]
        public ProductType Type { get; set; }
    }
}
