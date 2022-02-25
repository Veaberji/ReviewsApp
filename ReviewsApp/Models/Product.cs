using ReviewsApp.Models.Settings.Constrains;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    [MaxLength(ProductConstrains.NameMaxLength)]
    public string Name { get; set; }

    [Required]
    public ProductType Type { get; set; }
}