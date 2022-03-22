using ReviewsApp.Models.MainReview;
using ReviewsApp.Models.Settings.Constrains;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.ViewModels.MainReview.Components
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "Product Name Required")]
        [Display(Name = "Described Product Name")]
        [MaxLength(ProductConstrains.NameMaxLength,
         ErrorMessage = "Maximum Product Name length")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product Type Required")]
        [Display(Name = "Product Type")]
        public ProductType Type { get; set; }
    }
}
