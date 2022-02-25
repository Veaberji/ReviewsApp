using ReviewsApp.Models.Settings.Constrains;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    [DefaultValue("Product")]
    [MaxLength(ProductConstrains.NameMaxLength)]
    public string Name { get; set; }
}