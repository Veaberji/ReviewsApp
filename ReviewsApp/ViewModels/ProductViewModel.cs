using ReviewsApp.Models;
using ReviewsApp.Models.Settings.Constrains;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        [Display(Name = "Title of the described product")]
        [MaxLength(ProductConstrains.NameMaxLength)]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Product type")]
        public ProductType ProductType { get; set; }
    }
}
