using ReviewsApp.Models.Settings.Constrains;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ReviewsApp.Models.MainReview;

public class Product
{
    public int Id { get; set; }

    [Required]
    [MaxLength(ProductConstrains.NameMaxLength)]
    public string Name { get; set; }

    [Required]
    public ProductType Type { get; set; }

    public IList<UserGrade> Grades { get; set; }

    public Product()
    {
        Grades = new List<UserGrade>();
    }

    public double? GetAverageUserRating()
    {
        if (Grades.Count > 0)
        {
            return Grades.Average(g => g.Grade);
        }
        return null;
    }
}