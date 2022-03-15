using ReviewsApp.Models.MainReview;
using ReviewsApp.Models.Settings.Constrains;
using System;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.ViewModels.MainReview.Components
{
    public class ProductViewModel
    {
        [Required]
        [Display(Name = "Title of the described product")]
        [MaxLength(ProductConstrains.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Product type")]
        [Range(1, ProductConstrains.ProductTypesCount, ErrorMessage = "Select product type")]
        public ProductType Type { get; set; }
    }
}
